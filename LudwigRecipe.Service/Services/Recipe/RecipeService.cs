﻿using LudwigsRecipe.Service.Models.Recipe;
using LudwigsRecipe.Data.Repositories.RecipeRepository;
using System.Collections.Generic;
using LudwigsRecipe.Data.DataModels.Recipe;
using System;
using System.Linq;
using System.IO;
using LudwigsRecipe.Data.Repositories.IngredientListRepositories;
using LudwigsRecipe.Data.DataModels.IngredientList;
using LudwigsRecipe.Service.Models.Ingredient;
using LudwigsRecipe.Data.Repositories.IngredientRepository;
using LudwigsRecipe.Data.Repositories.MeasurementRepository;
using LudwigsRecipe.Data.Repositories.UserRepositories;
using LudwigsRecipe.Data.Repositories.SeoTagRepositories;
using LudwigsRecipe.Service.Models.Category;
using LudwigsRecipe.Data.Repositories.CategoryRepository;
using LudwigsRecipe.Data.DataModels.Category;
using LudwigsRecipe.Service.Models.Measurement;
using LudwigsRecipe.Data.DataModels.Measurement;
using LudwigsRecipe.Data.Helper;
using LudwigsRecipe.Service.Models.Navigation;
using DarkZero.Core.Extensions;
using LudwigRecipe.Data.DataModels.Recipe;
using LudwigRecipe.Service.Models.Recipe;

namespace LudwigsRecipe.Service.Services.Recipe
{
	public class RecipeService : IRecipeService
	{
		#region ctor
		private readonly IRecipeRepository _recipeRepository;
		private readonly IIngredientRepository _ingredientRepository;
		private readonly IMeasurementRepository _measurementRepository;
		private readonly IIngredientListRepository _ingredientListRepository;
		private readonly IUserRepository _userRepository;
		private readonly ISeoTagRepository _seoTagRepository;
		private readonly ICategoryRepository _categoryRespository;

		public RecipeService(IRecipeRepository recipeRepository, IIngredientRepository ingredientRepository, IMeasurementRepository measurementRepository, IIngredientListRepository ingredientListRepository, IUserRepository userRepository, ISeoTagRepository seoTagRepository, ICategoryRepository categoryRespository)
		{
			_recipeRepository = recipeRepository;
			_ingredientRepository = ingredientRepository;
			_measurementRepository = measurementRepository;
			_ingredientListRepository = ingredientListRepository;
			_userRepository = userRepository;
			_seoTagRepository = seoTagRepository;
			_categoryRespository = categoryRespository;
		}
		#endregion

		public SearchResultViewModel SearchRecipes(string term, bool isFriend)
		{
			int recipesPerPage = 8;
			RequestRecipe request = new RequestRecipe()
			{
				Top = recipesPerPage,
				ForPublicWeb = true,
				IsFriend = isFriend,
				SearchTerm = term
			};

			List<IRecipeOverviewData> recipes = _recipeRepository.LoadOverviewRecipes(request);
			if (recipes == null)
			{
				return null;
			}
			SearchResultViewModel model = new SearchResultViewModel()
			{
				SearchTerm = term
			};

			foreach (IRecipeOverviewData recipe in recipes)
			{
				model.Recipes.Add(new SearchResultRecipeViewModel()
				{
					Id = recipe.Id,
					Name = recipe.Name,
					TeaserImageUrl = String.IsNullOrEmpty(recipe.TeaserImageUrl) ? "default_teaser_image.png" : recipe.TeaserImageUrl,
					Url = recipe.Url
				});
			}
			return model;
		}

