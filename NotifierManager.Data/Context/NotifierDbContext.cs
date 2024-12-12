using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotifierManager.Core.Models;

namespace NotifierManager.Data.Context
{
    public class NotifierDbContext : DbContext
    {
        public NotifierDbContext()
            : base("name=NotifierDbContext")
        {
        }

        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Notification Configuration
            modelBuilder.Entity<Notification>()
                .HasRequired(n => n.Category)
                .WithMany(c => c.Notifications)
                .HasForeignKey(n => n.CategoryId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
