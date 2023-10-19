using Microsoft.EntityFrameworkCore;
using Models.Salarie;
using Models.Service;
namespace API_rest.Contexts
{
    public class AnnuaireContext : DbContext
    {
        public DbSet<Salarie> Salaries { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Site> Sites { get; set; }

        public AnnuaireContext(DbContextOptions<AnnuaireContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration du modèle Service
            modelBuilder.Entity<Service>()
                .HasKey(s => s.ID); // Clé primaire pour Service

            // Configuration du modèle Salarie
            modelBuilder.Entity<Salarie>()
                .HasKey(s => s.ID); // Clé primaire pour Salarie

            // Configuration du modèle Site
            modelBuilder.Entity<Site>()
                .HasKey(s => s.ID); // Clé primaire pour Site

            // Configuration de la relation entre Salarie et Service (Many-to-One)
            modelBuilder.Entity<Salarie>()
                .HasOne(s => s.Service)
                .WithMany(srv => srv.Salaries)
                .HasForeignKey(s => s.IDservice); // Clé étrangère dans Salarie

            // Configuration de la relation entre Salarie et Site (Many-to-One)
            modelBuilder.Entity<Salarie>()
                .HasOne(s => s.Site)
                .WithMany(sit => sit.Salaries)
                .HasForeignKey(s => s.IDsite); // Clé étrangère dans Salarie

            // Configuration de la relation entre Service et Salarie (One-to-Many)
            modelBuilder.Entity<Service>()
                .HasMany(srv => srv.Salaries)
                .WithOne(s => s.Service)
                .HasForeignKey(s => s.IDservice); // Clé étrangère dans Salarie

            // Configuration de la relation entre Site et Salarie (One-to-Many)
            modelBuilder.Entity<Site>()
                .HasMany(sit => sit.Salaries)
                .WithOne(s => s.Site)
                .HasForeignKey(s => s.IDsite); // Clé étrangère dans Salarie
        }
    }
}