		public RecipeOverviewViewModel LoadRecipeOverview(int count, int skip, string category, string subCategory, bool isFriend)
		{
			string headline = "Top Rezepte";
			if(!String.IsNullOrEmpty(subCategory))
			{
				headline = "Rezepte zum Thema " + _categoryRespository.LoadSubCategoryNameByUrl(subCategory);
			}
			else if(!String.IsNullOrEmpty(category))
			{
				headline = "Rezepte zum Thema " + _categoryRespository.LoadCategoryNameByUrl(category);
			}
			RequestRecipe request = new RequestRecipe()
			{
				Top = count,
				ForPublicWeb = true,
				IsFriend = isFriend,
				CategoryUrl = category,
				SubCategoryUrl = subCategory
			};
			int recipeCount = _recipeRepository.LoadOverviewRecipesCount(request);
			request.Skip = skip;

			List<IRecipeOverviewData> recipes = _recipeRepository.LoadOverviewRecipes(request);

			return MapRecipeOverviewViewModel(recipes, recipeCount, headline);
		}

		public RecipeOverviewViewModel LoadRecipesFromCategories(int page, bool isFriend, string url)
		{
			int recipesPerPage = 10;
			RequestRecipe request = new RequestRecipe()
			{
				Top = recipesPerPage,
				ForPublicWeb = true,
				IsFriend = isFriend,
				CategoryUrl = url
			};
			int recipeCount = _recipeRepository.LoadOverviewRecipesCount(request);
			int maxPages = (int)(recipeCount / recipesPerPage);
			if (maxPages < ((decimal)recipeCount / (decimal)recipesPerPage))
			{
				maxPages = maxPages + 1;
			}

			if (page > maxPages)
			{
				page = maxPages;
			}
			request.Skip = (recipesPerPage * page) - recipesPerPage;
			if ((recipeCount - request.Skip) < request.Top)
			{
				request.Top = (recipeCount - request.Skip);
			}

			List<IRecipeOverviewData> recipes = _recipeRepository.LoadOverviewRecipes(request);
			string name = _categoryRespository.LoadCategoryNameByUrl(url);
			return MapRecipeOverviewViewModel(recipes, recipeCount, "Rezepte zum Thema " + name);
		}

		public RecipeOverviewViewModel LoadRecipesFromSubCategories(int page, bool isFriend, string url)
		{
			int recipesPerPage = 10;
			RequestRecipe request = new RequestRecipe()
			{
				Top = recipesPerPage,
				ForPublicWeb = true,
				IsFriend = isFriend,
				SubCategoryUrl = url
			};

			int recipeCount = _recipeRepository.LoadOverviewRecipesCount(request);
			int maxPages = (int)(recipeCount / recipesPerPage);
			if (maxPages < ((decimal)recipeCount / (decimal)recipesPerPage))
			{
				maxPages = maxPages + 1;
			}

			if (page > maxPages)
			{
				page = maxPages;
			}
			request.Skip = (recipesPerPage * page) - recipesPerPage;
			if ((recipeCount - request.Skip) < request.Top)
			{
				request.Top = (recipeCount - request.Skip);
			}

			List<IRecipeOverviewData> recipes = _recipeRepository.LoadOverviewRecipes(request);
			string name = _categoryRespository.LoadSubCategoryNameByUrl(url);
			return MapRecipeOverviewViewModel(recipes, recipeCount, "Rezepte zum Thema " + name);
		}

		public RecipeOverviewViewModel LoadCMSRecipes(int count, int skip)
		{
			RequestRecipe request = new RequestRecipe()
			{
				Top = count,
				Skip = skip,
				ForPublicWeb = false,
				IsFriend = true
			};
			int recipeCount = _recipeRepository.LoadOverviewRecipesCount(request);
			List<IRecipeOverviewData> recipes = _recipeRepository.LoadOverviewRecipes(request);
			return MapRecipeOverviewViewModel(recipes, recipeCount, "Rezept Übersicht");
		}

		private RecipeOverviewViewModel MapRecipeOverviewViewModel(List<IRecipeOverviewData> recipes, int count, string title)
		{
			RecipeOverviewViewModel model = new RecipeOverviewViewModel()
			{
				Title = title,
				Count = count
			};
			model.Title = title;
			foreach (IRecipeOverviewData recipe in recipes)
			{
				model.Recipes.Add(new RecipeOverviewRecipeViewModel()
				{
					Id = recipe.Id,
					Name = recipe.Name,
					Url = recipe.Url,
					Description = recipe.Description,
					PublishDate = recipe.PublishDate.ToString("MM.dd.yyyy"),
					TeaserImageUrl = String.IsNullOrEmpty(recipe.TeaserImageUrl) ? "default_teaser_image.png" : recipe.TeaserImageUrl
				});
			}
			return model;
		}

