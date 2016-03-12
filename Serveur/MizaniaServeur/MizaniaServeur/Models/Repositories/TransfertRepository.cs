using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MizaniaServeur.Models.IRepositories;




namespace MizaniaServeur.Models
{
    public class TransfertRepository : ITransfertRepository
    {
        private MizaniaDbContext mizaniaDbContext  ;
        

        /* Contructeur */
        public TransfertRepository(MizaniaDbContext mizaniaDbContext){

            this.mizaniaDbContext = mizaniaDbContext ; // initialisation du dBContext
        }


        /* Requetes de selection   */

        public Transfert getTransfertById(int id)
        {
            return mizaniaDbContext.Transferts
                                   .Where(t => t.id == id).SingleOrDefault();

        }

        public List<Transfert> getAllTransferts(int idPorteFeuille)
        {

            return mizaniaDbContext.Transferts.Where(t => appartientAuPorteFeuille(t,idPorteFeuille) ).ToList();

            

        }

        public List<Transfert> getTransfertsByIdCompteExpediteur(int idCompteExpediteur)
        {
            return  mizaniaDbContext.Transferts
                                    .Where(t => t.idCompteExpediteur == idCompteExpediteur).ToList();
                                              

        }

        /* les transferts dont benificie un compte donné */
        public List<Transfert> getTransfertsByIdCompteRecepteur(int idCompteRecepteur)
        {
            return mizaniaDbContext.Transferts
                                   .Where(t => t.idCompteRecepteur == idCompteRecepteur).ToList();
                                              

        }

        /*les transfert d'un certain montant*/
        public List<Transfert> getTransfertsByMontant(int idPorteFeuille, float montant){

            return mizaniaDbContext.Transferts
                                   .Where(t => t.montant == montant &&
                                               appartientAuPorteFeuille(t,idPorteFeuille) ).ToList();
        }


        public List<Transfert> getTransfertsByMontantBetween(int idPorteFeuille, float min, float max)
        {
            return mizaniaDbContext.Transferts
                                   .Where(t => t.montant >= min &&
                                               t.montant <= max &&
                                               appartientAuPorteFeuille(t,idPorteFeuille) ).ToList();
        }

        public List<Transfert> getTransfertsByMontantBelow(int idPorteFeuille, float max)
        {
            return mizaniaDbContext.Transferts
                                   .Where(t =>  t.montant <= max &&
                                                appartientAuPorteFeuille(t,idPorteFeuille) ).ToList();
        }

        public List<Transfert> getTransfertsByMontantAbove(int idPorteFeuille, float min)
        {
            return mizaniaDbContext.Transferts
                                   .Where(t => t.montant >= min &&
                                               appartientAuPorteFeuille(t,idPorteFeuille) ).ToList();
        }

        /*les requetes liées au dates  */

        /* les transferts qui ont eu lieu à une certaine date non un date time
         * -1 pour l'un des paramettre veut dire qu'il n'est pas prise en compte dans la recherche*/
        public List<Transfert> getTransfertsByDate(int idPorteFeuille, int year, int month, int day, int hour, int minute, int seconds ){

            return mizaniaDbContext.Transferts
                                    .Where( 
                                    t=> t.dateCreation.Year == year &&
                                        (month == -1) ? true : t.dateCreation.Month == month &&
                                        (day == -1) ? true : t.dateCreation.Day == day &&
                                        (hour == -1 ) ? true : t.dateCreation.Hour == hour &&
                                        (minute == -1) ? true : t.dateCreation.Minute == minute &&
                                        (seconds == -1) ? true : t.dateCreation.Second == seconds &&
                                        appartientAuPorteFeuille(t,idPorteFeuille)
                                    ).ToList() ;
                                                                  
                                                                 
            
        }

        /*retourne les transferts à partir de la date entrée en paramettre */
        public List<Transfert> getTransfertsByDateFrom(int idPorteFeuille, DateTime date)
        {
            return mizaniaDbContext.Transferts
                                   .Where( t => t.dateCreation >= date &&
                                                appartientAuPorteFeuille(t,idPorteFeuille) ).ToList();
        }

