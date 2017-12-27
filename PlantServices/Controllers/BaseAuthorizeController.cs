using PlantServices.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace PlantServices.Controllers
{
    [RequestAuthorize]
    public class BaseAuthorizeController : ApiController
    {

    }
}