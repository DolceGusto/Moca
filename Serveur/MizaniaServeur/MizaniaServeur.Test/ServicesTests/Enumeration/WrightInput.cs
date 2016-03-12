using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MizaniaServeur.Models;

namespace MizaniaServeur.Test.ServicesTests.Enumeration
{

    /* cette class represente les données attendue par l'api 
     * les données qui vont être introduites au niveau des Urls de l'api
     */

    class WrightInput
    {
        public static readonly string id = "1";
        public static readonly string foreignId = "2";
        public static readonly string year = "2017";
        public static readonly string month = "9";
        public static readonly string day = "1";
        public static readonly string hour = "12";
        public static readonly string minute = "30";
        public static readonly string second = "30";
        public static readonly string designation = "une designation 00";
        public static readonly string description = "une description 11";
        public static readonly string date = DateTime.Today.ToString();
        public static readonly string montant = "9.99";
        public static readonly string frequence = "33";
        public static readonly string typeTransactEntree = "entree";
        public static readonly string typeTransactDepense = "depense";

        // des valeurs qui represent leurs type ;
        public static readonly string theInt = "0";
        public static readonly string theFloat = "3.14";
        public static readonly string theString = "Bazinga";

        // methodes qui retournent un exemple de chaque entite

        public static Transfert getSampleTransfert()
        {
            return new Transfert
            {
                id = 1,
                idCompteRecepteur = 2,
                idCompteExpediteur = 3,
                designation = "une designation",
                dateCreation = DateTime.Today,
                montant = 9.99F,
            };
        }

        public static Transaction getSampleTransaction(){

            return new Transaction
            {
                id = 1,
                dateCreation = DateTime.Today,
                designation = "une transaction",
                idCategorie = 1,
                idCompte = 2,
                montant = 3.14F,
                typeTransact = "depense"
            };
        }

        public static TransactionPeriodique getSampleTransactionPeriodique(){

           return  new TransactionPeriodique
            {
                id = 1,
                dateCreation = DateTime.Today,
                designation = "une transaction periodique",
                idCategorie = 1,
                idCompte = 2,
                montant = 3.14F,
                frequence = 2,
                typeTransact = "depense"
            };
        }

        public static Categorie getSampleCategorie(){

            return new Categorie
            {
                id = 1,
                idPorteFeuille = 1,
                descript = "une description",
                designation = "une designation"
            };
        }

        public static HashSet<KeyValuePair<string, string>> getSampleTranfertAsKeyValuePair()
        {
            return new HashSet<KeyValuePair<string, string>>{
                new KeyValuePair<string,string>("id",id),
                new KeyValuePair<string,string>("idCompteRecepteur",foreignId),
                new KeyValuePair<string,string>("idCompteExpediteur",foreignId),
                new KeyValuePair<string,string>("designation", designation),
                new KeyValuePair<string,string>("dateCreation",date),
                new KeyValuePair<string,string>("montant",montant)
            };
        }

        public static HashSet<KeyValuePair<string, string>> getSampleCategorieAsKeyValuePair()
        {
            return new HashSet<KeyValuePair<string, string>>{
                new KeyValuePair<string,string>("id",id),
                new KeyValuePair<string,string>("idPorteFeuille",foreignId),
                new KeyValuePair<string,string>("designation",designation),
                new KeyValuePair<string,string>("descript",designation)
            };
        }

        public static HashSet<KeyValuePair<string, string>> getSampleTransactionAsKeyValuePair()
        {
            return new HashSet<KeyValuePair<string, string>>{
                new KeyValuePair<string,string>("id",id),
                new KeyValuePair<string,string>("idCompte",foreignId),
                new KeyValuePair<string,string>("idCategorie",foreignId),
                new KeyValuePair<string,string>("montant",montant),
                new KeyValuePair<string,string>("dateCreation",date),
                new KeyValuePair<string,string>("designation",designation),
                new KeyValuePair<string,string>("typeTransact",foreignId),
            };
        }

        public static HashSet<KeyValuePair<string, string>> getSampleTransactionPeriodiqueAsKeyValuePair()
        {
            return new HashSet<KeyValuePair<string, string>>{

                new KeyValuePair<string,string>("id",id),
                new KeyValuePair<string,string>("idCompte",foreignId),
                new KeyValuePair<string,string>("idCategorie",foreignId),
                new KeyValuePair<string,string>("montant",montant),
                new KeyValuePair<string,string>("dateCreation",date),
                new KeyValuePair<string,string>("designation",designation),
                new KeyValuePair<string,string>("typeTransact",foreignId),
                new KeyValuePair<string,string>("frequence",frequence)
            };
        }




        
    }
}
