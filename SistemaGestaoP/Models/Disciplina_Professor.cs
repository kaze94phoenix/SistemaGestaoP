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
    
    public partial class Disciplina_Professor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Disciplina_Professor()
        {
            this.Alocacao_Aluno_Professor = new HashSet<Alocacao_Aluno_Professor>();
            this.Alocacao_Professor_Turma = new HashSet<Alocacao_Professor_Turma>();
        }
    
        public int DisciplinaProfessor_id { get; set; }
        public Nullable<int> disciplinaFK { get; set; }
        public Nullable<int> professorFK { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alocacao_Aluno_Professor> Alocacao_Aluno_Professor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alocacao_Professor_Turma> Alocacao_Professor_Turma { get; set; }
        public virtual Disciplina Disciplina { get; set; }
        public virtual Professor Professor { get; set; }
    }
}