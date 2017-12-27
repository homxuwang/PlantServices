using PlantServices.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace PlantServices.Controllers
{
    [RequestAuthorize]
    [RoutePrefix("api/Order")]
    public class OrderController : ApiController
    {
        // GET: api/Order
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="strUser"></param>
        /// <param name="strPwd"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Login")]
        [AllowAnonymous]
        public object Login(string strUser, string strPwd)
        {
            if (!ValidateUser(strUser, strPwd))
            {
                return new { bRes = false };
            }
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(0, strUser, DateTime.Now,
                            DateTime.Now.AddHours(1), true, string.Format("{0}&{1}", strUser, strPwd),
                            FormsAuthentication.FormsCookiePath);
            //返回登录结果、用户信息、用户验证票据信息
            var oUser = new UserInfo { bRes = true, UserName = strUser, Password = strPwd, Ticket = FormsAuthentication.Encrypt(ticket) };
            //将身份信息保存在session中，验证当前请求是否是有效请求
            HttpContext.Current.Session["username"] = oUser.UserName;
           
            return oUser;
        }

        //校验用户名密码（正式环境中应该是数据库校验）
        private bool ValidateUser(string strUser, string strPwd)
        {
            if (strUser == "admin" && strPwd == "123456")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // GET: api/Order/5
        [Route("Get1/{id}")]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// 测试接口
        /// </summary>
        /// <param name="id">参数ID</param>
        /// <returns></returns>
        [Route("Get2/{id}")]
        public string GetTest(int id)
        {
            return "value";
        }

       
        // POST: api/Order
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Order/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Order/5
        public void Delete(int id)
        {
        }
    }
    public class UserInfo
    {
        public bool bRes { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Ticket { get; set; }
    }
}
