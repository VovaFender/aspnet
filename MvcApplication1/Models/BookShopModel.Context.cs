﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcApplication1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BookShopEntities : DbContext
    {
        public BookShopEntities()
            : base("name=BookShopEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Book> Books { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Writer> Writers { get; set; }
    }
}
