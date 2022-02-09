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
                "Vehicles/Save",
                new { controller = "Vehicles", action = "Save" }
                );      


            //ROTA PARA SALVAR USUARIOS NO BANCO DE DADOS
            routes.MapRoute(
                "UsuarioSalvar",
                "Login/NewUser",
                new { controller = "User", action = "Save" }
                );    
            
            
            //ROTA PARA SALVAR USUARIOS NO BANCO DE DADOS
            routes.MapRoute(
                "UsuarioAdicionar",
                "User/Save",
                new { controller = "User", action = "Save" }
                );


            //ROTA PARA EDITAR VEICULO
            routes.MapRoute(
                "VeiculoEditar",
                "Vehicles/Edit/:id",
                new { controller = "Vehicles", action = "Edit", id = 0 }
                );
            
            //ROTA PARA EXCLUIR VEICULO
            routes.MapRoute(
                "VeiculoExcluir",
                "Vehicles/Delete/:id",
                new { controller = "Vehicles", action = "Delete", id = 0 }
                );


            //ROTA PARA PAGINA VEICULOS
            routes.MapRoute(
                "VeiculosHome",
                "Vehicles",
                new { controller = "Vehicles", action = "Vehicle" }
                );  

            //ROTA PADRÃO, SEMPRE POR ULTIMO
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
