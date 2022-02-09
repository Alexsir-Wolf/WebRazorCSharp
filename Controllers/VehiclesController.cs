using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRazorCSharp.Models;

namespace WebRazorCSharp.Controllers
{
    public class VehiclesController : Controller
    {
        // GET: Veiculos
        public ActionResult NewVehicle()
        {
            ViewBag.Title = "Veiculos";
            ViewBag.Message = "Adicionar veículo";

            return View();
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Veiculos";
            ViewBag.Message = "Editar veículo";

            var vehicle = new Vehicle();
            vehicle.GetVehicle(id);
            ViewBag.Vehicle = vehicle;

            return RedirectToAction("Edit", "vehicle");
        }

        public ActionResult Delete(int id)
        {
            ViewBag.Title = "Veiculos";
            ViewBag.Message = "Excluir veículo ";

            var vehicle = new Vehicle();
            vehicle.GetVehicle(id);
            ViewBag.Vehicle = vehicle;

            return View();
        }


        [HttpPost]
        public ActionResult Save(Vehicle vehicles)
        {
            if (ModelState.IsValid)
            {
                vehicles.Save();
                return RedirectToAction("Vehicles", "Home");
            }
            else
            {
                ViewBag.Title = "Veículos";
                if (Convert.ToInt32("0" + Request["id"]) == 0)
                {
                    ViewBag.Message = "Adicionar veículo";
                    return View("NewVehicle");
                }
                else
                {
                    ViewBag.veiculo = vehicles;
                    ViewBag.Message = "Alterar veiculos" + vehicles.Id;
                    return View("Edit");
                }
            }
        }


        [HttpPost]
        public ActionResult Delete()
        {
            var vehicle = new Vehicle();
            vehicle.Id = Convert.ToInt32(Request["id"]);
            vehicle.Delete();
            return RedirectToAction("Vehicles", "Home");
        }

    }
}