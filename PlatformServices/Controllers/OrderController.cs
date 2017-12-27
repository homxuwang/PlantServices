using Platform.DataBusiness;
using Platform.Entities;
using PlatformServices.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace PlatformServices.Controllers
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
        [HttpGet]
        [Route("CreateUser")]
        public int CreateUser(string username,string password,string email ,string mobile)
        {
            return UserInfoBusiness.CreateUser(new UserInfo() { Email = email, Mobile = mobile, Password = password, UserName = username });
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
            UserInfo login = UserInfoBusiness.Login(strUser, strPwd);
            if (login == null)
            {
                return new { IsLogin = false };
            }
            login.IsLogin = true;
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(0, strUser, DateTime.Now,
                            DateTime.Now.AddHours(1), true, string.Format("{0}&{1}", strUser, strPwd),
                            FormsAuthentication.FormsCookiePath);
            //返回登录结果、用户信息、用户验证票据信息
            login.Ticket = FormsAuthentication.Encrypt(ticket);
            //将身份信息保存在session中，验证当前请求是否是有效请求
            //  HttpContext.Current.Session[strUser] = oUser;
            return login;
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

        ////订单排产
        //[Route("OrderProduct")]
        //[HttpPost]
        //public void OrderProduct([FromBody]string strPostData)
        //{

        //}

        ////订单取消
        //[HttpPost]
        //public void OrderCancel([FromBody]string strPostData)
        //{

        //}

        ////订单删除
        //[HttpPost]
        //public void OrderDelete([FromBody]string strPostData)
        //{

        //}

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
}
