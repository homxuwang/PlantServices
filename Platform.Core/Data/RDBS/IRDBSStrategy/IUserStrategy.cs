using Platform.Entities;
using System;
using System.Data;

namespace Platform.Core
{
    /// <summary>
    /// Platform关系数据库策略之用户分部接口
    /// </summary>
    public partial interface IRDBSStrategy
    {
        /// <summary>
        /// 获得用户
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <returns></returns>
        IDataReader GetUserById(int uid);
        /// <summary>
        /// 获取登录用户的信息
        /// </summary>
        /// <param name="strUser">用户名</param>
        /// <param name="strPwd">密码</param>
        /// <returns></returns>
        IDataReader Login(string strUser, string strPwd);
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="UserInfo">部分用户信息</param>
        int CreateUser(UserInfo UserInfo);
        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        int UpdateUser(UserInfo userInfo);
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="uid">用户id</param>
        int DeleteUser(int uid);

    }
}
