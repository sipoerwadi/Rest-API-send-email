using MailAppService.Models.Datas;
using System.Net.Mail;

namespace MailAppService.Services
{
    public class ServiceMail
    {
        public string SendMail(DataMails dataMails)
        {
            try
            {
                using (SmtpClient SmtpServer = new SmtpClient())
                {
                    try
                    {
                        SmtpServer.Host = dataMails.strSMTP;
                        using (MailMessage mail = new MailMessage())
                        {
                            mail.From = new MailAddress(dataMails.strMailFrom);
                            string[] arrMailTo = dataMails.strMailFrom.Split(";");
                            string strTo = "";
                            int i = 0;
                            if (arrMailTo.GetUpperBound(0) > 0)
                            {
                                for (i = 0; i <= arrMailTo.GetUpperBound(0); i++)
                                {
                                    strTo = arrMailTo[i];
                                    if (!string.IsNullOrEmpty(strTo)) {mail.To.Add(strTo);}
                                }
                            }
                            else { mail.To.Add(dataMails.strMailTo);}
                            mail.Subject = dataMails.strSubject;
                            mail.Body = dataMails.strBody;
                            mail.IsBodyHtml = dataMails.booBodyHTML;

                            if (!string.IsNullOrEmpty(dataMails.strCC))
                            {
                                arrMailTo = dataMails.strCC.Split(";");
                                if (arrMailTo.GetUpperBound(0) > 0)
                                {
                                    for (i = 0; i <= arrMailTo.GetUpperBound(0); i++)
                                    {
                                        strTo = arrMailTo[i];
                                        if (!string.IsNullOrEmpty(strTo)){ mail.CC.Add(strTo);}
                                    }
                                }
                                else{ mail.CC.Add(dataMails.strCC);}
                            }
                            if (!string.IsNullOrEmpty(dataMails.strBCC))
                            {
                                arrMailTo = dataMails.strBCC.Split(";");
                                if (arrMailTo.GetUpperBound(0) > 0)
                                {
                                    for (i = 0; i <= arrMailTo.GetUpperBound(0); i++)
                                    {
                                        strTo = arrMailTo[i];
                                        if (!string.IsNullOrEmpty(strTo)) { mail.Bcc.Add(strTo);}
                                    }
                                }
                                else
                                {
                                    mail.Bcc.Add(dataMails.strBCC);
                                }
                            }
                            if (!string.IsNullOrEmpty(dataMails.strAttachmentFile))
                            {
                                string[] arrMailAttach = dataMails.strAttachmentFile.Split(";");
                                string strAttach = "";
                                if (arrMailAttach.GetUpperBound(0) > 0)
                                {
                                    for (i = 0; i <= arrMailAttach.GetUpperBound(0); i++)
                                    {
                                        strAttach = arrMailAttach[i];
                                        if (!string.IsNullOrEmpty(strAttach)) { mail.Attachments.Add(new Attachment(strAttach));}
                                    }
                                }
                                else
                                {
                                    mail.Attachments.Add(new Attachment(dataMails.strAttachmentFile));
                                }
                            }
                            SmtpServer.EnableSsl = dataMails.booEnableSSL;

                            //Check gmail SMTP
                            if (dataMails.strSMTP.Contains("smtp.gmail.com") == true)
                            {
                                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                                SmtpServer.UseDefaultCredentials = false;
                            }
                            SmtpServer.Port = dataMails.iPort;
                            if (!string.IsNullOrEmpty(dataMails.strPassword))
                            {
                                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(dataMails.strMailFrom, dataMails.strPassword);
                                SmtpServer.Credentials = credentials;
                            }
                            SmtpServer.Send(mail);
                            return "succes"; 
                        }
                    }
                    catch (Exception ex) {return ex.Message;}
                }
            }
            catch (Exception ex) {return ex.Message;}
        }
    }
}
