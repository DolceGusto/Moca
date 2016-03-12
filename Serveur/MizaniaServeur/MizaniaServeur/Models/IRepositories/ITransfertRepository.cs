using System;
using System.Collections.Generic;
using MizaniaServeur.Models;


namespace MizaniaServeur.Models.IRepositories
{
    public interface ITransfertRepository
    {
        bool addTransfert(Transfert transfert);
        bool deleteTransfertById(int id);
        List<Transfert> getAllTransferts(int idPorteFeuille );
        Transfert getTransfertById(int id);
        List<Transfert> getTransfertsByDate(int porteFeuilleId, int year, int month, int day, int hour, int minute, int seconds);
        List<Transfert> getTransfertsByDateBetween(int porteFeuilleId, DateTime debut, DateTime fin);
        List<Transfert> getTransfertsByDateFrom(int porteFeuilleId, DateTime date);
        List<Transfert> getTransfertsByDateTo(int porteFeuilleId, DateTime date);
        List<Transfert> getTransfertsByIdCompteExpediteur(int idCompteExpediteur);
        List<Transfert> getTransfertsByIdCompteRecepteur(int idCompteRecepteur);
        List<Transfert> getTransfertsByMontant(int porteFeuilleId, float montant);
        List<Transfert> getTransfertsByMontantAbove(int porteFeuilleId, float min);
        List<Transfert> getTransfertsByMontantBelow(int porteFeuilleId, float max);
        List<Transfert> getTransfertsByMontantBetween(int porteFeuilleId, float min, float max);
        bool updateTransfertDateCreation(int id, int year, int month, int day, int hour, int minute, int second);
        bool updateTransfertDesignation(int id, string designation);
        bool updateTransfertIdCompteExpediteur(int id, int idCompteExpediteur);
        bool updateTransfertIdCompteRecepteur(int id, int idCompteRecepteur);
        bool updateTransfertMontant(int id, float montant);
    }
}
