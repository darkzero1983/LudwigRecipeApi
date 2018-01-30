using LudwigsRecipe.Data.DataModels.Measurement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LudwigsRecipe.Data.DataModels.Recipe
{
	public interface IRecipeData
	{
		int Id { get; set; }
		bool IsPublished { get; set; }
		bool IsOnlyForFriends { get; set; }
		string Name { get; set; }
		string Url { get; set; }
		string Description { get; set; }
		string Content { get; set; }
		DateTime PublishDate { get; set; }
		string TeaserImageUrl { get; set; }
		Decimal? IngredientCount { get; set; }
		IMeasurementData Measurement { get; set; }
		Nullable<int> PreparationTime { get; set; }
		Nullable<int> WaitingTime { get; set; }
	}
}
