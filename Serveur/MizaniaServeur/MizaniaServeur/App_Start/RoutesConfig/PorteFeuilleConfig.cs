using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MizaniaServeur.App_Start.RoutesConfig
{
    public class PorteFeuilleConfig
    {
        public static void addRoutes(HttpConfiguration config)
        {

            config.Routes.MapHttpRoute(
             name: "getPortefeuille",
             routeTemplate: "api/Portefeuille/getById/{id}",
             defaults: new
             {
                 controller = "Portefeuille",
                 action = "getById"
             }
          );

            config.Routes.MapHttpRoute(
                              name: "PostPortefeuille",
                              routeTemplate: "api/Portefeuille/add",
                              defaults: new
                              {
                                  controller = "Portefeuille",
                                  action = "add"
                              }
                           );

            config.Routes.MapHttpRoute(
                         name: "PutPortefeuille",
                         routeTemplate: "api/Portefeuille/updatePortefeuille",
                         defaults: new
                         {
                             controller = "Portefeuille",
                             action = "updatePortefeuille"
                         }
                      );

            config.Routes.MapHttpRoute(
                       name: "deletePortefeuille",
                       routeTemplate: "api/Portefeuille/delete/{id}",
                       defaults: new
                       {
                           controller = "Portefeuille",
                           action = "delete"
                       }
                    );
            config.Routes.MapHttpRoute(
              name: "GetUsers",
              routeTemplate: "api/Portefeuille/getAllUsers",
              defaults: new
              {
                  controller = "Portefeuille",
                  action = "getAllUsers"

              }

           );

            config.Routes.MapHttpRoute(
             name: "GetNormalUsers",
             routeTemplate: "api/Portefeuille/getNormalUsers/{id}",
             defaults: new
             {
                 controller = "Portefeuille",
                 action = "getNormalUsers"

             }

          );
            config.Routes.MapHttpRoute(
            name: "GetCreator",
            routeTemplate: "api/Portefeuille/getCreator/{id}",
            defaults: new
            {
                controller = "Portefeuille",
                action = "getCreator"

            }

         );
            config.Routes.MapHttpRoute(
            name: "GetPrincipalUsers",
            routeTemplate: "api/Portefeuille/getPrincipalUsers/{id}",
            defaults: new
            {
                controller = "Portefeuille",
                action = "getPrincipalUsers"

            }

         );
        }
    }
}