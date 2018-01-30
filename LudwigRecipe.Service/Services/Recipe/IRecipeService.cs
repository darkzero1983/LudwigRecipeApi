using LudwigsRecipe.Service.Models.Navigation;
using LudwigsRecipe.Service.Models.Recipe;

namespace LudwigsRecipe.Service.Services.Recipe
{
	public interface IRecipeService
	{
		SearchResultViewModel SearchRecipes(string term, bool isFriend);
		RecipeOverviewViewModel LoadTopRecipes(int page, bool isFriend);
		RecipeOverviewViewModel LoadRecipesFromCategories(int page, bool isFriend, string url);
		RecipeOverviewViewModel LoadRecipesFromSubCategories(int page, bool isFriend, string url);
		RecipeOverviewViewModel LoadCMSRecipes();
		RecipeDetailViewModel LoadRecipe(int id, bool isFriend);

		RecipeEditViewModel LoadRecipeEditViewModel(int id);

		void SaveRecipeEditViewModel(RecipeEditViewModel model);

		void DeleteRecipe(int id);
	}
}
