using System.Collections.Generic;

namespace LudwigsRecipe.Service.Models.Navigation
{
	public class NavigationViewModel
	{
		public List<NavigationGroupViewModel> MainNavigation { get; set; }
		public List<NavigationGroupViewModel> SubNavigation { get; set; }

		public NavigationViewModel()
		{
			MainNavigation = new List<NavigationGroupViewModel>();
			SubNavigation = new List<NavigationGroupViewModel>();
		}
	}
}