		public RecipeDetailViewModel LoadRecipe(int id, bool isFriend)
		{
			RecipeDetailViewModel model = null;

			IRecipeDetailData recipe = _recipeRepository.LoadRecipeDetail(id, true, isFriend);
			if (recipe != null)
			{
				model = new RecipeDetailViewModel()
				{
					Id = recipe.Id,
					Name = recipe.Name,
					Description = recipe.Description,
					Content = recipe.Content,
					PublishDate = recipe.PublishDate,
					TeaserImageUrl = String.IsNullOrEmpty(recipe.TeaserImageUrl) ? "default_teaser_image.png" : recipe.TeaserImageUrl,
					IngredientCount = recipe.IngredientCount,
					Measurement = new MeasurementViewModel() { Id = recipe.Measurement.Id, Name = recipe.Measurement.Name },
					PreparationTime = recipe.PreparationTime,
					WaitingTime = recipe.WaitingTime
				};

				if (model.Id != 0)
				{
					List<IIngredientListData> ingredientListDatas = _ingredientListRepository.LoadIngredientListFromRecipe(model.Id);
					foreach (IIngredientListData ingredientListData in ingredientListDatas)
					{
						model.Ingredients.Add(new IngredientsViewModel()
						{
							Amount = ingredientListData.Amount,
							Ingredient = ingredientListData.IngredientName,
							Measurement = ingredientListData.MeasurementName
						});
					}

				}

				if (model.Id != 0)
				{
					List<IRecipeContent> contentItems = _recipeRepository.LoadRecipeContents(model.Id);
					if(contentItems != null)
					{ 
						foreach (IRecipeContent contentItem in contentItems)
						{
							model.ContentItems.Add(new LudwigRecipe.Service.Models.Recipe.RecipeContent()
							{
								Id = contentItem.Id,
								Content = contentItem.Content,
								ContentType = (RecipeContentType)contentItem.RecipeContentTypeId,
								SortOrder = contentItem.SortOrder
							});
						}
					}

				}
			}
			return model;
		}

