using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MizaniaServeur.Models
{
    public class UserRepository
    {
        private MizaniaDbContext mizaniaDbContext;
       
        /* Contructeur */
        public UserRepository(MizaniaDbContext mizaniaDbContext)
        {

            this.mizaniaDbContext = mizaniaDbContext; // initialisation du dBContext
        }

       
        /* Rechercher un utilisateur par son identifiant */ 

         public Utilisateur getUserById(int id)
        {
            return mizaniaDbContext.Utilisateurs
                                    .Where(u => u.id==id).SingleOrDefault(); 
        }


        /* Retrourner tous les utilisateurs */ 
        public List<Utilisateur> getAllUsers()
        {
            return mizaniaDbContext.Utilisateurs.ToList(); 
        } 


        /* Retourner un utilisateur par son nom */ 
        public List<Utilisateur> getUserByNom(string nom)
        {  
            return (mizaniaDbContext.Utilisateurs
                                   .Where (u=> (u.nom).Contains(nom))).ToList(); 
        }


        /* Retourner un utilisateur par son prénom */ 
        public List<Utilisateur> getUserByPrenom(string prenom)
        {
            return (mizaniaDbContext.Utilisateurs
                                    .Where (u=> u.prenom.Contains(prenom))).ToList(); 
        }

        
        /** Ajout d'un nouvel utilisateur à la base de donnée */ 
        public bool addUser(Utilisateur utilisateur)
        {

            mizaniaDbContext.Utilisateurs.Add(utilisateur);
            if (mizaniaDbContext.SaveChanges() == 1) return true;
            return false;
        }


        /* Mise à jour des infos d'un utilisateur */ 
        public bool updateUser(Utilisateur utilisateur)
        {
            Utilisateur user = mizaniaDbContext.Utilisateurs.Where(u => u.id == utilisateur.id).SingleOrDefault();
            if (user == null)
            {
                return false;
            }
            user.id = utilisateur.id;
            user.nom = utilisateur.nom;
            user.prenom = utilisateur.prenom;
            user.nomDeCompte = utilisateur.nomDeCompte;
            user.roleUtilisateur = utilisateur.roleUtilisateur;
            user.idPorteFeuille = utilisateur.idPorteFeuille; ; 
            mizaniaDbContext.SaveChanges();

            return true;
        }


        /* Suppression d'un utilisateur de la base de données */ 
        public bool deleteUserById(int id)
        {
            Utilisateur user = mizaniaDbContext.Utilisateurs
                                                  .Where(u => u.id == id)
                                                  .SingleOrDefault();

            mizaniaDbContext.Utilisateurs.Remove(user);
            if (mizaniaDbContext.SaveChanges() == 1) return true;
            return false;
        }


        /* Retourne le portefeuille de l'utilisateur */ 
        public PorteFeuille GetPorteFeuilleUser(int id)
        {
             Utilisateur user = mizaniaDbContext.Utilisateurs
                                                  .Where(u => u.id == id)
                                                  .SingleOrDefault();
             return user.PorteFeuille; 
        }


        /* Retourner la liste des comptes que possède un utilisateur */ 
        public List<Compte> GetListeComptesUser(int id)
        {

            Utilisateur user = mizaniaDbContext.Utilisateurs
                                                  .Where(u => u.id == id)
                                                  .SingleOrDefault();

            return user.Comptes.ToList(); 
        }


        /*  Retourner tous les privilèges d'un utilisateur */ 
        public List<Privilege> GetListePrivilegesUser(int id)
        {
            List<Privilege> listePrivileges = new List<Privilege>(); 
            Utilisateur user = mizaniaDbContext.Utilisateurs
                                                   .Where(u => u.id == id)
                                                   .SingleOrDefault();
            List<PrivilegeUtilisateur> droitsPrivileges =  user.PrivilegeUtilisateurs.ToList(); 
            foreach (PrivilegeUtilisateur privilege in droitsPrivileges)
            {
                listePrivileges.Add(mizaniaDbContext.Privileges
                                                     .Where(p => p.id == privilege.idPrivilege).SingleOrDefault()); 
            }
            return listePrivileges;
        }

        /*Retourner la liste des dépenses faites par un utilisateur */ 
        public List<Transaction> GetListeDepensesUser(int id)
        {
                Utilisateur user = mizaniaDbContext.Utilisateurs
                                                  .Where(u => u.id == id)
                                                  .SingleOrDefault();

                Compte compteDepenseUser = user.Comptes
                                               .Where(c => c.designation == "depense").SingleOrDefault();

                return mizaniaDbContext.Transactions
                                        .Where(t => t.idCompte == compteDepenseUser.id).ToList(); 
        }




        
    }

         
   
}