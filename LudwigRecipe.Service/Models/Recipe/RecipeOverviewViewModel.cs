using LudwigsRecipe.Service.Models.Paging;
using System.Collections.Generic;

namespace LudwigsRecipe.Service.Models.Recipe
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
