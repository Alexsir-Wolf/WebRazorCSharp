using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebRazorCSharp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //ROTA PARA SALVAR VEICULOS NO BANCO DE DADOS
            routes.MapRoute(
                "VeiculosSalvar",
                "/veiculos/salvar",
                new { controller = "Veiculos", action = "salvar" }
                );

            //ROTA PARA PAGINA VEICULOS.CSHTML
            routes.MapRoute(
                "Veiculos",
                "Veiculos",
                new { controller = "Veiculos", action = "Veiculos" }
                );

            //ROTA PADRÃO, SEMPRE POR ULTIMO
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
