using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace resultado_pdf {
    public class ProfissionalSaude {
        public int profissionalSaudeId { get; set; }
        public string titulo { get; set; }
        public string tipoCategoria { get; set; }
        public int numeroCertificado { get; set; }
        public string estadoOrigemCertificado { get; set; }
        public PessoaFisica pessoaFisica { get; set; }
        public ResultadoTradicional resultadoTradicional { get; set; }
        public ResultadoEvolutivo resultadoEvolutivo { get; set; }
    }
}
