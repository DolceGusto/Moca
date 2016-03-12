using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MizaniaServeur.Models
{
    public class CompteRepository
    {
        private MizaniaDbContext mizaniaDbContext;


        /* Contructeur */
        public CompteRepository(MizaniaDbContext mizaniaDbContext)
        {
            this.mizaniaDbContext = mizaniaDbContext;
        }


        public  Compte getCompte(int CompteID) /* Permet de récupérer un compte d'un identifiant CompteID */
        {
            return mizaniaDbContext.Comptes
                                   .Where(t => t.id == CompteID).SingleOrDefault();
            /*Retourne une seule valeur ou une valeur par défaut */
        }

        public Utilisateur getUserAccount(int accountID) /* Permet de retourner l'utilisateur d'un compte donné */
        {
            return getCompte(accountID).Utilisateur;
        }

        public List<TransactionPeriodique> getAccountPeriodicTransactions(int accountID) /* Permet de retourner la liste des transactions périodiques qui s'effectuent d'un compte donné */
        {
            return getCompte(accountID).TransactionPeriodiques.ToList();
        }

        public List<Transaction> getAccountTansactions(int accountID)  /* Permet de retourner la liste de toutes les transactions qui s'effectuent d'un compte donné */
        {
            return getCompte(accountID).Transactions.ToList();
        }

        public List<Transaction> getAccountTansactionsEntrees(int accountID) /*Permet de retourner toutes les transactions de type "entree" effectuées vers un compte */
        {
            var transacs = getAccountTansactions(accountID);
            var query = transacs.Where(t => t.typeTransact == "entree");
            return query.ToList();
        }

        public List<Transaction> getAccountTansactionsDepenses(int accountID) /*Permet de retourner toutes les transactions de type "depense" effectuées vers un compte */
        {
            var transacs = getAccountTansactions(accountID);
            var query = transacs.Where(t => t.typeTransact == "depense");
            return query.ToList();
        }

        public List<Transfert> getAccountTransfertsRecept(int accountIDRecepteur) /*Permet de récupérer les transferts dont le compte recepteur a l'idenetifiant accountIDRecepteur */
        {
            var transferts = getCompte(accountIDRecepteur).Transferts;
            var query = transferts
                .Where(t => t.idCompteRecepteur == accountIDRecepteur);
            return query.ToList();
           
        }

        public List<Transfert> getAccountTransfertsExpediteur(int accountIDExpediteur) /*Permet de récupérer les transferts dont le compte expéditeur a l'idenetifiant accountIDExpediteur */
        {
            var transferts = getCompte(accountIDExpediteur).Transferts;
            var query = transferts.Where(t => t.idCompteExpediteur == accountIDExpediteur);
            return query.ToList();
        }


        public bool InsertCompte(Compte compte) /*Permet d'insérer un compte dans la BD */
        {
            mizaniaDbContext.Comptes.Add(compte);
            if (mizaniaDbContext.SaveChanges() == 1)
            { return true; }

            else return false;
        }

        public  bool UpdateCompte(Compte account) /* Permet la MAJ d'un compte donné dans la BD */
        {
            var query = getCompte(account.id);
            query.id = account.id;
            query.idUtilisateur = account.idUtilisateur;
            query.solde = account.solde;
            query.designation = account.designation;
            query.descript = account.descript;

            if (mizaniaDbContext.SaveChanges() == 1)
            {
                return true;
            }
            else return false;
        }

        public  bool DeleteCompte(int accountID)  /*permet de supprimer un compte donné de la BD */
        {
            var query = getCompte(accountID);
            mizaniaDbContext.Comptes.Remove(query);
          if(  mizaniaDbContext.SaveChanges()==1)
          { return true; }
            else 
          {
              return false;
          }
        }

      


       
    }
}