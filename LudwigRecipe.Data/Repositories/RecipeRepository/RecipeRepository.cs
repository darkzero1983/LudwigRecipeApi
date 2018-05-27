using LudwigsRecipe.Data.DataModels.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using LudwigsRecipe.Data.DataModels.Measurement;
using LudwigsRecipe.Data.Helper;
using LudwigRecipe.Data.DataContext;
using LudwigRecipe.Data.DataModels.Recipe;

namespace LudwigsRecipe.Data.Repositories.RecipeRepository
{
	public class RecipeRepository : IRecipeRepository
	{
	
		public List<IRecipeOverviewData> LoadOverviewRecipes(IRequestRecipe requestData)
		{
			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
				List<IRecipeOverviewData> data = new List<IRecipeOverviewData>();

				var recipeQuery = context.Recipes.AsQueryable();

				if (!String.IsNullOrEmpty(requestData.SearchTerm))
				{
					recipeQuery = recipeQuery.Where(x => x.Name.Contains(requestData.SearchTerm));
				}

				if (!String.IsNullOrEmpty(requestData.CategoryUrl))
				{
					Category category = context.Categories.FirstOrDefault(x => x.Url == requestData.CategoryUrl);
					if (category != null)
					{
						recipeQuery = recipeQuery.Where(x => x.Categories.FirstOrDefault(y => y.Id == category.Id) != null);
					}

				}

				if (!String.IsNullOrEmpty(requestData.SubCategoryUrl))
				{
					SubCategory subCategory = context.SubCategories.FirstOrDefault(x => x.Url == requestData.SubCategoryUrl);
					if (subCategory != null)
					{
						recipeQuery = recipeQuery.Where(x => x.SubCategories.FirstOrDefault(y => y.Id == subCategory.Id) != null);
					}
				}


				if (requestData.ForPublicWeb)
				{
					recipeQuery = recipeQuery.Where(x => x.IsPublished == true && x.PublishDate <= DateTime.Now);
				}

				if (!requestData.IsFriend)
				{
					recipeQuery = recipeQuery.Where(x => x.IsOnlyForFriends == false);
				}

				recipeQuery = recipeQuery.OrderByDescending(x => x.PublishDate);

				if (requestData.Skip > 0)
				{
					recipeQuery = recipeQuery.Skip(requestData.Skip);
				}
				if (requestData.Top > 0)
				{
					recipeQuery = recipeQuery.Take(requestData.Top);
				}
				try
				{
					var recipes = recipeQuery.ToList();

					foreach (var recipe in recipes)
					{
						data.Add(new RecipeOverviewData()
						{
							Id = recipe.Id,
							Name = recipe.Name,
							Url = recipe.Url,
							Description = recipe.Description,
							PublishDate = recipe.PublishDate,
							TeaserImageUrl = recipe.TeaserImageUrl
						});
					}
				}
				catch (Exception exception)
				{
				}

				return data;
			}
		}

