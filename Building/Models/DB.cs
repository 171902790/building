using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Building.Models
{
    public class DB : DbContext
    {
        public DB()
            : base("name=db")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DB, Migrations.Configuration>());
        }
        public DbSet<User> Users { get; set; }

        public DbSet<Ad> Ads { get; set; }

        public DbSet<Module> Modules { get; set; }

        public DbSet<Article> Articles { get; set; }
    }
}