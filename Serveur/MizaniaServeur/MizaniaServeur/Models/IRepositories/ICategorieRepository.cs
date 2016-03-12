using System;
using MizaniaServeur.Models;
using System.Collections.Generic;

namespace MizaniaServeur.Models.IRepositories
{
    public interface ICategorieRepository
    {
        bool addCategorie(Categorie categorie);
        bool deleteCategorie(int id);
        List<Categorie> getAllCategories(int idPorteFeuillle);
        Categorie getCategorieById(int id);
        List<Categorie> getCategoriesByDescription(string description, int idPortefeuille);
        List<Categorie> getCategoriesByDesignation(string designation, int idPortefeuille);
        List<Categorie> getCategoriesByIdPortefeuille(int idPortefeuille);
        List<Categorie> getCategoriesDescriptionLike(string desciption, int idPorteFeuille);
        List<Categorie> getCategoriesDesignationLike(string designation, int idPorteFeuille);
        bool updateCategorieDescription(int id, string description);
        bool updateCategorieDesignation(int id, string designation);
    }
}
