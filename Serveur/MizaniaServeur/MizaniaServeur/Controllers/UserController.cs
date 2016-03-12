using MizaniaServeur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MizaniaServeur.Controllers
{
    public class UserController : ApiController
    {
        /*attribut*/
        private UserRepository userRepository;

        /*constructeur*/
        public UserController()
        {
            userRepository = new UserRepository(new MizaniaDbContext());
        }

        /* Les méthode exposées aux clients */



        [HttpGet] /* Retourne un seul utilisateur */ 
        public Utilisateur getUserById(int id)
        {
            return userRepository.getUserById(id);
        }

        [HttpGet] /* Retourne tous les utilisateurs */ 
        public List<Utilisateur> getAll()
        {
            return userRepository.getAllUsers();
        }

        [HttpGet] /* Retourne des urilisateurs par leurs noms */ 
        public List<Utilisateur> getUserByNom(string alpha)
        {
            return userRepository.getUserByNom(alpha);
        }

        [HttpGet] /* Retourne des urilisateurs par leurs prénoms */
        public List<Utilisateur> getUserByPrenom(string prenom)
        {
            return userRepository.getUserByPrenom(prenom);
        }

        [HttpGet]  /* Retourne le portefeuille d'un utilisateur */ 
        public PorteFeuille getUserPortefeuille(int id)
        {
            return userRepository.GetPorteFeuilleUser(id); 
        }

        [HttpGet]  /* Retourne la liste des comptes d'un utilisateur */
        public List<Compte> getUserAccounts(int id)
        {
            return userRepository.GetListeComptesUser(id); 
        }

        [HttpGet]  /* Retourne la liste des privilèges que détient un utilisateur */
        public List<Privilege> getUserPrivileges(int id)
        {
            return userRepository.GetListePrivilegesUser(id); 
        }

        [HttpGet]  /* Retourne la liste des transactions effecuees par un utilisateur */
        public List<Transaction> getUserDepenses(int id)
        {
            return userRepository.GetListeDepensesUser(id);
        }


        [HttpPost]  /*Permet d'ajouter un utilisateur */ 
        public HttpResponseMessage addUtilisateur([FromBody]Utilisateur user)
        {

            try
            {
                if (!userRepository.addUser(user))
                {
                    throw new Exception("ajout de l'instance de l'utilisateur non effecuté ");
                }
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
                response.StatusCode = HttpStatusCode.Created;
                String uri = Url.Link("GetUser", new { id = user.id });
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
        public HttpResponseMessage updateUser(Utilisateur user)
        {
            try
            {

                if (!userRepository.updateUser(user))
                {

                    throw new Exception("Mise à jour de l'utilisateur échouée");
                }
                Utilisateur utilisateur = userRepository.getUserById(user.id);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, utilisateur);
                response.StatusCode = HttpStatusCode.OK;
                String uri = Url.Link("GetUser", new { id = utilisateur.id });
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
        public HttpResponseMessage deleteUser(int id)
        {
            try
            {
                if (!userRepository.deleteUserById(id))
                {
                    throw new Exception(" Impossible de supprimer l'utilisateur dont ID = " + id);
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