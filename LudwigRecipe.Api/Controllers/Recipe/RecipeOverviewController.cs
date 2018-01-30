using LudwigsRecipe.Service.Models.Recipe;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LudwigRecipe.Api.Api.Recipe
{
	[Route("Recipe/Overview")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class RecipeOverviewController : ApiController
	{
		[HttpGet]
		public RecipeOverviewViewModel Get(int count, int skip, string category, string subCategory)
		{
			RecipeOverviewViewModel result = new RecipeOverviewViewModel();

			result.Title = "Rezepte von der APIs2";
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
