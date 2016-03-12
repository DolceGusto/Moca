using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using MizaniaServeur.Controllers;
using MizaniaServeur.Test.ServicesTests.FakeRepositories;

namespace MizaniaServeur.Test.ServicesTests.ServiceResovler
{
    public class ServiceResolverPositiveRepositories : IDependencyResolver
    {

        /*cette class va nous retourner les controller avec les FakeRepositories 
         *afin de découpler les controller de Entity FrameWork, De plus cette demarche nous 
         *permet de tester l'integrlité du tunel client server (tester les routes, la serialisation ... )
         *avec l'hypothese que les repository fonctionnent bien
         */
        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(TransfertController))

                return new TransfertController(new FakeTransfertPositiveRepository());

            else if (serviceType == typeof(TransactionController))

                return new TransactionController(new FakeTransactionPositiveRepository());

            else if (serviceType == typeof(TransactionPeriodiqueController))

                return new TransactionPeriodiqueController(new FakeTransactionPeriodiquePositiveRepository());

            else if (serviceType == typeof(CategorieController))

                return new CategorieController(new FakeCategoriePositiveRepository());

            else
                return null;
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
          
        }
    }
}