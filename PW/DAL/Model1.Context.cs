﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PW.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PWEntities : DbContext
    {
        public PWEntities()
            : base("name=PWEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<iwn_producers> iwn_producers { get; set; }
        public virtual DbSet<iwn_products> iwn_products { get; set; }
        public virtual DbSet<iwn_productType> iwn_productType { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<iwn_delivery> iwn_delivery { get; set; }
        public virtual DbSet<iwn_buyers> iwn_buyers { get; set; }
        public virtual DbSet<iwn_orders> iwn_orders { get; set; }
    }
}
