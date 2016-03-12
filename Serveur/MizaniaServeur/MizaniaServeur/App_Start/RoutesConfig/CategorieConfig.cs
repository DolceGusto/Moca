using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MizaniaServeur.App_Start.RoutesConfig
{
    public class CategorieConfig
    {

        public static void addRoutes(HttpConfiguration config)
        {
            /*les routes du controleur de categorie */

            config.Routes.MapHttpRoute(
                name: "getCategorieById",
                routeTemplate: "api/Categorie/getById/{id}",
                defaults: new
                {
                    controller = "Categorie",
                    action = "getById"
                },
                constraints: new
                {
                    id = @"\d+"
                }

                );

            config.Routes.MapHttpRoute(
                name: "getAllCategorie",
                routeTemplate: "api/Categorie/getAll/{idPorteFeuille}",
                defaults: new
                {
                    controller = "Categorie",
                    action = "getAll"
                },
                constraints: new 
                {
                    idPorteFeuille = @"\d+"
                }
                );

            config.Routes.MapHttpRoute(
                name: "getCategorieByIdPorteFeuille",
                routeTemplate: "api/Categorie/getByIdPorteFeuille/{id}",
                defaults: new
                {
                    controller = "Categorie",
                    action = "getByIdPorteFeuille"
                },
                constraints: new
                {
                    id = @"\d+"
                }

                );

            config.Routes.MapHttpRoute(
                name: "getCategorieByDesignation",
                routeTemplate: "api/Categorie/getByDesignation/{idPorteFeuille}/{designation}",
                defaults: new
                {
                    controller = "Categorie",
                    action = "getByDesignation"
                },
                constraints: new
                {
                    idPorteFeuille = @"\d+"
                }

                );

            config.Routes.MapHttpRoute(
                name: "getCategorieByDescription",
                routeTemplate: "api/Categorie/getByDescription/{idPorteFeuille}/{description}",
                defaults: new
                {
                    controller = "Categorie",
                    action = "getByDescription"
                },
                constraints: new
                {
                    idPorteFeuille = @"\d+"
                }

                );

            config.Routes.MapHttpRoute(
                name: "getCategorieLikeDescription",
                routeTemplate: "api/Categorie/getLikeDescription/{idPorteFeuille}/{description}",
                defaults: new
                {
                    controller = "Categorie",
                    action = "getLikeDescription"
                },
                constraints: new
                {
                    idPorteFeuille = @"\d+"
                }

                );

            config.Routes.MapHttpRoute(
                name: "getCategorieLikeDesignation",
                routeTemplate: "api/Categorie/getLikeDesignation/{idPorteFeuille}/{designation}",
                defaults: new
                {
                    controller = "Categorie",
                    action = "getLikeDesignation"
                },
                constraints: new
                {
                    idPorteFeuille = @"\d+"
                }

                );

            config.Routes.MapHttpRoute(
                name: "addCategorie",
                routeTemplate: "api/Categorie/add",
                defaults: new
                {
                    controller = "Categorie",
                    action = "add"
                }

                );

            config.Routes.MapHttpRoute(
                name: "updateCategorieDesignation",
                routeTemplate: "api/Categorie/updateDesignation/{id}/{designation}",
                defaults: new
                {
                    controller = "Categorie",
                    action = "updateDesignation"
                },
                constraints: new
                {
                    id = @"\d+"
                }

                );

            config.Routes.MapHttpRoute(
                name: "updateCategorieDescription",
                routeTemplate: "api/Categorie/updateDescription/{id}/{description}",
                defaults: new
                {
                    controller = "Categorie",
                    action = "updateDescription"
                },
                constraints: new
                {
                    id = @"\d+"
                }

                );

            config.Routes.MapHttpRoute(
                name: "deleteCategorie",
                routeTemplate: "api/Categorie/delete/{id}",
                defaults: new
                {
                    controller = "Categorie",
                    action = "delete"
                },
                constraints: new
                {
                    id = @"\d+"
                }
                );
        }
    }
}