//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RubberDuckRent.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ducks
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ducks()
        {
            this.Rented = new HashSet<Rented>();
        }
    
        public int id { get; set; }
        public string type { get; set; }
        public string color { get; set; }
        public Nullable<int> manufactured_by { get; set; }
    
        public virtual Companies Companies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rented> Rented { get; set; }
    }
}
