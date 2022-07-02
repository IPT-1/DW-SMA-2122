using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMA_21296.Models {
    
    /// <summary>
    /// Descreve os dados do Utente.
    /// </summary>
    public class Utente {

        public Utente() {
            ListaReceitasCriadas = new HashSet<Receita>();
            ListaReceitasAtribuidas = new HashSet<Receita>();
        }

        /// <summary>
        /// Chave primária PK para o Utenta na base de dados.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome do Utente.
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
        [StringLength(50, ErrorMessage = "O {0} não pode ter mais que {1} caracteres.")]
        [RegularExpression("[A-ZÂÓÍa-záéíóúàèìòùâêîôûãõäëïöüñç '-]+", ErrorMessage = "Só pode escrever letras no {0}")]
        public string Nome { get; set; }

        /// <summary>
        /// Número de telmóvel do Utente.
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
        [Display(Name = "Telemóvel")]
        [RegularExpression("9[1236][0-9]{7}|2[1-9][0-9]{7}", ErrorMessage = "Número de telemóvel inválido.")]
        public string Telemovel { get; set; }

        /// <summary>
        /// Número de Utente de Saúde do Cartão de Cidadão do Utente.
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [Display(Name = "Número de Utente de Saúde")]
        public string NumeroUtenteSaude { get; set; }

        /// <summary>
        /// Sexo do Utente. (M - Masculino / F - Feminino)
        /// </summary>
        [StringLength(1, ErrorMessage = "O {0} só aceita um caráter.")]
        [RegularExpression("[FM]", ErrorMessage = "No {0} só se aceitam as letras F ou M.")]
        public string Sexo { get; set; }

        /// <summary>
        /// Tipo de Utente. (P - Paciente / M - Médico)
        /// </summary>
        [StringLength(1, ErrorMessage = "O {0} só aceita um caráter. (P)aciente, (M)edico")]
        [Display(Name = "Paciente / Médico")]
        public string Funcao { get; set; }

        /// <summary>
        /// Lista de Receitas criadas em que está envolvido.
        /// </summary>
        [InverseProperty("Medico")]
        public ICollection<Receita> ListaReceitasCriadas { get; set; }

        /// <summary>
        /// Lista dos seus Pacientes, se o Utente for Médico.
        /// </summary>
        [InverseProperty("Paciente")]
        public ICollection<Receita> ListaReceitasAtribuidas { get; set; }

        /// <summary>
        /// Atributo que conecta o utilizador à autenticação da base de dados.
        /// </summary>
        public string UserID { get; set; }

    }
}
