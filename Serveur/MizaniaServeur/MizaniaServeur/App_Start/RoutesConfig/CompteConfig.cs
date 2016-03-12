using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MizaniaServeur.App_Start.RoutesConfig
{
    public class CompteConfig
    {
        public static void addRoutes(HttpConfiguration config)
        {
            //get compte by id 
            config.Routes.MapHttpRoute(
             name: "GetCompte",
             routeTemplate: "api/Compte/getById/{id}",
             defaults: new
             {
                 controller = "Compte",
                 action = "getById"
             }, constraints: new { accountIDRecepteur = @"\d+" }

          );
            //l'utilisateur d'un compte
            config.Routes.MapHttpRoute(
             name: "GetUtilisateurCompte",
             routeTemplate: "api/Compte/getAccountUserById/{id}",
             defaults: new
             {
                 controller = "Compte",
                 action = "getAccountUserById"
             }, constraints: new { id = @"\d+" }

          );


            config.Routes.MapHttpRoute(
             name: "getAccountPeriodicTransactionsById",
             routeTemplate: "api/Compte/getAccountPeriodicTransactionsById/{accountID}",
             defaults: new
             {
                 controller = "Compte",
                 action = "getAccountPeriodicTransactionsById"
             }, constraints: new { accountID = @"\d+" }

          );

            config.Routes.MapHttpRoute(
             name: "GetAccountTansactionsById",
             routeTemplate: "api/Compte/getAccountTansactionsById/{accountID}",
             defaults: new
             {
                 controller = "Compte",
                 action = "getAccountTansactionsById"
             }, constraints: new { accountID = @"\d+" }

          );

            config.Routes.MapHttpRoute(
           name: "GetAccountTansactionsEntreesById",
           routeTemplate: "api/Compte/getAccountTansactionsEntreesById/{accountID}",
           defaults: new
           {
               controller = "Compte",
               action = "getAccountTansactionsEntreesById"
           }, constraints: new { accountID = @"\d+" }

        );

            config.Routes.MapHttpRoute(
            name: "GetAccountTansactionsDepenses",
            routeTemplate: "api/Compte/getAccountTansactionsDepenses/{accountID}",
            defaults: new
            {
                controller = "Compte",
                action = "getAccountTansactionsDepenses"
            }, constraints: new { accountID = @"\d+" }

         );

            config.Routes.MapHttpRoute(
             name: "GetAccountTransfertsReceptById5",
             routeTemplate: "api/Compte/getAccountTransfertsReceptById/{accountIDRecepteur}",
             defaults: new
             {
                 controller = "Compte",
                 action = "getAccountTransfertsReceptById"
             }, constraints: new { accountIDRecepteur = @"\d+" }

          );

            config.Routes.MapHttpRoute(
                name: "GetAccountTransfertsExpediteurById",
                routeTemplate: "api/Compte/getAccountTransfertsExpediteurById/{accountIDExpediteur}",
                defaults: new
                {
                    controller = "Compte",
                    action = "getAccountTransfertsExpediteurById"
                }, constraints: new { accountIDExpediteur = @"\d+" }

             );

            config.Routes.MapHttpRoute(
                    name: "postCompte",
                    routeTemplate: "api/Compte/postCompte",
                    defaults: new
                    {
                        controller = "Compte",
                        action = "postCompte"
                    }

                 );

            config.Routes.MapHttpRoute(
                      name: "UpdateCompte",
                      routeTemplate: "api/Compte/UpdateCompte",
                      defaults: new
                      {
                          controller = "Compte",
                          action = "UpdateCompte"
                      }

                   );

            config.Routes.MapHttpRoute(
                          name: "DeleteById",
                          routeTemplate: "api/Compte/delete/{id}",
                          defaults: new
                          {
                              controller = "Compte",
                              action = "delete"
                          }

                       );
        }
    }
}