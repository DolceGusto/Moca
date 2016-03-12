using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MizaniaServeur.App_Start.RoutesConfig
{
    public class PrivilegeUtilisateurConfig
    {

        public static void addRoutes(HttpConfiguration config)
        {

            //la relation privilegeUtilisateur
            config.Routes.MapHttpRoute(
                             name: "GetPrivilegeUtilisateurById1",
                             routeTemplate: "api/PrivilegeUtilisateur/GetPrivilegeUtilisateurById/{UtilisateurID}/{PrivilegeID}",
                             defaults: new
                             {
                                 controller = "PrivilegeUtilisateur",
                                 action = "GetPrivilegeUtilisateurById"
                             }, constraints: new { UtilisateurID = @"\d+", PrivilegeID = @"\d+" }

                          );

            config.Routes.MapHttpRoute(
                                 name: "GetPrivilegeUtilisateur",
                                 routeTemplate: "api/PrivilegeUtilisateur/GetPrivilegeUtilisateur/{ID}",
                                 defaults: new
                                 {
                                     controller = "PrivilegeUtilisateur",
                                     action = "GetPrivileggeUtilisateur"
                                 }, constraints: new { ID = @"\d+" }



                              );
            config.Routes.MapHttpRoute(
                                    name: "GetAllPrivilegeUtilisateur",
                                    routeTemplate: "api/PrivilegeUtilisateur/GetAllPrivilegeUtilisateur",
                                    defaults: new
                                    {
                                        controller = "PrivilegeUtilisateur",
                                        action = "GetAllPrivilegeUtilisateur"
                                    }
                                 );

            config.Routes.MapHttpRoute(
                                    name: "postPrivilegeUtilisateur2",
                                    routeTemplate: "api/PrivilegeUtilisateur/postPrivilegeUtilisateur",
                                    defaults: new
                                    {
                                        controller = "PrivilegeUtilisateur",
                                        action = "postPrivilegeUtilisateur"
                                    }
                                 );


            config.Routes.MapHttpRoute(
                                name: "DeletePrivilegeUtilisateurById",
                                routeTemplate: "api/PrivilegeUtilisateur/DeletePrivilegeUtilisateurById/{PrivilegeID}/{UtilisateurID}",
                                defaults: new
                                {
                                    controller = "PrivilegeUtilisateur",
                                    action = "DeletePrivilegeUtilisateurById"
                                }, constraints: new { PrivilegeID = @"\d+", UtilisateurID = @"\d+" }



                             );
        }
    }
}