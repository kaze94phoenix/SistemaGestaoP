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
        public int alunoProfessor { set; get; }
        public int trimestre { set; get; }
        
        public MediaTrimestral(int alunoProfessorId, int trimestre)
        {
           this.alunoProfessor = alunoProfessorId;
            this.trimestre = trimestre;
            float? mAC = 0;
            float? mAS = 0;
            float? mT = 0;

        }
        public MediaTrimestral()
        {
            float? mAC = 0;
            float? mAS = 0;
            float? mT = 0;
        }
        public float? mediaAvaliacaoContinua()
        {
            List<float?> avaliacaoContinua = new List<float?>();
            //busca das avaliacoes tendo como chave a alocacao aluno_professor, o trimestre, e tipo de avaliacao
            foreach (Avaliacao ava in db.Avaliacaos)
            {
                if (ava.tipoAvaliacaoFK == 1 && ava.trimestreFK==trimestre && ava.alocacaoAlunoProfessorFK==alunoProfessor)
                {
                    avaliacaoContinua.Add(ava.nota);
                }
                
            }

            float? soma = 0;
                foreach(float? sum in avaliacaoContinua)
            {
                soma += sum;
            }
            return soma/avaliacaoContinua.Count;

    }
        public float? mediaAvaliacaoContinua(int alunoProfessor, int trimestre)
        {
            List<float?> avaliacaoContinua = new List<float?>();
            //busca das avaliacoes tendo como chave a alocacao aluno_professor, o trimestre, e tipo de avaliacao
            foreach (Avaliacao ava in db.Avaliacaos)
            {
                if (ava.tipoAvaliacaoFK == 1 && ava.trimestreFK == trimestre && ava.alocacaoAlunoProfessorFK == alunoProfessor)
                {
                    avaliacaoContinua.Add(ava.nota);
                }

            }

            float? soma = 0;
            foreach (float? sum in avaliacaoContinua)
            {
                soma += sum;
            }
            return soma / avaliacaoContinua.Count;

        }

        public float? mediaAvaliacaoSistematica()
        {
            List<float?> avaliacaoSistematica = new List<float?>();
            //busca das avaliacoes tendo como chave a alocacao aluno_professor, o trimestre, e tipo de avaliacao
            foreach (Avaliacao ava in db.Avaliacaos)
            {
                if (ava.tipoAvaliacaoFK == 2 && ava.trimestreFK == trimestre && ava.alocacaoAlunoProfessorFK == alunoProfessor)
                {
                    avaliacaoSistematica.Add(ava.nota);
                }

            }

            float? soma = 0;
            foreach (float? sum in avaliacaoSistematica)
            {
                soma += sum;
            }
            return (mediaAvaliacaoContinua()+soma)/(avaliacaoSistematica.Count+1);

        }

        public float? mediaAvaliacaoSistematica(int alunoProfessor, int trimestre)
        {
            List<float?> avaliacaoSistematica = new List<float?>();
            //busca das avaliacoes tendo como chave a alocacao aluno_professor, o trimestre, e tipo de avaliacao
            foreach (Avaliacao ava in db.Avaliacaos)
            {
                if (ava.tipoAvaliacaoFK == 2 && ava.trimestreFK == trimestre && ava.alocacaoAlunoProfessorFK == alunoProfessor)
                {
                    avaliacaoSistematica.Add(ava.nota);
                }

            }

            float? soma = 0;
            foreach (float? sum in avaliacaoSistematica)
            {
                soma += sum;
            }
            return (mediaAvaliacaoContinua() + soma) / (avaliacaoSistematica.Count + 1);

        }


        public float? mediaTrimestral(int alunoProfessor, int trimestre)
        {
            float? avaliacaoPeriodicaTrimestral = 0;
            //busca das avaliacoes tendo como chave a alocacao aluno_professor, o trimestre, e tipo de avaliacao
            foreach (Avaliacao ava in db.Avaliacaos)
            {
                if (ava.tipoAvaliacaoFK == 3 && ava.trimestreFK == trimestre && ava.alocacaoAlunoProfessorFK == alunoProfessor)
                {
                    avaliacaoPeriodicaTrimestral = ava.nota;
                }

            }   
            return ((2*mediaAvaliacaoSistematica(alunoProfessor,trimestre)) + avaliacaoPeriodicaTrimestral)/3;

        }

        public float? mediaTrimestral()
        {
            float? avaliacaoPeriodicaTrimestral = 0;
            //busca das avaliacoes tendo como chave a alocacao aluno_professor, o trimestre, e tipo de avaliacao
            foreach (Avaliacao ava in db.Avaliacaos)
            {
                if (ava.tipoAvaliacaoFK == 3 && ava.trimestreFK == trimestre && ava.alocacaoAlunoProfessorFK == alunoProfessor)
                {
                    avaliacaoPeriodicaTrimestral = ava.nota;
                }

            }
            return ((2 * mediaAvaliacaoSistematica()) + avaliacaoPeriodicaTrimestral) / 3;

        }
    }
}