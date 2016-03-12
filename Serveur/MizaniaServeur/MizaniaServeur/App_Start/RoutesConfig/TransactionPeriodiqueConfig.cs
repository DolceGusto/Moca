using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MizaniaServeur.App_Start.RoutesConfig
{
    public class TransactionPeriodiqueConfig
    {

        public static void addRoutes(HttpConfiguration config)
        {

            config.Routes.MapHttpRoute(
                 name: "getTransactionPeriodiqueById",
                 routeTemplate: "api/TransactionPeriodique/getById/{id}",
                 defaults: new
                 {
                     controller = "TransactionPeriodique",
                     action = "getById",

                 },
                 constraints: new { id = @"\d+" }
              );

            config.Routes.MapHttpRoute(
               name: "getTransactionPeriodiqueByIdPorteFeuille",
               routeTemplate: "api/TransactionPeriodique/getByIdPorteFeuille/{idPorteFeuille}",
               defaults: new
               {
                   controller = "TransactionPeriodique",
                   action = "getByIdPorteFeuille",

               },
               constraints: new { idPorteFeuille = @"\d+" }
            );


            config.Routes.MapHttpRoute(
               name: "getTransactionPeriodiqueByIdCompte",
               routeTemplate: "api/TransactionPeriodique/getByIdCompte/{id}",
               defaults: new
               {
                   controller = "TransactionPeriodique",
                   action = "getByIdCompte",

               },
               constraints: new { id = @"\d+" }
            );

            config.Routes.MapHttpRoute(
               name: "getTransactionPeriodiqueByCategorie",
               routeTemplate: "api/TransactionPeriodique/getByIdCategorie/{idPorteFeuille}/{id}",
               defaults: new
               {
                   controller = "TransactionPeriodique",
                   action = "getByIdCategorie",

               },
               constraints: new
               {
                   id = @"\d+",
                   idPorteFeuille = @"\d+"
               }
            );

            config.Routes.MapHttpRoute(
               name: "getTransactionPeriodiqueByMontant",
               routeTemplate: "api/TransactionPeriodique/getByMontant/{idPorteFeuille}/{montant}",
               defaults: new
               {
                   controller = "TransactionPeriodique",
                   action = "getByMontant",

               },
               constraints: new
               {
                   idPorteFeuille = @"\d+",
                   montant = @"\d+|\d+\.\d+"
               }
            );

            config.Routes.MapHttpRoute(
               name: "getTransactionPeriodiqueByDateCreation",
               routeTemplate: "api/TransactionPeriodique/getByDateCreation/{idPorteFeuille}/{year}/{month}/{day}/{hour}/{minute}/{second}",
               defaults: new
               {
                   controller = "TransactionPeriodique",
                   action = "getByDateCreation",
                   month = RouteParameter.Optional,
                   day = RouteParameter.Optional,
                   hour = RouteParameter.Optional,
                   minute = RouteParameter.Optional,
                   second = RouteParameter.Optional



               },
               constraints: new
               {
                   idPorteFeuille = @"\d+",
                   year = @"\d+",
                   month = @"\d*",
                   day = @"\d*",
                   hour = @"\d*",
                   minute = @"\d*",
                   second = @"\d*"
               }
            );

            config.Routes.MapHttpRoute(
               name: "getTransactionPeriodiqueLikeDesignation",
               routeTemplate: "api/TransactionPeriodique/getLikeDesignation/{idPorteFeuille}/{designation}",
               defaults: new
               {
                   controller = "TransactionPeriodique",
                   action = "getLikeDesignation",

               },
               constraints: new
               {
                   idPorteFeuille = @"\d+",

               }
            );

            config.Routes.MapHttpRoute(
               name: "getTransactionPeriodiqueByDesignation",
               routeTemplate: "api/TransactionPeriodique/getByDesignation/{idPorteFeuille}/{designation}",
               defaults: new
               {
                   controller = "TransactionPeriodique",
                   action = "getByDesignation",

               },
               constraints: new
               {
                   idPorteFeuille = @"\d+"

               }
            );

            config.Routes.MapHttpRoute(
               name: "getTransactionPeriodiqueByTypeTransaction",
               routeTemplate: "api/TransactionPeriodique/getByTypeTransaction/{idPorteFeuille}/{typeTransaction}",
               defaults: new
               {
                   controller = "TransactionPeriodique",
                   action = "getByTypeTransaction",

               },
               constraints: new
               {
                   idPorteFeuille = @"\d+",
                   typeTransaction= "entree|depense"
               }
            );

            config.Routes.MapHttpRoute(
               name: "getTransactionPeriodiqueByMontantBetween",
               routeTemplate: "api/TransactionPeriodique/getByMontantBetween/{idPorteFeuille}/{min}/{max}",
               defaults: new
               {
                   controller = "TransactionPeriodique",
                   action = "getByMontantBetween",

               },
               constraints: new
               {
                   idPorteFeuille = @"\d+",
                   min = @"\d+|\d+\.\d+",
                   max = @"\d+|\d+\.\d+"
               }

            );

            config.Routes.MapHttpRoute(
               name: "getTransactionPeriodiqueByMontantAbove",
               routeTemplate: "api/TransactionPeriodique/getByMontantAbove/{idPorteFeuille}/{min}",
               defaults: new
               {
                   controller = "TransactionPeriodique",
                   action = "getByMontantAbove",

               },
               constraints: new
               {
                   idPorteFeuille = @"\d+",
                   min = @"\d+|\d+\.\d+"
               }

            );

            config.Routes.MapHttpRoute(
               name: "getTransactionPeriodiqueByMontantBelow",
               routeTemplate: "api/TransactionPeriodique/getByMontantBelow/{idPorteFeuille}/{max}",
               defaults: new
               {
                   controller = "TransactionPeriodique",
                   action = "getByMontantBelow",

               },
               constraints: new
               {
                   idPorteFeuille = @"\d+",
                   max = @"\d+|\d+\.\d+"
               }

            );

            config.Routes.MapHttpRoute(
               name: "getTransactionPeriodiqueByDateFrom",
               routeTemplate: "api/TransactionPeriodique/getByDateCreationFrom/{idPorteFeuille}/{year}/{month}/{day}/{hour}/{minute}/{second}",
               defaults: new
               {
                   controller = "TransactionPeriodique",
                   action = "getByDateCreationFrom",
                   month = RouteParameter.Optional,
                   day = RouteParameter.Optional,
                   hour = RouteParameter.Optional,
                   minute = RouteParameter.Optional,
                   second = RouteParameter.Optional,

               },
               constraints: new
               {
                   idPorteFeuille = @"\d+",
                   year = @"\d+",
                   month = @"\d+",
                   day = @"\d+",
                   hour = @"\d+",
                   minute = @"\d+",
                   second = @"\d+"
               }

            );

            config.Routes.MapHttpRoute(
               name: "getTransactionPeriodiqueByDateTo",
               routeTemplate: "api/TransactionPeriodique/getByDateCreationTo/{idPorteFeuille}/{year}/{month}/{day}/{hour}/{minute}/{second}",
               defaults: new
               {
                   controller = "TransactionPeriodique",
                   action = "getByDateCreationTo",
                   month = RouteParameter.Optional,
                   day = RouteParameter.Optional,
                   hour = RouteParameter.Optional,
                   minute = RouteParameter.Optional,
                   second = RouteParameter.Optional,

               },
               constraints: new
               {
                   idPorteFeuille = @"\d+",
                   year = @"\d+",
                   month = @"\d+",
                   day = @"\d+",
                   hour = @"\d+",
                   minute = @"\d+",
                   second = @"\d+"
               }

            );

            config.Routes.MapHttpRoute(
                name: "getTransactionPeriodiqueByDateBetween",
                routeTemplate: "api/TransactionPeriodique/getByDateBetween/{idPorteFeuille}/{dYear}/{fYear}/{dMonth}/{fMonth}/" +
                                "{dDay}/{fDay}/{dHour}/{fHour}/{dMinute}/{fMinute}/{dSecond}/{fSecond}",
                defaults: new
                {
                    controller = "TransactionPeriodique",
                    action = "updateIdCategorie",
                    fMonth = RouteParameter.Optional,
                    dMonth = RouteParameter.Optional,
                    fDay = RouteParameter.Optional,
                    dDay = RouteParameter.Optional,
                    dHour = RouteParameter.Optional,
                    fHour = RouteParameter.Optional,
                    dMinute = RouteParameter.Optional,
                    fMinute = RouteParameter.Optional,
                    dSecond = RouteParameter.Optional,
                    fSecond = RouteParameter.Optional

                },
                constraints: new
                {
                    id = @"\d+",
                    idCategorie = @"\d*",
                    dYear = @"\d+",
                    fYear = @"\d+",
                    dMonth = @"\d*",
                    fMonth = @"\d*",
                    dDay = @"\d*",
                    fDay = @"\d*",
                    dHour = @"\d*",
                    fHour = @"\d*",
                    dMinute = @"\d*",
                    fMinute = @"\d*",
                    dSecond = @"\d*",
                    fSecond = @"\d*"
                }

                );

            config.Routes.MapHttpRoute(

                name: "addTransactionPeriodique",
                routeTemplate: "api/TransactionPeriodique/add",
                defaults: new
                {
                    controller = "TransactionPeriodique",
                    action = "add"
                }

                );

            config.Routes.MapHttpRoute(
                name: "updateTransactionPeriodiqueIdCommpte",
                routeTemplate: "api/TransactionPeriodique/updateIdCompte/{id}/{idCompte}",
                defaults: new
                {
                    controller = "TransactionPeriodique",
                    action = "updateIdCompte"
                },
                constraints: new
                {
                    id = @"\d+",
                    idCompte = @"\d+"
                }
                );

            config.Routes.MapHttpRoute(
                name: "updateTransactionPeriodiqueIdCategorie",
                routeTemplate: "api/TransactionPeriodique/updateIdCategorie/{id}/{idCategorie}",
                defaults: new
                {
                    controller = "TransactionPeriodique",
                    action = "updateIdCategorie"
                },
                constraints: new
                {
                    id = @"\d+",
                    idCategorie = @"\d*"
                }

                );

            config.Routes.MapHttpRoute(
                name: "updateTransactionPeriodiqueMontant",
                routeTemplate: "api/TransactionPeriodique/updateMontant/{id}/{montant}",
                defaults: new
                {
                    controller = "TransactionPeriodique",
                    action = "updateMontant"
                },
                constraints: new
                {
                    id = @"\d+",
                    montant = @"\d+|\d+\.\d+"
                }

                );

            config.Routes.MapHttpRoute(
                name: "updateTransactionPeriodiqueDesignation",
                routeTemplate: "api/TransactionPeriodique/updateDesignation/{id}/{designation}",
                defaults: new
                {
                    controller = "TransactionPeriodique",
                    action = "updateDesignation"
                },
                constraints: new
                {
                    id = @"\d+"
                }

                );

            config.Routes.MapHttpRoute(
                name: "updateTransactionPeriodiqueTypeTransaction",
                routeTemplate: "api/TransactionPeriodique/updateTypeTransaction/{id}/{typeTransaction}",
                defaults: new
                {
                    controller = "TransactionPeriodique",
                    action = "updateTypeTransaction"
                },
                constraints: new
                {
                    id = @"\d+",
                    typeTransaction = "entree|depense"
                }
                );

            config.Routes.MapHttpRoute(
                name: "updateTransactionPeriodiqueDateCreation",
                routeTemplate: "api/Transcation/updateDateCreation/{id}/{year}/{month}/{day}/{hour}/{minute}/{second}",
                defaults: new
                {
                    controller = "TransactionPeriodique",
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
                    day = @"\d*",
                    hour = @"\d*",
                    minute = @"\d*",
                    second = @"\d*"
                }

                );

            config.Routes.MapHttpRoute(
                name: "deleteTransactionPeriodique",
                routeTemplate: "api/TransactionPeriodique/delete/{id}",
                defaults: new
                {
                    controller = "TransactionPeriodique",
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