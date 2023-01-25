using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace resultado_pdf {
    public class PDF {

        public DateTime dataAberturaFicha { get; set; }
        public Cliente cliente { get; set; }
        public UnidadeAtendimento unidadeAtendimento { get; set; }
        public List<ProfissionalSaude> listaProfissionalSaudeSolicitante { get; set; }
        public string avisoLegal { get; set; }
        public List<string> listaImagem { get; set; }
    }
}
