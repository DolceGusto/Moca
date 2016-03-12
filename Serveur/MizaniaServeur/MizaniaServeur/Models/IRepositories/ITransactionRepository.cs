using System;
using System.Collections.Generic;

namespace MizaniaServeur.Models.IRepositories
{
    public interface ITransactionRepository
    {
        bool addTransaction(Transaction transaction);
        bool deleteTransaction(int id);
        Transaction getTransactionById(int id);
        List<Transaction> getTransactionsByCategorie(int idPorteFeuille, int idCategorie);
        List<Transaction> getTransactionsByDate(int idPorteFeuille, int year, int month, int day, int hour, int minute, int second);
        List<Transaction> getTransactionsByDateBetween(int idPorteFeuille, DateTime debut, DateTime fin);
        List<Transaction> getTransactionsByDateFrom(int idPorteFeuille, DateTime debut);
        List<Transaction> getTransactionsByDateTo(int idPorteFeuille, DateTime fin);
        List<Transaction> getTransactionsByDesignation(int idPorteFeuille, string designation);
        List<Transaction> getTransactionsByIdCompte(int idCompte);
        List<Transaction> getTransactionsByIdPorteFeuille(int idPorteFeuille);
        List<Transaction> getTransactionsByMontant(int idPorteFeuille, float montant);
        List<Transaction> getTransactionsByMontantAbove(int idPorteFeuille, float min);
        List<Transaction> getTransactionsByMontantBelow(int idPorteFeuille, float max);
        List<Transaction> getTransactionsByMontantBetween(int idPortefeuille, float min, float max);
        List<Transaction> getTransactionsByType(int idPorteFeuille, string typeTransact);
        List<Transaction> getTransactionsLikeDesignation(int idPortefeuille, string designation);
        bool updateTransactionDateCreation(int id, int year, int month, int day, int hour, int minute, int second);
        bool updateTransactionDesignation(int id, string designation);
        bool updateTransactionIdCategorie(int id, int idCategorie);
        bool updateTransactionIdCompte(int id, int idCompte);
        bool updateTransactionMontant(int id, float montant);
        bool updateTransactionTypeTransaction(int id, string typeTransaction);
    }
}
