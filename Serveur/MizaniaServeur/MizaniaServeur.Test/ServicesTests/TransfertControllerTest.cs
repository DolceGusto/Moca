using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http.Routing;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using MizaniaServeur.Controllers;
using MizaniaServeur.Test.ServicesTests.Enumeration;
using System.Net;
using MizaniaServeur.Models;
using MizaniaServeur.Test.ServicesTests.FakeRepositories;




namespace MizaniaServeur.Test.ServicesTests
{
    [TestClass]
    public class TransfertControllerTest
    {
        /*les champs*/
        private static FakeTransfertPositiveRepository fakeTransfertRepository;
        private  TransfertController transfertController;
        private  HttpConfiguration config;
        private  HttpRequestMessage request;
        private  HttpRouteData routeData;
        private  IHttpRoute route;
        private  HttpResponseMessage response;


        [ClassInitialize]
        public static void InitializeRessources(TestContext testContext)
        {
            fakeTransfertRepository = new FakeTransfertPositiveRepository();
        }

        [TestInitialize]
        public void initTests()
        {
            transfertController = new TransfertController(fakeTransfertRepository);
            config = new HttpConfiguration();
        }


        /*  les testes methodes  */
        [TestMethod]
        public void addTest()
        {
            // l'initialisation (arrange)
            request = getRequest(HttpMethod.Post);

            route = config.Routes.MapHttpRoute(
                  name: "PostTransfert",
                  routeTemplate: "api/Transfert/add",
                  defaults: new
                  {
                      controller = "Transfert",
                      action = "add"
                  }
               );

            // la route pour le get afin de faire le link dans le controller 
            
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

            routeData = new HttpRouteData(route);
            setControllerContext(transfertController, config, routeData,request);
            setRequestProperties(request, config, routeData);
            transfertController.Request = request;
            transfertController.Url = new UrlHelper(request);

            // l'execution (act)
            response = transfertController.add(WrightInput.getSampleTransfert());


            // les assertions (asert)
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.IsNotNull(response.Headers.Location);


        }

        [TestMethod]
        public void updateIdCompteExpediteurTest()
        {
            request = getRequest(HttpMethod.Put);
            route = config.Routes.MapHttpRoute(
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
               name: "GetTransfert",
               routeTemplate: "api/TransfertBId/{id}",
               defaults: new
               {
                   controller = "Transfert",
                   action = "getById",

               },
               constraints: new { id = @"\d+" }
            );

            routeData = new HttpRouteData(route, new HttpRouteValueDictionary
                                                 {
                                                     { "id", WrightInput.id },
                                                     { "idCompteExpediteur" , WrightInput.foreignId }
                                                 });
            setControllerContext(transfertController, config, routeData, request);
            setRequestProperties(request, config, routeData);
            transfertController.Request = request;
            transfertController.Url = new UrlHelper(request);

            response = transfertController.updateIdCompteExpediteur(1, 2);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(response.Headers.Location);
            Assert.IsNotNull(response.Content);
        }


        [TestMethod]
        public void getByIdTest()
        {
            request = getRequest(HttpMethod.Get);
            route = config.Routes.MapHttpRoute(
               name: "GetTransfert",
               routeTemplate: "api/TransfertBId/{id}",
               defaults: new
               {
                   controller = "Transfert",
                   action = "getById",

               },
               constraints: new { id = @"\d+" }
            );
            routeData = new HttpRouteData(route, new HttpRouteValueDictionary
                                                 {
                                                     { "id", WrightInput.id }
                                                 });
            setControllerContext(transfertController, config, routeData, request);
            setRequestProperties(request, config, routeData);
            transfertController.Request = request;
            transfertController.Url = new UrlHelper(request);

            Transfert t = transfertController.getById(1);


            Assert.IsNotNull(t);

        }


        /*methodes utilitaire (helper methodes)*/

        private void setControllerContext(ApiController controller,HttpConfiguration config, HttpRouteData routeData, HttpRequestMessage request)
        {
            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
        }

        private void setRequestProperties(HttpRequestMessage request, HttpConfiguration config, HttpRouteData routeData)
        {
            request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;

        }

        private HttpRequestMessage getRequest(HttpMethod methode)
        {
            return new HttpRequestMessage(methode, Constantes.localhost);
        }

    }
}
