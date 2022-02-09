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
            if (Session["Autorizado"] != null)
            {
                return View();
            }
            else
            {          
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Vehicles()
        {
            ViewBag.Title = "Vende-se";
            ViewBag.Message = "Relação de veículos";

            if (Session["Autorizado"] != null)
            {
                var lista = Vehicle.GetCars();
                ViewBag.Lista = lista;

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Contact()
        {
            if (Session["Autorizado"] != null)
            {
                ViewBag.Title = "Contato";
                ViewBag.Message = "Web page contatos.";
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }
    }
}