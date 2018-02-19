using LudwigsRecipe.Service.Models.Navigation;
using LudwigsRecipe.Service.Models.Recipe;
using LudwigsRecipe.Service.Services.Recipe;
using System.Web.Http;

namespace LudwigRecipe.Api.Api.Recipe
{
	public class RecipeController : ApiController
	{
		private readonly IRecipeService _recipeService;

		public RecipeController(IRecipeService recipeService)
		{
			_recipeService = recipeService;
		}

		[HttpGet]
		[Route("api/Recipe/Overview")]
		public RecipeOverviewViewModel Overview(int count, int skip, string category, string subCategory)
		{
			return _recipeService.LoadRecipeOverview(count, skip, category, subCategory, true);
		}

		[HttpGet]
		[Route("api/Recipe/Detail/{id}")]
		public RecipeDetailViewModel Detail(int id)
		{
			bool isFriend = User.IsInRole("Friend");
			RecipeDetailViewModel recipe = _recipeService.LoadRecipe(id, true);
			return recipe;
		}

		[HttpPost]
		[Route("api/Recipe/Search")]
		public SearchResultViewModel Search([FromBody]string term)
		{
			bool isFriend = User.IsInRole("Friend");
			return _recipeService.SearchRecipes(term, true);
		}
	}
	
}
