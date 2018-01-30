using System;

namespace LudwigsRecipe.Data.DataModels.HitCount
{
	public interface IHitCountData
	{
		int Id { get; set; }
		DateTime HitDate { get; set; }
		string UserName { get; set; }
		int RecipeId { get; set; }
		string Ip { get; set; }
		string Url { get; set; }
	}
}
