using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MizaniaServeur.Models;

namespace MizaniaServeur.Test.ServicesTests.Enumeration
{
    /*
     * cette classe represente les données qui ne sont pas conformes à l'api
     * ce sont les parametres des differentes Urls offertes par l'api
     * */
    class WrongInput
    {
        public static string id = "-1";
        public static string foreignId = "-2";
        public static string year = "-2017";
        public static string month = "-13";
        public static string day = "-31";
        public static string hour = "-24";
        public static string minute = "-60";
        public static string second = "-60";
        public static string designation = "";
        public static string description = "";
        public static string date = "pas une Date";
        public static string montant = "-9.99F";

        // des valeurs qui ne represent pas leurs type ;
        public static string notTheInt = "2.71F";
        public static string notTheFloat = "pas un float";
        public static string notTheString = "";

        
    }
}
