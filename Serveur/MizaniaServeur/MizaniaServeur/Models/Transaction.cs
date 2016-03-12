//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MizaniaServeur.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class Transaction
    {
        public int id { get; set; }
        public int idCompte { get; set; }
        public int idCategorie { get; set; }
        public double montant { get; set; }
        public Nullable<System.DateTime> dateCreation { get; set; }
        public string designation { get; set; }
        public string typeTransact { get; set; }
        [JsonIgnore]
        public virtual Categorie Categorie { get; set; }
        [JsonIgnore]
        public virtual Compte Compte { get; set; }
    }
}
