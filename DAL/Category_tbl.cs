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
    
    public partial class Category_tbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category_tbl()
        {
            this.SendingHistory_tbl = new HashSet<SendingHistory_tbl>();
            this.SendingHistory_tbl1 = new HashSet<SendingHistory_tbl>();
            this.WordPerCategory_tbl = new HashSet<WordPerCategory_tbl>();
            this.EmailRequest_tbl = new HashSet<EmailRequest_tbl>();
        }
    
        public int ID_category { get; set; }
        public string Name_category { get; set; }
        public string Mail_category { get; set; }
        public string FolderPath_category { get; set; }
        public string Descriptiopn_category { get; set; }
        public string ManagerID_category { get; set; }
        public string ManagerName_category { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SendingHistory_tbl> SendingHistory_tbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SendingHistory_tbl> SendingHistory_tbl1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WordPerCategory_tbl> WordPerCategory_tbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmailRequest_tbl> EmailRequest_tbl { get; set; }
    }
}
