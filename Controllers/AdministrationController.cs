using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NSTP.Controllers
{
    public class AdministrationController : Controller
    {
        // GET: Administration
        public ActionResult DashBoard()
        {
            return View();
        }
        public ActionResult NSTPSlider()
        {
            return View();
        }
    }
}