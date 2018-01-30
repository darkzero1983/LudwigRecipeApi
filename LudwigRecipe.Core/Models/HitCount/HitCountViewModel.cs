using System;

namespace LudwigRecipe.Core.Models.HitCount
{
	public class HitCountViewModel
	{
		public int Id { get; set; }
		public int RecipeId { get; set; }
		public string Url { get; set; }
		public string Ip { get; set; }
		public string UserName { get; set; }
	}
}
