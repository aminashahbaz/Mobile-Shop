using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ThetaMobileProject.Controllers
{
    public class EmailSending
    {

        public string ManagerEmail = "nenanoor73@gmail.com";
        public void SendEmail(string Subject, string msgBody, string To)
        {
            try
            {
                MailMessage oEmail = new MailMessage();
                oEmail.Subject = Subject;

                oEmail.Body = msgBody;
                oEmail.IsBodyHtml = true;

                oEmail.To.Add(new MailAddress(To));
                oEmail.CC.Add(new MailAddress(ManagerEmail));


                oEmail.From = new MailAddress("nenanoor73@gmail.com", "My Mobile Shop");



                SmtpClient oSMTP = new SmtpClient();
                oSMTP.Port = 587; //25, 465
                oSMTP.EnableSsl = true;
                oSMTP.Host = "smtp.gmail.com";

                oSMTP.Credentials = new System.Net.NetworkCredential("nenanoor73@gmail.com", "mytestemailnena");

                oSMTP.Send(oEmail);
            }
            catch (Exception ex)
            {

            }

        }
    }
}
