﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ManageAssets.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AssetsManagerEntities : DbContext
    {
        public AssetsManagerEntities()
            : base("name=AssetsManagerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CONTACTS_CATEGORIES> CONTACTS_CATEGORIES { get; set; }
        public virtual DbSet<CONTACTS_DATA> CONTACTS_DATA { get; set; }
        public virtual DbSet<CONTACTS_EQUIPMENT> CONTACTS_EQUIPMENT { get; set; }
        public virtual DbSet<EQUIPMENT> EQUIPMENTs { get; set; }
        public virtual DbSet<SUPPLIER> SUPPLIERs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<PAYMENT> PAYMENTS { get; set; }
    }
}
