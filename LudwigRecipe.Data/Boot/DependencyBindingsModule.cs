using LudwigsRecipe.Data.Repositories.CategoryRepository;
using LudwigsRecipe.Data.Repositories.IngredientListRepositories;
using LudwigsRecipe.Data.Repositories.IngredientRepository;
using LudwigsRecipe.Data.Repositories.MeasurementRepository;
using LudwigsRecipe.Data.Repositories.RecipeRepository;
using LudwigsRecipe.Data.Repositories.SeoTagRepositories;
using LudwigsRecipe.Data.Repositories.UserRepositories;
using Ninject.Modules;


namespace LudwigRecipe.Data.Boot
{
	public class DependencyBindingsModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IRecipeRepository>().To<RecipeRepository>().InSingletonScope();
			Bind<IIngredientRepository>().To<IngredientRepository>().InSingletonScope();
			Bind<IMeasurementRepository>().To<MeasurementRepository>().InSingletonScope();
			Bind<IIngredientListRepository>().To<IngredientListRepository>().InSingletonScope();
			Bind<IUserRepository>().To<UserRepository>().InSingletonScope();
			Bind<ISeoTagRepository>().To<SeoTagRepository>().InSingletonScope();
			Bind<ICategoryRepository>().To<CategoryRepository>().InSingletonScope();
		}
		
	}
}
