
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Newtonsoft.Json;

namespace Fixit.Utils
{
    public class Email
    {
         public static bool sendEmail(string subject, string body, string email)
        {
            try
            {

                var message = new MimeMessage();

                message.From.Add(
                    new MailboxAddress(
                        "FAHAD",
                          Constant.MAIL_FROM_ADDRESS_EMAIL)
                );
                message.To.Add(new MailboxAddress("HELLO", email));
                message.Subject = subject;
                var bodyBuilder = new BodyBuilder ();
                bodyBuilder.HtmlBody = body;
                message.Body = bodyBuilder.ToMessageBody ();
                // body=JsonConvert.SerializeObject(body);
                // message.Body=new TextPart ("html") { Text = body };
            //    message.Body = new MimeKit.Multipart("alternative")
            //     {
            //         html=body;
            //     }; 
                using (var client = new SmtpClient())
                {
                    client.Connect(Constant.MAIL_HOST_ADDRESS, Constant.MAIL_HOST_PORT, SecureSocketOptions.SslOnConnect);


                    client.AuthenticateAsync(
                         Constant.MAIL_AUTHENTICAITON_USER,
                         Constant.MAIL_AUTHENTICATION_PASSWORD
                     ).Wait();


                     client.Send(message);
                     client.Disconnect(true);
                 }

               return true;


             }
             catch (Exception EX)
             {
                 return false;
             }
        }



        // public void sendEmail(string email,string msg)
        // {
            
        //     var message = new MimeMessage ();
		// 	message.From.Add (new MailboxAddress ("King Fahad", "M.Fahad2015@outlook.com"));
		// 	message.To.Add (new MailboxAddress ("Usman Mani", "abdulmuqeet.ngenc@gmail.com"));
		// 	message.Subject = "How you doin'?";

		// 	message.Body = new TextPart ("plain") {
		// 		Text = @"Hey King,I just wanted to let you know that Monica and I were going to go play some paintball, you in?-- Joey"
		// 	};

		// 	using (var client = new SmtpClient ()) {
		// 		// For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
		// 		client.ServerCertificateValidationCallback = (s,c,h,e) => true;

		// 		client.Connect ("smtp-mail.outlook.com", 587, true);

		// 		// Note: since we don't have an OAuth2 token, disable
		// 		// the XOAUTH2 authentication mechanism.
		// 		client.AuthenticationMechanisms.Remove ("XOAUTH2");

		// 		// Note: only needed if the SMTP server requires authentication
		// 		client.Authenticate ("M.Fahad2015@outlook.com", "king0341");
				
		// 		client.Send (message);
		// 		client.Disconnect (true);
		// 	}
        // }
    }
}