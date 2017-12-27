﻿using System;
using System.IO;

namespace Platform.Core
{
    /// <summary>
    /// Platform数据管理类
    /// 提供关系型和非关系的数据管理类
    /// </summary>
    public partial class DataManager
    {
        private static object _locker = new object();//锁对象
        private static bool _enablednosql = false;//是否启用非关系型数据库

        private static IRDBSStrategy _irdbsstrategy = null;//关系型数据库策略

        private static IUserNOSQLStrategy _iusernosqlstrategy = null;//用户非关系型数据库策略


        static DataManager()
        {
            try
            {
                string[] fileNameList = Directory.GetFiles(System.Web.HttpRuntime.BinDirectory, "Platform.RDBS."+DatabaseConfig.DefaultDatabaseName+".dll", SearchOption.TopDirectoryOnly);
                _irdbsstrategy = (IRDBSStrategy)Activator.CreateInstance(Type.GetType(string.Format("Platform.RDBS.{0}.RDBSStrategy, Platform.RDBS.{0}", DatabaseConfig.DefaultDatabaseName), false, true));
            }
            catch
            {
                throw new PlatformException("创建'"+DatabaseConfig.DefaultDatabaseName+"关系数据库策略对象'失败,可能存在的原因:未将'关系数据库策略程序集'添加到bin目录中;'关系数据库策略程序集'文件名不符合'Platform.RDBS.{策略名称}.dll'格式");
            }
            _enablednosql = Directory.GetFiles(System.Web.HttpRuntime.BinDirectory, "Platform.NOSQL." + DatabaseConfig.DefaultDatabaseName + ".dll", SearchOption.TopDirectoryOnly).Length > 0;
        }

        /// <summary>
        /// 用户关系型数据库
        /// </summary>
        public static IRDBSStrategy RDBS
        {
            get { return _irdbsstrategy; }
        }

        /// <summary>
        /// 用户非关系型数据库
        /// </summary>
        public static IUserNOSQLStrategy UserNOSQL
        {
            get
            {
                if (_enablednosql )
                {
                    if (_iusernosqlstrategy == null)
                    {
                        lock (_locker)
                        {
                            if (_iusernosqlstrategy == null)
                            {
                                try
                                {
                                    string[] fileNameList = Directory.GetFiles(System.Web.HttpRuntime.BinDirectory,"Platform.NOSQL." + DatabaseConfig.DefaultDatabaseName + ".dll",SearchOption.TopDirectoryOnly);
                                    _iusernosqlstrategy = (IUserNOSQLStrategy)Activator.CreateInstance(Type.GetType(string.Format("Platform.NOSQL.{0}.UserNOSQLStrategy, Platform.NOSQL.{0}", DatabaseConfig.DefaultDatabaseName),
                                                                                                                          false,
                                                                                                                          true));
                                }
                                catch
                                {
                                    throw new PlatformException("创建'" + DatabaseConfig.DefaultDatabaseName + "用户非关系数据库策略对象'失败,可能存在的原因:未将'用户非关系数据库策略程序集'添加到bin目录中;'用户非关系数据库策略程序集'文件名不符合'Platform.NOSQL.{策略名称}.dll'格式");
                                }
                            }
                        }
                    }
                }
                return _iusernosqlstrategy;
            }
        }

    }
}
