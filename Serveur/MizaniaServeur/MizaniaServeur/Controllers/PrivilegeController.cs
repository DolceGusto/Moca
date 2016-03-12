using MizaniaServeur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MizaniaServeur.Controllers
{
    public class PrivilegeController : ApiController
    {
         /*attribut*/
        private PrivilegeRepository privilegeRepository;

        /*constructeur*/
        public PrivilegeController()
        {
            privilegeRepository = new PrivilegeRepository(new MizaniaDbContext());
        }

        /*récupérer le privilege par son ID*/
        [HttpGet]
        public Privilege getById(int id)
        {
            return privilegeRepository.getPrivilegeById(id);
        }
        /*récupérer tous les privileges*/
        [HttpGet]
        public List<Privilege> getAllPrivileges()
        {
            return privilegeRepository.getAllPrivileges();
        }
        /* insérer un nouveau privilege*/
        [HttpPost]
        public HttpResponseMessage add([FromBody]Privilege privilege)
        {

            try
            {
                if (!privilegeRepository.InsertPrivilege(privilege))
                {
                    throw new Exception("ajout de l'instance de privilege non effecuté ");
                }
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
                response.StatusCode = HttpStatusCode.Created;
                String uri = Url.Link("GetPrivilege", new { id = privilege.id });
                response.Headers.Location = new Uri(uri);

                return response;

            }
            catch (Exception e)
            {
                HttpResponseMessage response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);

                return response;
            }

        }
        /*modifier un privilège*/
        [HttpPut]
        public HttpResponseMessage updatePrivilege([FromBody]Privilege privilege)
        {
            try
            {

                if (!privilegeRepository.updatePrivilege(privilege))
                {

                    throw new Exception("update privilège échouée");
                }
                Privilege p = privilegeRepository.getPrivilegeById(privilege.id);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, privilege);
                response.StatusCode = HttpStatusCode.OK;
                String uri = Url.Link("GetPrivilege", new { id = privilege.id });
                response.Headers.Location = new Uri(uri);

                return response;


            }
            catch (Exception e)
            {
                HttpResponseMessage response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);

                return response;
            }
        }

        /*supprimer un privilège*/

        [HttpDelete]
        public HttpResponseMessage delete(int id)
        {
            try
            {
                if (!privilegeRepository.deletePrivilege(id))
                {
                    throw new Exception("impossible de supprimer le privilege de ID = " + id);
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
