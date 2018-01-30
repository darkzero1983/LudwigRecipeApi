using System;

namespace LudwigsRecipe.Data.DataModels.Recipe
{
	public class RecipeOverviewData : IRecipeOverviewData
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Url { get; set; }
		public string Description { get; set; }
		public DateTime PublishDate { get; set; }
		public string TeaserImageUrl { get; set; }
	}
}
