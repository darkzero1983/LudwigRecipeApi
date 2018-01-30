namespace LudwigsRecipe.Data.DataModels.IngredientList
{
	public interface IIngredientListData
	{
		int Id { get; set; }
		int RecipeId { get; set; }
		decimal Amount { get; set; }
		int IngredientId { get; set; }
		string IngredientName { get; set; }
		int MeasurementId { get; set; }
		string MeasurementName { get; set; }
		int SortOrder { get; set; }
	}
}
