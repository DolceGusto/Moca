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
    public class CompteController : ApiController
    {
        /*attribut*/
        private CompteRepository compteRepository;


        /*constructeur*/
        public CompteController()
        {
            compteRepository = new CompteRepository(new MizaniaDbContext());
        }

        //retourne le compte ayant id comme identifiant
        [HttpGet]
        public Compte getById(int id)
        {
            return compteRepository.getCompte(id);
        }

        //retourne l'utilisateur ayant le compte id
        [HttpGet]
        public Utilisateur getAccountUserById(int id)
        {
            return compteRepository.getCompte(id).Utilisateur;
        }
        //
        [HttpGet]
        public List<TransactionPeriodique> getAccountPeriodicTransactionsById(int accountID) /* Permet de retourner la liste des transactions périodiques qui s'effectuent d'un compte donné */
        {
            return compteRepository.getAccountPeriodicTransactions(accountID);
        }
        
        [HttpGet]
        public List<Transaction> getAccountTansactionsById(int accountID)  /* Permet de retourner la liste de toutes les transactions qui s'effectuent d'un compte donné */
        {
            return compteRepository.getAccountTansactions(accountID);
        }
        [HttpGet]
        public List<Transaction> getAccountTansactionsEntreesById(int accountID) /*Permet de retourner toutes les transactions de type "entree" effectuées vers un compte */
        {
            return compteRepository.getAccountTansactionsEntrees(accountID);
        }
        
        [HttpGet]
        public List<Transaction> getAccountTansactionsDepenses(int accountID) /*Permet de retourner toutes les transactions de type "depense" effectuées vers un compte */
        {
            return compteRepository.getAccountTansactionsDepenses(accountID);
        }
        [HttpGet]
        public List<Transfert> getAccountTransfertsReceptById(int accountIDRecepteur) /*Permet de récupérer les transferts dont le compte recepteur a l'idenetifiant accountIDRecepteur */
        {
            return compteRepository.getAccountTransfertsRecept(accountIDRecepteur);
        }
        [HttpGet]
        public List<Transfert> getAccountTransfertsExpediteurById(int accountIDExpediteur) /*Permet de récupérer les transferts dont le compte expéditeur a l'idenetifiant accountIDExpediteur */
        {
            return compteRepository.getAccountTransfertsExpediteur(accountIDExpediteur);
        }

        [HttpPost]
        public HttpResponseMessage postCompte(Compte compte) /*Permet d'insérer un compte dans la BD */
        {
            try
            {
                if (!compteRepository.InsertCompte(compte))
                {
                    throw new Exception("ajout de l'instance de compte non effecuté ");
                }

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
                response.StatusCode = HttpStatusCode.Created;
                String uri = Url.Link("postCompte", new { id = compte.id });
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
        public  HttpResponseMessage UpdateCompte(Compte account) /* Permet la MAJ d'un compte donné dans la BD */
        {
            try
            {
                if (!compteRepository.UpdateCompte(account))
                {
                    throw new Exception("update compte échouée");

                }
                Compte compte = compteRepository.getCompte(account.id);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, compte);
                response.StatusCode = HttpStatusCode.OK;
                String uri = Url.Link("UpdateCompte", new { id = account.id });
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
        public HttpResponseMessage delete(int id)  /*permet de supprimer un compte donné de la BD */
        {

            try
            {

                if (!compteRepository.DeleteCompte(id))
                {
                    throw new Exception("impossible de supprimer le compte de ID = " + id);
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
