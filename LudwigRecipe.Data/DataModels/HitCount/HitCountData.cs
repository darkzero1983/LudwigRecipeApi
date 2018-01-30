using System;

namespace LudwigsRecipe.Data.DataModels.HitCount
{
	public class HitCountData : IHitCountData
	{
		public int Id { get; set; }
		public DateTime HitDate { get; set; }
		public string UserName { get; set; }
		public int	RecipeId { get; set; }
		public string Ip { get; set; }
		public string Url { get; set; }
	}
}
