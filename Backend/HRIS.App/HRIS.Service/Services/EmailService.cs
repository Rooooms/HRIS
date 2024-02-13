using HRIS.Core.Interfaces.Services.EmailSender;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HRIS.Service.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var mail = "romeorojo45@outlook.com";
            var pw = "ozaamauknmmdrymd";

            var client = new SmtpClient("smtp.outlook.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(mail, pw)
            };

            try
            {
                await client.SendMailAsync(
                    new MailMessage(from: mail,
                                    to: toEmail,
                                    subject: subject,
                                    body: message)
                    {
                        IsBodyHtml = true
                    });
            }
            catch (SmtpException ex)
            {
                // Log or handle the exception appropriately
                throw ex;
            }
            finally
            {
                client.Dispose();
            }
        }
    }
}
