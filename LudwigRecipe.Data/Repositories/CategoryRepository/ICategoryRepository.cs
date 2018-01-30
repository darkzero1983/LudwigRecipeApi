using LudwigsRecipe.Data.DataModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LudwigsRecipe.Data.Repositories.CategoryRepository
{
	public interface ICategoryRepository
	{
		int AddCategory(ICategoryData category);
		int AddSubCategory(ISubCategoryData subCategory);

		void SaveCategory(ICategoryData category);
		void SaveSubCategory(ISubCategoryData subCategory);

		void DeleteCategoriesWhereNotInLIst(List<int> categoryIDs);
		void DeleteSubCategoriesWhereNotInLIst(List<int> subCategoryIDs);

		List<ICategoryData> LoadCategories();
		List<ICategorySelectData> LoadCategoriesForRecipe(int recipeId);

		void AddAndRemoveCategoriesFromRecipe(List<int> categoryIds, int recipeId);
		void AddAndRemoveSubCategoriesFromRecipe(List<int> subCategoryIds, int recipeId);

		List<ICategoryData> LoadCategoriesWithRecipes(bool isFriend);
		string LoadCategoryNameByUrl(string url);
		string LoadSubCategoryNameByUrl(string url);
	}
}
