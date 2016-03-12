using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MizaniaServeur.Models
{
    public class PortefeuilleRepository
    {
         private MizaniaDbContext mizaniaDbContext  ;
        

        /* Contructeur */
        public PortefeuilleRepository(MizaniaDbContext mizaniaDbContext){

            this.mizaniaDbContext = mizaniaDbContext ; // initialisation du dBContext
        }

        /*Récupérer un portefeuuille avec son id*/
        public PorteFeuille getPortefeuilleById(int id)
        {
            return mizaniaDbContext.PorteFeuilles.Where(t => t.id == id).FirstOrDefault();

        }

        /*insérer un nouveau portefeuille*/
        public bool InsertPortefeuille(PorteFeuille portefeuille)
        {

            mizaniaDbContext.PorteFeuilles.Add(portefeuille);
            if (mizaniaDbContext.SaveChanges() == 1) return true;
            return false;
        }
        /* Mettre à jour un privilège*/

        public bool updatePortefeuille(PorteFeuille portefeuille)
        {
            PorteFeuille p = mizaniaDbContext.PorteFeuilles.Where(t => t.id == portefeuille.id).SingleOrDefault();
            if (p == null)
            {
                return false;
            }
            p.id = portefeuille.id;
            p.designation = portefeuille.designation;
            p.dateCreation = portefeuille.dateCreation;

            mizaniaDbContext.SaveChanges();

            return true;
        }

        /* supprimer un portefeuille */

        public bool deletePortefeuille(int id)
        {
            PorteFeuille p = mizaniaDbContext.PorteFeuilles
                                                  .Where(t => t.id == id)
                                                  .SingleOrDefault();

            mizaniaDbContext.PorteFeuilles.Remove(p);
            if (mizaniaDbContext.SaveChanges() == 1) return true;
            return false;
        }

        /* Récupérer la liste de membres d'un portefeuille*/
        public List<Utilisateur> getUsersPortefeuille(int idPortefeuille)
        {
           PorteFeuille p=getPortefeuilleById(idPortefeuille);
            return mizaniaDbContext.Utilisateurs
                                    .Where(t => t.idPorteFeuille == idPortefeuille).ToList();
        }

        /* Récupérer la liste de membres principaux d'un portefeuille*/
        public List<Utilisateur> getPrincipalUsersPortefeuille(int idPortefeuille)
        {
            PorteFeuille p = getPortefeuilleById(idPortefeuille);
            return mizaniaDbContext.Utilisateurs
                                    .Where(t => t.idPorteFeuille == idPortefeuille && t.roleUtilisateur=="principal").ToList();
        }

        /* Récupérer la liste de membres normaux d'un portefeuille*/
        public List<Utilisateur> getNormalUsersPortefeuille(int idPortefeuille)
        {
            PorteFeuille p = getPortefeuilleById(idPortefeuille);
            return mizaniaDbContext.Utilisateurs
                                    .Where(t => t.idPorteFeuille == idPortefeuille && t.roleUtilisateur == "normal").ToList();
        }
        /* Récupérer la liste de membres normaux d'un portefeuille*/
        public Utilisateur getCreatorPortefeuille(int idPortefeuille)
        {
            PorteFeuille p = getPortefeuilleById(idPortefeuille);
            return mizaniaDbContext.Utilisateurs
                                    .Where(t => t.idPorteFeuille == idPortefeuille && t.roleUtilisateur == "creator").SingleOrDefault();
        }

    }
}