namespace LudwigRecipe.Core.Models.Ingredient
{
	public class IngredientListItemViewModel
	{
		public int Id { get; set; }
		public decimal Amount { get; set; }
		public int MeasurementId { get; set; }
		public string MeasurementName { get; set; }
		public int IngredientId { get; set; }
		public string IngredientName { get; set; }
	}
}
