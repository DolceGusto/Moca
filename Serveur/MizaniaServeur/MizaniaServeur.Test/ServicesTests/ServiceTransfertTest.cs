using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using MizaniaServeur.Test.ServicesTests.ServiceResovler;
using MizaniaServeur.Test.ServicesTests.Enumeration ;
using System.Collections.Generic;
using MizaniaServeur.Models;

namespace MizaniaServeur.Test.ServicesTests
{
    [TestClass]
    public class ServiceTransfertTest
    {
        private static HttpConfiguration config;
        private static HttpServer server;
        private static HttpClient client;

        [ClassInitialize]
        public static void initializeTest(TestContext testContext)
        {
            config = new HttpConfiguration();
            config.DependencyResolver = new ServiceResolverPositiveRepositories(); // ne pas utiliser EF
            WebApiConfig.Register(config);

            server = new HttpServer(config);
            client = new HttpClient(server);
        }

        [TestMethod]
        public void getById_Test_WrightIdFormat()
        {
            var response = client.GetAsync(Constantes.localhost+"api/Transfert/getById/"+WrightInput.id).Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode); 
        }

        [TestMethod]
        public void getById_Test_WrongIdFormat()
        {
            var response = client.GetAsync(Constantes.localhost + "api/Transfert/getById/" + WrongInput.id).Result;

            Assert.AreNotEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public void getAll_Test_WrightIdFormat()
        {
            var response = client.GetAsync(Constantes.localhost + "api/Transfert/getAll/" + WrightInput.foreignId).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
            
        }

        [TestMethod]
        public void getByIdCompteExpediteur_Test()
        {
            var response = client.GetAsync(Constantes.localhost + "api/Transfert/getByIdCompteExpediteur/" + WrightInput.foreignId).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void getIdCompteRecepteur_Test()
        {
            var response = client.GetAsync(Constantes.localhost + "api/Transfert/getByIdCompteRecepteur/" + WrightInput.foreignId).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void getByMontant_Test_WrightMontant()
        {
            var response = client.GetAsync(Constantes.localhost + "api/Transfert/getByMontant/" +WrightInput.foreignId +"/" + WrightInput.montant).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void getByMontantAbove_Test_WrightMontant()
        {
            var response = client.GetAsync(Constantes.localhost + "api/Transfert/getByMontantAbove/" + WrightInput.foreignId + "/" + WrightInput.montant).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void getByMontantBelow_Test_WrightMontant()
        {
            var response = client.GetAsync(Constantes.localhost + "api/Transfert/getByMontantBelow/" + WrightInput.foreignId + "/" + WrightInput.montant).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void getByMontantAbove_Test_WrongMontant()
        {
            var response = client.GetAsync(Constantes.localhost + "api/Transfert/getByMontantAbove/" + WrightInput.foreignId + "/" + WrongInput.montant).Result;

            Assert.AreNotEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public void getByMontantBetween_Test_WrightMontant()
        {
            var response = client.GetAsync(Constantes.localhost + "api/Transfert/getByMontantBetween/" + WrightInput.foreignId 
                                           + "/" + WrightInput.montant+"/"+WrightInput.montant).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void getByDate_test_Wrightdate()
        {
            var response = client.GetAsync(Constantes.localhost+"api/Transfert/getByDate/"+
                                           WrightInput.foreignId+"/"+WrightInput.year+"/"+WrightInput.month
                                           +"/"+WrightInput.day+"/"+WrightInput.hour+"/"+WrightInput.second).Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
         public void getByDateFrom_test_Wrightdate()
        {
            var response = client.GetAsync(Constantes.localhost+"api/Transfert/getByDateFrom/"+
                                           WrightInput.foreignId+"/"+WrightInput.year+"/"+WrightInput.month
                                           +"/"+WrightInput.day+"/"+WrightInput.hour+"/"+WrightInput.second).Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }


        [TestMethod]
        public void getByDateTo_test_With_Omitted_Optional_Parameters()
        {
            var response = client.GetAsync(Constantes.localhost + "api/Transfert/getByDateTo/" +
                                           WrightInput.foreignId + "/" + WrightInput.year + "/" + WrightInput.month
                                           + "/" + WrightInput.day).Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }


      
        [TestMethod]
        public void getByDateBetween_test_With_Omitted_Optional_Parameters()
        {
            var response = client.GetAsync(Constantes.localhost + "api/Transfert/getByDateBetween/" +
                                           WrightInput.foreignId + "/" + WrightInput.year + "/" + WrightInput.year +
                                           "/" + WrightInput.month).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);

        }

        [TestMethod]
        public void add_test()
        {
            var response = client.PostAsync(Constantes.localhost + "api/Transfert/add",
                                            new FormUrlEncodedContent(WrightInput.
                                                                     getSampleTranfertAsKeyValuePair() ) ).Result;

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.IsNotNull(response.Headers.Location);
        }

        [TestMethod]
        public void updateIdCompteExpediteur_Test()
        {
            var response = client.PutAsync(Constantes.localhost + "api/Transfert/updateIdCompteExpediteur/" +
                                           WrightInput.id +"/"+ WrightInput.foreignId,
                                           new FormUrlEncodedContent(new HashSet<KeyValuePair<string,string>>()) ).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void updateIdCompteRecepteur_Test()
        {
            var response = client.PutAsync(Constantes.localhost + "api/Transfert/updateIdCompteRecepteur/" +
                                           WrightInput.id + "/" + WrightInput.foreignId,
                                           new FormUrlEncodedContent(new HashSet<KeyValuePair<string, string>>()) ).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void updateDesignation_Test()
        {
            var response = client.PutAsync(Constantes.localhost + "api/Transfert/updateDesignation/" +
                                            WrightInput.id + "/" + WrightInput.designation,
                                           new FormUrlEncodedContent(new HashSet<KeyValuePair<string, string>>())).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void updateMontant_Test()
        {
            var response = client.PutAsync(Constantes.localhost + "api/Transfert/updateMontant/" +
                                           WrightInput.id + "/" + WrightInput.montant,
                                           new FormUrlEncodedContent(new HashSet<KeyValuePair<string, string>>())).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void updateDateCreation_Test()
        {
            var response = client.PutAsync(Constantes.localhost + "api/Transfert/updateDateCreation/" +
                                           WrightInput.id + "/" + WrightInput.year+"/"+ WrightInput.month,
                                           new FormUrlEncodedContent(new HashSet<KeyValuePair<string, string>>())).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void delete_Test()
        {
            var response = client.DeleteAsync(Constantes.localhost + "api/Transfert/delete/" +
                                           WrightInput.id).Result;

            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
            
        }

    }
}
