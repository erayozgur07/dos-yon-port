
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace AngularVize.Models
{

using System;
    using System.Collections.Generic;
    
public partial class TDosyalar
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public TDosyalar()
    {

        this.TDosyaKayit = new HashSet<TDosyaKayit>();

    }


    public string dosyaId { get; set; }

    public string dosyaAdi { get; set; }

    public string dosyaFoto { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<TDosyaKayit> TDosyaKayit { get; set; }

}

}
