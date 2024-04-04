using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace CommonLayer.RequestModel
{
    public class Send
    {
        public string SendMail(string ToEmail, string Token)
        {
            string FromEmail = "arunraksha234@gmail.com";
            MailMessage Message = new MailMessage(FromEmail, ToEmail);
            /* string MailBody = $"Book Store User Password Reset:<a href=http://localhost:4200/reset/{Token}>Click Here</a>";*/
            string MailBody = $"Book Store User Password Reset: Click Here";
            Message.Subject = "Token generated for Forget Password";
            Message.Body = MailBody.ToString();
            Message.BodyEncoding = Encoding.UTF8;
            Message.IsBodyHtml = true;

            SmtpClient SmtpClient = new SmtpClient("smtp.gmail.com", 587);
            NetworkCredential credential = new NetworkCredential("arunraksha234@gmail.com", "tjzl tyak krld iukh");
            SmtpClient.EnableSsl = true;
            SmtpClient.UseDefaultCredentials = true;
            SmtpClient.Credentials = credential;
            SmtpClient.Send(Message);
            return ToEmail;
        }
    }
}
