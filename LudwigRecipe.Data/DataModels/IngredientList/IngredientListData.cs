namespace LudwigsRecipe.Data.DataModels.IngredientList
{
	public class IngredientListData : IIngredientListData
	{
		public int Id { get; set; }
		public int RecipeId { get; set; }
		public decimal Amount { get; set; }
		public int IngredientId { get; set; }
		public string IngredientName { get; set; }
		public int MeasurementId { get; set; }
		public string MeasurementName { get; set; }
		public int SortOrder { get; set; }
	}
}
