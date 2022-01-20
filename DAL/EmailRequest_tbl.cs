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
    
    public partial class EmailRequest_tbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EmailRequest_tbl()
        {
            this.SendingHistory_tbl = new HashSet<SendingHistory_tbl>();
            this.WordPerRequest_tbl = new HashSet<WordPerRequest_tbl>();
        }
    
        public int ID_emailRequest { get; set; }
        public string EmailSubject { get; set; }
        public string EmailContent { get; set; }
        public string SenderEmail { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<int> ID_category { get; set; }
        public string EntryId { get; set; }
    
        public virtual Category_tbl Category_tbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SendingHistory_tbl> SendingHistory_tbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WordPerRequest_tbl> WordPerRequest_tbl { get; set; }
    }
}
