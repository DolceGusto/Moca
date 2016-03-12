using System;
using System.Collections.Generic;

namespace MizaniaServeur.Models.IRepositories
{
   public interface ITransactionPeriodiqueRepository
    {
        bool addTransactionPeriodique(TransactionPeriodique transaction);
        bool deleteTransactionPeriodique(int id);
        TransactionPeriodique getTransactionPeriodiqueById(int id);
        List<TransactionPeriodique> getTransactionPeriodiquesByCategorie(int idPorteFeuille, int idCategorie);
        List<TransactionPeriodique> getTransactionPeriodiquesByDate(int idPorteFeuille, int year, int month, int day, int hour, int minute, int second);
        List<TransactionPeriodique> getTransactionPeriodiquesByDateBetween(int idPorteFeuille, DateTime debut, DateTime fin);
        List<TransactionPeriodique> getTransactionPeriodiquesByDateFrom(int idPorteFeuille, DateTime debut);
        List<TransactionPeriodique> getTransactionPeriodiquesByDateTo(int idPorteFeuille, DateTime fin);
        List<TransactionPeriodique> getTransactionPeriodiquesByDesignation(int idPorteFeuille, string designation);
        List<TransactionPeriodique> getTransactionPeriodiquesByIdCompte(int idCompte);
        List<TransactionPeriodique> getTransactionPeriodiquesByIdPorteFeuille(int idPorteFeuille);
        List<TransactionPeriodique> getTransactionPeriodiquesByMontant(int idPorteFeuille, float montant);
        List<TransactionPeriodique> getTransactionPeriodiquesByMontantAbove(int idPorteFeuille, float min);
        List<TransactionPeriodique> getTransactionPeriodiquesByMontantBelow(int idPorteFeuille, float max);
        List<TransactionPeriodique> getTransactionPeriodiquesByMontantBetween(int idPortefeuille, float min, float max);
        List<TransactionPeriodique> getTransactionPeriodiquesByType(int idPorteFeuille, string typeTransact);
        List<TransactionPeriodique> getTransactionPeriodiquesLikeDesignation(int idPortefeuille, string designation);
        bool updateTransactionPeriodiqueDateCreation(int id, int year, int month, int day, int hour, int minute, int second);
        bool updateTransactionPeriodiqueDesignation(int id, string designation);
        bool updateTransactionPeriodiqueIdCategorie(int id, int idCategorie);
        bool updateTransactionPeriodiqueIdCompte(int id, int idCompte);
        bool updateTransactionPeriodiqueMontant(int id, float montant);
        bool updateTransactionPeriodiqueTypeTransaction(int id, string typeTransaction);
    }
}
