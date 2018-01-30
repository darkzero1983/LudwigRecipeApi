using System;

namespace LudwigsRecipe.Data.DataModels.Recipe
{
	public interface IRecipeOverviewData
	{
		int Id { get; set; }
		string Name { get; set; }
		string Url { get; set; }
		string Description { get; set; }
		DateTime PublishDate { get; set; }
		string TeaserImageUrl { get; set; }
	}
}
