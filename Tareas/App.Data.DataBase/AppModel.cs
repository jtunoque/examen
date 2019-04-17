namespace App.Data.DataBase
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using App.Entities.Base;

    public partial class AppModel : DbContext
    {
        public AppModel()
            : base("name=cnxAppDBModel")
        {
            Database.SetInitializer<AppModel>(null);
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = false;

            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Tarea> Tarea { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Tarea)
                .WithRequired(e => e.AutorTarea)
                .HasForeignKey(item=>item.AutorTareaID)
                .WillCascadeOnDelete(false);

        }
    }
}
