using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MizaniaServeur.Models.IRepositories;

namespace MizaniaServeur.Models
{
    public class TransactionRepository : ITransactionRepository
    {

        private MizaniaDbContext mizaniaDbContext;

        public TransactionRepository()
        {
            mizaniaDbContext = new MizaniaDbContext();
        }



        /*les requetes*/

        /*les selection*/

        public Transaction getTransactionById(int id)
        {
            return mizaniaDbContext.Transactions.Where(t => t.id == id).SingleOrDefault();
        }

        /*toutes les transactions du portefeuille */
        public List<Transaction> getTransactionsByIdPorteFeuille(int idPorteFeuille)
        {
            return mizaniaDbContext.Transactions.Where(t => t.Categorie.idPorteFeuille == idPorteFeuille ).ToList();
        }

        public List<Transaction> getTransactionsByIdCompte(int idCompte)
        {
            return mizaniaDbContext.Transactions.Where(t => t.idCompte == idCompte).ToList();
        }

           // les transactions par categorie par porteFeuillle
        public List<Transaction> getTransactionsByCategorie(int idPorteFeuille,int idCategorie)
        {
            return mizaniaDbContext.Transactions.Where(t => t.idCategorie == idCategorie &&
                                                        t.Categorie.idPorteFeuille == idPorteFeuille ).ToList();
        }

        public List<Transaction> getTransactionsByMontant(int idPorteFeuille,float montant)
        {
            return mizaniaDbContext.Transactions.Where(t => t.montant == montant &&
                                                            t.Categorie.idPorteFeuille == idPorteFeuille ).ToList();
        }

        public List<Transaction> getTransactionsByDate(int idPorteFeuille ,int year, int month, int day, int hour, int minute, int second)
        {
            return mizaniaDbContext.Transactions.Where(t => t.dateCreation.Value.Year == year &&
                                                            month == -1 ? true : t.dateCreation.Value.Month == month &&
                                                            day == -1 ? true : t.dateCreation.Value.Day == day &&
                                                            hour == -1 ? true : t.dateCreation.Value.Hour == hour &&
                                                            minute == -1 ? true : t.dateCreation.Value.Minute == minute &&
                                                            second == -1 ? true : t.dateCreation.Value.Second == second &&
                                                            t.Categorie.idPorteFeuille == idPorteFeuille 
                                                        ).ToList();
        }

        public List<Transaction> getTransactionsByDesignation(int idPorteFeuille, string designation)
        {
            return mizaniaDbContext.Transactions.Where(t => t.Categorie.idPorteFeuille == idPorteFeuille &&
                                                            t.designation == designation).ToList();
        }

        public List<Transaction> getTransactionsLikeDesignation(int idPortefeuille, string designation)
        {
            return mizaniaDbContext.Transactions.Where(t => t.Categorie.idPorteFeuille == idPortefeuille &&
                                                            t.designation.Contains(designation)).ToList();
        }


        public List<Transaction> getTransactionsByType(int idPorteFeuille, string typeTransact)
        {
            return mizaniaDbContext.Transactions.Where(t => t.Categorie.idPorteFeuille == idPorteFeuille &&
                                                        t.typeTransact == typeTransact).ToList();
        }

        public List<Transaction> getTransactionsByDateBetween(int idPorteFeuille, DateTime debut, DateTime fin)
        {
            return mizaniaDbContext.Transactions.Where(t => t.Categorie.idPorteFeuille == idPorteFeuille &&
                                                            t.dateCreation.Value >= debut &&
                                                            t.dateCreation.Value <= fin).ToList();
        }

        public List<Transaction> getTransactionsByDateFrom(int idPorteFeuille, DateTime debut)
        {
            return mizaniaDbContext.Transactions.Where(t => t.Categorie.idPorteFeuille == idPorteFeuille &&
                                                            t.dateCreation.Value >= debut).ToList();

        }