		public RecipeEditViewModel LoadRecipeEditViewModel(int id)
		{
			RecipeEditViewModel model = new RecipeEditViewModel();

			#region Recipe
			if (id == 0)
			{
				int Minute;
				if (DateTime.Now.Minute > 9)
				{
					Int32.TryParse(DateTime.Now.Minute.ToString().Substring(1), out Minute);
				}
				else
				{
					Minute = DateTime.Now.Minute;
				}
				model = new RecipeEditViewModel()
				{
					PublishDate = DateTime.Now.ToString("dd.MM.yyyy"),
					PublishHour = DateTime.Now.Hour,
					PublishMinute = (DateTime.Now.Minute - Minute),
					Content = @"<h2>Zubereitung</h2>
<ol>
	<li></li>
</ol>
<ol class=""no-number default-color"">
	<li><strong>Guten Appetit!</strong></li>
</ol>",
					TeaserImageUrl = "default_teaser_image.png"
				};
			}
			IRecipeData recipe = _recipeRepository.LoadRecipe(id);
			if (recipe != null)
			{
				model = new RecipeEditViewModel()
				{
					Id = recipe.Id,
					Name = recipe.Name,
					Description = recipe.Description,
					Content = recipe.Content,
					PublishDate = recipe.PublishDate.ToString("dd.MM.yyyy"),
					PublishHour = recipe.PublishDate.Hour,
					PublishMinute = recipe.PublishDate.Minute,
					IsPublished = recipe.IsPublished,
					IsOnlyForFriends = recipe.IsOnlyForFriends,
					TeaserImageUrl = String.IsNullOrEmpty(recipe.TeaserImageUrl) ? "default_teaser_image.png" : recipe.TeaserImageUrl,
					IngredientCount = recipe.IngredientCount,
					Measurement = (recipe.Measurement != null) ? recipe.Measurement.Name : "",
					PreparationTime = recipe.PreparationTime,
					WaitingTime = recipe.WaitingTime
				};
			}
			#endregion

			#region Ingredients
			if (model.Id != 0)
			{
				List<IIngredientListData> ingredientListDatas = _ingredientListRepository.LoadIngredientListFromRecipe(model.Id);
				foreach (IIngredientListData ingredientListData in ingredientListDatas)
				{
					model.IngredientList.Add(new IngredientListItemViewModel()
					{
						Id = ingredientListData.Id,
						Amount = ingredientListData.Amount,
						IngredientName = ingredientListData.IngredientName,
						MeasurementName = ingredientListData.MeasurementName
					});
				}
			}
			#endregion

			#region Categories
			List<ICategorySelectData> categoryDatas = _categoryRespository.LoadCategoriesForRecipe(model.Id);
			if(categoryDatas != null)
			{ 
				foreach (ICategorySelectData categoryData in categoryDatas)
				{
					List<SubCategoryToRecipeViewModel> subCategories = new List<SubCategoryToRecipeViewModel>();
					foreach (ISubCategorySelectData subCategoryData in categoryData.SubCategoryDatas)
					{
						subCategories.Add(new SubCategoryToRecipeViewModel()
						{
							Id = subCategoryData.Id,
							Name = subCategoryData.Name,
							IsSelected = subCategoryData.IsSelected
						});
					}
					model.Categories.Add(new CategoryToRecipeViewModel()
					{
						Id = categoryData.Id,
						Name = categoryData.Name,
						IsSelected = categoryData.IsSelected,
						SubCategories = subCategories
					});
				}
			}
			#endregion

			#region Content
			List<IRecipeContent> contents = _recipeRepository.LoadRecipeContents(model.Id);
			if(contents != null)
			{
				foreach (IRecipeContent content in contents)
				{
					model.ContentItems.Add(new LudwigRecipe.Service.Models.Recipe.RecipeContent()
					{
						Id = content.Id,
						Content = content.Content,
						ContentType = (RecipeContentType)content.RecipeContentTypeId,
						SortOrder = content.SortOrder
					});
				}
			}

			#endregion

			return model;
		}

