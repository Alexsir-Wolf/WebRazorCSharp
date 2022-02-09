using System.Web.Mvc;
using WebRazorCSharp.Models;

namespace WebRazorCSharp.Controllers
{
    public class UserController : Controller
    {
        // GET: Usuario
        public ActionResult NewUser()
        {
            ViewBag.Title = "Usuário";
            ViewBag.Message = "Novo Usuário";
            return View();
        }

        [HttpPost]
        public ActionResult Save(User user)
        {
            if (ModelState.IsValid)
            {
                user.Save();
                return RedirectToAction("index", "Home");
            }
            else
            {
                ViewBag.Title = "usuário";
                ViewBag.Message = "Adicionar usuário";
                return View("NewUser");
            }

        }       
    }
}