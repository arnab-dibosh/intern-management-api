﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InternProject_Demo_22
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TrainingDBEntities1 : DbContext
    {
        public TrainingDBEntities1()
            : base("name=TrainingDBEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Intern_Project> Intern_Project { get; set; }
        public virtual DbSet<Intern> Interns { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
    }
}
