//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class repair
    {
        public int MachineNO { get; set; }
        public int repair_id { get; set; }
        public Nullable<double> cost { get; set; }
        public string description { get; set; }
        public Nullable<System.DateTime> repair_date { get; set; }
    
        public virtual computer computer { get; set; }
    }
}
