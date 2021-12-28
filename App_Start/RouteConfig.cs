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
                "VeiculoAdicionar",
                "veiculos/adicionar",
                new { controller = "Veiculos", action = "Adicionar" }
                );


            //ROTA PARA ALTERAR VEICULO
            routes.MapRoute(
                "VeiculoEditar",
                "Veiculos/Alterar/:id",
                new { controller = "Veiculos", action = "Alterar", id = 0 }
                );


            //ROTA PARA PAGINA VEICULOS
            routes.MapRoute(
                "VeiculosHome",
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