        public List<Transaction> getTransactionsByDateTo(int idPorteFeuille, DateTime fin)
        {
            return mizaniaDbContext.Transactions.Where(t => t.Categorie.idPorteFeuille == idPorteFeuille &&
                                                            t.dateCreation.Value <= fin).ToList();
        }


        public List<Transaction> getTransactionsByMontantBetween(int idPortefeuille, float min, float max)
        {
            return mizaniaDbContext.Transactions.Where(t => t.Categorie.idPorteFeuille == idPortefeuille &&
                                                            t.montant >= min &&
                                                            t.montant <= max).ToList();
        }

        public List<Transaction> getTransactionsByMontantAbove(int idPorteFeuille, float min)
        {
            return mizaniaDbContext.Transactions.Where(t => t.Categorie.idPorteFeuille == idPorteFeuille &&
                                                            t.montant >= min).ToList();
        }

        public List<Transaction> getTransactionsByMontantBelow(int idPorteFeuille, float max)
        {
            return mizaniaDbContext.Transactions.Where(t => t.Categorie.idPorteFeuille == idPorteFeuille &&
                                                            t.montant <= max).ToList();
        }


        /*insertion*/

        public bool addTransaction(Transaction transaction)
        {
            mizaniaDbContext.Transactions.Add(transaction);
            if (mizaniaDbContext.SaveChanges() == 1)
                return true;
            else
                return false;
        }

        /* update */

        public bool updateTransactionDesignation(int id, string designation)
        {
            Transaction transaction = mizaniaDbContext.Transactions.Where(t => t.id == id).SingleOrDefault();
            if (transaction == null)
                return false;
            transaction.designation = designation;
            if (mizaniaDbContext.SaveChanges() == 1)
                return true;
            else
                return false;
        }

        public bool updateTransactionMontant(int id, float montant)
        {
            Transaction transaction = mizaniaDbContext.Transactions.Where( t => t.id ==id ).SingleOrDefault() ;
            if(transaction == null )
                return false;
            transaction.montant = montant ;
            if(mizaniaDbContext.SaveChanges() == 1)
                return true ;
            else
                return false ;
        }

        public bool updateTransactionDateCreation(int id, int year, int month, int day, int hour, int minute, int second)
        {
            Transaction transaction = mizaniaDbContext.Transactions.Where(t => t.id == id).SingleOrDefault();
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

        public bool updateTransactionIdCompte(int id, int idCompte)
        {
            Transaction transaction = mizaniaDbContext.Transactions.Where(t => t.id == id).SingleOrDefault();
            if (transaction == null)
                return false;
            transaction.idCompte = idCompte;
            if (mizaniaDbContext.SaveChanges() == 1)
                return true ;
            else 
                return false ;
        }

        public bool updateTransactionIdCategorie(int id, int idCategorie)
        {
            Transaction transaction = mizaniaDbContext.Transactions.Where(t => t.id == id).SingleOrDefault();
            if (transaction == null)
                return false;
            transaction.idCategorie = idCategorie;
            if (mizaniaDbContext.SaveChanges() == 1)
                return true;
            else
                return false;
        }

        public bool updateTransactionTypeTransaction(int id ,string typeTransaction)
        {
            Transaction transaction = mizaniaDbContext.Transactions.Where(t => t.id == id).SingleOrDefault();
            if (transaction == null)
                return true;
            transaction.typeTransact = typeTransaction;
            if (mizaniaDbContext.SaveChanges() == 1)
                return true;
            else
                return false;
        }

        /*suppression*/

        public bool deleteTransaction(int id)
        {
            Transaction transaction = mizaniaDbContext.Transactions.Where(t => t.id == id).SingleOrDefault();
            if (transaction == null)
                return false;
            mizaniaDbContext.Transactions.Remove(transaction);
            if (mizaniaDbContext.SaveChanges() == 1)
                return true;
            else
                return false;
        }
    }
}