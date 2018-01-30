using LudwigsRecipe.Service.Models.Navigation;

namespace LudwigsRecipe.Service.Services.Navigation
{
	public interface INavigationService
	{
		NavigationViewModel LoadNavigation(bool isFriend, bool isAdminOrAuthor, bool cmsVersion);
	}
}
