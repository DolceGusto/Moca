using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MizaniaServeur.App_Start.RoutesConfig
{
    public class PrivilegeConfig
    {

        public static void addRoutes(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
           name: "getPrivilege",
           routeTemplate: "api/Privilege/getById/{id}",
           defaults: new
           {
               controller = "Privilege",
               action = "getById"
           }
        );


            config.Routes.MapHttpRoute(
            name: "getAllPrivileges",
            routeTemplate: "api/Privilege/getAllPrivileges",
            defaults: new
            {
                controller = "Privilege",
                action = "getAllPrivileges"
            }
         );

            config.Routes.MapHttpRoute(
           name: "deletePrivileges",
           routeTemplate: "api/Privilege/delete/{id}",
           defaults: new
           {
               controller = "Privilege",
               action = "delete"
           }
        );
            config.Routes.MapHttpRoute(
          name: "updatePrivileges",
          routeTemplate: "api/Privilege/updatePrivilege",
          defaults: new
          {
              controller = "Privilege",
              action = "updatePrivilege"
          }
       );
            config.Routes.MapHttpRoute(
                     name: "addPrivileges",
                     routeTemplate: "api/Privilege/add",
                     defaults: new
                     {
                         controller = "Privilege",
                         action = "add"
                     }
                  );
        }
    }
}