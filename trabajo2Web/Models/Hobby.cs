//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace trabajo2Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Hobby
    {
        public Hobby()
        {
            this.Client = new HashSet<Client>();
        }
    
        public int hobbyId { get; set; }
        public string name { get; set; }
    
        public virtual ICollection<Client> Client { get; set; }
    }
}
