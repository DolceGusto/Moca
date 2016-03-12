using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MizaniaServeur.Models.IRepositories;

namespace MizaniaServeur.Models
{
    




    public class CategorieRepository : ICategorieRepository
    {

        /* les Champs*/

        private MizaniaDbContext mizaniaDbContext;

        public CategorieRepository(MizaniaDbContext dbContext){
            this.mizaniaDbContext = dbContext;
        }

        /*les requetes*/


        /*selection*/

        public Categorie getCategorieById(int id)
        {
            return mizaniaDbContext.Categories.Where(c => c.id == id ).SingleOrDefault() ;
        }

        public List<Categorie> getAllCategories(int idPorteFeuille)
        {
            return mizaniaDbContext.Categories.Where(c => c.idPorteFeuille ==idPorteFeuille).ToList();
        }

            //les categories d'un portefeuille donné 

        public List<Categorie> getCategoriesByIdPortefeuille(int idPortefeuille)
        {
            return mizaniaDbContext.Categories.Where(c => c.idPorteFeuille == idPortefeuille).ToList();
        }

        public List<Categorie> getCategoriesByDesignation(string designation ,int idPortefeuille)
        {
            return mizaniaDbContext.Categories.Where(c => c.designation == designation
                                                          && c.idPorteFeuille == idPortefeuille ).ToList();
        }

        public List<Categorie> getCategoriesByDescription(string description, int idPortefeuille)
        {
            return mizaniaDbContext.Categories.Where(c => c.descript == description
                                                          && c.idPorteFeuille == idPortefeuille ).ToList();
        }

           // les categorie qui ont comme designation %designation% avec % qui peut être remplacé par une chaine quelconque

        public List<Categorie> getCategoriesDescriptionLike(string desciption, int idPorteFeuille)
        {
            return mizaniaDbContext.Categories.Where(c => c.descript.Contains(desciption)
                                                          && c.idPorteFeuille == idPorteFeuille ).ToList();
        }

        public List<Categorie> getCategoriesDesignationLike(string designation, int idPorteFeuille)
        {
            return mizaniaDbContext.Categories.Where(c => c.designation.Contains(designation)
                                                          && c.idPorteFeuille == idPorteFeuille).ToList();
        }
        
        /*insertion*/

        public bool addCategorie(Categorie categorie)
        {
            mizaniaDbContext.Categories.Add(categorie);
            if (mizaniaDbContext.SaveChanges() == 1)
                return true;
            else
                return false;
        }


        /*mise à jour*/

        public bool updateCategorieDesignation(int id, string designation)
        {
            Categorie categorie = mizaniaDbContext.Categories.Where(c => c.id == id).FirstOrDefault();
            if (categorie == null) 
                return false;
            
            categorie.designation = designation;
            if (mizaniaDbContext.SaveChanges() == 1)
                return true;
            else
                return false;
            
            
        }

        public bool updateCategorieDescription(int id, string description)
        {
            Categorie categorie = mizaniaDbContext.Categories.Where(c => c.id == id).FirstOrDefault();
            if (categorie == null)
                return false;

            categorie.descript = description;
            if(mizaniaDbContext.SaveChanges() == 1)
                return true;
            else
                return false ;
            
        }


        /*delete*/

        public bool deleteCategorie(int id)
        {
            Categorie categorie = mizaniaDbContext.Categories.Where(c => c.id == id).FirstOrDefault();
            if (categorie == null)
                return false;
            mizaniaDbContext.Categories.Remove(categorie);
            if (mizaniaDbContext.SaveChanges() == 1)
                return true;
            else
                return false;
        }


    }
}