namespace MtOMAttribute
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Entity5> Entity5 { get; set; }
        public virtual DbSet<Entity6> Entity6 { get; set; }
        public virtual DbSet<Rel8> Rel8 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entity6>()
                .HasMany(e => e.Rel8)
                .WithRequired(e => e.Entity6)
                .WillCascadeOnDelete(false);
        }
    }
}
