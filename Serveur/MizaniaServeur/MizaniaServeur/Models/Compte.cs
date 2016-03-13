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
    
    public partial class Compte
    {
        public Compte()
        {
            this.Transactions = new HashSet<Transaction>();
            this.TransactionPeriodiques = new HashSet<TransactionPeriodique>();
            this.Transferts = new HashSet<Transfert>();
            this.Transferts1 = new HashSet<Transfert>();
        }
    
        public int id { get; set; }
        public int idUtilisateur { get; set; }
        public double solde { get; set; }
        public string designation { get; set; }
        public string descript { get; set; }

        [JsonIgnore]
        public virtual Utilisateur Utilisateur { get; set; }
        [JsonIgnore]
        public virtual ICollection<Transaction> Transactions { get; set; }
        [JsonIgnore]
        public virtual ICollection<TransactionPeriodique> TransactionPeriodiques { get; set; }
        [JsonIgnore]
        public virtual ICollection<Transfert> Transferts { get; set; }
        [JsonIgnore]
        public virtual ICollection<Transfert> Transferts1 { get; set; }
    }
}