using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MizaniaServeur.App_Start.RoutesConfig
{
    public class UtilisateurConfig
    {

        public static void addRoutes(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
              name: "GetAllUsers",
              routeTemplate: "api/User/getAll/",
              defaults: new
              {
                  controller = "User",
                  action = "getAll"
              }
           );

            config.Routes.MapHttpRoute(
               name: "GetUser",
               routeTemplate: "api/User/getUserById/{id}",
               defaults: new
               {
                   controller = "User",
                   action = "getUserById"

               },
               constraints: new { accountIDRecepteur = @"\d+" }

            );

            config.Routes.MapHttpRoute(
              name: "GetUserByNom",
              routeTemplate: "api/User/getUserByNom/{name:alpha}",
              defaults: new
              {
                  controller = "User",
                  action = "getUserByNom"
              }
           );

            config.Routes.MapHttpRoute(
              name: "GetUserByPrenom",
              routeTemplate: "api/User/getUserByPrenom/{name:alpha}",
              defaults: new
              {
                  controller = "User",
                  action = "getUserByPrenom"
              }
           );

            config.Routes.MapHttpRoute(
             name: "GetUserPortefeuille",
             routeTemplate: "api/User/getUserPortefeuille/{id}",
             defaults: new
             {
                 controller = "User",
                 action = "getUserPortefeuille",

             },
               constraints: new { accountIDRecepteur = @"\d+" }
          );

            config.Routes.MapHttpRoute(
             name: "GetUserAccounts",
             routeTemplate: "api/User/getUserAccounts/{id}",
             defaults: new
             {
                 controller = "User",
                 action = "getUserAccounts"

             },
               constraints: new { accountIDRecepteur = @"\d+" }
          );

            config.Routes.MapHttpRoute(
             name: "GetUserPrivileges",
             routeTemplate: "api/User/getUserPrivileges/{id}",
             defaults: new
             {
                 controller = "User",
                 action = "getUserPrivileges"

             },
               constraints: new { accountIDRecepteur = @"\d+" }
          );

            config.Routes.MapHttpRoute(
             name: "GetUserDepenses",
             routeTemplate: "api/User/getUserDepenses/{id}",
             defaults: new
             {
                 controller = "User",
                 action = "getUserDepenses"

             },
               constraints: new { accountIDRecepteur = @"\d+" }
          );

            config.Routes.MapHttpRoute(
                  name: "PostUser",
                  routeTemplate: "api/User/addUser",
                  defaults: new
                  {
                      controller = "User",
                      action = "addUtilisateur"
                  }
               );

            config.Routes.MapHttpRoute(
                  name: "PutUser",
                  routeTemplate: "api/User/updateUser/{id}",
                  defaults: new
                  {
                      controller = "User",
                      action = "updateUser"
                  },
               constraints: new { accountIDRecepteur = @"\d+" }
               );

            config.Routes.MapHttpRoute(
                  name: "DeleteUser",
                  routeTemplate: "api/User/deleteUser/{id}",
                  defaults: new
                  {
                      controller = "User",
                      action = "deleteUser",

                  },
                   constraints: new
                   {
                       accountIDRecepteur = @"\d+",
                   }
               );
        }
    }
}