using MailAppService.Models.Datas;
using MailAppService.Services;
using Microsoft.AspNetCore.Mvc;

namespace MailAppService.Controllers
{
    /*
      The Rest API program is used to send emails and validate only the sender's email address
      by Purwadi
     */
    public class MailController : Controller
    {
        public IActionResult Index() {return View();}

        [HttpPost("[controller]/SendEmail")]
        public IActionResult SendEMail_v0([FromBody] DataMails dataMails)
        {
            string strReturn = "";
            try
            {
                if (!String.IsNullOrEmpty(Convert.ToString(dataMails.strMailTo)))
                {
                     ServiceMail serviceMail = new ServiceMail();
                     strReturn=serviceMail.SendMail(dataMails);
                }
                else{ return Unauthorized(new { emailto = "The sender's email is empty" });}
            }
            catch (Exception ex){ return Unauthorized(new { requestclient = "Failed to send email", message = ex.Message });}
            return Ok(new { status = strReturn, description = "Email sent" + Convert.ToString(dataMails.strMailTo), email = dataMails });
        }
    }
}
