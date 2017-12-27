# PlantServices
 WEBAPI 通用框架后台部分
WEBAPI_1
.net Framework 4.0
## 1.Ticket验证用户请求路由权限
## 2.解决了跨域问题：
    2.1 <appSettings>
          <add key="cors_allowOrigins" value="http://localhost:55472"/>//（*为允许所有）
          <add key="cors_allowHeaders" value="*"/>
          <add key="cors_allowMethods" value="*"/>
        </appSettings>
    2.2 WebApiConfig.cs
        public static void Register（HttpConfiguration config）{} 添加以下：
        
            //解决API跨域访问的问题
            var allowOrigins = ConfigurationManager.AppSettings["cors_allowOrigins"];
            var allowHeaders = ConfigurationManager.AppSettings["cors_allowHeaders"];
            var allowMethods = ConfigurationManager.AppSettings["cors_allowMethods"];
            var globalCors = new EnableCorsAttribute(allowOrigins, allowHeaders, allowMethods) { SupportsCredentials = true};
            config.EnableCors(globalCors);
