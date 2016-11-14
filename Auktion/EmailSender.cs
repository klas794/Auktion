using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Hosting;

namespace Auktion.Helpers
{
    public class EmailSender
    {
        public SmtpClient PrepareLocalSender()
        {
            var smtpClient = new SmtpClient();
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            var emailPickupDirectory = HostingEnvironment.MapPath("~/EmailPickup");
            if (!Directory.Exists(emailPickupDirectory))
            {
                Directory.CreateDirectory(emailPickupDirectory);
            }
            smtpClient.PickupDirectoryLocation = emailPickupDirectory;

            return smtpClient;
        }

        public void DeliverEmail(string subject, string message)
        {
            MailMessage mail = new MailMessage("notsold@auction.se", "gunnar@auction.se");
            //SmtpClient client = new SmtpClient();
            SmtpClient client = PrepareLocalSender();

            /*
            client.Port = 25;
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.google.com";
            */

            mail.Subject = subject;
            mail.Body = message;
            client.Send(mail);
        }
    }
}