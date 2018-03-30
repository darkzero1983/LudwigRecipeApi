using LudwigRecipe.Data.DataModels.Recipe;
using LudwigsRecipe.Data.DataModels.Measurement;
using System;
using System.Collections.Generic;

namespace LudwigsRecipe.Data.DataModels.Recipe
{
	public class RecipeData : IRecipeData
	{
		public int Id { get; set; }
		public bool IsPublished { get; set; }
		public bool IsOnlyForFriends { get; set; }
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
		public List<IRecipeContent> ContentItems { get; set; }

		public RecipeData()
		{
			Measurement = new MeasurementData();
		}
	}
}
