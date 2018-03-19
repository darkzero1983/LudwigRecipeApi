using LudwigsRecipe.Service.Models.Navigation;
using LudwigsRecipe.Service.Models.Recipe;
using LudwigsRecipe.Service.Services.IngredientService;
using LudwigsRecipe.Service.Services.MeasurementService;
using LudwigsRecipe.Service.Services.Recipe;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace LudwigRecipe.Api.Api.Recipe
{
	[Authorize]
	public class CmsController : ApiController
	{
		private readonly IRecipeService _recipeService;
		private readonly IMeasurementService _measurementService;
		private readonly IIngredientService _ingredientService;

		public CmsController(IRecipeService recipeService, IMeasurementService measurementService, IIngredientService ingredientService)
		{
			_recipeService = recipeService;
			_measurementService = measurementService;
			_ingredientService = ingredientService;
		}

		[HttpGet]
		[Route("api/Cms/Recipe/Overview")]
		public RecipeOverviewViewModel Overview(int count, int skip)
		{
			return _recipeService.LoadCMSRecipes(count, skip);
		}

		[HttpGet]
		[Route("api/Cms/Recipe/{id}")]
		public RecipeEditViewModel GetRecipe(int id)
		{
			return _recipeService.LoadRecipeEditViewModel(id);
		}

		[HttpGet]
		[Route("api/Cms/Measurements")]
		public List<string> GetMeasurements()
		{
			return _measurementService.LoadMeasurements().OrderBy(x => x.Name).Select(x => x.Name).ToList().FindAll(x => !String.IsNullOrEmpty(x));
		}

		[HttpGet]
		[Route("api/Cms/Ingredients")]
		public List<string> GetIngredients()
		{
			return _ingredientService.LoadIngredients().OrderBy(x => x.Name).Select(x => x.Name).ToList().FindAll(x => !String.IsNullOrEmpty(x));
		}

		[HttpPost]
		[Route("api/Cms/Recipe")]
		public int Post([FromBody]RecipeEditViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return 0;
			}
			try
			{
				_recipeService.SaveRecipeEditViewModel(model);
				return model.Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}

		[HttpPost]
		[Route("api/Cms/UploadTeaserImage/{id}")]
		public async Task<IHttpActionResult> UploadTeaserImage(string id)
		{
			var uploads = "D:\\Dropbox\\Dokumente Peter\\Visual Studio\\ImageManager\\ImageManager.Web\\media\\LudwigsRezepte\\" + id + "\\";

			var provider = new MultipartMemoryStreamProvider();
			await Request.Content.ReadAsMultipartAsync(provider);
			foreach (var file in provider.Contents)
			{
				try
				{ 
					string fileName = file.Headers.ContentDisposition.FileName.Trim('\"');
					byte[] buffer = await file.ReadAsByteArrayAsync();

					using (var fs = new FileStream(uploads + fileName, FileMode.OpenOrCreate, FileAccess.Write))
					{
						fs.Write(buffer, 0, buffer.Length);
					}
				}
				catch(Exception e)
				{

				}
			}

			return Ok();
		}
	}
}
