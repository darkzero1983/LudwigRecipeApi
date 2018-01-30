using LudwigRecipe.Core.Interfaces.Servcies;
using LudwigRecipe.Service.Services;
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
