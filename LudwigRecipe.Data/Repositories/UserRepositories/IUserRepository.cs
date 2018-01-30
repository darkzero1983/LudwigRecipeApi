using LudwigsRecipe.Data.DataModels.User;
using System.Collections.Generic;

namespace LudwigsRecipe.Data.Repositories.UserRepositories
{
	public interface IUserRepository
	{
		List<IUserData> LoadAuthors();
		List<IUserData> LoadAuthorsFromRecipe(int recipeId);
		void AddAndRemoveAuthorsFromRecipe(List<string> authorIds, int recipeId);
	}
}