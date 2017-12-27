using Platform.Core;
using Platform.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.DataBusiness
{
    public class UserInfoBusiness
    {
        public static UserInfo Login(string strUser, string strPwd)
        {
            UserInfo userInfo = null;
            IDataReader reader = DataManager.RDBS.Login(strUser, strPwd);
            if (reader.Read())
            {
                userInfo = BuildUserFromReader(reader);
            }
            reader.Close();
            return userInfo;
        }
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <returns></returns>
        public static int CreateUser(UserInfo userInfo)
        {
            return DataManager.RDBS.CreateUser(userInfo);
        }

        public static int DeleteUser(int uid)
        {
            throw new NotImplementedException();
        }

        public static UserInfo GetUserById(int uid)
        {
            throw new NotImplementedException();
        }

        public static int UpdateUser(UserInfo userInfo)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 从IDataReader创建UserInfo
        /// </summary>
        public static UserInfo BuildUserFromReader(IDataReader reader)
        {
            UserInfo userInfo = new UserInfo();
            userInfo.Uid = TypeHelper.ObjectToInt(reader["id"]);
            userInfo.UserName = reader["username"].ToString();
            userInfo.Email = reader["email"].ToString();
            userInfo.Mobile = reader["mobile"].ToString();
            userInfo.Password = reader["pword"].ToString();
            return userInfo;
        }
    }
}
