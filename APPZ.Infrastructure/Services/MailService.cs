using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
namespace APPZ.Infrastructure.Services
{
    public class MailService
    {
        public IConfiguration Configuration { get; set; }
        private SmtpClient _smtpClient;
        private static MailService _instance;
        public static MailService GetInstance { 
            get
            {
                if (_instance == null)
                    _instance = new MailService();

                return _instance;
            }
        }
        private MailService()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            _smtpClient = new SmtpClient(Configuration["Smtp:Host"])
            {
                Port = int.Parse(Configuration["Smtp:Port"]),
                Credentials = new NetworkCredential(Configuration["Smtp:Username"], Configuration["Smtp:Password"]),
                EnableSsl = true,
            };
        }

        public async Task SendMail(string toEmail, string message)
        {
            _smtpClient.Send(Configuration["Smtp:Username"], toEmail, "Notification", message);
        }
    }
}
