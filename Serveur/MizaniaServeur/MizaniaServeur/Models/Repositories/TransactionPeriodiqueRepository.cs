using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MizaniaServeur.Models.IRepositories;

namespace MizaniaServeur.Models
{
    public class TransactionPeriodiqueRepository : ITransactionPeriodiqueRepository
    {
        /*les champs*/

        private MizaniaDbContext mizaniaDbContext;

        public TransactionPeriodiqueRepository(){
            
            this.mizaniaDbContext = new MizaniaDbContext();
        }


        /*les requetes*/

        /*selection*/

        public TransactionPeriodique getTransactionPeriodiqueById(int id)
        {
            return mizaniaDbContext.TransactionPeriodiques.Where(t => t.id == id).SingleOrDefault();
        }

        public List<TransactionPeriodique> getTransactionPeriodiquesByIdPorteFeuille(int idPorteFeuille)
        {
            return mizaniaDbContext.TransactionPeriodiques.Where(t => t.Categorie.idPorteFeuille == idPorteFeuille ).ToList();
        }

        public List<TransactionPeriodique> getTransactionPeriodiquesByIdCompte(int idCompte)
        {
            return mizaniaDbContext.TransactionPeriodiques.Where(t => t.idCompte == idCompte).ToList();
        }

           // les transactions Periodique par categorie par porteFeuillle
        public List<TransactionPeriodique> getTransactionPeriodiquesByCategorie(int idPorteFeuille,int idCategorie)
        {
            return mizaniaDbContext.TransactionPeriodiques.Where(t => t.idCategorie == idCategorie &&
                                                        t.Categorie.idPorteFeuille == idPorteFeuille ).ToList();
        }

        public List<TransactionPeriodique> getTransactionPeriodiquesByMontant(int idPorteFeuille,float montant)
        {
            return mizaniaDbContext.TransactionPeriodiques.Where(t => t.montant == montant &&
                                                            t.Categorie.idPorteFeuille == idPorteFeuille ).ToList();
        }

        public List<TransactionPeriodique> getTransactionPeriodiquesByDate(int idPorteFeuille ,int year, int month, int day, int hour, int minute, int second)
        {
            return mizaniaDbContext.TransactionPeriodiques.Where(t => t.dateCreation.Value.Year == year &&
                                                            month == -1 ? true : t.dateCreation.Value.Month == month &&
                                                            day == -1 ? true : t.dateCreation.Value.Day == day &&
                                                            hour == -1 ? true : t.dateCreation.Value.Hour == hour &&
                                                            minute == -1 ? true : t.dateCreation.Value.Minute == minute &&
                                                            second == -1 ? true : t.dateCreation.Value.Second == second &&
                                                            t.Categorie.idPorteFeuille == idPorteFeuille 
                                                        ).ToList();
        }

        public List<TransactionPeriodique> getTransactionPeriodiquesByDesignation(int idPorteFeuille, string designation)
        {
            return mizaniaDbContext.TransactionPeriodiques.Where(t => t.Categorie.idPorteFeuille == idPorteFeuille &&
                                                            t.designation == designation).ToList();
        }

        public List<TransactionPeriodique> getTransactionPeriodiquesLikeDesignation(int idPortefeuille, string designation)
        {
            return mizaniaDbContext.TransactionPeriodiques.Where(t => t.Categorie.idPorteFeuille == idPortefeuille &&
                                                            t.designation.Contains(designation)).ToList();
        }


        public List<TransactionPeriodique> getTransactionPeriodiquesByType(int idPorteFeuille, string typeTransact)
        {
            return mizaniaDbContext.TransactionPeriodiques.Where(t => t.Categorie.idPorteFeuille == idPorteFeuille &&
                                                        t.typeTransact == typeTransact).ToList();
        }

        public List<TransactionPeriodique> getTransactionPeriodiquesByDateBetween(int idPorteFeuille, DateTime debut, DateTime fin)
        {
            return mizaniaDbContext.TransactionPeriodiques.Where(t => t.Categorie.idPorteFeuille == idPorteFeuille &&
                                                            t.dateCreation.Value >= debut &&
                                                            t.dateCreation.Value <= fin).ToList();
        }

        public List<TransactionPeriodique> getTransactionPeriodiquesByDateFrom(int idPorteFeuille, DateTime debut)
        {
            return mizaniaDbContext.TransactionPeriodiques.Where(t => t.Categorie.idPorteFeuille == idPorteFeuille &&
                                                            t.dateCreation.Value >= debut).ToList();

        }

        public List<TransactionPeriodique> getTransactionPeriodiquesByDateTo(int idPorteFeuille, DateTime fin)
        {
            return mizaniaDbContext.TransactionPeriodiques.Where(t => t.Categorie.idPorteFeuille == idPorteFeuille &&
                                                            t.dateCreation.Value <= fin).ToList();
        }


