using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Zarzadzanie_Projektami.Models;

namespace Zarzadzanie_Projektami.DAL
{
    public class ProjektContext: DbContext
    {
        public ProjektContext()
            :base("DefaultConnection")
        {

        }
        public DbSet<Profil> Profil { get; set; }
        public DbSet<Projekt> Projekt { get; set; }
        public DbSet<Zadanie> Zadanie { get; set; }
        public DbSet<Zasob> Zasob { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}