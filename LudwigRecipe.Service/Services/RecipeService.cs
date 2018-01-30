using LudwigRecipe.Core.Interfaces.Servcies;
using LudwigRecipe.Core.Models.Recipe;

namespace LudwigRecipe.Service.Services
{
	public class RecipeService : IRecipeService
	{
		public RecipeOverviewViewModel LoadRecipeOverview()
		{
			return new RecipeOverviewViewModel()
			{
				Title = "From Ninject Service"
			};
		}
	}
}
