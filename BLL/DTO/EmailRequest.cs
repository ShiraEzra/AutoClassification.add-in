using System;

namespace BLL.DTO
{
    public class EmailRequest
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Sender { get; set; }
        public DateTime Date { get; set; }
        public string EntryID { get; set; }
    }
}
