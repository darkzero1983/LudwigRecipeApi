using LudwigRecipe.Data.DataContext;
using LudwigsRecipe.Data.DataModels.IngredientList;

using System.Collections.Generic;
using System.Linq;

namespace LudwigsRecipe.Data.Repositories.IngredientListRepositories
{
	public class IngredientListRepository : IIngredientListRepository
	{
		public List<IIngredientListData> LoadIngredientListFromRecipe(int recipeId)
		{
			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
				List<IIngredientListData> ingredientLists = new List<IIngredientListData>();
				List<IngredientList> dbIngredientLists = context.IngredientLists.Where(x => x.Recipe.Id == recipeId).OrderBy(y => y.SortOrder).ToList();

				foreach (IngredientList dbIngredientList in dbIngredientLists)
				{
					ingredientLists.Add(new IngredientListData()
					{
						Id = dbIngredientList.Id,
						Amount = dbIngredientList.Amount,
						IngredientId = dbIngredientList.Ingredient.Id,
						IngredientName = dbIngredientList.Ingredient.Name,
						MeasurementId = dbIngredientList.Measurement.Id,
						MeasurementName = dbIngredientList.Measurement.Name,
						SortOrder = dbIngredientList.SortOrder,
						RecipeId = recipeId
					});
				}
				return ingredientLists;
			}
		}

		public int AddOrUpdateIngredientListFromRecipe(IIngredientListData ingredientListData)
		{
			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
				if (ingredientListData.IngredientId == 0 || ingredientListData.MeasurementId == 0)
				{
					return 0;
				}

				Recipe recipe = context.Recipes.FirstOrDefault(x => x.Id == ingredientListData.RecipeId);
				if (recipe == null)
				{
					return 0;
				}

				Measurement measurement = context.Measurements.FirstOrDefault(x => x.Id == ingredientListData.MeasurementId);
				if (measurement == null)
				{
					return 0;
				}

				Ingredient ingredient = context.Ingredients.FirstOrDefault(x => x.Id == ingredientListData.IngredientId);
				if (ingredient == null)
				{
					return 0;
				}

				if (ingredientListData.Id == 0)
				{
					IngredientList dbIngredientList = new IngredientList()
					{
						Amount = ingredientListData.Amount,
						Ingredient = ingredient,
						Measurement = measurement,
						Recipe = recipe,
						SortOrder = ingredientListData.SortOrder
					};
					context.IngredientLists.Add(dbIngredientList);
					context.SaveChanges();
					return dbIngredientList.Id;
				}
				else
				{
					IngredientList dbIngredientList = context.IngredientLists.FirstOrDefault(x => x.Id == ingredientListData.Id);
					if (dbIngredientList != null)
					{
						dbIngredientList.Ingredient = ingredient;
						dbIngredientList.Measurement = measurement;
						dbIngredientList.Recipe = recipe;
						dbIngredientList.SortOrder = ingredientListData.SortOrder;
						dbIngredientList.Amount = ingredientListData.Amount;
						context.SaveChanges();
						return dbIngredientList.Id;
					}
				}
				return 0;
			}
		}

		public void DeleteIngredientListFromRecipeWhereNotInList(List<int> ingerdientListIds, int recipeId)
		{
			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
				List<IngredientList> ingredientLists = context.IngredientLists.Where(x => !ingerdientListIds.Contains(x.Id) && x.Recipe.Id == recipeId).ToList();

				context.IngredientLists.RemoveRange(ingredientLists);
				context.SaveChanges();
			}
		}
	}
}
