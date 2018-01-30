using System.Collections.Generic;

namespace LudwigRecipe.Core.Models.Navigation
{
	public class NavigationGroupViewModel
	{
		public string Name { get; set; }
		public string Href { get; set; }
		public string RouteName { get; set; }
		public string CategoryUrl { get; set; }
		
		public List<NavigationItemViewModel> Items { get; set; }

		public NavigationGroupViewModel()
		{
			Items = new List<NavigationItemViewModel>();
		}
	}
}
