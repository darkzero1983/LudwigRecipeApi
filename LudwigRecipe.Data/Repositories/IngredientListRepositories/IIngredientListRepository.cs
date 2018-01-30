using LudwigsRecipe.Data.DataModels.IngredientList;
using System.Collections.Generic;

namespace LudwigsRecipe.Data.Repositories.IngredientListRepositories
{
	public interface IIngredientListRepository
	{
		List<IIngredientListData> LoadIngredientListFromRecipe(int recipeId);
		int AddOrUpdateIngredientListFromRecipe(IIngredientListData ingredientListData);

		void DeleteIngredientListFromRecipeWhereNotInList(List<int> ingerdientListIds, int recipeId);
	}
}
