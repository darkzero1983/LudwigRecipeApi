using System.ComponentModel.DataAnnotations;

namespace LudwigsRecipe.Service.Models.Ingredient
{
	public class IngredientsViewModel
	{
		[DisplayFormat(DataFormatString = "{0:0.##}")]
		public decimal Amount { get; set; }
		public string Measurement { get; set; }
		public string Ingredient { get; set; }
	}
}
