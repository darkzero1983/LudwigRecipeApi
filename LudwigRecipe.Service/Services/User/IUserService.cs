using LudwigsRecipe.Service.Models.User;
using System.Collections.Generic;

namespace LudwigsRecipe.Service.Services.User
{
	public interface IUserService
	{
		List<AuthorViewModel> LoadAuthors();
	}
}
