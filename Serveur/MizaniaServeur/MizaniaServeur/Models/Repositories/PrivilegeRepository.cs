using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace MizaniaServeur.Models
{
    public class PrivilegeRepository
    {
        private MizaniaDbContext mizaniaDbContext  ;
        

        /* Contructeur */
        public PrivilegeRepository(MizaniaDbContext mizaniaDbContext){

            this.mizaniaDbContext = mizaniaDbContext ; // initialisation du dBContext
        }



        /* Requetes de selection   */

        public Privilege getPrivilegeById(int id)
        {
            return mizaniaDbContext.Privileges.Where(t => t.id == id).FirstOrDefault();

        }
        public List<Privilege> getAllPrivileges()
        {

            return mizaniaDbContext.Privileges.ToList();

         }

        /* insérer un nouveau privilège*/
      
        public bool InsertPrivilege(Privilege privilege)
        {

            mizaniaDbContext.Privileges.Add(privilege);
            if (mizaniaDbContext.SaveChanges() == 1) return true;
            return false;
        }

        /* Mettre à jour un privilège*/

        public bool updatePrivilege(Privilege privilege)
        {
            Privilege p = mizaniaDbContext.Privileges.Where(t => t.id == privilege.id).SingleOrDefault();
            if (p == null)
            {
                return false;
            }
            p.id = privilege.id;
            p.designation = privilege.designation;
           
            mizaniaDbContext.SaveChanges();

            return true;
        }
        /* supprimer un privilège */

        public bool deletePrivilege(int id)
        {
            Privilege p = mizaniaDbContext.Privileges
                                                  .Where(t => t.id == id)
                                                  .SingleOrDefault();

            mizaniaDbContext.Privileges.Remove(p);
            if (mizaniaDbContext.SaveChanges() == 1) return true;
            return false;
        }





    }
}