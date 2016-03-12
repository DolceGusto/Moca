using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;
using System.Net.Http;
using MizaniaServeur.Test.ServicesTests.ServiceResovler;
using MizaniaServeur.Test.ServicesTests.Enumeration;
using System.Net;
using System.Collections.Generic;

namespace MizaniaServeur.Test.ServicesTests
{
    [TestClass]
    public class ServiceTransactionTest
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
        public void getById_Test()
        {
            var response = client.GetAsync(Constantes.localhost + "api/Transaction/getById/" + WrightInput.id).Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode); 
        }

        [TestMethod]
        public void getByIdPorteFeuille_Test()
        {
            var response = client.GetAsync(Constantes.localhost + "api/Transaction/getByIdPorteFeuille/" + WrightInput.foreignId).Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode); 
        }

        [TestMethod]
        public void getByMontant_Test()
        {
            var response = client.GetAsync(Constantes.localhost + "api/Transaction/getByMontant/" 
                                           + WrightInput.foreignId+ "/" + WrightInput.montant ).Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode); 
        }

        [TestMethod]
        public void getByMontantAbove_Test()
        {
            var response = client.GetAsync(Constantes.localhost + "api/Transaction/getByMontantAbove/"
                                           + WrightInput.foreignId + "/" + WrightInput.montant).Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode); 
        }

        [TestMethod]
        public void getByMontantBelow_Test()
        {
            var response = client.GetAsync(Constantes.localhost + "api/Transaction/getByMontantBelow/"
                                           + WrightInput.foreignId + "/" + WrightInput.montant).Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode); 
        }

        [TestMethod]
        public void getDateCreation_Test()
        {
            var response = client.GetAsync(Constantes.localhost + "api/Transaction/getByDateCreation/"
                                           + WrightInput.foreignId + "/" + WrightInput.year +"/"+WrightInput.month+"/"
                                           + WrightInput.day + "/" + WrightInput.hour + "/" + WrightInput.minute + "/"
                                           + WrightInput.second ).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode); 
        }

        [TestMethod]
        public void getByDateCreationFrom_Test()
        {
            var response = client.GetAsync(Constantes.localhost + "api/Transaction/getByDateCreationFrom/"
                                          + WrightInput.foreignId + "/" + WrightInput.year + "/" + WrightInput.month + "/"
                                          + WrightInput.day + "/" + WrightInput.hour + "/" + WrightInput.minute + "/"
                                          + WrightInput.second).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode); 
        }

        [TestMethod]
        public void getByDateCreationTo_Test()
        {
            var response = client.GetAsync(Constantes.localhost + "api/Transaction/getByDateCreationTo/"
                                          + WrightInput.foreignId + "/" + WrightInput.year + "/" + WrightInput.month + "/"
                                          + WrightInput.day + "/" + WrightInput.hour + "/" + WrightInput.minute + "/"
                                          + WrightInput.second).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode); 
        }

        [TestMethod]
        public void getByDesignation_Test()
        {
            var response = client.GetAsync(Constantes.localhost + "api/Transaction/getByDesignation/"
                                          + WrightInput.foreignId +"/" + WrightInput.designation ).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode); 
        }

        [TestMethod]
        public void getLikeDesignation_Test()
        {
            var response = client.GetAsync(Constantes.localhost + "api/Transaction/getLikeDesignation/"
                                          + WrightInput.foreignId + "/" + WrightInput.designation).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode); 
        }

        [TestMethod]
        public void getByIdCategorie_Test()
        {
            var response = client.GetAsync(Constantes.localhost + "api/Transaction/getByIdCategorie/"
                                          + WrightInput.foreignId + "/" + WrightInput.foreignId).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode); 
        }

        [TestMethod]
        public void getByTypeTransaction_Test()
        {
            var response = client.GetAsync(Constantes.localhost + "api/Transaction/getByTypeTransaction/"
                                          + WrightInput.foreignId + "/" + WrightInput.typeTransactEntree).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode); 
        }

        [TestMethod]
        public void add_Test()
        {
            var response = client.PostAsync(Constantes.localhost + "api/Transaction/add",
                                            new FormUrlEncodedContent(WrightInput.
                                                                     getSampleTransactionAsKeyValuePair())).Result;

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.IsNotNull(response.Headers.Location);
        }

        [TestMethod]
        public void updateMontant_Test()
        {
            var response = client.PutAsync(Constantes.localhost + "api/Transaction/updateMontant/" +
                                           WrightInput.id + "/" + WrightInput.montant,
                                           new FormUrlEncodedContent(new HashSet<KeyValuePair<string, string>>())).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void updateIdComtpe_Test()
        {
            var response = client.PutAsync(Constantes.localhost + "api/Transaction/updateIdCompte/" +
                                          WrightInput.id + "/" + WrightInput.foreignId,
                                          new FormUrlEncodedContent(new HashSet<KeyValuePair<string, string>>())).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void updateIdCategorie_Test()
        {
            var response = client.PutAsync(Constantes.localhost + "api/Transaction/updateIdCategorie/" +
                                          WrightInput.id + "/" + WrightInput.foreignId,
                                          new FormUrlEncodedContent(new HashSet<KeyValuePair<string, string>>())).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void updateTypeTransaction_Test()
        {
            var response = client.PutAsync(Constantes.localhost + "api/Transaction/updateTypeTransaction/" +
                                          WrightInput.id + "/" + WrightInput.typeTransactDepense,
                                          new FormUrlEncodedContent(new HashSet<KeyValuePair<string, string>>())).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void updateDateCreation_Test()
        {
            var response = client.PutAsync(Constantes.localhost + "api/Transfert/updateDateCreation/" +
                                          WrightInput.id + "/" + WrightInput.year + "/" + WrightInput.month+
                                          "/"+ WrightInput.day +"/"+ WrightInput.hour +"/"+ WrightInput.minute +"/"+
                                          WrightInput.second,
                                          new FormUrlEncodedContent(new HashSet<KeyValuePair<string, string>>())).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void updateDesignation_Test()
        {
            var response = client.PutAsync(Constantes.localhost + "api/Transaction/updateDesignation/" +
                                          WrightInput.id + "/" + WrightInput.designation,
                                          new FormUrlEncodedContent(new HashSet<KeyValuePair<string, string>>())).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void delete_Test()
        {
            var response = client.DeleteAsync(Constantes.localhost + "api/Transaction/delete/" +
                                           WrightInput.id).Result;

            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

    }
}