		public int LoadOverviewRecipesCount(IRequestRecipe requestData)
		{
			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
				List<IRecipeOverviewData> data = new List<IRecipeOverviewData>();

				var recipeQuery = context.Recipes.AsQueryable();

				int categoryId = 0;
				if (!String.IsNullOrEmpty(requestData.CategoryUrl))
				{
					Category category = context.Categories.FirstOrDefault(x => x.Url == requestData.CategoryUrl);
					if (category != null)
					{
						categoryId = category.Id;
						recipeQuery = recipeQuery.Where(x => x.Categories.FirstOrDefault(y => y.Id == category.Id) != null);
					}

				}

				int subCategoryId = 0;
				if (!String.IsNullOrEmpty(requestData.SubCategoryUrl))
				{
					SubCategory subCategory = context.SubCategories.FirstOrDefault(x => x.Url == requestData.SubCategoryUrl);
					if (subCategory != null)
					{
						recipeQuery = recipeQuery.Where(x => x.SubCategories.FirstOrDefault(y => y.Id == subCategory.Id && y.CategoryId == categoryId) != null);
					}
				}

				if (requestData.ForPublicWeb)
				{
					recipeQuery = recipeQuery.Where(x => x.IsPublished == true && x.PublishDate <= DateTime.Now);
				}

				if (!requestData.IsFriend)
				{
					recipeQuery = recipeQuery.Where(x => x.IsOnlyForFriends == false);
				}

				try
				{
					var recipes = recipeQuery.ToList();
					return recipes.Count();
				}
				catch (Exception exception)
				{
				}

				return 0;
			}
		}

		public IRecipeDetailData LoadRecipeDetail(int id, bool forPublicWeb, bool isFriend)
		{
			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
				IRecipeDetailData recipe = null;

				var dbRecipeQuery = context.Recipes.AsQueryable();

				dbRecipeQuery = dbRecipeQuery.Where(x => x.Id == id);

				if (forPublicWeb)
				{
					dbRecipeQuery = dbRecipeQuery.Where(x => x.IsPublished == true && x.PublishDate <= DateTime.Now);
				}
				if (!isFriend)
				{
					dbRecipeQuery = dbRecipeQuery.Where(x => x.IsOnlyForFriends == false);
				}

				var dbRecipe = dbRecipeQuery.FirstOrDefault();

				if (dbRecipe != null)
				{
					recipe = new RecipeDetailData()
					{
						Id = dbRecipe.Id,
						Name = dbRecipe.Name,
						Description = dbRecipe.Description,
						Content = dbRecipe.Content,
						PublishDate = dbRecipe.PublishDate,
						Url = dbRecipe.Url,
						TeaserImageUrl = dbRecipe.TeaserImageUrl,
						IngredientCount = dbRecipe.IngredientCount,
						Measurement = (dbRecipe.Measurement != null) ? new MeasurementData() { Id = dbRecipe.Measurement.Id, Name = dbRecipe.Measurement.Name } : null,
						PreparationTime = dbRecipe.PreparationTime,
						WaitingTime = dbRecipe.WaitingTime
					};
				}

				return recipe;
			}
		}

		public IRecipeData LoadRecipe(int id)
		{
			IRecipeData recipe = null;

			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
				try
				{
					var dbRecipeQuery = context.Recipes.AsQueryable();

					dbRecipeQuery = dbRecipeQuery.Where(x => x.Id == id);

					var dbRecipe = dbRecipeQuery.FirstOrDefault();

					if (dbRecipe != null)
					{
						recipe = new RecipeData()
						{
							Id = dbRecipe.Id,
							IsPublished = dbRecipe.IsPublished,
							IsOnlyForFriends = dbRecipe.IsOnlyForFriends,
							Name = dbRecipe.Name,
							Description = dbRecipe.Description,
							Content = dbRecipe.Content,
							PublishDate = dbRecipe.PublishDate,
							Url = dbRecipe.Url,
							TeaserImageUrl = dbRecipe.TeaserImageUrl,
							IngredientCount = dbRecipe.IngredientCount,
							Measurement = (dbRecipe.Measurement != null) ? new MeasurementData() { Id = dbRecipe.Measurement.Id, Name = dbRecipe.Measurement.Name } : new MeasurementData(),
							PreparationTime = dbRecipe.PreparationTime,
							WaitingTime = dbRecipe.WaitingTime
						};
					}
				}
				catch (Exception e)
				{
				}
			}
			return recipe;
		}

		public int AddRecipe(IRecipeData recipe)
		{
			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
				Measurement measurement = null;
				if (recipe.Measurement != null && recipe.Measurement.Id != 0)
				{
					measurement = context.Measurements.FirstOrDefault(x => x.Id == recipe.Measurement.Id);
				}

				Recipe dbRecipe = new Recipe()
				{
					Name = recipe.Name,
					Description = recipe.Description,
					Content = recipe.Content,
					IsPublished = recipe.IsPublished,
					IsOnlyForFriends = recipe.IsOnlyForFriends,
					PublishDate = recipe.PublishDate,
					Url = recipe.Url,
					IngredientCount = recipe.IngredientCount,
					Measurement = measurement,
					PreparationTime = recipe.PreparationTime,
					WaitingTime = recipe.WaitingTime
				};
				context.Recipes.Add(dbRecipe);
				context.SaveChanges();

				recipe.Id = dbRecipe.Id;
				return recipe.Id;
			}
		}

		public void EditRecipe(IRecipeData recipe)
		{
			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
				Recipe dbRecipe = context.Recipes.FirstOrDefault(x => x.Id == recipe.Id);
				if (dbRecipe == null)
				{
					return;
				}

				Measurement measurement = context.Measurements.FirstOrDefault(x => x.Id == recipe.Measurement.Id);

				dbRecipe.Name = recipe.Name;
				dbRecipe.Description = recipe.Description;
				dbRecipe.Content = recipe.Content;
				dbRecipe.IsPublished = recipe.IsPublished;
				dbRecipe.IsOnlyForFriends = recipe.IsOnlyForFriends;
				dbRecipe.PublishDate = recipe.PublishDate;
				dbRecipe.Url = recipe.Url;
				dbRecipe.IngredientCount = recipe.IngredientCount;
				dbRecipe.Measurement = measurement;
				dbRecipe.PreparationTime = recipe.PreparationTime;
				dbRecipe.WaitingTime = recipe.WaitingTime;
				context.SaveChanges();
			}
		}

		public void DeleteRecipe(int id)
		{
			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
				context.Recipes.Remove(context.Recipes.FirstOrDefault(x => x.Id == id));
				context.SaveChanges();
			}
		}

		public void EditTeaserImage(int recipeId, string teaserImageUrl)
		{
			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
				Recipe dbRecipe = context.Recipes.FirstOrDefault(x => x.Id == recipeId);
				if (dbRecipe == null)
				{
					return;
				}

				dbRecipe.TeaserImageUrl = teaserImageUrl;

				context.SaveChanges();
			}
		}

		public List<IRecipeContent> LoadRecipeContents(int recipeId)
		{
			List<IRecipeContent> contents = new List<IRecipeContent>();

			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
				try
				{
					var recipeContents = context.RecipeContents.Where(x => x.RecipeId == recipeId).ToList();
					if(recipeContents == null)
					{
						return contents;
					}

					foreach (var recipeContent in recipeContents)
					{
						contents.Add(new LudwigRecipe.Data.DataModels.Recipe.RecipeContent()
						{
							Id = recipeContent.Id,
							RecipeContentTypeId = recipeContent.RecipeContentType.Id,
							Content = recipeContent.Content,
							SortOrder = recipeContent.SortOrder
						});
					}
				}
				catch (Exception e)
				{
				}
			}
			return contents;
		}

		public void DeleteAllRecipeContents(int recipeId)
		{
			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
				context.RecipeContents.RemoveRange(context.RecipeContents.Where(x => x.RecipeId == recipeId));
				context.SaveChanges();
			}
		}

		public void AddRecipeContent(int recipeId, IRecipeContent content)
		{
			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
				context.RecipeContents.Add(new LudwigRecipe.Data.DataContext.RecipeContent()
				{
					RecipeId = recipeId,
					Content = content.Content,
					ContentTypeId = content.RecipeContentTypeId,
					SortOrder = content.SortOrder
				});
				context.SaveChanges();
			}
		}
	}
}