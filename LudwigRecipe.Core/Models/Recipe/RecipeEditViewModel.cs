using LudwigRecipe.Core.Models.Category;
using LudwigRecipe.Core.Models.Ingredient;
using LudwigRecipe.Core.Models.Measurement;
using LudwigRecipe.Core.Models.SeoTag;
using LudwigRecipe.Core.Models.User;
using System;
using System.Collections.Generic;

namespace LudwigRecipe.Core.Models.Recipe
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
		public MeasurementViewModel Measurement { get; set; }
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
			Measurement = new MeasurementViewModel();
		}
	}
}
