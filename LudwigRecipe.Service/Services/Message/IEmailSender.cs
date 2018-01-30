using LudwigsRecipe.Service.Models.Contact;
using System;
using System.Threading.Tasks;

namespace LudwigsRecipe.Service.Services.Message
{
	public interface IEmailSender
	{
		Task SendRegisterValidationMail(string email, string subject, string message);
		Task SendContactMail(ContactViewModel model);
		Task SendErrorMail(Exception error);
	}
}
