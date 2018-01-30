using LudwigsRecipe.Service.Models.Recipe;
using System.Web.Http;

namespace LudwigRecipe.Api.Api.Recipe
{
	[Route("Recipe/Overview")]
	public class RecipeOverviewController : ApiController
	{
		[HttpGet]
		public RecipeOverviewViewModel Get()
		{
			RecipeOverviewViewModel result = new RecipeOverviewViewModel();

			result.title = "Rezepte von der API";
			return result;
		}

		/*
		[HttpGet]
		public RecipeOverviewViewModel Get(int? page, string categoryUrl, string subCategoryUrl)
		{
			RecipeOverviewViewModel result = new RecipeOverviewViewModel();

			result.Title = "Rezepte von der API";
			return result;
		}
		*/
	}
	
}
