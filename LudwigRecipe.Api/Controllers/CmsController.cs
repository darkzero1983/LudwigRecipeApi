using LudwigsRecipe.Service.Models.Navigation;
using LudwigsRecipe.Service.Models.Recipe;
using LudwigsRecipe.Service.Services.Recipe;
using System.Web.Http;

namespace LudwigRecipe.Api.Api.Recipe
{
	public class CmsController : ApiController
	{
		private readonly IRecipeService _recipeService;

		public CmsController(IRecipeService recipeService)
		{
			_recipeService = recipeService;
		}

		[HttpGet]
		[Route("api/Cms/Recipe/Overview")]
		public RecipeOverviewViewModel Overview(int count, int skip)
		{
			return _recipeService.LoadCMSRecipes(count, skip);
		}
	}
}
