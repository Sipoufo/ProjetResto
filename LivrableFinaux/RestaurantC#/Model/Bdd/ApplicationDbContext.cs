using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ProjectResto.Models.BDD
{
    using ProjectResto.Models.Cuisine;
    using ProjectResto.Models.Personnels;
    using ProjectResto.Models.Restaurant;
    class ApplicationDbContext : DbContext
    {
        // Table Cuisine
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<Ustensil> Ustensil { get; set; }
        public DbSet<UstensilUtilise> UstensilUtilise { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<IngredientUtilise> IngredientUtilise { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Commande> Commande { get; set; }

        //Table
        public DbSet<Client> Client { get; set; }
        public DbSet<Serveur> Serveur { get; set; }
        public DbSet<Plongeur> Plongeur { get; set; }
        public DbSet<MaitreHotel> MaitreHotel { get; set; }
        public DbSet<Cuisinier> Cuisinier { get; set; }
        public DbSet<CommisSalle> CommisSalle { get; set; }
        public DbSet<CommisCuisinier> CommisCuisinier { get; set; }
        public DbSet<ChefRang> ChefRang { get; set; }
        public DbSet<ChefPartie> ChefCuisinier { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        private readonly string _connectionString;

        public ApplicationDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test");
        }
        
        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Commande>()
               .HasOne(co => co.Client)
               .WithMany(cli => cli.Commande)
               .HasForeignKey(co => co.IdClient)
               .HasPrincipalKey(cli => cli.Id);

            modelBuilder.Entity<Ustensil>()
                .HasKey(u => u.Id)
                .HasName("PrimaryKey_Id");

            modelBuilder.Entity<Ingredient>()
                .HasKey(i => i.Id)
                .HasName("PrimaryKey_Id");

            modelBuilder.Entity<UstensilUtilise>()
                .Property(e => e.QuantiteUtilise)
                .IsRequired(true);
            
            modelBuilder.Entity<IngredientUtilise>()
                .Property(e => e.QuantiteUtilise)
                .IsRequired(true);

            modelBuilder.Entity<Recipe>()
               .HasMany(u => u.UstensilUtilise)
               .WithOne(r => r.Recipe)
               .HasForeignKey(u => u.IdRecipe)
               .HasPrincipalKey(r => r.Id);

            modelBuilder.Entity<Recipe>()
               .HasMany(i => i.IngredientUtilise)
               .WithOne(r => r.Recipe)
               .HasForeignKey(i => i.IdRecipe)
               .HasPrincipalKey(r => r.Id);

            modelBuilder.Entity<Client>()
                .HasKey(i => i.Id)
                .HasName("PrimaryKey_Id");

            modelBuilder.Entity<MaitreHotel>()
                .HasKey(i => i.Id)
                .HasName("PrimaryKey_Id");

            modelBuilder.Entity<Serveur>()
                .HasKey(i => i.Id)
                .HasName("PrimaryKey_Id");

            modelBuilder.Entity<Plongeur>()
                .HasKey(i => i.Id)
                .HasName("PrimaryKey_Id");

            modelBuilder.Entity<Cuisinier>()
                .HasKey(i => i.Id)
                .HasName("PrimaryKey_Id");

            modelBuilder.Entity<CommisSalle>()
                .HasKey(i => i.Id)
                .HasName("PrimaryKey_Id");

            modelBuilder.Entity<CommisCuisinier>()
                .HasKey(i => i.Id)
                .HasName("PrimaryKey_Id");

            modelBuilder.Entity<ChefCuisinier>()
                .HasKey(i => i.Id)
                .HasName("PrimaryKey_Id");

            modelBuilder.Entity<ChefRang>()
                .HasKey(i => i.Id)
                .HasName("PrimaryKey_Id");

            modelBuilder.Entity<ChefPartie>()
                .HasKey(i => i.Id)
                .HasName("PrimaryKey_Id");

            modelBuilder.Entity<Table>()
                .HasKey(i => i.Id)
                .HasName("PrimaryKey_Id");
        }
        #endregion
    }
}
