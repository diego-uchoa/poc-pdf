using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace resultado_pdf {
    public class UnidadeAtendimento {
        public int unidadeAtendimentoId { get; set; }
        public string nome { get; set; }
        public string tipoCategoria { get; set; }
        public string numeroCertificado { get; set; }
        public bool unidadeHospitalar { get; set; }
        public string endereco { get; set; }
        public bool utilizaPapelTimbrado { get; set; }
        public Marca marca { get; set; }
        public ProfissionalSaude profissionalSaudeResponsavelTecnico { get; set; }
    }
}
