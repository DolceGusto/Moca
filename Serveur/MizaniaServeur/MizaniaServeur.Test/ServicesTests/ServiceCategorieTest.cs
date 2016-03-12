using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;
using System.Net.Http;
using MizaniaServeur.Test.ServicesTests.ServiceResovler;
using MizaniaServeur.Test.ServicesTests.Enumeration;
using System.Net;

namespace MizaniaServeur.Test.ServicesTests
{
    

    [TestClass]
    public class ServiceCategorieTest
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
            var response = client.GetAsync(Constantes.localhost + "api/Categorie/getById/" + WrightInput.id).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void getByIdPorteFeuille_Test()
        {
            var response = client.GetAsync(Constantes.localhost + "api/Categorie/getByIdPorteFeuille/" + WrightInput.id).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void getByDesignation_Test()
        {
            var response = client.GetAsync(Constantes.localhost + "api/Categorie/getByDesignation/" + WrightInput.id+
                                           "/"+ WrightInput.designation ).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void getByDescription_Test()
        {
            var response = client.GetAsync(Constantes.localhost + "api/Categorie/getByDescription/" + WrightInput.id +
                                           "/" + WrightInput.description).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void getLikeDesignation_Test()
        {
            var response = client.GetAsync(Constantes.localhost + "api/Categorie/getLikeDesignation/" + WrightInput.id +
                                           "/" + WrightInput.designation).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void getLikeDescrption_Test()
        {
            var response = client.GetAsync(Constantes.localhost + "api/Categorie/getLikeDescription/" + WrightInput.id +
                                           "/" + WrightInput.description).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void add_Test()
        {
            var response = client.PostAsync(Constantes.localhost + "api/Categorie/add",
                                           new FormUrlEncodedContent(WrightInput.
                                                                    getSampleCategorieAsKeyValuePair())).Result;

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.IsNotNull(response.Headers.Location);
        }

        [TestMethod]
        public void updateDesignation_Test()
        {
            var response = client.PutAsync(Constantes.localhost + "api/Categorie/updateDesignation/" +
                                           WrightInput.id+ "/" + WrightInput.designation,
                                           new FormUrlEncodedContent(new HashSet<KeyValuePair<string, string>>())).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void updateDescription_Test()
        {
            var response = client.PutAsync(Constantes.localhost + "api/Categorie/updateDescription/" +
                                           WrightInput.id + "/" + WrightInput.description,
                                           new FormUrlEncodedContent(new HashSet<KeyValuePair<string, string>>())).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void delete_Test()
        {
            var response = client.DeleteAsync(Constantes.localhost + "api/Categorie/delete/" +
                                           WrightInput.id).Result;

            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
