using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace PomoControl_API.Controllers
{
    public class HomeController : ApiController
    {
        public IHttpActionResult Index()
        {
            //ViewBag.Title = "Home Page";

            //return View();
            return Ok("teste home");
        }
    }
}
