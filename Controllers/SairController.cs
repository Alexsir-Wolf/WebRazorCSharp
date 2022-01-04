using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebRazorCSharp.Controllers
{
    public class SairController : Controller
    {
        // GET: Sair
        public ActionResult FinalizarSessao()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}