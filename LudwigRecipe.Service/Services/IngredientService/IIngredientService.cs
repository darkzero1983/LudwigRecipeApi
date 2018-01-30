using LudwigsRecipe.Service.Models.Ingredient;
using System.Collections.Generic;

namespace LudwigsRecipe.Service.Services.IngredientService
{
	public interface IIngredientService
	{
		List<IngredientViewModel> LoadIngredients();
	}
}
