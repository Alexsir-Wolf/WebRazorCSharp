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


            //ROTA PARA SALVAR USUARIOS NO BANCO DE DADOS
            routes.MapRoute(
                "UsuarioSalvar",
                "Login/adicionar",
                new { controller = "Usuario", action = "Salvar" }
                );    
            
            
            //ROTA PARA SALVAR USUARIOS NO BANCO DE DADOS
            routes.MapRoute(
                "UsuarioAdicionar",
                "Usuario/Salvar",
                new { controller = "Usuario", action = "Salvar" }
                );


            //ROTA PARA ALTERAR VEICULO
            routes.MapRoute(
                "VeiculoEditar",
                "Veiculos/Alterar/:id",
                new { controller = "Veiculos", action = "Alterar", id = 0 }
                );
            
            //ROTA PARA EXCLUIR VEICULO
            routes.MapRoute(
                "VeiculoExcluir ",
                "Veiculos/Excluir/:id",
                new { controller = "Veiculos", action = "Excluir", id = 0 }
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
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
