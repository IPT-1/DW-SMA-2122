using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMA_21296.Models {

    /// <summary>
    /// Descreve os dados da prescrição da receita.
    /// </summary>
    public class ReceitaMedicamento {

        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Chave estrangeira para o medicamento envolvente.
        /// </summary>
        [ForeignKey(nameof(Medicamento))]
        public int MedicamentoFK { get; set; }
        public Medicamento Medicamento { get; set; }

        /// <summary>
        /// Chave estrangeira para a receita envolvente.
        /// </summary>
        [ForeignKey(nameof(Receita))]
        public int ReceitaFK { get; set; }
        public Receita Receita { get; set; }

        /// <summary>
        /// Dosagem da receita.
        /// </summary>
        [Required]
        public string Dosagem { get; set; }

    }
}
