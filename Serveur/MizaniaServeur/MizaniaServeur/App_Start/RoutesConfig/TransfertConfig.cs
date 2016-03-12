using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MizaniaServeur.App_Start.RoutesConfig
{
    public class TransfertConfig
    {

        /*ajoute les routes du controleur TransfertControleur*/

        public static void addRoutes(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
              name: "GetAllTransferts",
              routeTemplate: "api/Transfert/getAll/{idPorteFeuille}",
              defaults: new
              {
                  controller = "Transfert",
                  action = "getAll"
              },
              constraints: new 
              {
                  idPorteFeuille = @"\d+"
              }
           );

            config.Routes.MapHttpRoute(
               name: "GetTransfert",
               routeTemplate: "api/Transfert/getById/{id}",
               defaults: new
               {
                   controller = "Transfert",
                   action = "getById",

               },
               constraints: new { id = @"\d+" }
            );

            config.Routes.MapHttpRoute(
               name: "GetTransfertByIdCompteExpediteur",
               routeTemplate: "api/Transfert/getByIdCompteExpediteur/{id}",
               defaults: new
               {
                   controller = "Transfert",
                   action = "getByIdCompteExpediteur",

               },
               constraints: new { id = @"\d+" }
            );

            config.Routes.MapHttpRoute(
               name: "GetTransfertByIdCompteRecepteur",
               routeTemplate: "api/Transfert/getByIdCompteRecepteur/{id}",
               defaults: new
               {
                   controller = "Transfert",
                   action = "getByIdCompteRecepteur",

               },
               constraints: new { id = @"\d+" }
            );

            config.Routes.MapHttpRoute(
               name: "GetTransfertByMontant",
               routeTemplate: "api/Transfert/getByMontant/{idPorteFeuille}/{montant}",
               defaults: new
               {
                   controller = "Transfert",
                   action = "getByMontant",

               },
               constraints: new 
               {    montant = @"\d+\.\d+|\d+",
                    idPorteFeuille = @"\d+"
               }
            );

            config.Routes.MapHttpRoute(
               name: "GetTransfertByMontantAbove",
               routeTemplate: "api/Transfert/getByMontantAbove/{idPorteFeuille}/{min}",
               defaults: new
               {
                   controller = "Transfert",
                   action = "getByMontantAbove",

               },
               constraints: new 
               {   min = @"\d+|\d+\.\d+",
                   idPorteFeuille = @"\d+"
               }
            );

            config.Routes.MapHttpRoute(
               name: "GetTransfertByMontantBelow",
               routeTemplate: "api/Transfert/getByMontantBelow/{idPorteFeuille}/{max}",
               defaults: new
               {
                   controller = "Transfert",
                   action = "getByMontantBelow",

               },
               constraints: new 
               {    max = @"\d+|\d+\.\d+",
                   idPorteFeuille = @"\d+"
               }
            );

            config.Routes.MapHttpRoute(
               name: "GetTransfertByMontantBetween",
               routeTemplate: "api/Transfert/getByMontantBetween/{idPorteFeuille}/{min}/{max}",
               defaults: new
               {
                   controller = "Transfert",
                   action = "getByMontantBetween",

               },
               constraints: new 
               {   min = @"\d+|\d+\.\d+",
                   max = @"\d+|\d+\.\d+",
                   idPorteFeuille = @"\d+|\d+\.\d+"
               }
            );

            config.Routes.MapHttpRoute(
               name: "GetTransfertByDate",
               routeTemplate: "api/Transfert/getByDate/{idPorteFeuille}/{year}/{month}/{day}/{hour}/{minute}/{seconds}",
               defaults: new
               {
                   controller = "Transfert",
                   action = "getByDate",
                   month = RouteParameter.Optional,
                   day = RouteParameter.Optional,
                   hour = RouteParameter.Optional,
                   minute = RouteParameter.Optional,
                   seconds = RouteParameter.Optional,

               },
               constraints: new
               {
                   year = @"\d+",
                   month = @"\d*",
                   day = @"\d*",
                   hour = @"\d*",
                   minute = @"\d*",
                   seconds = @"\d*",
                   idPorteFeuille = @"\d+"
               }
            );

            config.Routes.MapHttpRoute(
              name: "GetTransfertByDateFrom",
              routeTemplate: "api/Transfert/getByDateFrom/{idPorteFeuille}/{year}/{month}/{day}/{hour}/{minute}/{seconds}",
              defaults: new
              {
                  controller = "Transfert",
                  action = "getByDateFrom",
                  month = RouteParameter.Optional,
                  day = RouteParameter.Optional,
                  hour = RouteParameter.Optional,
                  minute = RouteParameter.Optional,
                  seconds = RouteParameter.Optional,

              },
              constraints: new
              {
                  year = @"\d+",
                  month = @"\d*",
                  day = @"\d*",
                  hour = @"\d*",
                  minute = @"\d*",
                  seconds = @"\d*",
                  idPorteFeuille = @"\d+"
              }
           );

            config.Routes.MapHttpRoute(
              name: "GetTransfertByDateTo",
              routeTemplate: "api/Transfert/getByDateTo/{idPorteFeuille}/{year}/{month}/{day}/{hour}/{minute}/{seconds}",
              defaults: new
              {
                  controller = "Transfert",
                  action = "getByDateTo",
                  month = RouteParameter.Optional,
                  day = RouteParameter.Optional,
                  hour = RouteParameter.Optional,
                  minute = RouteParameter.Optional,
                  seconds = RouteParameter.Optional,

              },
              constraints: new
              {
                  year = @"\d+",
                  month = @"\d*",
                  day = @"\d*",
                  hour = @"\d*",
                  minute = @"\d*",
                  seconds = @"\d*",
                  idPorteFeuille = @"\d+"
              }
           );

            config.Routes.MapHttpRoute(
              name: "GetTransfertByDateBetween",
              routeTemplate: "api/Transfert/getByDateBetween/{idPorteFeuille}/{dYear}/{fYear}/{dMonth}/{fMonth}/"+
                              "{dDay}/{fDay}/{dHour}/{fHour}/{dMinute}/{fMinute}/{dSeconds}/{fSeconds}",
              defaults: new
              {
                  controller = "Transfert",
                  action = "getByDateBetween",
                  dMonth = RouteParameter.Optional,
                  dDay = RouteParameter.Optional,
                  dHour = RouteParameter.Optional,
                  dMinute = RouteParameter.Optional,
                  dSeconds = RouteParameter.Optional,
                  fMonth = RouteParameter.Optional,
                  fDay = RouteParameter.Optional,
                  fHour = RouteParameter.Optional,
                  fMinute = RouteParameter.Optional,
                  fSeconds = RouteParameter.Optional,

              },
              constraints: new
              {
                  dYear = @"\d+",
                  fYear = @"\d+",
                  dMonth = @"\d*",
                  dDay = @"\d*",
                  dHour = @"\d*",
                  dMinute = @"\d*",
                  dSeconds = @"\d*",
                  fMonth = @"\d*",
                  fDay = @"\d*",
                  fHour = @"\d*",
                  fMinute = @"\d*",
                  fSeconds = @"\d*",
                  idPorteFeuille = @"\d+"
              }
           );

            config.Routes.MapHttpRoute(
                  name: "PostTransfert",
                  routeTemplate: "api/Transfert/add",
                  defaults: new
                  {
                      controller = "Transfert",
                      action = "add"
                  }
               );

            config.Routes.MapHttpRoute(
                  name: "PuTTransfertIdCompteExpediteur",
                  routeTemplate: "api/Transfert/updateIdCompteExpediteur/{id}/{idCompteExpediteur}",
                  defaults: new
                  {
                      controller = "Transfert",
                      action = "updateIdCompteExpediteur"
                  },
                   constraints: new
                   {
                       id = @"\d+",
                       idCompteExpediteur = @"\d+"
                   }
               );

            config.Routes.MapHttpRoute(
                  name: "PuTTransfertIdCompteRecepteur",
                  routeTemplate: "api/Transfert/updateIdCompteRecepteur/{id}/{idCompteRecepteur}",
                  defaults: new
                  {
                      controller = "Transfert",
                      action = "updateIdCompteRecepteur"
                  },
                   constraints: new
                   {
                       id = @"\d+",
                       idCompteRecepteur = @"\d+"
                   }
               );

            config.Routes.MapHttpRoute(
                  name: "PuTTransfertDesignation",
                  routeTemplate: "api/Transfert/updateDesignation/{id}/{designation}",
                  defaults: new
                  {
                      controller = "Transfert",
                      action = "updateDesignation"
                  },
                   constraints: new
                   {
                       id = @"\d+"
                   }
               );

            config.Routes.MapHttpRoute(
                  name: "PuTTransfertMontant",
                  routeTemplate: "api/Transfert/updateMontant/{id}/{montant}",
                  defaults: new
                  {
                      controller = "Transfert",
                      action = "updateMontant"
                  },
                   constraints: new
                   {
                       id = @"\d+",
                       montant = @"\d+|\d+\.\d+"
                   }
               );

            config.Routes.MapHttpRoute(
                  name: "PuTTransfertDateCreation",
                  routeTemplate: "api/Transfert/updateDateCreation/{id}/{year}/{month}/{day}/{hour}/{minute}/{second}",
                  defaults: new
                  {
                      controller = "Transfert",
                      action = "updateDateCreation",
                      month = RouteParameter.Optional,
                      day = RouteParameter.Optional,
                      hour = RouteParameter.Optional,
                      minute = RouteParameter.Optional,
                      second = RouteParameter.Optional
                  },
                   constraints: new
                   {
                       id = @"\d+",
                       year = @"\d+",
                       month = @"\d*",
                       hour = @"\d*",
                       minute = @"\d*",
                       second = @"\d*"
                   }
               );

            config.Routes.MapHttpRoute(
                  name: "DeleteTranfert",
                  routeTemplate: "api/Transfert/delete/{id}",
                  defaults: new
                  {
                      controller = "Transfert",
                      action = "delete",

                  },
                   constraints: new
                   {
                       id = @"\d+"
                   }
               );
        }
    }
}