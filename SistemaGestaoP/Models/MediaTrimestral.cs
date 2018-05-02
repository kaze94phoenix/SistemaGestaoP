using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SistemaGestaoP.Models
{
    public class MediaTrimestral
    {
        private SGPEntities db = new SGPEntities();
        public int alunoId { set; get; }
        public int anoLectivo { set; get; }
        public int trimestre { set; get; }
        public int disciplinaProfessor { set; get; }
        public int classeTurma { set; get; }

        public MediaTrimestral(int alunoId, int disciplinaProfessor, int classeTurma, int trimestre, int anoLectivo)
        {
           this.alunoId=alunoId;
           this.disciplinaProfessor = disciplinaProfessor;
            this.classeTurma = classeTurma;
            this.trimestre = trimestre;
            this.anoLectivo = anoLectivo;
            float? mAC = 0;
            float? mAS = 0;
            float? mT = 0;

        }
        public MediaTrimestral()
        {

        }
        public float? mediaAvaliacaoContinua()
        {
            List<int> alunoProfessores = new List<int>();
            foreach (Alocacao_Aluno_Professor aP in db.Alocacao_Aluno_Professor)
            {
                if(aP.alunoFK==alunoId && aP.classeTurmaFK==classeTurma && aP.disciplinaProfessorFK == disciplinaProfessor && aP.anoLectivo==anoLectivo)
                {
                    alunoProfessores.Add(aP.Alocacao_Aluno_Professor_id);
                }
                
            }
            var avaliacoes = db.Avaliacaos;
            List<float?> avaliacaoContinua = new List<float?>();
            foreach (int a in alunoProfessores)
            {
                foreach(Avaliacao ava in avaliacoes){
                    if (a==ava.alocacaoAlunoProfessorFK && ava.tipoAvaliacaoFK==1 && ava.trimestreFK==trimestre)
                    {
                        avaliacaoContinua.Add(ava.nota);
                    }
                }
            }

            float? soma = 0;
                foreach(float? sum in avaliacaoContinua)
            {
                soma += sum;
            }
            return soma/avaliacaoContinua.Count;

    }
    }
}