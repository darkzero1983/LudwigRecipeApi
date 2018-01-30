using LudwigRecipe.Core.Models.Paging;
using System.Collections.Generic;

namespace LudwigRecipe.Core.Models.Recipe
{
	public class RecipeOverviewViewModel
	{
		public string Title { get; set; }
		public List<RecipeOverviewRecipeViewModel> Recipes { get; set; }

		public PagingViewModel Paging { get; set; }

		public RecipeOverviewViewModel()
		{
			Recipes = new List<RecipeOverviewRecipeViewModel>();
			Paging = new PagingViewModel();
		}
	}
}
