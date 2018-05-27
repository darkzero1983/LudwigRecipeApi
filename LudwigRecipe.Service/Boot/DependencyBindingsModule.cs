using LudwigsRecipe.Service.Services.IngredientService;
using LudwigsRecipe.Service.Services.MeasurementService;
using LudwigsRecipe.Service.Services.Navigation;
using LudwigsRecipe.Service.Services.Recipe;
using Ninject.Modules;


namespace LudwigRecipe.Service.Boot
{
	public class DependencyBindingsModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IRecipeService>().To<RecipeService>().InSingletonScope();
			Bind<IIngredientService>().To<IngredientService>().InSingletonScope();
			Bind<IMeasurementService>().To<MeasurementService>().InSingletonScope();
			Bind<INavigationService>().To<NavigationService>().InSingletonScope();
		}
		
	}
}
