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
    using System;
    using Newtonsoft.Json; 
    using System.Collections.Generic;
    
    public partial class PorteFeuille
    {
        public PorteFeuille()
        {
            this.Categories = new HashSet<Categorie>();
            this.Utilisateurs = new HashSet<Utilisateur>();
        }
    
        public int id { get; set; }
        public string designation { get; set; }
        public Nullable<System.DateTime> dateCreation { get; set; }

        [JsonIgnore]
        public virtual ICollection<Categorie> Categories { get; set; }
        [JsonIgnore]
        public virtual ICollection<Utilisateur> Utilisateurs { get; set; }
    }
}
