using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LudwigRecipe.Core.Boot
{
	public static class BootLoader
	{
		/// <summary>
		/// Boots all BootModules that are registered in the DependencyResolver 
		/// (The DependencyResolver should be Ninject anyway)
		/// </summary>
		public static void Boot()
		{
			List<IBootModule> bootModules = DependencyResolver.Current.GetServices<IBootModule>().OrderBy(m => m.Priority).ToList();
			bootModules.ForEach(b => b.Boot());
		}
	}
}
