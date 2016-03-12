using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MizaniaServeur.Models.IRepositories;
using MizaniaServeur.Models;
using MizaniaServeur.Test.ServicesTests.Enumeration;

namespace MizaniaServeur.Test.ServicesTests.FakeRepositories
{
    /*
     *  cette classe represente un Fake object sa seul responsabilité est d'implementer l'interface ITransfertRepository pour 
     *  que le controleur TransfertController puisse être testé d'une manière independante (unitaire). Donc les methodes 
     *  vont retourner des objets/lists Transfert independamment des parametres en entrèe.
     *  Ce Repository a le nom Positive il represente l'hypothese d'un data Layer (Entity Framework) qui donne toujours 
     *  de bons resultat.
     */
    public class FakeTransfertPositiveRepository : ITransfertRepository
    {

        /*les champs*/

        private List<Transfert> list;
        private Transfert transfert;


        /*constructeur*/
        /*
           initialise la liste de tranferts pour qu'elle puisse être retourner par les méthodes adéquates.
         * ici notre but est de tester si le Service Layer a le comportement adéquat, donc on suppose que le Data Layer marche
         * le plus normalement du monde.
         */
        public FakeTransfertPositiveRepository()
        {
            list = new List<Transfert>();
            list.Add(WrightInput.getSampleTransfert() );
            list.Add(WrightInput.getSampleTransfert() );
            transfert = WrightInput.getSampleTransfert();
        }

        /*les requetes*/


        // l'insertion c'est bien passée
        public bool addTransfert(Transfert transfert)
        {
            return true; 
        }

        // la suppression se deroule sans accroc
        public bool deleteTransfertById(int id)
        {
            return true;
        }

        // pour les listes on se limite à deux objets
        public List<Transfert> getAllTransferts(int idPorteFeuille)
        {
            return list;
        }

        public Transfert getTransfertById(int id)
        {
            return transfert;
        }

        public List<Transfert> getTransfertsByDate(int idPorteFeuille, int year, int month, int day, int hour, int minute, int seconds)
        {
            return list;
        }

        public List<Transfert> getTransfertsByDateBetween(int idPorteFeuille, DateTime debut, DateTime fin)
        {
            return list;
        }

        public List<Transfert> getTransfertsByDateFrom(int idPorteFeuille, DateTime date)
        {
            return list;
        }

        public List<Transfert> getTransfertsByDateTo(int idPorteFeuille, DateTime date)
        {
            return list;
        }

        public List<Transfert> getTransfertsByIdCompteExpediteur(int idCompteExpediteur)
        {
            return list;
        }

        public List<Transfert> getTransfertsByIdCompteRecepteur(int idCompteRecepteur)
        {
            return list;
        }

        public List<Transfert> getTransfertsByMontant(int idPorteFeuille, float montant)
        {
            return list;
        }

        public List<Transfert> getTransfertsByMontantAbove(int idPorteFeuille, float min)
        {
            return list;
        }

        public List<Transfert> getTransfertsByMontantBelow(int idPorteFeuille, float max)
        {
            return list;
        }

        public List<Transfert> getTransfertsByMontantBetween(int idPorteFeuille, float min, float max)
        {
            return list;
        }

        public bool updateTransfertDateCreation(int id, int year, int month, int day, int hour, int minute, int second)
        {
            return true;
        }

        public bool updateTransfertDesignation(int id, string designation)
        {
            return true;
        }

        public bool updateTransfertIdCompteExpediteur(int id, int idCompteExpediteur)
        {
            return true;
        }

        public bool updateTransfertIdCompteRecepteur(int id, int idCompteRecepteur)
        {
            return true;
        }

        public bool updateTransfertMontant(int id, float montant)
        {
            return true;
        }
    }
}
