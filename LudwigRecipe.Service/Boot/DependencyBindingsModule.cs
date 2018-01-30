using LudwigsRecipe.Service.Services.Recipe;
using Ninject.Modules;


namespace LudwigRecipe.Service.Boot
{
	public class DependencyBindingsModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IRecipeService>().To<RecipeService>().InSingletonScope();
		}
		
	}
}
