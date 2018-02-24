using LudwigsRecipe.Service.Models.Recipe;
using LudwigsRecipe.Service.Services.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace LudwigRecipe.Api.Controllers
{
    public class PrintController : Controller
    {
		private readonly IRecipeService _recipeService;

		public PrintController(IRecipeService recipeService)
		{
			_recipeService = recipeService;
		}
		
		[HttpGet]
		[Route("api/Drucken/Rezept/{id}")]
		public ActionResult Recipe(int id)
		{
			RecipeDetailViewModel recipe = _recipeService.LoadRecipe(id, User.IsInRole("Friend"));

			foreach (Match match in Regex.Matches(recipe.Content, "d n=\"([^ \"]*)\""))
			{
				if (match.Success)
				{
					for (int i = 0; i < match.Groups.Count; i++)
					{
						Group g = match.Groups[i];
						string dynamicNumber = g.Value.Replace("d n=", "").Replace("\"", "");
						recipe.Content = recipe.Content.Replace("<d n=\"" + dynamicNumber + "\"></d>", dynamicNumber);
					}
				}
			}

			return View(recipe);
		}
	}
}