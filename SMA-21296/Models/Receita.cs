using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMA_21296.Models {

    /// <summary>
    /// Descreve os dados da Receita.
    /// </summary>
    public class Receita {

        public Receita() {
            Medicamentos = new HashSet<ReceitaMedicamento>();
        }

        /// <summary>
        /// Chave primária PK para a Receita na base de dados.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Data de quando a Receita foi criada.
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                     ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        //     /// <summary>
        //     /// Prescrição da Receita.
        //     /// </summary>
        //     [Display(Name = "Prescrição")]
        ////     public string Prescricao { get; set; }

        /// <summary>
        /// Chave estrangeira para o médico.
        /// </summary>
        [ForeignKey(nameof(Medico))]
        public int MedicoFK { get; set; }
        public Utente Medico { get; set; }

        /// <summary>
        /// Chave estrangeira para o paciente.
        /// </summary>
        [ForeignKey(nameof(Paciente))]
        public int PacienteFK { get; set; }
        public Utente Paciente { get; set; }

        /// <summary>
        /// Lista de medicamentos.
        /// </summary>
        public ICollection<ReceitaMedicamento> Medicamentos { get; set; }

    }
}
