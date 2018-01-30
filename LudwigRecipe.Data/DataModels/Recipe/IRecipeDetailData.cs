using LudwigsRecipe.Data.DataModels.Measurement;
using System;

namespace LudwigsRecipe.Data.DataModels.Recipe
{
	public interface IRecipeDetailData
	{
		int Id { get; set; }
		string Name { get; set; }
		string Url { get; set; }
		string Description { get; set; }
		string Content { get; set; }
		DateTime PublishDate { get; set; }
		string TeaserImageUrl { get; set; }
		Decimal? IngredientCount { get; set; }
		IMeasurementData Measurement { get; set; }
		int? PreparationTime { get; set; }
		int? WaitingTime { get; set; }
	}
}
