using System.ComponentModel.DataAnnotations;

namespace LudwigRecipe.Api.Models
{
	public class LoginUserBindingModel
	{
		[Required]
		public string Username { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}