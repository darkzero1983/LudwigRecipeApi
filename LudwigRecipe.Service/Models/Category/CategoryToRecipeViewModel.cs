using System.Collections.Generic;

namespace LudwigsRecipe.Service.Models.Category
{
	public class CategoryToRecipeViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public bool IsSelected { get; set; }
		public List<SubCategoryToRecipeViewModel> SubCategories { get; set; }

		public CategoryToRecipeViewModel()
		{
			SubCategories = new List<SubCategoryToRecipeViewModel>();
		}
	}
}
