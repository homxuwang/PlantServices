using System;
using System.Data;
using System.Data.Common;


using Platform.Core;
using MySql.Data.MySqlClient;

namespace Platform.RDBS.MySQL
{
    /// <summary>
    /// MySQL策略之关系数据库分部类
    /// </summary>
    public partial class RDBSStrategy : IRDBSStrategy
    {
        #region  辅助方法

        /// <summary>
        /// 生成输入参数
        /// </summary>
        /// <param name="paramName">参数名</param>
        /// <param name="MySqlDbType">参数类型</param>
        /// <param name="size">类型大小</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        private DbParameter GenerateInParam(string paramName, MySqlDbType MySqlDbType, int size, object value)
        {
            return GenerateParam(paramName, MySqlDbType, size, ParameterDirection.Input, value);
        }

        /// <summary>
        /// 生成输出参数
        /// </summary>
        /// <param name="paramName">参数名</param>
        /// <param name="MySqlDbType">参数类型</param>
        /// <param name="size">类型大小</param>
        /// <returns></returns>
        private DbParameter GenerateOutParam(string paramName, MySqlDbType MySqlDbType, int size)
        {
            return GenerateParam(paramName, MySqlDbType, size, ParameterDirection.Output, null);
        }

        /// <summary>
        /// 生成返回参数
        /// </summary>
        /// <param name="paramName">参数名</param>
        /// <param name="MySqlDbType">参数类型</param>
        /// <param name="size">类型大小</param>
        /// <returns></returns>
        private DbParameter GenerateReturnParam(string paramName, MySqlDbType MySqlDbType, int size)
        {
            return GenerateParam(paramName, MySqlDbType, size, ParameterDirection.ReturnValue, null);
        }

        /// <summary>
        /// 生成参数
        /// </summary>
        /// <param name="paramName">参数名</param>
        /// <param name="MySqlDbType">参数类型</param>
        /// <param name="size">类型大小</param>
        /// <param name="direction">方向</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        private DbParameter GenerateParam(string paramName, MySqlDbType MySqlDbType, int size, ParameterDirection direction, object value)
        {
            MySqlParameter param = new MySqlParameter(paramName, MySqlDbType, size);
            param.Direction = direction;
            if (direction == ParameterDirection.Input && value != null)
                param.Value = value;
            return param;
        }

        #endregion

       
    }
}
