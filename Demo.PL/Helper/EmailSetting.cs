using Demo.DAL.Model;
using System.Net;
using System.Net.Mail;

namespace Demo.PL.Helper
{
    public class EmailSetting
    {
        public static void SendEmail(Email email)
        {
            var clinet = new SmtpClient("linkdev.com", 222);
            clinet.EnableSsl = true;
          
        }
    }
}
