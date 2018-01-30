using Ninject.Modules;
using Ninject.Extensions.Conventions;
using LudwigRecipe.Core.Boot;

namespace LudwigRecipe.Api.Boot
{
	public class DependencyBindingsModule : NinjectModule
	{
		public override void Load()
		{
			Kernel.Bind(i => i.FromAssembliesMatching("LudwigRecipe.*.dll")
					.SelectAllClasses()
					.InheritedFrom(typeof(IBootModule))
					.BindSingleInterface()
			);

		}
	}
}