using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MizaniaServeur.Models;

namespace MizaniaServeur.Controllers
{
    public class PrivilegeUtilisateurController : ApiController
    {

        /*attribut*/
        private PrivilegeUtilisateurRepository privilegeUtilisateurRepository;
        public PrivilegeUtilisateurController()
        {
            privilegeUtilisateurRepository = new PrivilegeUtilisateurRepository(new MizaniaDbContext());
        }
        /*constructeur*/
       public PrivilegeUtilisateurController(PrivilegeUtilisateurRepository privilegeUtilisateurRepository)
       {
           this.privilegeUtilisateurRepository = privilegeUtilisateurRepository;
       
       }
        
        [HttpGet]
       public PrivilegeUtilisateur GetPrivilegeUtilisateurById(int UtilisateurID, int PrivilegeID) /* Permet de récupérer un droitprivilege dont l'idUtilisateur=UtilisateurID et idPrivilege=PrivilegeID */
       {
           return privilegeUtilisateurRepository.GetPrivilegeUtilisateur(UtilisateurID,PrivilegeID);
       }
       //retourne le compte ayant id comme identifiant
       [HttpGet]
       public  List<PrivilegeUtilisateur> GetPrivilegeUtilisateur(int ID) /* Permet de récupérer les privilégesUtilisateurs d'un utilisateur ayant comme identifiant ID */
       {
           return privilegeUtilisateurRepository.GetUtilisateurPrivilegeUtilisateur(ID);
       }

       


        [HttpGet]
        public List<PrivilegeUtilisateur> GetAllPrivilegeUtilisateur() /*Permet de retourner tous les droitsPrivilleges */
        {
            return privilegeUtilisateurRepository.GetAllPrivilegeUtilisateur();
        }

        [HttpPost]
        public HttpResponseMessage postPrivilegeUtilisateur(PrivilegeUtilisateur droitPrivilege)  /*permet d'ajouter un droitprivilege donné de la BD */
        {
            try
            {

                if (!privilegeUtilisateurRepository.InsertPrivilegeUtilisateur(droitPrivilege))
                {
                    throw new Exception("ajout de l'instance de privilegeUtilisateur non effecuté ");
                }

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
                response.StatusCode = HttpStatusCode.Created;
                String uri = Url.Link("GetPrivilegeUtilisateur", new { id = droitPrivilege.idPrivilege ,idUser=droitPrivilege.idUtilisateur});
                response.Headers.Location = new Uri(uri);

                return response;
            }
            catch (Exception e)
            {
                HttpResponseMessage response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);

                return response;
            }
        }

        [HttpDelete]
       public HttpResponseMessage DeletePrivilegeUtilisateurById(int PrivilegeID, int UtilisateurID)  /*permet de supprimer un droitprivilege donné de la BD */
       {
           try
           {

               if (!privilegeUtilisateurRepository.DeleteDroitPrivilege(PrivilegeID,UtilisateurID))
               {
                   throw new Exception("impossible de supprimer le privilegeUtilisateur dont l'IdPrivilege = " + PrivilegeID+"et IdUtilisateur="+UtilisateurID);
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