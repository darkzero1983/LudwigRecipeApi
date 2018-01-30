using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LudwigsRecipe.Service.Models.Category;
using LudwigsRecipe.Data.Repositories.CategoryRepository;
using LudwigsRecipe.Data.DataModels.Category;

namespace LudwigsRecipe.Service.Services.Category
{
	public class CategoryService : ICategoryService
	{
		#region ctor
		private readonly ICategoryRepository _categoryRepository;

		public CategoryService(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}
		#endregion

		public void SaveCategories(CategoryEditViewModel categoryEdit)
		{
			foreach (CategoryViewModel category in categoryEdit.Categories)
			{
				if(category.Id == 0)
				{
					//Add new Category
					CategoryData newCategory = new CategoryData()
					{
						IsMainMenu = category.IsMainMenu,
						Name = category.Name,
						Order = category.Order,
						Url = category.Url
					};
					category.Id = _categoryRepository.AddCategory(newCategory);
				}
				else
				{
					//Update Category
					CategoryData changeCategory = new CategoryData()
					{
						Id = category.Id,
						IsMainMenu = category.IsMainMenu,
						Name = category.Name,
						Order = category.Order,
						Url = category.Url
					};
					_categoryRepository.SaveCategory(changeCategory);
				}
				foreach (SubCategoryViewModel subCategory in category.SubCategories)
				{
					if (subCategory.Id == 0)
					{
						//Add new SubCategory
						SubCategoryData newSubCategory = new SubCategoryData()
						{
							CategoryId = category.Id,
							Name = subCategory.Name,
							Order = subCategory.Order,
							Url = subCategory.Url
						};
						subCategory.Id = _categoryRepository.AddSubCategory(newSubCategory);
					}
					else
					{
						//Add new SubCategory
						SubCategoryData changeSubCategory = new SubCategoryData()
						{
							Id = subCategory.Id,
							CategoryId = category.Id,
							Name = subCategory.Name,
							Order = subCategory.Order,
							Url = subCategory.Url
						};
						_categoryRepository.SaveSubCategory(changeSubCategory);
					}
				}
			}

			List<int> deleteSubCategoryIds = categoryEdit.Categories.SelectMany(x => x.SubCategories.Select(y => y.Id)).Distinct().ToList();
			_categoryRepository.DeleteSubCategoriesWhereNotInLIst(deleteSubCategoryIds);

			List<int> deleteCategoryIds = categoryEdit.Categories.Select(x => x.Id).Distinct().ToList();
			_categoryRepository.DeleteCategoriesWhereNotInLIst(deleteCategoryIds);
		}

		public CategoryEditViewModel LoadCategoryEditViewModel()
		{
			CategoryEditViewModel model = new CategoryEditViewModel();

			List<ICategoryData> categories = _categoryRepository.LoadCategories();
			foreach (ICategoryData category in categories)
			{
				List<SubCategoryViewModel> subCategories = new List<SubCategoryViewModel>();

				foreach (ISubCategoryData subCategory in category.SubCategories)
				{
					subCategories.Add(new SubCategoryViewModel()
					{
						Id = subCategory.Id,
						Name = subCategory.Name,
						Order = subCategory.Order,
						Url = subCategory.Url
					});
					
				}

				model.Categories.Add(new CategoryViewModel()
				{
					Id = category.Id,
					IsMainMenu = category.IsMainMenu,
					Name = category.Name,
					Order = category.Order,
					Url = category.Url,
					SubCategories = subCategories
				});
				
			}
			return model;
		}
	}
}
