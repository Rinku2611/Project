﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DeliveryInatechMvc.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DeliveryDbEntities : DbContext
    {
        public DeliveryDbEntities()
            : base("name=DeliveryDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BookingTb> BookingTbs { get; set; }
        public virtual DbSet<CustomerTb> CustomerTbs { get; set; }
        public virtual DbSet<ExecutiveTb> ExecutiveTbs { get; set; }
    }
}