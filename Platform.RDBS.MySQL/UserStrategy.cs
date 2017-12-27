using MySql.Data.MySqlClient;
using Platform.Core;
using Platform.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.RDBS.MySQL
{
    public partial class RDBSStrategy : IRDBSStrategy
    {
        /// <summary>
        /// 创建新用户
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public int CreateUser(UserInfo userInfo)
        {
            DbParameter[] parms = {
                                       GenerateInParam("@username",MySqlDbType.VarChar,255,userInfo.UserName),
                                       GenerateInParam("@pword",MySqlDbType.VarChar,255,userInfo.Password),
                                       GenerateInParam("@email",MySqlDbType.VarChar,255,userInfo.Email),
                                       GenerateInParam("@mobile",MySqlDbType.VarChar,255,userInfo.Mobile),
                                       GenerateOutParam("@id",MySqlDbType.Int32,11)
                                   };

           Dictionary<string,string> result=  RDBSHelper.ExecuteScalarProc("userinfo_insert", parms);
            return  TypeHelper.ObjectToInt(result["@id"]);
        }

        public int DeleteUser(int uid)
        {
            throw new NotImplementedException();
        }

        public IDataReader GetUserById(int uid)
        {
            throw new NotImplementedException();
        }

        public IDataReader Login(string strUser, string strPwd)
        {
            string query = "select * from userinfo where username=@username and pword=@pword";
            DbParameter[] parms = {
                                       GenerateInParam("@username",MySqlDbType.VarChar,255,strUser),
                                       GenerateInParam("@pword",MySqlDbType.VarChar,255,strPwd )};

            return RDBSHelper.ExecuteReader(query, parms);
        }

        public int UpdateUser(UserInfo userInfo)
        {
            throw new NotImplementedException();
        }
    }
}
