﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MizaniaDbContext : DbContext
    {
        public MizaniaDbContext()
            : base("name=MizaniaDbContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Categorie> Categories { get; set; }
        public virtual DbSet<Compte> Comptes { get; set; }
        public virtual DbSet<PorteFeuille> PorteFeuilles { get; set; }
        public virtual DbSet<Privilege> Privileges { get; set; }
        public virtual DbSet<PrivilegeUtilisateur> PrivilegeUtilisateurs { get; set; }
        public virtual DbSet<TransactionPeriodique> TransactionPeriodiques { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Transfert> Transferts { get; set; }
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; }
    }
}
