using System.Threading.Tasks;

//using MailKit.Net.Smtp;
//using MimeKit;
using LudwigsRecipe.Service.Models.Contact;
using System.Net;
using System;

namespace LudwigsRecipe.Service.Services.Message
{
	public class MessageService : IEmailSender
	{
		public Task SendRegisterValidationMail(string email, string subject, string message)
		{

			/*
			var mail = new MimeMessage();
			mail.From.Add(new MailboxAddress("Ludwigs Rezepte", "anmeldung@ludwigs-rezepte.de"));
			mail.To.Add(new MailboxAddress(email, email));
			mail.Subject = subject;

			var builder = new BodyBuilder();

			builder.HtmlBody = message;
			mail.Body = builder.ToMessageBody();

			using (var client = new SmtpClient())
			{
				client.Connect("mail.ludwigs-rezepte.de", 25, false);
				
				client.Authenticate("anmeldung@ludwigs-rezepte.de", "P47hf1nd3r");

				client.Send(mail);
				client.Disconnect(true);
			}

			return Task.FromResult(0);
			*/
			return null;
		}

		public Task SendContactMail(ContactViewModel model)
		{
			/*
			var mail = new MimeMessage();
			string email = "kontakt@ludwigs-rezepte.de";
			mail.From.Add(new MailboxAddress(model.Name, model.Email));
			mail.To.Add(new MailboxAddress(email, email));
			mail.Subject = "Kontaktanfrage Ludwigs-Rezepte.de";

			var builder = new BodyBuilder();

			builder.HtmlBody = "<strong>Kontaktanfrage</strong>:<br><br>" + WebUtility.HtmlEncode(model.Content).Replace("\n", "<br>");
			mail.Body = builder.ToMessageBody();

			using (var client = new SmtpClient())
			{
				client.Connect("mail.ludwigs-rezepte.de", 25, false);
				
				client.Authenticate(email, "P47hf1nd3r");

				client.Send(mail);
				client.Disconnect(true);
			}

			return Task.FromResult(0);
			*/
			return null;
		}

		public Task SendErrorMail(Exception error)
		{
			/*
			var mail = new MimeMessage();
			string email = "logging@ludwigs-rezepte.de";
			mail.From.Add(new MailboxAddress("Logging Ludwigs-Rezepte", email));
			mail.To.Add(new MailboxAddress(email, email));
			mail.Subject = error.Message;

			var builder = new BodyBuilder();

			builder.HtmlBody = error.StackTrace.Replace("\r\n","<br>");
			mail.Body = builder.ToMessageBody();

			using (var client = new SmtpClient())
			{
				client.Connect("mail.ludwigs-rezepte.de", 25, false);

				client.Authenticate(email, "P47hf1nd3r");

				client.Send(mail);
				client.Disconnect(true);
			}

			return Task.FromResult(0);
			*/
			return null;
		}
	}
}
