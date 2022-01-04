using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRazorCSharp.Models;

namespace WebRazorCSharp.Controllers
{
    public class VeiculosController : Controller
    {
        // GET: Veiculos
        public ActionResult Adicionar()
        {
            ViewBag.Title = "Veiculos";
            ViewBag.Message = "Adicionar veículo";

            return View();
        }

        public ActionResult Alterar(int id)
        {
            ViewBag.Title = "Veiculos";
            ViewBag.Message = "Editar veículo";

            var veiculo = new Veiculos();
            veiculo.GetVeiculo(id);
            ViewBag.Veiculo = veiculo;

            return View();
        }
        public ActionResult Excluir(int id)
        {
            ViewBag.Title = "Veiculos";
            ViewBag.Message = "Excluir veículo " + id;

            var veiculo = new Veiculos();
            veiculo.GetVeiculo(id);
            ViewBag.Veiculo = veiculo;

            return View();
        }


        [HttpPost]
        public ActionResult Salvar(Veiculos veiculos)
        {
            if (ModelState.IsValid)
            {
                veiculos.Salvar();
                return RedirectToAction("Veiculo", "Home");
            }
            else
            {
                ViewBag.Title = "Veículos";
                if (Convert.ToInt32("0" + Request["id"]) == 0)
                {
                    ViewBag.Message = "Adicionar veículo";
                    return View("Adicionar");
                }
                else
                {
                    ViewBag.veiculo = veiculos;
                    ViewBag.Message = "Alterar veiculos" + veiculos.Id;
                    return View("Alterar");
                }
            }
        }


        [HttpPost]
        public void Excluir()
        {
            var veiculo = new Veiculos();
            veiculo.Id = Convert.ToInt32("0" + Request["id"]);

            veiculo.Excluir();

            Response.Redirect("/Home/Veiculo");
        }

    }
}