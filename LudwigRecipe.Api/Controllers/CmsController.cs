using LudwigsRecipe.Service.Models.Navigation;
using LudwigsRecipe.Service.Models.Recipe;
using LudwigsRecipe.Service.Services.Recipe;
using System;
using System.Web.Http;

namespace LudwigRecipe.Api.Api.Recipe
{
	[Authorize]
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

		[HttpGet]
		[Route("api/Cms/Recipe/{id}")]
		public RecipeEditViewModel GetRecipe(int id)
		{
			return _recipeService.LoadRecipeEditViewModel(id);
		}

		[HttpPost]
		[Route("api/Cms/Recipe")]
		public int Post([FromBody]RecipeEditViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return 0;
			}
			try
			{
				_recipeService.SaveRecipeEditViewModel(model);
				return model.Id;
			}
			catch (Exception e)
			{
				return 0;
			}
		}
	}
}
