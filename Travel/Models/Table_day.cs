//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Travel.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Table_day
    {
        public Table_day()
        {
            this.Table_bus = new HashSet<Table_bus>();
        }
    
        public int A_id { get; set; }
        public Nullable<int> R_id { get; set; }
        public string Day { get; set; }
    
        public virtual ICollection<Table_bus> Table_bus { get; set; }
        public virtual Table_route Table_route { get; set; }
    }
}
