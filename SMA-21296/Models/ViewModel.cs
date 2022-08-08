namespace SMA_21296.Models {
    
    /// <summary>
    /// ViewModel para ser usado na API dos Utentes
    /// </summary>
    public class UtentesViewModel {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telemovel { get; set; }
        public string NumeroUtenteSaude { get; set; }
        public string Sexo { get; set; }
        public string Funcao { get; set; }
    }
    
    /// <summary>
    /// ViewModel para ser usado na API dos Medicamentos
    /// </summary>
    public class MedicamentosViewModel {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Laboratorio { get; set; }
        public string Observacoes { get; set; }
        public string Foto { get; set; }

    }
    
    
    public class ErrorViewModel {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}