//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaGestaoP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Aluno
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Aluno()
        {
            this.Alocacao_Aluno_Professor = new HashSet<Alocacao_Aluno_Professor>();
            this.Alocacao_Aluno_Turma = new HashSet<Alocacao_Aluno_Turma>();
        }
    
        public int Aluno_id { get; set; }
        public string nome { get; set; }
        public string nomepai { get; set; }
        public string nomemae { get; set; }
        public string bi { get; set; }
        public Nullable<System.DateTime> datanascimento { get; set; }
        public Nullable<int> utilizadorFK { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alocacao_Aluno_Professor> Alocacao_Aluno_Professor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alocacao_Aluno_Turma> Alocacao_Aluno_Turma { get; set; }
        public virtual Utilizador Utilizador { get; set; }
    }
}
