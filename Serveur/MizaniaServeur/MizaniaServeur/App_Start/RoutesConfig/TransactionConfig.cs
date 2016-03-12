using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MizaniaServeur.App_Start.RoutesConfig
{
    public class TransactionConfig
    {


        public static void addRoutes(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
               name: "getTransactionById",
               routeTemplate: "api/Transaction/getById/{id}",
               defaults: new
               {
                   controller = "Transaction",
                   action = "getById",

               },
               constraints: new { id = @"\d+" }
            );

            config.Routes.MapHttpRoute(
               name: "getTransactionByIdPorteFeuille",
               routeTemplate: "api/Transaction/getByIdPorteFeuille/{idPorteFeuille}",
               defaults: new
               {
                   controller = "Transaction",
                   action = "getByIdPorteFeuille",

               },
               constraints: new { idPorteFeuille = @"\d+" }
            );


            config.Routes.MapHttpRoute(
               name: "getTransactionByIdCompte",
               routeTemplate: "api/Transaction/getByIdCompte/{id}",
               defaults: new
               {
                   controller = "Transaction",
                   action = "getByIdCompte",

               },
               constraints: new { id = @"\d+" }
            );

            config.Routes.MapHttpRoute(
               name: "getTransactionByCategorie",
               routeTemplate: "api/Transaction/getByIdCategorie/{idPorteFeuille}/{id}",
               defaults: new
               {
                   controller = "Transaction",
                   action = "getByIdCategorie",

               },
               constraints: new
               {
                   id = @"\d+",
                   idPorteFeuille = @"\d+"
               }
            );

            config.Routes.MapHttpRoute(
               name: "getTransactionByMontant",
               routeTemplate: "api/Transaction/getByMontant/{idPorteFeuille}/{montant}",
               defaults: new
               {
                   controller = "Transaction",
                   action = "getByMontant",

               },
               constraints: new
               {
                   idPorteFeuille = @"\d+",
                   montant = @"\d+|\d+\.\d+"
               }
            );

            config.Routes.MapHttpRoute(
               name: "getTransactionByDateCreation",
               routeTemplate: "api/Transaction/getByDateCreation/{idPorteFeuille}/{year}/{month}/{day}/{hour}/{minute}/{second}",
               defaults: new
               {
                   controller = "Transaction",
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
               name: "getTransactionLikeDesignation",
               routeTemplate: "api/Transaction/getLikeDesignation/{idPorteFeuille}/{designation}",
               defaults: new
               {
                   controller = "Transaction",
                   action = "getLikeDesignation",

               },
               constraints: new
               {
                   idPorteFeuille = @"\d+",

               }
            );

            config.Routes.MapHttpRoute(
               name: "getTransactionByDesignation",
               routeTemplate: "api/Transaction/getByDesignation/{idPorteFeuille}/{designation}",
               defaults: new
               {
                   controller = "Transaction",
                   action = "getByDesignation",

               },
               constraints: new
               {
                   idPorteFeuille = @"\d+"

               }
            );

            config.Routes.MapHttpRoute(
               name: "getTransactionByTypeTransaction",
               routeTemplate: "api/Transaction/getByTypeTransaction/{idPorteFeuille}/{typeTransaction}",
               defaults: new
               {
                   controller = "Transaction",
                   action = "getByTypeTransaction",

               },
               constraints: new
               {
                   idPorteFeuille = @"\d+",
                   typeTransaction = "entree|depense"
               }
            );

            config.Routes.MapHttpRoute(
               name: "getTransactionByMontantBetween",
               routeTemplate: "api/Transaction/getByMontantBetween/{idPorteFeuille}/{min}/{max}",
               defaults: new
               {
                   controller = "Transaction",
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
               name: "getTransactionByMontantAbove",
               routeTemplate: "api/Transaction/getByMontantAbove/{idPorteFeuille}/{min}",
               defaults: new
               {
                   controller = "Transaction",
                   action = "getByMontantAbove",

               },
               constraints: new
               {
                   idPorteFeuille = @"\d+",
                   min = @"\d+|\d+\.\d+"
               }

            );

            config.Routes.MapHttpRoute(
               name: "getTransactionByMontantBelow",
               routeTemplate: "api/Transaction/getByMontantBelow/{idPorteFeuille}/{max}",
               defaults: new
               {
                   controller = "Transaction",
                   action = "getByMontantBelow",

               },
               constraints: new
               {
                   idPorteFeuille = @"\d+",
                   max = @"\d+|\d+\.\d+"
               }

            );

            config.Routes.MapHttpRoute(
               name: "getTransactionByDateFrom",
               routeTemplate: "api/Transaction/getByDateCreationFrom/{idPorteFeuille}/{year}/{month}/{day}/{hour}/{minute}/{second}",
               defaults: new
               {
                   controller = "Transaction",
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
               name: "getTransactionByDateTo",
               routeTemplate: "api/Transaction/getByDateCreationTo/{idPorteFeuille}/{year}/{month}/{day}/{hour}/{minute}/{second}",
               defaults: new
               {
                   controller = "Transaction",
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
                name: "getTransactionByDateBetween",
                routeTemplate: "api/Transaction/getByDateBetween/{idPorteFeuille}/{dYear}/{fYear}/{dMonth}/{fMonth}/" +
                                "{dDay}/{fDay}/{dHour}/{fHour}/{dMinute}/{fMinute}/{dSecond}/{fSecond}",
                defaults: new
                {
                    controller = "Transaction",
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

                name: "addTransaction",
                routeTemplate: "api/Transaction/add",
                defaults: new
                {
                    controller = "Transaction",
                    action = "add"
                }

                );

            config.Routes.MapHttpRoute(
                name: "updateTransactionIdCommpte",
                routeTemplate: "api/Transaction/updateIdCompte/{id}/{idCompte}",
                defaults: new
                {
                    controller = "Transaction",
                    action = "updateIdCompte"
                },
                constraints: new
                {
                    id = @"\d+",
                    idCompte = @"\d+"
                }
                );

            config.Routes.MapHttpRoute(
                name: "updateTransactionIdCategorie",
                routeTemplate: "api/Transaction/updateIdCategorie/{id}/{idCategorie}",
                defaults: new
                {
                    controller = "Transaction",
                    action = "updateIdCategorie"
                },
                constraints: new
                {
                    id = @"\d+",
                    idCategorie = @"\d*"
                }

                );

            config.Routes.MapHttpRoute(
                name: "updateTransactionMontant",
                routeTemplate: "api/Transaction/updateMontant/{id}/{montant}",
                defaults: new
                {
                    controller = "Transaction",
                    action = "updateMontant"
                },
                constraints: new
                {
                    id = @"\d+",
                    montant = @"\d+|\d+\.\d+"
                }

                );

            config.Routes.MapHttpRoute(
                name: "updateTransactionDesignation",
                routeTemplate: "api/Transaction/updateDesignation/{id}/{designation}",
                defaults: new
                {
                    controller = "Transaction",
                    action = "updateDesignation"
                },
                constraints: new
                {
                    id = @"\d+"
                }

                );

            config.Routes.MapHttpRoute(
                name: "updateTransactionTypeTransaction",
                routeTemplate: "api/Transaction/updateTypeTransaction/{id}/{typeTransaction}",
                defaults: new
                {
                    controller = "Transaction",
                    action = "updateTypeTransaction"
                },
                constraints: new
                {
                    id = @"\d+",
                    typeTransaction = "entree|depense"
                }
                );

            config.Routes.MapHttpRoute(
                name: "updateTransactionDateCreation",
                routeTemplate: "api/Transcation/updateDateCreation/{id}/{year}/{month}/{day}/{hour}/{minute}/{second}",
                defaults: new
                {
                    controller = "Transaction",
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
                name: "deleteTransaction",
                routeTemplate: "api/Transaction/delete/{id}",
                defaults: new
                {
                    controller = "Transaction",
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