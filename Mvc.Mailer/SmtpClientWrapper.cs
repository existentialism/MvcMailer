using System.ComponentModel;
using System.Net.Mail;

namespace Mvc.Mailer
{
    public class SmtpClientWrapper : SmtpClientBase
    {
        public SmtpClientWrapper()
        {
            InnerSmtpClient = new SmtpClient();
        }
        
        public SmtpClientWrapper(SmtpClient smtpClient)
        {
            InnerSmtpClient = smtpClient;
        }

        public SmtpClient InnerSmtpClient
        {
            get;
            set;
        }

        public override void Send(MailMessage mailMessage)
        {
            this.InnerSmtpClient.Send(mailMessage);
        }

        public override void SendAsync(MailMessage mailMessage, object userState)
        {
            InnerSmtpClient.SendCompleted += new SendCompletedEventHandler(InnerSmtpClient_SendCompleted);
            InnerSmtpClient.SendAsync(mailMessage, userState);
        }

        void InnerSmtpClient_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            base.OnSendCompleted(sender, e);
        }

        public override void Dispose()
        {
            this.InnerSmtpClient = null;
        }

        public static implicit operator SmtpClientWrapper(SmtpClient innerSmtpClient)
        {
            return new SmtpClientWrapper(innerSmtpClient);
        }
    }
}
