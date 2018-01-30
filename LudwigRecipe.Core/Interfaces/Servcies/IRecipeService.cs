using LudwigRecipe.Core.Models.Recipe;

namespace LudwigRecipe.Core.Interfaces.Servcies
{
	public interface IRecipeService
	{
		RecipeOverviewViewModel LoadRecipeOverview();
	}
}
