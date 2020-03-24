namespace CFT.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelBugTracker : DbContext
    {
        public ModelBugTracker()
            : base("name=ModelBugTracker")
        {
        }

        public virtual DbSet<Applications> Applications { get; set; }
        public virtual DbSet<BugTrackers> BugTrackers { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Applications>()
        //        .Property(e => e.NameApplication)
        //        .IsFixedLength();

        //    modelBuilder.Entity<Applications>()
        //        .HasOptional(e => e.Applications1)
        //        .WithRequired(e => e.Applications2);

        //    modelBuilder.Entity<Applications>()
        //        .HasMany(e => e.BugTrackers)
        //        .WithRequired(e => e.Applications)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<BugTrackers>()
        //        .Property(e => e.Email)
        //        .IsUnicode(false);
        //}
    }
}
