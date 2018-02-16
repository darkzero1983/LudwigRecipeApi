using LudwigsRecipe.Service.Models.Recipe;
using LudwigsRecipe.Service.Services.Recipe;
using System.Web.Http;

namespace LudwigRecipe.Api.Api.Recipe
{
	public class RecipeOverviewController : ApiController
	{
		private readonly IRecipeService _recipeService;

		public RecipeOverviewController(IRecipeService recipeService)
		{
			_recipeService = recipeService;
		}

		[Route("api/Recipe/Overview")]
		[HttpGet]
		public RecipeOverviewViewModel Overview(int count, int skip, string category, string subCategory)
		{

			return _recipeService.LoadRecipeOverview(count, skip, category, subCategory, true);
		}

	}
	
}
