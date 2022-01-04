using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRazorCSharp.Models;

namespace WebRazorCSharp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            if(Session["Erro"] != null)            
                ViewBag.Erro = Session["Erro"].ToString();
            
            return View();
        }

        [HttpPost]
        public ActionResult ChecarLogin()
        {
            var usuario = new Usuario();
            usuario.Email = Request["EMAIL"];
            usuario.Senha = Request["PassWord"];

            if (usuario.Login())
            {
                Session["Autorizado"] = "OK";
                Session.Remove("Erro");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Session["Erro"] = "Senha ou usuário inválidos.";
                return RedirectToAction("Index", "Login");
            }

        }

    }

}