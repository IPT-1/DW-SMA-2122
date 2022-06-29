using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SMA_21296.Models;
using System.ComponentModel.DataAnnotations;

namespace SMA_21296.Data {

    /// <summary>
    /// Classe que representa os dados do novo Utilizador.
    /// </summary>
    public class ApplicationUser : IdentityUser {

        /// <summary>
        /// Nome pessoal do utilizador a usar na interface.
        /// </summary>
        [Required]
        public string Nome { get; set; }

        /// <summary>
        /// Data de registo.
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DataRegisto { get; set; }

    }

    /// <summary>
    /// Esta classe funciona como base dados do projeto.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }

        /// <summary>
        /// Executa o código antes da criação do model.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            // Importa a última execução deste método.
            base.OnModelCreating(modelBuilder);

            // Adicionar os dados dos cargos.
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "a", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "m", Name = "Medico", NormalizedName = "MEDICO" },
                new IdentityRole { Id = "p", Name = "Paciente", NormalizedName = "PACIENTE" }
                );

        }

        // Definir tabelas para a base de dados.
        public DbSet<Utente> Utentes { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<Receita> Receitas { get; set; }
        public DbSet<ReceitaMedicamento> ReceitasMedicamento { get; set; }

    }
}