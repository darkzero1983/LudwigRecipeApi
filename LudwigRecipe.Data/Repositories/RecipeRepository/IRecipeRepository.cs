using LudwigRecipe.Data.DataModels.Recipe;
using LudwigsRecipe.Data.DataModels.Recipe;
using LudwigsRecipe.Data.Helper;
using System.Collections.Generic;

namespace LudwigsRecipe.Data.Repositories.RecipeRepository
{
	public interface IRecipeRepository
	{
		List<IRecipeOverviewData> LoadOverviewRecipes(IRequestRecipe requestData);
		int LoadOverviewRecipesCount(IRequestRecipe requestData);
		IRecipeDetailData LoadRecipeDetail(int id, bool forPublicWeb, bool isFriend);
		IRecipeData LoadRecipe(int id);
		void DeleteRecipe(int id);
		int AddRecipe(IRecipeData recipe);
		void EditTeaserImage(int recipeId, string teaserImageUrl);
		void EditRecipe(IRecipeData recipe);

		List<IRecipeContent> LoadRecipeContents(int recipeId);
		void DeleteAllRecipeContents(int recipeId);
		void AddRecipeContent(int recipeId, IRecipeContent content);
	}
}
