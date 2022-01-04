using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRazorCSharp.Models;

namespace WebRazorCSharp.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult adicionar()
        {
            ViewBag.Title = "Usuário";
            ViewBag.Message = "Novo Usuário";
            return View();
        }


        [HttpPost]
        public void Salvar()
        {
            var usuario = new Usuario();
            usuario.Id = Convert.ToInt32(Request["id"]);
            usuario.Nome = Request["Nome"];
            usuario.Email = Request["email"];
            usuario.Senha = Request["senha"];

            usuario.Salvar();

            Response.Redirect("/login/index");
        }
    }
}