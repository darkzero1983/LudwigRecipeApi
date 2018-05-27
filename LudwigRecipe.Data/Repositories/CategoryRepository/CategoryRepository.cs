using LudwigsRecipe.Data.DataModels.Category;
using System.Linq;
using System;
using System.Collections.Generic;
using LudwigRecipe.Data.DataContext;

namespace LudwigsRecipe.Data.Repositories.CategoryRepository
{
	public class CategoryRepository : ICategoryRepository
	{

		public int AddCategory(ICategoryData category)
		{
			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
		
				Category newCategory = new Category()
				{
					DisplayOrder = category.Order,
					IsDisplayInMainNavigation = category.IsMainMenu,
					Name = category.Name,
					Url = category.Url
				};
				context.Categories.Add(newCategory);
				context.SaveChanges();
				return newCategory.Id;
			}	
		}

		public int AddSubCategory(ISubCategoryData subCategory)
		{
			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
				Category category = context.Categories.FirstOrDefault(x => x.Id == subCategory.CategoryId);

				SubCategory newSubCategory = new SubCategory()
				{
					DisplayOrder = subCategory.Order,
					Name = subCategory.Name,
					Url = subCategory.Url,
					Category = category
				};
				context.SubCategories.Add(newSubCategory);
				context.SaveChanges();
				return newSubCategory.Id;
			}
		}


		public void SaveCategory(ICategoryData category)
		{
			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
				Category changeCategory = context.Categories.FirstOrDefault(x => x.Id == category.Id);

				changeCategory.DisplayOrder = category.Order;
				changeCategory.IsDisplayInMainNavigation = category.IsMainMenu;
				changeCategory.Name = category.Name;
				changeCategory.Url = category.Url;

				context.SaveChanges();
			}
		}

		public void SaveSubCategory(ISubCategoryData subCategory)
		{
			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
				SubCategory changeSubCategory = context.SubCategories.FirstOrDefault(x => x.Id == subCategory.Id);

				changeSubCategory.DisplayOrder = subCategory.Order;
				changeSubCategory.Name = subCategory.Name;
				changeSubCategory.Url = subCategory.Url;

				context.SaveChanges();
			}
		}

		public void DeleteCategoriesWhereNotInLIst(List<int> categoryIDs)
		{
			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
				List<Category> categories = context.Categories.Where(x => !categoryIDs.Contains(x.Id)).ToList();

				context.Categories.RemoveRange(categories);
				context.SaveChanges();
			}
		}

		public void DeleteSubCategoriesWhereNotInLIst(List<int> subCategoryIDs)
		{
			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
				List<SubCategory> subCategories = context.SubCategories.Where(x => !subCategoryIDs.Contains(x.Id)).ToList();

				context.SubCategories.RemoveRange(subCategories);
				context.SaveChanges();
			}
		}

		public List<ICategoryData> LoadCategories()
		{
			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
				List<ICategoryData> categories = new List<ICategoryData>();
				List<Category> dbCategories = context.Categories.ToList();
				foreach (Category category in dbCategories)
				{
					List<ISubCategoryData> subCategories = new List<ISubCategoryData>();

					foreach (SubCategory subCategory in category.SubCategories)
					{
						subCategories.Add(new SubCategoryData()
						{
							CategoryId = category.Id,
							Id = subCategory.Id,
							Name = subCategory.Name,
							Order = subCategory.DisplayOrder,
							Url = subCategory.Url
						});
					}

					categories.Add(new CategoryData()
					{
						Id = category.Id,
						IsMainMenu = category.IsDisplayInMainNavigation,
						Name = category.Name,
						Order = category.DisplayOrder,
						Url = category.Url,
						SubCategories = subCategories
					});
				}
				return categories;
			}
		}

		public List<ICategorySelectData> LoadCategoriesForRecipe(int recipeId)
		{
			
			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
				Recipe recipe = context.Recipes.FirstOrDefault(x => x.Id == recipeId);
				if(recipe == null)
				{
					return null;
				}

				List<int> selectedCategories = recipe.Categories.Select(x => x.Id).ToList<int>();
				List<int> selectedSubCategories = recipe.SubCategories.Select(x => x.Id).ToList<int>();

				List<ICategorySelectData> categories = new List<ICategorySelectData>();
				List<Category> dbCategories = context.Categories.ToList();
				foreach (Category category in dbCategories)
				{
					List<ISubCategorySelectData> subCategories = new List<ISubCategorySelectData>();

					foreach (SubCategory subCategory in category.SubCategories)
					{
						subCategories.Add(new SubCategorySelectData()
						{
							Id = subCategory.Id,
							Name = subCategory.Name,
							IsSelected = selectedSubCategories.Contains(subCategory.Id)
						});
					}

					categories.Add(new CategorySelectData()
					{
						Id = category.Id,
						Name = category.Name,
						IsSelected = selectedCategories.Contains(category.Id),
						SubCategoryDatas = subCategories
					});
				}
				return categories;
			}
		}

		public void AddAndRemoveCategoriesFromRecipe(List<int> categoryIds, int recipeId)
		{
			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
				Recipe recipe = context.Recipes.FirstOrDefault(x => x.Id == recipeId);
				if (recipe == null)
				{
					return;
				}

				recipe.Categories.Clear();
				context.SaveChanges();

				List<Category> categories = context.Categories.Where(x => categoryIds.Contains(x.Id)).ToList();
				foreach (Category category in categories)
				{
					recipe.Categories.Add(category);
				}
				context.SaveChanges();
			}
		}

		public void AddAndRemoveSubCategoriesFromRecipe(List<int> subCategoryIds, int recipeId)
		{
			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
				Recipe recipe = context.Recipes.FirstOrDefault(x => x.Id == recipeId);
				if (recipe == null)
				{
					return;
				}

				recipe.SubCategories.Clear();
				context.SaveChanges();

				List<SubCategory> subCategories = context.SubCategories.Where(x => subCategoryIds.Contains(x.Id)).ToList();
				foreach (SubCategory subCategory in subCategories)
				{
					recipe.SubCategories.Add(subCategory);
				}
				context.SaveChanges();
			}
		}

		public List<ICategoryData> LoadCategoriesWithRecipes(bool isFriend)
		{
			
			List<ICategoryData> categories = new List<ICategoryData>();
			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
				List<int> categoryIds = new List<int>();
				List<int> subCategoryIds = new List<int>();

				List<IEnumerable<int>> categoriesFromRecipeIds = context.Recipes.Where(x => x.IsPublished && x.PublishDate <= DateTime.Now).Select(x => x.Categories.Select(y => y.Id)).ToList();
				foreach (List<int> categoriesFromRecipeId in categoriesFromRecipeIds)
				{
					foreach (int categorieId in categoriesFromRecipeId)
					{
						if(!categoryIds.Contains(categorieId))
						{
							categoryIds.Add(categorieId);
						}
					}
				}

				List<IEnumerable<int>> subCategoriesFromRecipeIds = context.Recipes.Where(x => x.IsPublished && x.PublishDate <= DateTime.Now).Select(x => x.SubCategories.Select(y => y.Id)).ToList();
				foreach (List<int> subCategoriesFromRecipeId in subCategoriesFromRecipeIds)
				{
					foreach (int subCategorieId in subCategoriesFromRecipeId)
					{
						if (!subCategoryIds.Contains(subCategorieId))
						{
							subCategoryIds.Add(subCategorieId);
						}
					}
				}

				foreach (int categoryId in categoryIds)
				{
					List<ISubCategoryData> subCategories = new List<ISubCategoryData>();

					Category dbCategory = context.Categories.FirstOrDefault(x => x.Id == categoryId);
					List<SubCategory> dbSubCategories = context.SubCategories.Where(x => x.CategoryId == categoryId && subCategoryIds.Contains(x.Id)).ToList();

					if (dbSubCategories != null)
					{
						foreach (SubCategory subCategory in dbSubCategories)
						{
							if(subCategories.FirstOrDefault(x => x.Id == subCategory.Id) != null)
							{
								continue;
							}
							subCategories.Add(new SubCategoryData()
							{
								CategoryId = categoryId,
								Id = subCategory.Id,
								Name = subCategory.Name,
								Order = subCategory.DisplayOrder,
								Url = subCategory.Url
							});
						}
					}
					categories.Add(new CategoryData()
					{
						Id = dbCategory.Id,
						IsMainMenu = dbCategory.IsDisplayInMainNavigation,
						Name = dbCategory.Name,
						Order = dbCategory.DisplayOrder,
						Url = dbCategory.Url,
						SubCategories = subCategories
					});
				}


			}
			return categories;
		}

		public string LoadCategoryNameByUrl(string url)
		{
			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
				Category category = context.Categories.FirstOrDefault(x => x.Url == url);
				if (category == null)
				{
					return string.Empty;
				}
				return category.Name;
			}
		}

		public string LoadSubCategoryNameByUrl(string url)
		{
			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
				SubCategory subCategory = context.SubCategories.FirstOrDefault(x => x.Url == url);
				if (subCategory == null)
				{
					return string.Empty;
				}
				return subCategory.Name;
			}
		}
	}
}