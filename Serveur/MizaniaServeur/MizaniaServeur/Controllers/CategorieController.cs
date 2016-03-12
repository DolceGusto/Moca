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
    public class CategorieController : ApiController
    {
        private ICategorieRepository categorieRepository;
       

        public CategorieController()
        {
            // --TODO mettre le context en singleton
            categorieRepository = new CategorieRepository(new MizaniaDbContext());

        }

        public CategorieController(ICategorieRepository categorieRepository)
        {
            this.categorieRepository = categorieRepository;
        }

        /*l'interface exposée au client*/

        [HttpGet]
        public Categorie getById(int id)
        {
            return categorieRepository.getCategorieById(id);
        }

        [HttpGet]

        public List<Categorie> getAll(int idPorteFeuille)
        {
            return categorieRepository.getAllCategories(idPorteFeuille);
        }
        
        [HttpGet]
        public List<Categorie> getByIdPorteFeuille(int id)
        {
            return categorieRepository.getCategoriesByIdPortefeuille(id);
        }

        [HttpGet]
        public List<Categorie> getByDesignation(string designation, int idPorteFeuille)
        {
            return categorieRepository.getCategoriesByDesignation(designation,idPorteFeuille);
        }
        
        [HttpGet]
        public List<Categorie> getByDescription(string description, int idPorteFeuille)
        {
            return categorieRepository.getCategoriesByDescription(description, idPorteFeuille);
        }

        [HttpGet]
        public List<Categorie> getLikeDescription(string description, int idPorteFeuille)
        {
            return categorieRepository.getCategoriesDescriptionLike(description, idPorteFeuille);
        }

        [HttpGet]
        public List<Categorie> getLikeDesignation(string designation, int idPorteFeuille)
        {
            return categorieRepository.getCategoriesDesignationLike(designation,idPorteFeuille);
        }

        [HttpPost]
        public HttpResponseMessage add([FromBody]Categorie categorie)
        {
            try
            {
                if (!categorieRepository.addCategorie(categorie))
                {
                    throw new Exception("echec lors de l'ajout de la categorie ");

                }
                else
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
                    string uri = Url.Link("getCategorieById", new { id = categorie.id });
                    response.Headers.Location = new Uri(uri) ;

                    return response ;
                    
                }

            }
            catch(Exception e)
            {
                HttpResponseMessage response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
                return response;

            }
        }

        [HttpPut]
        public HttpResponseMessage updateDesignation(int id, string designation)
        {
            try
            {
                if (!categorieRepository.updateCategorieDesignation(id,designation))
                {
                    throw new Exception("echec de update de la designation de la categorie");
                }
                else
                {
                    Categorie categorie = categorieRepository.getCategorieById(id) ;
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, categorie);
                    string uri = Url.Link("getCategorieById", new { id = categorie.id });
                    response.Headers.Location = new Uri(uri) ;

                    return response ;
                }
            }
            catch (Exception e)
            {
                HttpResponseMessage response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);

                return response;
            }
        }

        [HttpPut]
        public HttpResponseMessage updateDescription(int id, string description)
        {
            try
            {
                if (!categorieRepository.updateCategorieDescription(id,description))
                {
                    throw new Exception("echec de update de la description de la categorie");

                }
                else
                {
                    Categorie categorie = categorieRepository.getCategorieById(id) ;
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, categorie);
                    string uri = Url.Link("getCategorieById",new {id = categorie.id });
                    response.Headers.Location = new Uri(uri) ;

                    return response ;
                }
            }
            catch (Exception e)
            {
                HttpResponseMessage response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);

                return response;
            }
        }

        [HttpDelete]
        public HttpResponseMessage delete(int id)
        {
            try
            {
                if (!categorieRepository.deleteCategorie(id))
                {
                    throw new Exception("echec delete categorie id = " + id);
                }
                else
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NoContent);

                    return response;
                }
            }
            catch(Exception e)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.InternalServerError,e);

                return response;
            }
        }

    }
}