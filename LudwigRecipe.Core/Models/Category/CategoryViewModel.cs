using System.Collections.Generic;

namespace LudwigRecipe.Core.Models.Category
{
	public class CategoryViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Url { get; set; }

		public bool IsMainMenu { get; set; }

		public int Order { get; set; }

		public List<SubCategoryViewModel> SubCategories { get; set; }

		public CategoryViewModel()
		{
			SubCategories = new List<SubCategoryViewModel>();
		}
	}
}
