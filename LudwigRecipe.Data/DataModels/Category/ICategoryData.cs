using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LudwigsRecipe.Data.DataModels.Category
{
	public interface ICategoryData
	{
		int Id { get; set; }

		string Name { get; set; }

		string Url { get; set; }

		bool IsMainMenu { get; set; }

		int Order { get; set; }

		List<ISubCategoryData> SubCategories { get; set; }
	}
}
