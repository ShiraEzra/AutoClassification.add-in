//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class User_tbl
    {
        public int ID_user { get; set; }
        public string Name_user { get; set; }
        public int ID_premissionLevel { get; set; }
    
        public virtual PermissionLevel_tbl PermissionLevel_tbl { get; set; }
    }
}
