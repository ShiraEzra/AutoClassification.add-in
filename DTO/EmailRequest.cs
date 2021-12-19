using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EmailRequest
    {
        public int ID_emailRequest { get; set; }
        public string EmailSubject { get; set; }
        public string EmailContent { get; set; }
        public string SenderEmail { get; set; }
        public Nullable<System.DateTime> Date { get; set; }

        public EmailRequest(string subject, string body, string sender, DateTime date)
        {
            this.EmailSubject = subject;
            this.EmailContent = body;
            this.SenderEmail = sender;
            this.Date = date;
        }

        public EmailRequest_tbl DtoTODal()
        {
            var config = new MapperConfiguration(cfg =>
                   cfg.CreateMap<EmailRequest, EmailRequest_tbl>()
               );
            var mapper = new Mapper(config);
            return mapper.Map<EmailRequest_tbl>(this);
        }

        public static EmailRequest DalToDto(EmailRequest_tbl e)
        {
            var config = new MapperConfiguration(cfg =>
                 cfg.CreateMap<EmailRequest_tbl, EmailRequest>()
             );
            var mapper = new Mapper(config);
            return mapper.Map<EmailRequest>(e);
        }
    }
}
