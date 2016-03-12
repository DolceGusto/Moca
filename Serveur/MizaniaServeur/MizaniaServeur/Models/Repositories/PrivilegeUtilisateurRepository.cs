using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MizaniaServeur.Models
{
    public class PrivilegeUtilisateurRepository
    {

        private MizaniaDbContext mizaniaDbContext;


        /* Contructeur */
        public PrivilegeUtilisateurRepository(MizaniaDbContext mizaniaDbContext)
        {
            this.mizaniaDbContext = mizaniaDbContext;
        }

        public PrivilegeUtilisateur GetPrivilegeUtilisateur(int UtilisateurID, int PrivilegeID) /* Permet de récupérer un droitprivilege dont l'idUtilisateur=UtilisateurID et idPrivilege=PrivilegeID */
        {
            return mizaniaDbContext.PrivilegeUtilisateurs
                .Where(t => t.idUtilisateur == UtilisateurID && t.idPrivilege == PrivilegeID).SingleOrDefault(); /*Retourne une seule valeur ou une valeur par défaut */
        }

        public  List<PrivilegeUtilisateur> GetUtilisateurPrivilegeUtilisateur(int ID) /* Permet de récupérer les priviléges d'un utilisateur ayant comme identifiant ID */
        {
            return mizaniaDbContext.PrivilegeUtilisateurs
                                   .Where(t => t.idUtilisateur == ID).ToList();
            /*Retourne la liste des droitsprivileges d'un utilisateur*/
        }

     
        public List<PrivilegeUtilisateur> GetAllPrivilegeUtilisateur() /*Permet de retourner tous les droitsPrivilleges */
        {
            return mizaniaDbContext.PrivilegeUtilisateurs.ToList();
                
        }

        public bool InsertPrivilegeUtilisateur(PrivilegeUtilisateur droitPrivilege)  /*permet d'ajouter un droitprivilege donné de la BD */
        {

            mizaniaDbContext.PrivilegeUtilisateurs.Add(droitPrivilege);
            if (mizaniaDbContext.SaveChanges() == 1)
            { return true; }

            else return false;
        }

       

        public  bool DeleteDroitPrivilege(int PrivilegeID, int UtilisateurID)  /*permet de supprimer un droitprivilege donné de la BD */
        {
            var query = GetPrivilegeUtilisateur(PrivilegeID,  UtilisateurID); 
            mizaniaDbContext.PrivilegeUtilisateurs.Remove(query);
          if(mizaniaDbContext.SaveChanges()==1)
              return true;
            else return false;
        }





    }
}