namespace LudwigsRecipe.Service.Models.Ingredient
{
	public class IngredientListItemViewModel
	{
		public int? Id { get; set; }
		public decimal? Amount { get; set; }
		public string MeasurementName { get; set; }
		public string IngredientName { get; set; }
	}
}
