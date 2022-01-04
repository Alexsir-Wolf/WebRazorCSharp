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
        public void ChecarLogin()
        {
            var usuario = new Usuario();
            usuario.Email = Request["EMAIL"];
            usuario.Senha = Request["PassWord"];

            if (usuario.Login())
            {
                Session["Autorizado"] = "OK";
                Session.Remove("Erro");
                Response.Redirect("/Home/Index");
            }
            else
            {
                Session["Erro"] = "Senha ou usuário inválidos.";
                Response.Redirect("/Login/Index");
            }

        }

    }

}