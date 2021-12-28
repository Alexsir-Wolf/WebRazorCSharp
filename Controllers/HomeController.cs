using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRazorCSharp.Models;

namespace WebRazorCSharp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Veiculo()
        {
            ViewBag.Title = "Vende-se";
            ViewBag.Message = "Relação de veículos";

            var lista = Veiculos.GetCarros();
            ViewBag.Lista = lista;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "Contato";
            ViewBag.Message = "Web page contatos.";

            return View();
        }
    }
}