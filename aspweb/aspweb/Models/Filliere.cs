//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace aspweb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Filliere
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Filliere()
        {
            this.Groupes = new HashSet<Groupe>();
            this.Modules = new HashSet<Module>();
        }
    
        public int codeFil { get; set; }
        public string nomF { get; set; }
        public int codeSecteur { get; set; }
    
        public virtual Secteur Secteur { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Groupe> Groupes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Module> Modules { get; set; }
    }
}
