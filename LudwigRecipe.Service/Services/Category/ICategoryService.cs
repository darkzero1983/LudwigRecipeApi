using LudwigsRecipe.Service.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LudwigsRecipe.Service.Services.Category
{
	public interface ICategoryService
	{
		void SaveCategories(CategoryEditViewModel categoryEdit);

		CategoryEditViewModel LoadCategoryEditViewModel();
	}
}
