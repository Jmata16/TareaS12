//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiTareaS12.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Principal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Principal()
        {
            this.Abonos = new HashSet<Abono>();
        }
    
        public long Id_Compra { get; set; }
        public decimal Precio { get; set; }
        public decimal Saldo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Abono> Abonos { get; set; }
    }
}
