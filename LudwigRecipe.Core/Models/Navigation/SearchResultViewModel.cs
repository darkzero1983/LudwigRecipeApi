using System.Collections.Generic;

namespace LudwigRecipe.Core.Models.Navigation
{
	public class SearchResultViewModel
	{
		public string SearchTerm { get; set; }
		public List<SearchResultRecipeViewModel> Recipes { get; set; }
		public SearchResultViewModel()
		{
			Recipes = new List<SearchResultRecipeViewModel>();
		}
	}
}
