using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebRazorCSharp.Controllers
{
    public class ExitController : Controller
    {
        // GET: Sair
        public ActionResult Exit()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}