﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AutomaticClassificationDBEntities : DbContext
    {
        protected AutomaticClassificationDBEntities()
            : base("name=AutomaticClassificationDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Category_tbl> Category_tbl { get; set; }
        public virtual DbSet<EmailRequest_tbl> EmailRequest_tbl { get; set; }
        public virtual DbSet<PermissionLevel_tbl> PermissionLevel_tbl { get; set; }
        public virtual DbSet<SendingAdjustmentStatus_tbl> SendingAdjustmentStatus_tbl { get; set; }
        public virtual DbSet<SendingHistory_tbl> SendingHistory_tbl { get; set; }
        public virtual DbSet<User_tbl> User_tbl { get; set; }
        public virtual DbSet<Word_tbl> Word_tbl { get; set; }
        public virtual DbSet<WordPerCategory_tbl> WordPerCategory_tbl { get; set; }
    }
}
