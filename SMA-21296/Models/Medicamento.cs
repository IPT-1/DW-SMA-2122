using System.ComponentModel.DataAnnotations;

namespace SMA_21296.Models {

    /// <summary>
    /// Descreve os dados do Medicamento.
    /// </summary>
    public class Medicamento {

        public Medicamento() {
            Receitas = new HashSet<ReceitaMedicamento>();
        }

        /// <summary>
        /// Chave primária PK para o Medicamento na base de dados.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome do Medicamento.
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
        [StringLength(50, ErrorMessage = "O {0} não pode ter mais que {1} caracteres.")]
        public string Nome { get; set; }

        /// <summary>
        ///// Dosagem do Medicamento.
        ///// </summary>
        //[Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
        //[StringLength(5, ErrorMessage = "O {0} não pode ter mais que {1} caracteres.")]
        //public string Dosagem { get; set; }

        /// <summary>
        /// Nome do Laboratório em que o Medicamento foi desenvolvido.
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
        [StringLength(50, ErrorMessage = "O {0} não pode ter mais que {1} caracteres.")]
        [Display(Name = "Laboratório")]
        public string Laboratorio { get; set; }

        /// <summary>
        /// Observações adicionais ao Medicamento (Facultativo).
        /// </summary>
        [Display(Name = "Observações")]
        public string Observacoes { get; set; }

        /// <summary>
        /// Foto do Medicamento.
        /// </summary>
        public string Foto { get; set; }

        /// <summary>
        /// Lista de Receitas em que o Medicamento está envolvido.
        /// </summary>
        public ICollection<ReceitaMedicamento> Receitas { get; set; }

    }
}