        public List<TransactionPeriodique> getTransactionPeriodiquesByMontantBetween(int idPortefeuille, float min, float max)
        {
            return mizaniaDbContext.TransactionPeriodiques.Where(t => t.Categorie.idPorteFeuille == idPortefeuille &&
                                                            t.montant >= min &&
                                                            t.montant <= max).ToList();
        }

        public List<TransactionPeriodique> getTransactionPeriodiquesByMontantAbove(int idPorteFeuille, float min)
        {
            return mizaniaDbContext.TransactionPeriodiques.Where(t => t.Categorie.idPorteFeuille == idPorteFeuille &&
                                                            t.montant >= min).ToList();
        }

        public List<TransactionPeriodique> getTransactionPeriodiquesByMontantBelow(int idPorteFeuille, float max)
        {
            return mizaniaDbContext.TransactionPeriodiques.Where(t => t.Categorie.idPorteFeuille == idPorteFeuille &&
                                                            t.montant <= max).ToList();
        }


        /*insertion*/

        public bool addTransactionPeriodique(TransactionPeriodique transaction)
        {
            mizaniaDbContext.TransactionPeriodiques.Add(transaction);
            if (mizaniaDbContext.SaveChanges() == 1)
                return true;
            else
                return false;
        }

        /* update */

        public bool updateTransactionPeriodiqueDesignation(int id, string designation)
        {
            TransactionPeriodique transaction = mizaniaDbContext.TransactionPeriodiques.Where(t => t.id == id).SingleOrDefault();
            if (transaction == null)
                return false;
            transaction.designation = designation;
            if (mizaniaDbContext.SaveChanges() == 1)
                return true;
            else
                return false;
        }

        public bool updateTransactionPeriodiqueMontant(int id, float montant)
        {
            TransactionPeriodique transaction = mizaniaDbContext.TransactionPeriodiques.Where( t => t.id ==id ).SingleOrDefault() ;
            if(transaction == null )
                return false;
            transaction.montant = montant ;
            if(mizaniaDbContext.SaveChanges() == 1)
                return true ;
            else
                return false ;
        }

        public bool updateTransactionPeriodiqueDateCreation(int id, int year, int month, int day, int hour, int minute, int second)
        {
            TransactionPeriodique transaction = mizaniaDbContext.TransactionPeriodiques.Where(t => t.id == id).SingleOrDefault();
            if (transaction == null)
            {
                return false;
            }

            if (year != -1) transaction.dateCreation = Utilitaire.setYear(transaction.dateCreation.Value, year);
            if (month != -1) transaction.dateCreation = Utilitaire.setMonth(transaction.dateCreation.Value, month);
            if (day != -1) transaction.dateCreation = Utilitaire.setDay(transaction.dateCreation.Value, day);
            if (hour != -1) transaction.dateCreation = Utilitaire.setHour(transaction.dateCreation.Value, hour);
            if (minute != -1) transaction.dateCreation = Utilitaire.setMinute(transaction.dateCreation.Value, minute);
            if (second != -1) transaction.dateCreation = Utilitaire.setSecond(transaction.dateCreation.Value, second);

            if (mizaniaDbContext.SaveChanges() == 1)
                return true;
            else
                return false;
        }

        public bool updateTransactionPeriodiqueIdCompte(int id, int idCompte)
        {
            TransactionPeriodique transaction = mizaniaDbContext.TransactionPeriodiques.Where(t => t.id == id).SingleOrDefault();
            if (transaction == null)
                return false;
            transaction.idCompte = idCompte;
            if (mizaniaDbContext.SaveChanges() == 1)
                return true ;
            else 
                return false ;
        }

        public bool updateTransactionPeriodiqueIdCategorie(int id, int idCategorie)
        {
            TransactionPeriodique transaction = mizaniaDbContext.TransactionPeriodiques.Where(t => t.id == id).SingleOrDefault();
            if (transaction == null)
                return false;
            transaction.idCategorie = idCategorie;
            if (mizaniaDbContext.SaveChanges() == 1)
                return true;
            else
                return false;
        }

        public bool updateTransactionPeriodiqueTypeTransaction(int id ,string typeTransaction)
        {
            TransactionPeriodique transaction = mizaniaDbContext.TransactionPeriodiques.Where(t => t.id == id).SingleOrDefault();
            if (transaction == null)
                return true;
            transaction.typeTransact = typeTransaction;
            if (mizaniaDbContext.SaveChanges() == 1)
                return true;
            else
                return false;
        }

        /*suppression*/

        public bool deleteTransactionPeriodique(int id)
        {
            TransactionPeriodique transaction = mizaniaDbContext.TransactionPeriodiques.Where(t => t.id == id).SingleOrDefault();
            if (transaction == null)
                return false;
            mizaniaDbContext.TransactionPeriodiques.Remove(transaction);
            if (mizaniaDbContext.SaveChanges() == 1)
                return true;
            else
                return false;
        }
    }

}
