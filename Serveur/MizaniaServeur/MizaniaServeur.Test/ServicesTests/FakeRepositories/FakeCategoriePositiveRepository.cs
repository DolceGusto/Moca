using MizaniaServeur.Models;
using MizaniaServeur.Models.IRepositories;
using MizaniaServeur.Test.ServicesTests.Enumeration;
using System.Collections.Generic;

namespace MizaniaServeur.Test.ServicesTests.FakeRepositories
{
    class FakeCategoriePositiveRepository : ICategorieRepository
    {

        /*les champs*/

        private List<Categorie> list;
        private Categorie categorie;

        public FakeCategoriePositiveRepository()
        {
            list = new List<Categorie>();
            list.Add(WrightInput.getSampleCategorie());
            list.Add(WrightInput.getSampleCategorie());
            categorie = WrightInput.getSampleCategorie();

        }


        public bool addCategorie(Categorie categorie)
        {
            return true;
        }

        public bool deleteCategorie(int id)
        {
            return true;
        }

        public List<Categorie> getAllCategories(int idPorteFeuille)
        {
            return list;
        }

        public Categorie getCategorieById(int id)
        {
            return categorie;
        }

        public List<Categorie> getCategoriesByDescription(string description, int idPortefeuille)
        {
            return list;
        }

        public List<Categorie> getCategoriesByDesignation(string designation, int idPortefeuille)
        {
            return list;
        }

        public List<Categorie> getCategoriesByIdPortefeuille(int idPortefeuille)
        {
            return list;
        }

        public List<Categorie> getCategoriesDescriptionLike(string desciption, int idPorteFeuille)
        {
            return list;
        }

        public List<Categorie> getCategoriesDesignationLike(string designation, int idPorteFeuille)
        {
            return list;
        }

        public bool updateCategorieDescription(int id, string description)
        {
            return true;
        }

        public bool updateCategorieDesignation(int id, string designation)
        {
            return true;
        }
    }
}
