using LudwigsRecipe.Service.Models.Category;
using LudwigsRecipe.Service.Models.Ingredient;
using LudwigsRecipe.Service.Models.Measurement;
using LudwigsRecipe.Service.Models.SeoTag;
using LudwigsRecipe.Service.Models.User;
using System;
using System.Collections.Generic;

namespace LudwigsRecipe.Service.Models.Recipe
{
	public class RecipeEditViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Content { get; set; }
		public bool IsPublished { get; set; }
		public bool IsOnlyForFriends { get; set; }
		public string PublishDate { get; set; }
		public int PublishHour { get; set; }
		public int PublishMinute { get; set; }
		public string TeaserImageUrl { get; set; }
		public Decimal? IngredientCount { get; set; }
		public string Measurement { get; set; }
		public List<IngredientListItemViewModel> IngredientList { get; set; }
		public List<AuthorViewModel> Authors { get; set; }
		public List<SeoTagViewModel> SeoTags { get; set; }
		public List<CategoryToRecipeViewModel> Categories { get; set; }
		public int? PreparationTime { get; set; }
		public int? WaitingTime { get; set; }
		public RecipeEditViewModel()
		{
			IngredientList = new List<IngredientListItemViewModel>();
			Authors = new List<AuthorViewModel>();
			SeoTags = new List<SeoTagViewModel>();
			Categories = new List<CategoryToRecipeViewModel>();
		}
	}
}
