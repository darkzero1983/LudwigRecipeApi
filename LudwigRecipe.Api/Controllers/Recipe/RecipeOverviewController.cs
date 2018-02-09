using LudwigsRecipe.Service.Models.Recipe;
using LudwigsRecipe.Service.Services.Recipe;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LudwigRecipe.Api.Api.Recipe
{
	[Route("Recipe/Overview")]
	public class RecipeOverviewController : ApiController
	{
		private readonly IRecipeService _recipeService;

		public RecipeOverviewController(IRecipeService recipeService)
		{
			_recipeService = recipeService;
		}


		[HttpGet]
		public RecipeOverviewViewModel Get(int count, int skip, string category, string subCategory)
		{
			return _recipeService.LoadRecipeOverview(count, skip, category, subCategory, true);
		}

	}
	
}