		public void SaveRecipeEditViewModel(RecipeEditViewModel model)
		{
			#region Recipe
	
			int measurementRecipeId = _measurementRepository.FindOrAddMeasurement(model.Measurement);

			IRecipeData recipeData = new RecipeData()
			{
				Id = model.Id,
				Content = model.Content,
				Description = model.Description,
				IsPublished = model.IsPublished,
				IsOnlyForFriends = model.IsOnlyForFriends,
				Name = model.Name,
				Url = model.Name.BuildUrl(),
				PublishDate = ConvertPublishDate(model.PublishDate, model.PublishHour, model.PublishMinute),
				IngredientCount = model.IngredientCount,
				Measurement = new MeasurementData() { Id = measurementRecipeId, Name = model.Measurement },
				PreparationTime = model.PreparationTime,
				WaitingTime = model.WaitingTime,
				TeaserImageUrl = model.TeaserImageUrl
			};
			if (model.Id == 0)
			{
				model.Id = _recipeRepository.AddRecipe(recipeData);
			}
			else
			{
				_recipeRepository.EditRecipe(recipeData);
			}
			#endregion

			#region TeaserImage
			if (model.TeaserImageUrl != null && model.TeaserImageUrl.ToLower().StartsWith("/upload/"))
			{
				string fileName = model.TeaserImageUrl.ToLower().Replace("/upload/", "");
				string newFileName = fileName.BuildUrl();
				string mediaPath;
				string mediaExtension = "";
#if DEBUG
				mediaPath = "D:\\Dropbox\\Dokumente Peter\\Visual Studio\\ImageManager\\ImageManager.Web\\media\\LudwigsRezepte";
#else
				mediaPath = "C:\\DarkZero\\Dropbox\\DarkServer\\Webs\\ImageManager\\media\\LudwigsRezepte";
#endif

				mediaPath = mediaPath + "\\" + model.Id + "\\teaser\\";
				string uploadPath = Path.Combine(Environment.CurrentDirectory, "upload\\");

				Directory.CreateDirectory(mediaPath);
				if (File.Exists(mediaPath + newFileName))
				{
					File.Delete(mediaPath + newFileName);
				}
				if (File.Exists(uploadPath + fileName))
				{
					File.Move(uploadPath + fileName, mediaPath + newFileName);
				}

				string imageUrl = model.Id + "/teaser/" + newFileName;
				_recipeRepository.EditTeaserImage(model.Id, imageUrl);
			}
#endregion

			#region IngredientList
			if (model.IngredientList != null)
			{

				List<int> IngredientListIds = new List<int>();
				int ingredientListOrder = 0;
				int measurementId;
				int ingredientId;
				foreach (IngredientListItemViewModel ingredientListItemViewModel in model.IngredientList)
				{
					measurementId = _measurementRepository.FindOrAddMeasurement(ingredientListItemViewModel.MeasurementName);
					ingredientId = _ingredientRepository.FindOrAddIngredient(ingredientListItemViewModel.IngredientName);
				

					if (measurementId != 0 && ingredientId != 0)
					{
						ingredientListOrder = ingredientListOrder + 1;
						IngredientListIds.Add(_ingredientListRepository.AddOrUpdateIngredientListFromRecipe(new IngredientListData()
						{
							Id = ingredientListItemViewModel.Id,
							Amount = ingredientListItemViewModel.Amount,
							SortOrder = ingredientListOrder,
							IngredientId = ingredientId,
							MeasurementId = measurementId,
							RecipeId = model.Id
						}));
					}
				}
				_ingredientListRepository.DeleteIngredientListFromRecipeWhereNotInList(IngredientListIds, model.Id);
			}
#endregion

			#region Categories
			List<int> categoryIds = model.Categories.Where(x => x.IsSelected == true).Select(x => x.Id).ToList();
			_categoryRespository.AddAndRemoveCategoriesFromRecipe(categoryIds, model.Id);
			List<int> subCategoryIds = model.Categories.SelectMany(x => x.SubCategories).Where(x => x.IsSelected == true).Select(x => x.Id).ToList<int>();
			_categoryRespository.AddAndRemoveSubCategoriesFromRecipe(subCategoryIds, model.Id);
			#endregion

			#region Contents
			_recipeRepository.DeleteAllRecipeContents(model.Id);
			int sortOrder = 1;
			foreach (var contentItem in model.ContentItems.OrderBy(x => x.SortOrder))
			{
				if(String.IsNullOrWhiteSpace(contentItem.Content))
				{
					continue;
				}
				_recipeRepository.AddRecipeContent(model.Id, new LudwigRecipe.Data.DataModels.Recipe.RecipeContent()
				{
					Content = contentItem.Content,
					RecipeContentTypeId = (int)contentItem.ContentType,
					SortOrder = sortOrder
				});
				sortOrder = sortOrder + 1;
			}
			#endregion
		}

		public void DeleteRecipe(int id)
		{
			_recipeRepository.DeleteRecipe(id);
		}

		private DateTime ConvertPublishDate(string date, int hour, int minute)
		{
			int year = DateTime.Now.Year;
			int month = DateTime.Now.Month;
			int day = DateTime.Now.Day;
			string[] dateParts = date.Split('.');
			if (dateParts.Length == 3)
			{
				int.TryParse(dateParts[2], out year);
				int.TryParse(dateParts[1], out month);
				int.TryParse(dateParts[0], out day);
			}
			return new DateTime(year, month, day, hour, minute, 0);
		}
	}
}