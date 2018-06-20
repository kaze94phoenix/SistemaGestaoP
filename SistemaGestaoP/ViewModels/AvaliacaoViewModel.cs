using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaGestaoP.Models
{
    public class AvaliacaoViewModel
    {
        public int tipoAvaliacao { set; get; }
        public int trimestre { set; get; }
        public int disciplinaProfessor { set; get; }
        public int classeTurma {set; get;}
        public int anoLectivo { set; get; }
        public List<Avaliacao> Avaliacoes { set; get; }
        public List<Alocacao_Aluno_Professor> AlunoProfessor { set; get; }
        public MediaTrimestral MediaTrimestral { set; get; }

        public IEnumerable<SelectListItem> turmas { set; get; }

        public IEnumerable<SelectListItem> disciplinas { set; get; }

        
        
    }
}