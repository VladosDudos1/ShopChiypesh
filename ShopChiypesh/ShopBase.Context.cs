﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopChiypesh
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ShopChiypeshEntities : DbContext
    {
        public ShopChiypeshEntities()
            : base("name=ShopChiypeshEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Client> Client { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCountry> ProductCountry { get; set; }
        public DbSet<ProductIntake> ProductIntake { get; set; }
        public DbSet<ProductIntakeProduct> ProductIntakeProduct { get; set; }
        public DbSet<ProductOrder> ProductOrder { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<StatusIntake> StatusIntake { get; set; }
        public DbSet<StatusOrder> StatusOrder { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Worker> Worker { get; set; }
    }
}
