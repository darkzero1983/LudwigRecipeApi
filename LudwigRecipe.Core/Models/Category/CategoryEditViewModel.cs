using System.Collections.Generic;

namespace LudwigRecipe.Core.Models.Category
{
	public class CategoryEditViewModel
	{
		public List<CategoryViewModel> Categories { get; set; }

		public CategoryEditViewModel()
		{
			Categories = new List<CategoryViewModel>();
		}
	}
}
