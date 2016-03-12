using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MizaniaServeur.Models;
using MizaniaServeur.Models.IRepositories;

namespace MizaniaServeur.Controllers
{
    public class TransactionController : ApiController
    {
        /*les champs*/

        private ITransactionRepository transactionRepository;
        

        public TransactionController()
        {
            transactionRepository = new TransactionRepository();
        }

        public TransactionController(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }

        /*les requetes*/

        /*la selection*/
        [HttpGet]
        public Transaction getById(int id)
        {
            return transactionRepository.getTransactionById(id);
        }

        [HttpGet]
        public List<Transaction> getByIdPorteFeuille(int idPorteFeuille)
        {
            return transactionRepository.getTransactionsByIdPorteFeuille(idPorteFeuille);
        }

        [HttpGet]
        public List<Transaction> getByIdCompte(int id)
        {
            return transactionRepository.getTransactionsByIdCompte(id);
        }

        [HttpGet]
        public List<Transaction> getByIdCategorie(int idPorteFeuille, int id)
        {
            return transactionRepository.getTransactionsByCategorie(idPorteFeuille, id);
        }

        [HttpGet]
        public List<Transaction> getByMontant(int idPorteFeuille, float montant)
        {
            return transactionRepository.getTransactionsByMontant(idPorteFeuille, montant);
        }

        [HttpGet]
        public List<Transaction> getByDateCreation(int idPorteFeuille, int year, int month = -1, int day = -1,
                                                   int hour = -1, int minute = -1, int second = -1)
        {
            return transactionRepository.getTransactionsByDate(idPorteFeuille, year, month, day, hour, minute, second);
        }

        [HttpGet]
        public List<Transaction> getLikeDesignation(int idPorteFeuille, string designation)
        {
            return transactionRepository.getTransactionsLikeDesignation(idPorteFeuille, designation);
        }

        [HttpGet]
        public List<Transaction> getByDesignation(int idPorteFeuille, string designation)
        {
            return transactionRepository.getTransactionsByDesignation(idPorteFeuille, designation);
        }

        [HttpGet]
        public List<Transaction> getByTypeTransaction(int idPorteFeuille, string typeTransaction)
        {
            return transactionRepository.getTransactionsByType(idPorteFeuille, typeTransaction);
        }

        [HttpGet]
        public List<Transaction> getByMontantBetween(int idPorteFeuille, float min, float max)
        {
            return transactionRepository.getTransactionsByMontantBetween(idPorteFeuille, min, max);
        }

        [HttpGet]
        public List<Transaction> getByMontantAbove(int idPorteFeuille, float min)
        {
            return transactionRepository.getTransactionsByMontantAbove(idPorteFeuille, min);
        }

        [HttpGet]
        public List<Transaction> getByMontantBelow(int idPorteFeuille, float max)
        {
            return transactionRepository.getTransactionsByMontantBelow(idPorteFeuille, max);
        }

        [HttpGet]
        public List<Transaction> getByDateBetween(int idPorteFeuille, int dYear, int fYear,
                                                  int dMonth = 1, int dDay = 1, int dHour = 0,
                                                  int dMinute = 0, int dSecond = 0, int fMonth = 12,
                                                  int fDay = 30, int fHour = 23,int fMinute = 59, int fSecond = 59)
        {
            DateTime debut = new DateTime(dYear, dMonth, dDay, dHour, dMinute, dSecond);
            DateTime fin = new DateTime(fYear, fMonth, fDay, fHour, fMinute, fSecond);

            return transactionRepository.getTransactionsByDateBetween(idPorteFeuille, debut, fin);
        }

        [HttpGet]
        public List<Transaction> getByDateCreationFrom(int idPorteFeuille, int year, int month = 1, int day = 1,
                                              int hour = 0 , int minute = 0 , int second = 0)
        {
            DateTime debut = new DateTime(year, month, day, hour, minute, second);

            return transactionRepository.getTransactionsByDateFrom(idPorteFeuille, debut);
        }

        [HttpGet]
        public List<Transaction> getByDateCreationTo(int idPorteFeuille, int year, int month = 12, int day = 30,
                                             int hour = 23, int minute = 59, int second = 59)
        {
            DateTime fin = new DateTime(year, month, day, hour, minute, second);

            return transactionRepository.getTransactionsByDateTo(idPorteFeuille, fin);
        }


        /*insertion*/

        [HttpPost]
        public HttpResponseMessage add([FromBody]Transaction transaction)
        {
            try
            {
                if (!transactionRepository.addTransaction(transaction))
                {
                    throw new Exception("echec de l'ajout de la transaction");
                }
                else
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
                    string uri = Url.Link("getTransactionById", new { id = transaction.id });
                    response.Headers.Location = new Uri(uri) ;

                    return response ;
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
                if (!transactionRepository.updateTransactionIdCompte(id, idCompte))
                {
                    throw new Exception("echec de l'update idCompte de la transaction");
                }
                else
                {
                    Transaction transaction = transactionRepository.getTransactionById(id) ;
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, transaction);
                    string uri = Url.Link("getTransactionById", new { id = transaction.id });
                    response.Headers.Location = new Uri(uri);

                    return response ;
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
                if (!transactionRepository.updateTransactionIdCategorie(id, idCategorie))
                {
                    throw new Exception("echec de l'update idCategorie de la transaction");
                }
                else
                {
                    Transaction transaction = transactionRepository.getTransactionById(id) ;
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, transaction);
                    string uri = Url.Link("getTransactionById", new { id = transaction.id });
                    response.Headers.Location = new Uri(uri);

                    return response ;
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
                if (!transactionRepository.updateTransactionMontant(id, montant))
                {
                    throw new Exception("echec de l'update montant de la transaction");
                }
                else
                {
                    Transaction transaction = transactionRepository.getTransactionById(id) ;
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, transaction);
                    string uri = Url.Link("getTransactionById", new { id = transaction.id });
                    response.Headers.Location = new Uri(uri);

                    return response ;
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
                if (!transactionRepository.updateTransactionDesignation(id, designation))
                {
                    throw new Exception("echec de l'update designation de la transaction");
                }
                else
                {
                    Transaction transaction = transactionRepository.getTransactionById(id) ;
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, transaction);
                    string uri = Url.Link("getTransactionById", new { id = transaction.id });
                    response.Headers.Location = new Uri(uri);

                    return response ;
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
                if (!transactionRepository.updateTransactionTypeTransaction(id, TypeTransaction))
                {
                    throw new Exception("echec de l'update typeTransaction de la transaction");
                }
                else
                {
                    Transaction transaction = transactionRepository.getTransactionById(id) ;
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, TypeTransaction);
                    string uri = Url.Link("getTransactionById", new { id = transaction.id });
                    response.Headers.Location = new Uri(uri);

                    return response ;
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPut]
        public HttpResponseMessage updateDateCreation(int id, int year , int month = -1 , int day = -1,
                                                      int hour = -1, int minute = -1 , int second = -1)
        {
            try
            {
                if ( ! transactionRepository.updateTransactionDateCreation(id,year,month,day,hour,minute,second))
                {
                    throw new Exception("echec de l'update DateCreation de la transaction");
                }
                else
                {
                    Transaction transaction = transactionRepository.getTransactionById(id) ;
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, transaction);
                    string uri = Url.Link("getTransactionById", new { id = transaction.id });
                    response.Headers.Location = new Uri(uri);

                    return response ;
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
                if (!transactionRepository.deleteTransaction(id))
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