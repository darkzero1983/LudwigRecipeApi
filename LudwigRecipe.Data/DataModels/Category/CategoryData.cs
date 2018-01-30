using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LudwigsRecipe.Data.DataModels.Category
{
	public class CategoryData : ICategoryData
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Url { get; set; }

		public bool IsMainMenu { get; set; }

		public int Order { get; set; }

		public List<ISubCategoryData> SubCategories { get; set; }

		public CategoryData()
		{
			SubCategories = new List<ISubCategoryData>();
		}
	}
}
