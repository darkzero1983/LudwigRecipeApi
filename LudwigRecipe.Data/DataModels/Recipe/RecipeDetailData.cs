using LudwigsRecipe.Data.DataModels.Measurement;
using System;

namespace LudwigsRecipe.Data.DataModels.Recipe
{
	public class RecipeDetailData : IRecipeDetailData
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Url { get; set; }
		public string Description { get; set; }
		public string Content { get; set; }
		public DateTime PublishDate { get; set; }
		public string TeaserImageUrl { get; set; }
		public Decimal? IngredientCount { get; set; }
		public IMeasurementData Measurement { get; set; }
		public Nullable<int> PreparationTime { get; set; }
		public Nullable<int> WaitingTime { get; set; }
	}
}
