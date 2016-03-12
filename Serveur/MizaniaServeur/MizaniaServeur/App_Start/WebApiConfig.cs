using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using MizaniaServeur.App_Start.RoutesConfig;


namespace MizaniaServeur
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services API Web
            // Itinéraires de l'API Web

            config.MapHttpAttributeRoutes();

            UtilisateurConfig.addRoutes(config);
            PrivilegeConfig.addRoutes(config);
            PrivilegeUtilisateurConfig.addRoutes(config);
            CompteConfig.addRoutes(config);
            TransactionConfig.addRoutes(config);
            TransactionPeriodiqueConfig.addRoutes(config);
            TransfertConfig.addRoutes(config);
            CategorieConfig.addRoutes(config);
            PorteFeuilleConfig.addRoutes(config);
        }

    }
}
