using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MizaniaServeur.Models;
using MizaniaServeur.Models.IRepositories;
using MizaniaServeur.Test.ServicesTests.Enumeration;


namespace MizaniaServeur.Test.ServicesTests.FakeRepositories
{
    class FakeTransactionPeriodiquePositiveRepository : ITransactionPeriodiqueRepository
    {
        private List<TransactionPeriodique> list;
        private TransactionPeriodique transactionPeriodique;

        public FakeTransactionPeriodiquePositiveRepository()
        {
            list = new List<TransactionPeriodique>();
            list.Add(WrightInput.getSampleTransactionPeriodique());
            list.Add(WrightInput.getSampleTransactionPeriodique());
            transactionPeriodique = WrightInput.getSampleTransactionPeriodique();
        }

        public bool addTransactionPeriodique(TransactionPeriodique transaction)
        {
            return true;
        }

        public bool deleteTransactionPeriodique(int id)
        {
            return true;
        }

        public TransactionPeriodique getTransactionPeriodiqueById(int id)
        {
            return transactionPeriodique;
        }

        public List<TransactionPeriodique> getTransactionPeriodiquesByCategorie(int idPorteFeuille, int idCategorie)
        {
            return list;
        }

        public List<TransactionPeriodique> getTransactionPeriodiquesByDate(int idPorteFeuille, int year, int month, int day, int hour, int minute, int second)
        {
            return list;
        }

        public List<TransactionPeriodique> getTransactionPeriodiquesByDateBetween(int idPorteFeuille, DateTime debut, DateTime fin)
        {
            return list;
        }

        public List<TransactionPeriodique> getTransactionPeriodiquesByDateFrom(int idPorteFeuille, DateTime debut)
        {
            return list;
        }

        public List<TransactionPeriodique> getTransactionPeriodiquesByDateTo(int idPorteFeuille, DateTime fin)
        {
            return list;
        }

        public List<TransactionPeriodique> getTransactionPeriodiquesByDesignation(int idPorteFeuille, string designation)
        {
            return list;
        }

        public List<TransactionPeriodique> getTransactionPeriodiquesByIdCompte(int idCompte)
        {
            return list;
        }

        public List<TransactionPeriodique> getTransactionPeriodiquesByIdPorteFeuille(int idPorteFeuille)
        {
            return list;
        }

        public List<TransactionPeriodique> getTransactionPeriodiquesByMontant(int idPorteFeuille, float montant)
        {
            return list;
        }

        public List<TransactionPeriodique> getTransactionPeriodiquesByMontantAbove(int idPorteFeuille, float min)
        {
            return list;
        }

        public List<TransactionPeriodique> getTransactionPeriodiquesByMontantBelow(int idPorteFeuille, float max)
        {
            return list;
        }

        public List<TransactionPeriodique> getTransactionPeriodiquesByMontantBetween(int idPortefeuille, float min, float max)
        {
            return list;
        }

        public List<TransactionPeriodique> getTransactionPeriodiquesByType(int idPorteFeuille, string typeTransact)
        {
            return list;
        }

        public List<TransactionPeriodique> getTransactionPeriodiquesLikeDesignation(int idPortefeuille, string designation)
        {
            return list;
        }

        public bool updateTransactionPeriodiqueDateCreation(int id, int year, int month, int day, int hour, int minute, int second)
        {
            return true;
        }

        public bool updateTransactionPeriodiqueDesignation(int id, string designation)
        {
            return true;
        }

        public bool updateTransactionPeriodiqueIdCategorie(int id, int idCategorie)
        {
            return true;
        }

        public bool updateTransactionPeriodiqueIdCompte(int id, int idCompte)
        {
            return true;
        }

        public bool updateTransactionPeriodiqueMontant(int id, float montant)
        {
            return true;
        }

        public bool updateTransactionPeriodiqueTypeTransaction(int id, string typeTransaction)
        {
            return true;
        }
    }
}
