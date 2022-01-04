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
        public ActionResult Salvar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Salvar();
                return RedirectToAction("veiculo", "Home");
            }
            else
            {
                ViewBag.Title = "usuário";
                ViewBag.Message = "Adicionar usuário";
                return View("Adicionar");
            }

        }       
    }
}