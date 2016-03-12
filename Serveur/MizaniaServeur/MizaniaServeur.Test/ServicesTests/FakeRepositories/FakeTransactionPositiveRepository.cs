using MizaniaServeur.Models.IRepositories;
using MizaniaServeur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MizaniaServeur.Test.ServicesTests.Enumeration;

namespace MizaniaServeur.Test.ServicesTests.FakeRepositories
{
    class FakeTransactionPositiveRepository : ITransactionRepository
    {
        /*les champs*/

        private List<Transaction> list;
        private Transaction transaction;

        public FakeTransactionPositiveRepository()
        {
            list = new List<Transaction>();
            list.Add(WrightInput.getSampleTransaction());
            list.Add(WrightInput.getSampleTransaction());
            transaction = WrightInput.getSampleTransaction();
        }


        public bool addTransaction(Transaction transaction)
        {
            return true;
        }

        public bool deleteTransaction(int id)
        {
            return true;
        }

        public Transaction getTransactionById(int id)
        {
            return transaction;
        }

        public List<Transaction> getTransactionsByCategorie(int idPorteFeuille, int idCategorie)
        {
            return list;
        }

        public List<Transaction> getTransactionsByDate(int idPorteFeuille, int year, int month, int day, int hour, int minute, int second)
        {
            return list;
        }

        public List<Transaction> getTransactionsByDateBetween(int idPorteFeuille, DateTime debut, DateTime fin)
        {
            return list;
        }

        public List<Transaction> getTransactionsByDateFrom(int idPorteFeuille, DateTime debut)
        {
            return list;
        }

        public List<Transaction> getTransactionsByDateTo(int idPorteFeuille, DateTime fin)
        {
            return list;
        }

        public List<Transaction> getTransactionsByDesignation(int idPorteFeuille, string designation)
        {
            return list;
        }

        public List<Transaction> getTransactionsByIdCompte(int idCompte)
        {
            return list;
        }

        public List<Transaction> getTransactionsByIdPorteFeuille(int idPorteFeuille)
        {
            return list;
        }

        public List<Transaction> getTransactionsByMontant(int idPorteFeuille, float montant)
        {
            return list; 
        }

        public List<Transaction> getTransactionsByMontantAbove(int idPorteFeuille, float min)
        {
            return list;
        }

        public List<Transaction> getTransactionsByMontantBelow(int idPorteFeuille, float max)
        {
            return list;
        }

        public List<Transaction> getTransactionsByMontantBetween(int idPortefeuille, float min, float max)
        {
            return list;
        }

        public List<Transaction> getTransactionsByType(int idPorteFeuille, string typeTransact)
        {
            return list;
        }

        public List<Transaction> getTransactionsLikeDesignation(int idPortefeuille, string designation)
        {
            return list;
        }

        public bool updateTransactionDateCreation(int id, int year, int month, int day, int hour, int minute, int second)
        {
            return true;
        }

        public bool updateTransactionDesignation(int id, string designation)
        {
            return true;
        }

        public bool updateTransactionIdCategorie(int id, int idCategorie)
        {
            return true;
        }

        public bool updateTransactionIdCompte(int id, int idCompte)
        {
            return true;
        }

        public bool updateTransactionMontant(int id, float montant)
        {
            return true;
        }

        public bool updateTransactionTypeTransaction(int id, string typeTransaction)
        {
            return true;
        }
    }
}
