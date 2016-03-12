using MizaniaServeur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MizaniaServeur.Controllers
{
    public class PortefeuilleController : ApiController
    {
         /*attribut*/
        private PortefeuilleRepository portefeuilleRepository;

        /*constructeur*/
        public PortefeuilleController()
        {
            portefeuilleRepository = new PortefeuilleRepository(new MizaniaDbContext());
        }

        /*les methode exposées aux clients */

        [HttpGet]
        public PorteFeuille getById(int id)
        {
            return portefeuilleRepository.getPortefeuilleById(id);
        }
         [HttpGet]
        public List<Utilisateur> getAllUsers(int id)
        {

            return portefeuilleRepository.getUsersPortefeuille(id);

        }
         [HttpGet]
         public List<Utilisateur> getNormalUsers(int id)
         {

             return portefeuilleRepository.getNormalUsersPortefeuille(id);

         }
         [HttpGet]
         public List<Utilisateur> getPrincipalUsers(int id)
         {

             return portefeuilleRepository.getPrincipalUsersPortefeuille(id);

         }
         [HttpGet]
         public Utilisateur getCreator(int id)
         {

             return portefeuilleRepository.getCreatorPortefeuille(id);

         }

        /* service d'Ajout d'un nouveau portefeuille*/

        [HttpPost]
        public HttpResponseMessage add([FromBody]PorteFeuille portefeuille)
        {

            try
            {
                if (!portefeuilleRepository.InsertPortefeuille(portefeuille))
                {
                    throw new Exception("ajout de l'instance de portefuille non effecuté ");
                }
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
                response.StatusCode = HttpStatusCode.Created;
                String uri = Url.Link("PostPortefeuille", new { id = portefeuille.id });
                response.Headers.Location = new Uri(uri);

                return response;

            }
            catch (Exception e)
            {
                HttpResponseMessage response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);

                return response;
            }

        }

        [HttpPut]
        public HttpResponseMessage updatePortefeuille([FromBody]PorteFeuille portefeuille)
        {
            try
            {

                if (!portefeuilleRepository.updatePortefeuille(portefeuille))
                {

                    throw new Exception("update portefeuille échouée");
                }
                PorteFeuille p = portefeuilleRepository.getPortefeuilleById(portefeuille.id);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, portefeuille);
                response.StatusCode = HttpStatusCode.OK;
                String uri = Url.Link("PutPortefeuille", new { id = portefeuille.id });
                response.Headers.Location = new Uri(uri);

                return response;


            }
            catch (Exception e)
            {
                HttpResponseMessage response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);

                return response;
            }
        }

        /*supprimer un portefeuille*/

        [HttpDelete]
        public HttpResponseMessage delete(int id)
        {
            try
            {
                if (!portefeuilleRepository.deletePortefeuille(id))
                {
                    throw new Exception("impossible de supprimer le portefeuille de ID = " + id);
                }
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NoContent);

                return response;
            }
            catch (Exception e)
            {
                HttpResponseMessage response;
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);

                return response;
            }
        }


    }
}
