using Microsoft.Practices.EnterpriseLibrary.Data;
using Platform.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Core
{

    /// <summary>
    /// 数据库操作通用类
    /// </summary>
    public static class RDBSHelper
    {
        private static Database db;//操作数据库

        static RDBSHelper()
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(DatabaseConfig.DefaultDatabaseName);
        }

        #region DataSet
        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="sqlText">查询语句</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>数据表</returns>
        public static DataSet GetDataSet(string sqlText)
        {


            DbCommand dbCommand = db.GetSqlStringCommand(sqlText);
            return db.ExecuteDataSet(dbCommand);
        }
        #endregion
        #region GetDataTable 返回数据表
        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="sqlText">查询语句</param>
        /// <returns>数据表</returns>
        public static DataTable GetDataTable(string sqlText)
        {
            return ExecuteDataSet(sqlText, null);
        }
        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="sqlText">查询语句</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>数据表</returns>
        public static DataTable GetDataTable(string sqlText, DbParameter[] parameters)
        {
            return ExecuteDataSet(sqlText, parameters);
        }

        /// <summary>
        /// 公用执行查询语句
        /// </summary>
        /// <param name="sqlText">查询语句</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>数据表</returns>
        private static DataTable ExecuteDataSet(string sqlText, DbParameter[] parameters)
        {

            DbCommand dbCommand = db.GetSqlStringCommand(sqlText);
            if (parameters != null)
            {
                //添加输入参数
                foreach (DbParameter p in parameters)
                {
                    db.AddInParameter(dbCommand, p.ParameterName, p.DbType, p.Value);
                }
            }
            DataSet dataSet = db.ExecuteDataSet(dbCommand);
            if (dataSet != null && dataSet.Tables.Count > 0)
            {
                return dataSet.Tables[0];
            }
            else
            {
                return null;
            }
        }

        #endregion
        #region ExecuteReader 返回结果集
        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="sqlText">查询语句</param>
        /// <returns>结果集</returns>
        public static IDataReader ExecuteReader(string sqlText)
        {
            return GetDataReader(sqlText, null);
        }
        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="sqlText">查询语句</param>
        /// <param name="inParameters">输入参数数组</param>
        /// <returns>结果集</returns>
        public static IDataReader ExecuteReader(string sqlText, DbParameter[] parameters)
        {
            return GetDataReader(sqlText, parameters);
        }
        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="sqlText">查询语句</param>
        /// <param name="inParameters">输入参数</param>
        /// <returns>结果集</returns>
        private static IDataReader GetDataReader(string sqlText, DbParameter[] parameters)
        {
            DbCommand dbCommand = db.GetSqlStringCommand(sqlText);
            if (parameters != null)
            {
                //添加输入参数
                foreach (DbParameter p in parameters)
                {
                    db.AddInParameter(dbCommand, p.ParameterName, p.DbType, p.Value);
                }
            }
            IDataReader dataReader = db.ExecuteReader(dbCommand);
            return dataReader;
        }
        #endregion
        #region ExecuteNonQuery返回影响行数
        /// <summary>
        /// 执行增、删、改语句
        /// </summary>
        /// <param name="sqlText">增、删、改语句</param>
        /// <returns>影响行数</returns>
        public static int ExecuteNonQuery(string sqlText)
        {
            return GetNonQuery(sqlText, null);
        }
        /// <summary>
        /// 执行增、删、改语句
        /// </summary>
        /// <param name="sqlText">增、删、改语句</param>
        /// <param name="parameters">输入参数数组</param>
        /// <returns>影响行数</returns>
        public static int ExecuteNonQuery(string sqlText, DbParameter[] parameters)
        {
            return GetNonQuery(sqlText, parameters);
        }
        /// <summary>
        /// 公用执行增、删、改语句
        /// </summary>
        /// <param name="sqlText">增、删、改语句</param>
        /// <param name="parameters">输入参数数组</param>
        /// <returns>影响行数</returns>
        private static int GetNonQuery(string sqlText, DbParameter[] parameters)
        {


            DbCommand dbCommand = db.GetSqlStringCommand(sqlText);
            if (parameters != null)
            {
                //添加输入参数
                foreach (DbParameter p in parameters)
                {
                    db.AddInParameter(dbCommand, p.ParameterName, p.DbType, p.Value);
                }
            }
            return db.ExecuteNonQuery(dbCommand);
        }
        #endregion
        #region ExecuteScalar返回单值
        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="sqlText">查询语句</param>
        /// <returns>单个值</returns>
        public static object ExecuteScalar(string sqlText)
        {
            return GetScalar(sqlText, null);
        }
        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="sqlText">查询语句</param>
        /// <param name="parameters">输入参数数组</param>
        /// <returns>单个值</returns>
        public static object ExecuteScalar(string sqlText, DbParameter[] parameters)
        {
            return GetScalar(sqlText, parameters);
        }
        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="sqlText">查询语句</param>
        /// <param name="parameters">输入参数数组</param>
        /// <returns>单个值</returns>
        private static object GetScalar(string sqlText, DbParameter[] parameters)
        {


            DbCommand dbCommand = db.GetSqlStringCommand(sqlText);
            if (parameters != null)
            {
                //添加输入参数
                foreach (DbParameter p in parameters)
                {
                    db.AddInParameter(dbCommand, p.ParameterName, p.DbType, p.Value);
                }
            }
            return db.ExecuteScalar(dbCommand);
        }
        #endregion
        #region ExecuteNonQueryProc 返回影响行数
        /// <summary>
        /// 执行增、删、改存储过程
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <returns>影响行数</returns>
        public static Dictionary<string, string> ExecuteNonQueryProc(string procName)
        {
            return GetNonQueryProc(procName, null);
        }
        /// <summary>
        /// 执行增、删、改存储过程
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>影响行数</returns>
        public static Dictionary<string, string> ExecuteNonQueryProc(string procName, DbParameter[] parameters)
        {
            return GetNonQueryProc(procName, parameters);
        }
        /// <summary>
        /// 公用执行增、删、改存储过程
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>影响行数</returns>
        private static Dictionary<string, string> GetNonQueryProc(string procName, DbParameter[] parameters)
        {


            DbCommand dbCommand = db.GetStoredProcCommand(procName);
            if (parameters != null)
            {
                foreach (DbParameter p in parameters)
                {
                    if (p.Direction == ParameterDirection.Output)
                    {
                        db.AddOutParameter(dbCommand, p.ParameterName, p.DbType, p.Size);//添加输出参数
                    }
                    else
                    {
                        db.AddInParameter(dbCommand, p.ParameterName, p.DbType, p.Value);//添加输入参数
                    }
                }
            }
            db.ExecuteNonQuery(dbCommand);
            Dictionary<string, string> htOupParam = new Dictionary<string, string>();
            if (parameters != null)
            {
                //得到输出参数的值
                object key = db.GetParameterValue(dbCommand, "po_Errcode");
                object value = db.GetParameterValue(dbCommand, "po_Errmsg");

                if (key != null && value != null)
                {
                    htOupParam.Add(key.ToString(), value.ToString());
                }
            }
            return htOupParam;
        }
        #endregion
        #region ExecuteScalarProc 返回单值
        /// <summary>
        /// 执行查询存储过程
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <returns>单个值</returns>
        public static Dictionary<string, string> ExecuteScalarProc(string procName)
        {
            return GetScalarProc(procName, null);
        }
        /// <summary>
        /// 执行查询存储过程
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="parameters">输入参数数组</param>
        /// <returns>单个值</returns>
        public static Dictionary<string, string> ExecuteScalarProc(string procName, DbParameter[] parameters)
        {
            return GetScalarProc(procName, parameters);
        }
        /// <summary>
        /// 执行查询存储过程
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>单个值</returns>
        private static Dictionary<string, string> GetScalarProc(string procName, DbParameter[] parameters)
        {


            DbCommand dbCommand = db.GetStoredProcCommand(procName);
            if (parameters != null)
            {
                foreach (DbParameter p in parameters)
                {
                    if (p.Direction == ParameterDirection.Output)
                    {
                        db.AddOutParameter(dbCommand, p.ParameterName, p.DbType, p.Size);//添加输出参数
                    }
                    else
                    {
                        db.AddInParameter(dbCommand, p.ParameterName, p.DbType, p.Value);//添加输入参数
                    }
                }
            }
            db.ExecuteScalar(dbCommand);
            Dictionary<string, string> htOupParam = new Dictionary<string, string>();
            if (parameters != null)
            {
                //得到输出参数的值
                foreach (DbParameter p in parameters)
                {
                    if (p.Direction == ParameterDirection.Output)
                    {
                        string value = db.GetParameterValue(dbCommand, p.ParameterName).ToString();
                        htOupParam.Add(p.ParameterName, value);
                    }
                }
            }
            return htOupParam;
        }
        #endregion
        #region ExecuteNonQuery 多记录操作带事务
        /// <summary>
        /// 带事务执行增、删、改操作
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="inParameters">输入参数</param>
        public static void ExecuteNonQuery(string procName, List<DbParameter[]> inParameters)
        {


            DbCommand dbCommand = db.GetStoredProcCommand(procName);
            using (DbConnection conn = db.CreateConnection())
            {
                //打开连接
                conn.Open();
                //创建事务
                DbTransaction trans = conn.BeginTransaction();
                try
                {
                    foreach (DbParameter[] inParas in inParameters)
                    {
                        dbCommand.Parameters.Clear();
                        //添加输入参数
                        foreach (DbParameter p in inParas)
                        {
                            db.AddInParameter(dbCommand, p.ParameterName, p.DbType, p.Value);
                            db.ExecuteNonQuery(dbCommand);
                        }
                    }
                    //都执行成功则提交事务
                    trans.Commit();
                }
                catch (Exception)
                {
                    //发生异常，事务回滚
                    trans.Rollback();
                }
                finally
                {
                    //关闭连接
                    conn.Close();
                }
            }
        }
        #endregion
        #region 用DataSet批量的添加，修改，删除数据，预留方法
        /// <summary>
        /// 用DataSet批量的添加，修改，删除数据
        /// <param name="dataSet">数据集对象</param>
        /// <param name="tableName">数据集中表名</param>
        /// <param name="procName">存储过程名</param>
        /// <param name="pkParameter">主键参数</param>
        /// <param name="parameters">其它参数</param>
        /// <returns>影响的行数</returns>
        /// </summary>
        public static int Update(DataSet dataSet, string tableName, string procName, DbParameter pkParameter, DbParameter[] parameters)
        {

            // 下面分别创建添加，修改，删除的操作
            DbCommand insertCommand = db.GetStoredProcCommand(procName);
            DbCommand updateCommand = db.GetStoredProcCommand(procName);
            DbCommand deleteCommand = db.GetStoredProcCommand(procName);
            db.AddInParameter(insertCommand, pkParameter.ParameterName, pkParameter.DbType, pkParameter.Value.ToString(), DataRowVersion.Current);
            db.AddInParameter(updateCommand, pkParameter.ParameterName, pkParameter.DbType, pkParameter.Value.ToString(), DataRowVersion.Current);
            db.AddInParameter(deleteCommand, pkParameter.ParameterName, pkParameter.DbType, pkParameter.Value.ToString(), DataRowVersion.Current);
            if (parameters != null)
            {
                foreach (DbParameter p in parameters)
                {
                    db.AddInParameter(insertCommand, p.ParameterName, p.DbType, p.Value.ToString(), DataRowVersion.Current);
                    db.AddInParameter(updateCommand, p.ParameterName, p.DbType, p.Value.ToString(), DataRowVersion.Current);
                }
            }
            // 提交对DataSet的修改，并返回影响的行数
            return db.UpdateDataSet(dataSet, tableName, insertCommand, updateCommand, deleteCommand, Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
        }
        #endregion

    }
}
