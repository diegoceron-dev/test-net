using listaHTML.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace listaHTML.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {       
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult LlamarJson()
        {
            var output = ObtenerListaUsuarios();
            return Json(output, JsonRequestBehavior.AllowGet);
        }

        private List<Usuario> ObtenerListaUsuarios()
        {
            List<Usuario> lUsuarios = new List<Usuario>(){
            new Usuario(){ Nombre = "Diego",  Apellido = "Ceron" },
            new Usuario(){ Nombre = "Alejandro", Apellido = "Arcia" },
            new Usuario(){ Nombre = "Gerardo", Apellido = "Alcantara" },
            new Usuario(){ Nombre = "Juan", Apellido = "Martinez" },
            new Usuario(){ Nombre = "Carolina", Apellido = "Cazares" },
            new Usuario(){ Nombre = "Alan", Apellido="Ceron"},
            new Usuario(){ Nombre = "Martha", Apellido = "Arcia" }
        };
            return lUsuarios;
        }
    }
}