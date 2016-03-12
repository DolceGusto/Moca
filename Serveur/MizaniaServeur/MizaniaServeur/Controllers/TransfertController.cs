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
    public class TransfertController : ApiController
    {
        /*attribut*/
        private ITransfertRepository transfertRepository;

        /*constructeur*/
        public TransfertController(ITransfertRepository transfertRepository)
        {
            this.transfertRepository = transfertRepository;
        }

        public TransfertController()
        {
            this.transfertRepository = new TransfertRepository(new MizaniaDbContext());
        }



        /*les methodes exposées aux clients */

        [HttpGet]
        public Transfert getById(int id)
        {
            return transfertRepository.getTransfertById(id);
        }

        [HttpGet]
        // retourne tout les transferts
        public List<Transfert> getAll(int idPorteFeuille )
        {
            return transfertRepository.getAllTransferts(idPorteFeuille);
        }

        [HttpGet]
        public List<Transfert> getByIdCompteExpediteur(int id)
        {
            return transfertRepository.getTransfertsByIdCompteExpediteur(id);
        }

        [HttpGet]
        public List<Transfert> getByIdCompteRecepteur(int id)
        {
            return transfertRepository.getTransfertsByIdCompteRecepteur(id);
        }

        [HttpGet]
        public List<Transfert> getByMontant(int idPorteFeuille, float montant)
        {
            return transfertRepository.getTransfertsByMontant(idPorteFeuille ,montant);
        }

        [HttpGet]
        public List<Transfert> getByMontantBelow(int idPorteFeuille, float max)
        {
            return transfertRepository.getTransfertsByMontantBelow(idPorteFeuille, max);
        }

        [HttpGet]
        public List<Transfert> getByMontantAbove(int idPorteFeuille, float min)
        {
            return transfertRepository.getTransfertsByMontantAbove(idPorteFeuille, min);
        }

        [HttpGet]
        public List<Transfert> getByMontantBetween(int idPorteFeuille, float min, float max)
        {
            return transfertRepository.getTransfertsByMontantBetween(idPorteFeuille, min, max);
        }

        /*les transferts par date (-1 est la valeur par defaut des parametres qui n'auraient pas été inclus dans L'URL)*/
        [HttpGet]
        public List<Transfert> getByDate(int idPorteFeuille, int year, int month = -1 , int day = -1 ,
                                            int hour = -1 , int minute = -1,int seconds = -1)
        {
            return transfertRepository.getTransfertsByDate(idPorteFeuille, year, month, day, hour, minute, seconds);
        }

        [HttpGet]
        public List<Transfert> getByDateBetween(   int idPorteFeuille, int dYear, int fYear, // parametres obligatoires
                                                   int dMonth = 1, int dDay = 1,
                                                   int dHour = 0, int dMinute = 0,int dSeconds = 0,
                                                   int fMonth = 12 , int fDay = 31 ,
                                                   int fHour = 23, int fMinute = 59, int fSeconds = 59)
        {
            DateTime debut = new DateTime(dYear, dMonth, dDay, dHour, dMinute, dSeconds);
            DateTime fin = new DateTime(fYear, fMonth, fDay, fHour, fMinute, fSeconds);

            return transfertRepository.getTransfertsByDateBetween(idPorteFeuille, debut, fin);
        }

        [HttpGet]
        public List<Transfert> getByDateFrom(int idPorteFeuille, int year, int month = 1, int day = 1,
                                                int hour = 0, int minute = 0, int seconds = 0)
        {
            DateTime debut = new DateTime(year, month, day, hour, minute, seconds);
            return transfertRepository.getTransfertsByDateFrom(idPorteFeuille, debut);
        }

        [HttpGet]
        public List<Transfert> getByDateTo(int idPorteFeuille, int year, int month = 12, int day = 31,
                                              int hour = 23, int minute = 59, int seconds = 59)
        {
            DateTime fin = new DateTime(year, month, day, hour, minute, seconds);
            return transfertRepository.getTransfertsByDateTo(idPorteFeuille, fin);
        }

        
        [HttpPost]
        public HttpResponseMessage add([FromBody]Transfert transfert)
        {
            
            try{
                if (!transfertRepository.addTransfert(transfert))
                {
                    throw new Exception("ajout de l'instance de transfert non effecuté ");
                }
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
                response.StatusCode = HttpStatusCode.Created;
                String uri = Url.Link("GetTransfert", new { id = transfert.id });
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
        public HttpResponseMessage updateIdCompteExpediteur(int id, int idCompteExpediteur)
        {
            try
            {
                
                if( !transfertRepository.updateTransfertIdCompteExpediteur(id,idCompteExpediteur) )
                {
                    
                    throw new Exception("update transfert échouée") ;
                }
                Transfert transfert = transfertRepository.getTransfertById(id) ;
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, transfert);
                response.StatusCode = HttpStatusCode.OK;
                String uri = Url.Link("GetTransfert", new { id = transfert.id });
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
        public HttpResponseMessage updateIdCompteRecepteur(int id, int idCompteRecepteur)
        {
            try
            {

                if (!transfertRepository.updateTransfertIdCompteRecepteur(id, idCompteRecepteur))
                {

                    throw new Exception("update transfert échouée");
                }
                Transfert transfert = transfertRepository.getTransfertById(id);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, transfert);
                response.StatusCode = HttpStatusCode.OK;
                String uri = Url.Link("GetTransfert", new { id = transfert.id });
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
        public HttpResponseMessage updateDesignation(int id, string designation )
        {
            try
            {

                if (!transfertRepository.updateTransfertDesignation(id, designation))
                {

                    throw new Exception("update transfert échouée");
                }
                Transfert transfert = transfertRepository.getTransfertById(id);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, transfert);
                response.StatusCode = HttpStatusCode.OK;
                String uri = Url.Link("GetTransfert", new { id = transfert.id });
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
        public HttpResponseMessage updateMontant(int id, float montant = -1)
        {
            try
            {

                if (!transfertRepository.updateTransfertMontant(id, montant))
                {

                    throw new Exception("update transfert échouée");
                }
                Transfert transfert = transfertRepository.getTransfertById(id);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, transfert);
                response.StatusCode = HttpStatusCode.OK;
                String uri = Url.Link("GetTransfert", new { id = transfert.id });
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
        public HttpResponseMessage updateDateCreation(int id, int year, int month =-1 , int day = -1,
                                                      int hour = -1, int minute = -1, int second = -1)
        {
            try
            {

                if (!transfertRepository.updateTransfertDateCreation(id, year, month, day, hour, minute, second))
                {

                    throw new Exception("update transfert échouée");
                }
                Transfert transfert = transfertRepository.getTransfertById(id);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, transfert);
                response.StatusCode = HttpStatusCode.OK;
                String uri = Url.Link("GetTransfert", new { id = transfert.id });
                response.Headers.Location = new Uri(uri);

                return response;


            }
            catch (Exception e)
            {
                HttpResponseMessage response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);

                return response;
            }
        }

        /*supprimer un transfert*/

        [HttpDelete]
        public HttpResponseMessage delete(int id)
        {
            try
            {
                if (!transfertRepository.deleteTransfertById(id))
                {
                    throw new Exception("impossible de supprimer le transfert de ID = "+id);
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