        /*retourne les transferts qui ont été effectué à partir de la date entrée en parmettre */
        public List<Transfert> getTransfertsByDateTo(int idPorteFeuille, DateTime date)
        {
            return mizaniaDbContext.Transferts
                                   .Where(t => t.dateCreation <= date&&
                                               appartientAuPorteFeuille(t,idPorteFeuille) ).ToList();
        }

        public List<Transfert> getTransfertsByDateBetween(int idPorteFeuille, DateTime debut, DateTime fin)
        {
            return mizaniaDbContext.Transferts
                                    .Where(t => t.dateCreation >= debut &&
                                                t.dateCreation <= fin &&
                                                appartientAuPorteFeuille(t,idPorteFeuille) ).ToList();
        }

        


        /*les requetes d'insertions de données */

        public bool addTransfert(Transfert transfert){

            mizaniaDbContext.Transferts.Add(transfert);
            if (mizaniaDbContext.SaveChanges() == 1)
                return true;
            else
                return false;
        }

        /*les requetes de mise à jour*/
        
        public bool updateTransfertIdCompteExpediteur(int id, int idCompteExpediteur)
        {
            Transfert transfert = mizaniaDbContext.Transferts.Where(t => t.id == id).SingleOrDefault();
            if (transfert == null)
            {
                return false;
            }
            transfert.idCompteExpediteur = idCompteExpediteur;
            if (mizaniaDbContext.SaveChanges() == 1)
                return true;
            else
                return false;
        }

        public bool updateTransfertIdCompteRecepteur(int id, int idCompteRecepteur)
        {
            Transfert transfert = mizaniaDbContext.Transferts.Where(t => t.id == id).SingleOrDefault();
            if (transfert == null)
            {
                return false;
            }
            transfert.idCompteRecepteur = idCompteRecepteur;
            if (mizaniaDbContext.SaveChanges() == 1)
                return true;
            else
                return false;
        }
        public bool updateTransfertMontant(int id, float montant)
        {
            Transfert transfert = mizaniaDbContext.Transferts.Where(t => t.id == id).SingleOrDefault();
            if (transfert == null)
            {
                return false;
            }
            transfert.montant = montant;
            if (mizaniaDbContext.SaveChanges() == 1)
                return true;
            else
                return false;
        }

        public bool updateTransfertDesignation(int id, string designation)
        {
            Transfert transfert = mizaniaDbContext.Transferts.Where(t => t.id == id).SingleOrDefault();
            if (transfert == null)
            {
                return false;
            }
            transfert.designation = designation;
            if (mizaniaDbContext.SaveChanges() == 1)
                return true;
            else
                return false;
        }

        public bool updateTransfertDateCreation(int id, int year ,int month, int day, int hour, int minute, int second)
        {
            Transfert transfert = mizaniaDbContext.Transferts.Where(t => t.id == id).SingleOrDefault();
            if (transfert == null)
            {
                return false;
            }

            if (year != -1) transfert.dateCreation = Utilitaire.setYear(transfert.dateCreation, year);
            if (month != -1) transfert.dateCreation = Utilitaire.setMonth(transfert.dateCreation, month);
            if (day != -1) transfert.dateCreation = Utilitaire.setDay(transfert.dateCreation, day);
            if (hour != -1) transfert.dateCreation = Utilitaire.setHour(transfert.dateCreation, hour);
            if (minute != -1) transfert.dateCreation = Utilitaire.setMinute(transfert.dateCreation, minute);
            if (second != -1) transfert.dateCreation = Utilitaire.setSecond(transfert.dateCreation, second);

            if (mizaniaDbContext.SaveChanges() == 1)
                return true;
            else
                return false;
        }

        /* supprimer un transfert */

        public bool deleteTransfertById(int id)
        {
            Transfert transfert = mizaniaDbContext.Transferts
                                                  .Where(t=> t.id == id)
                                                  .SingleOrDefault();

            mizaniaDbContext.Transferts.Remove(transfert);
            if (mizaniaDbContext.SaveChanges() == 1) return true;
            return false;
        }


        /*methodes utilitaires*/

        private bool appartientAuPorteFeuille(Transfert t, int idPorteFeuille)
        {
            return t.Compte.Utilisateur.idPorteFeuille == idPorteFeuille;
        }


    }
}