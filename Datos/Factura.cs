
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Datos
{

using System;
    using System.Collections.Generic;
    
public partial class Factura
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Factura()
    {

        this.DETALLE = new HashSet<DETALLE>();

    }


    public int num_factura { get; set; }

    public Nullable<int> id_cliente { get; set; }

    public Nullable<System.DateTime> fecha { get; set; }

    public Nullable<int> num_pago { get; set; }



    public virtual CLIENTE CLIENTE { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<DETALLE> DETALLE { get; set; }

    public virtual MODO_PAGO MODO_PAGO { get; set; }

}

}
