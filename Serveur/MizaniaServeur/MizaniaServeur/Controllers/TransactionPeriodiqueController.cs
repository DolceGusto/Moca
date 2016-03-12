using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MizaniaServeur.Models ;
using MizaniaServeur.Models.IRepositories;

namespace MizaniaServeur.Controllers
{
    public class TransactionPeriodiqueController : ApiController
    {
       private ITransactionPeriodiqueRepository transactionPeriodiqueRepository;
      

        public TransactionPeriodiqueController()
        {
            transactionPeriodiqueRepository = new TransactionPeriodiqueRepository();
        }

        public TransactionPeriodiqueController(ITransactionPeriodiqueRepository transactionPeriodiqueRepository)
        {
            this.transactionPeriodiqueRepository = transactionPeriodiqueRepository;
        }


        /*la selection*/
        [HttpGet]
        public TransactionPeriodique getById(int id)
        {
            return transactionPeriodiqueRepository.getTransactionPeriodiqueById(id);
        }

        [HttpGet]
        public List<TransactionPeriodique> getByIdPorteFeuille(int idPorteFeuille)
        {
            return transactionPeriodiqueRepository.getTransactionPeriodiquesByIdPorteFeuille(idPorteFeuille);
        }

        [HttpGet]
        public List<TransactionPeriodique> getByIdCompte(int id)
        {
            return transactionPeriodiqueRepository.getTransactionPeriodiquesByIdCompte(id);
        }

        [HttpGet]
        public List<TransactionPeriodique> getByIdCategorie(int idPorteFeuille, int id)
        {
            return transactionPeriodiqueRepository.getTransactionPeriodiquesByCategorie(idPorteFeuille, id);
        }

        [HttpGet]
        public List<TransactionPeriodique> getByMontant(int idPorteFeuille, float montant)
        {
            return transactionPeriodiqueRepository.getTransactionPeriodiquesByMontant(idPorteFeuille, montant);
        }

        [HttpGet]
        public List<TransactionPeriodique> getByDateCreation(int idPorteFeuille, int year, int month = -1, int day = -1,
                                                   int hour = -1, int minute = -1, int second = -1)
        {
            return transactionPeriodiqueRepository.getTransactionPeriodiquesByDate(idPorteFeuille, year, month, day, hour, minute, second);
        }

        [HttpGet]
        public List<TransactionPeriodique> getLikeDesignation(int idPorteFeuille, string designation)
        {
            return transactionPeriodiqueRepository.getTransactionPeriodiquesLikeDesignation(idPorteFeuille, designation);
        }

        [HttpGet]
        public List<TransactionPeriodique> getByDesignation(int idPorteFeuille, string designation)
        {
            return transactionPeriodiqueRepository.getTransactionPeriodiquesByDesignation(idPorteFeuille, designation);
        }

        [HttpGet]
        public List<TransactionPeriodique> getByTypeTransaction(int idPorteFeuille, string typeTransaction)
        {
            return transactionPeriodiqueRepository.getTransactionPeriodiquesByType(idPorteFeuille, typeTransaction);
        }

        [HttpGet]
        public List<TransactionPeriodique> getByMontantBetween(int idPorteFeuille, float min, float max)
        {
            return transactionPeriodiqueRepository.getTransactionPeriodiquesByMontantBetween(idPorteFeuille, min, max);
        }

        [HttpGet]
        public List<TransactionPeriodique> getByMontantAbove(int idPorteFeuille, float min)
        {
            return transactionPeriodiqueRepository.getTransactionPeriodiquesByMontantAbove(idPorteFeuille, min);
        }

        [HttpGet]
        public List<TransactionPeriodique> getByMontantBelow(int idPorteFeuille, float max)
        {
            return transactionPeriodiqueRepository.getTransactionPeriodiquesByMontantBelow(idPorteFeuille, max);
        }

        [HttpGet]
        public List<TransactionPeriodique> getByDateBetween(int idPorteFeuille, int dYear, int fYear,
                                                  int dMonth = 1, int dDay = 1, int dHour = 0,
                                                  int dMinute = 0, int dSecond = 0, int fMonth = 12,
                                                  int fDay = 30, int fHour = 23, int fMinute = 59, int fSecond = 59)
        {
            DateTime debut = new DateTime(dYear, dMonth, dDay, dHour, dMinute, dSecond);
            DateTime fin = new DateTime(fYear, fMonth, fDay, fHour, fMinute, fSecond);

            return transactionPeriodiqueRepository.getTransactionPeriodiquesByDateBetween(idPorteFeuille, debut, fin);
        }

        [HttpGet]
        public List<TransactionPeriodique> getByDateCreationFrom(int idPorteFeuille, int year, int month = 1, int day = 1,
                                              int hour = 0, int minute = 0, int second = 0)
        {
            DateTime debut = new DateTime(year, month, day, hour, minute, second);

            return transactionPeriodiqueRepository.getTransactionPeriodiquesByDateFrom(idPorteFeuille, debut);
        }

