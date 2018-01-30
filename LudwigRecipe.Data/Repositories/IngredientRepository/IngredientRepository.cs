using LudwigRecipe.Data.DataContext;
using LudwigsRecipe.Data.DataModels.Ingredient;
using System.Collections.Generic;
using System.Linq;

namespace LudwigsRecipe.Data.Repositories.IngredientRepository
{
	public class IngredientRepository : IIngredientRepository
	{
		public int FindOrAddIngredient(string ingredient)
		{
			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
				if (string.IsNullOrWhiteSpace(ingredient))
				{
					return 0;
				}

				Ingredient dbIngredient = context.Ingredients.FirstOrDefault(x => x.Name.ToLower() == ingredient.ToLower().Trim());

				if (dbIngredient == null)
				{
					dbIngredient = new Ingredient()
					{
						Name = ingredient
					};
					context.Ingredients.Add(dbIngredient);
					context.SaveChanges();
				}
				return dbIngredient.Id;
			}
		}

		public List<IIngredientData> LoadIngredients()
		{
			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
				List<IIngredientData> ingredients = new List<IIngredientData>();

				List<Ingredient> dbIngredients = context.Ingredients.OrderBy(x => x.Name).ToList();
				foreach (Ingredient dbIngredient in dbIngredients)
				{
					ingredients.Add(new IngredientData()
					{
						Id = dbIngredient.Id,
						Name = dbIngredient.Name
					});
				}
				return ingredients;
			}
		}
	}
}
