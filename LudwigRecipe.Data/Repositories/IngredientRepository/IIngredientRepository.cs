using LudwigsRecipe.Data.DataModels.Ingredient;
using System.Collections.Generic;

namespace LudwigsRecipe.Data.Repositories.IngredientRepository
{
	public interface IIngredientRepository
	{
		int FindOrAddIngredient(string ingredient);
		List<IIngredientData> LoadIngredients();
	}
}