        [HttpGet]
        public List<TransactionPeriodique> getByDateCreationTo(int idPorteFeuille, int year, int month = 12, int day = 30,
                                             int hour = 23, int minute = 59, int second = 59)
        {
            DateTime fin = new DateTime(year, month, day, hour, minute, second);

            return transactionPeriodiqueRepository.getTransactionPeriodiquesByDateTo(idPorteFeuille, fin);
        }


        /*insertion*/

        [HttpPost]
        public HttpResponseMessage add([FromBody]TransactionPeriodique transaction)
        {
            try
            {
                if (!transactionPeriodiqueRepository.addTransactionPeriodique(transaction))
                {
                    throw new Exception("echec de l'ajout de la transaction");
                }
                else
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
                    string uri = Url.Link("getTransactionPeriodiqueById", new { id = transaction.id });
                    response.Headers.Location = new Uri(uri);

                    return response;
                }


            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        /*update*/

        [HttpPut]
        public HttpResponseMessage updateIdCompte(int id, int idCompte)
        {
            try
            {
                if (!transactionPeriodiqueRepository.updateTransactionPeriodiqueIdCompte(id, idCompte))
                {
                    throw new Exception("echec de l'update idCompte de la transaction");
                }
                else
                {
                    TransactionPeriodique transaction = transactionPeriodiqueRepository.getTransactionPeriodiqueById(id);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, transaction);
                    string uri = Url.Link("getTransactionPeriodiqueById", new { id = transaction.id });
                    response.Headers.Location = new Uri(uri);

                    return response;
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
        [HttpPut]
        public HttpResponseMessage updateIdCategorie(int id, int idCategorie)
        {
            try
            {
                if (!transactionPeriodiqueRepository.updateTransactionPeriodiqueIdCategorie(id, idCategorie))
                {
                    throw new Exception("echec de l'update idCategorie de la transaction");
                }
                else
                {
                    TransactionPeriodique transaction = transactionPeriodiqueRepository.getTransactionPeriodiqueById(id);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, transaction);
                    string uri = Url.Link("getTransactionPeriodiqueById", new { id = transaction.id });
                    response.Headers.Location = new Uri(uri);

                    return response;
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPut]
        public HttpResponseMessage updateMontant(int id, float montant)
        {
            try
            {
                if (!transactionPeriodiqueRepository.updateTransactionPeriodiqueMontant(id, montant))
                {
                    throw new Exception("echec de l'update montant de la transaction");
                }
                else
                {
                    TransactionPeriodique transaction = transactionPeriodiqueRepository.getTransactionPeriodiqueById(id);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, transaction);
                    string uri = Url.Link("getTransactionPeriodiqueById", new { id = transaction.id });
                    response.Headers.Location = new Uri(uri);

                    return response;
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPut]
        public HttpResponseMessage updateDesignation(int id, string designation)
        {
            try
            {
                if (!transactionPeriodiqueRepository.updateTransactionPeriodiqueDesignation(id, designation))
                {
                    throw new Exception("echec de l'update designation de la transaction");
                }
                else
                {
                    TransactionPeriodique transaction = transactionPeriodiqueRepository.getTransactionPeriodiqueById(id);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, transaction);
                    string uri = Url.Link("getTransactionPeriodiqueById", new { id = transaction.id });
                    response.Headers.Location = new Uri(uri);

                    return response;
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPut]
        public HttpResponseMessage updateTypeTransaction(int id, string TypeTransaction)
        {
            try
            {
                if (!transactionPeriodiqueRepository.updateTransactionPeriodiqueTypeTransaction(id, TypeTransaction))
                {
                    throw new Exception("echec de l'update typeTransaction de la transaction");
                }
                else
                {
                    TransactionPeriodique transaction = transactionPeriodiqueRepository.getTransactionPeriodiqueById(id);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, TypeTransaction);
                    string uri = Url.Link("getTransactionPeriodiqueById", new { id = transaction.id });
                    response.Headers.Location = new Uri(uri);

                    return response;
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPut]
        public HttpResponseMessage updateDateCreation(int id, int year, int month = -1, int day = -1,
                                                      int hour = -1, int minute = -1, int second = -1)
        {
            try
            {
                if (!transactionPeriodiqueRepository.updateTransactionPeriodiqueDateCreation(id, year, month, day, hour, minute, second))
                {
                    throw new Exception("echec de l'update DateCreation de la transaction");
                }
                else
                {
                    TransactionPeriodique transaction = transactionPeriodiqueRepository.getTransactionPeriodiqueById(id);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, transaction);
                    string uri = Url.Link("getTransactionPeriodiqueById", new { id = transaction.id });
                    response.Headers.Location = new Uri(uri);

                    return response;
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpDelete]
        public HttpResponseMessage delete(int id)
        {
            try
            {
                if (!transactionPeriodiqueRepository.deleteTransactionPeriodique(id))
                {
                    throw new Exception("echec de suppression de la transaction ");
                }
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NoContent);

                return response;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }

        }
    }
}