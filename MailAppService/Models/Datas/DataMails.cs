namespace MailAppService.Models.Datas
{
    public class DataMails
    {
        public string strSMTP { get; set; } = string.Empty;
        public string strMailFrom { get; set; } = string.Empty;
        public string strMailTo { get; set;} = string.Empty;
        public string strSubject { get; set; } = string.Empty;
        public string strBody { get; set; } = string.Empty;
        public string strPassword { get; set;} = string.Empty;
        public int iPort { get; set; }
        public bool booEnableSSL { get; set; }
        public bool booBodyHTML { get; set;}
        public string strAttachmentFile { get; set; } = string.Empty;
        public string strCC { get; set; } = string.Empty;
        public string strBCC { get; set; } = string.Empty;  
     }
}
