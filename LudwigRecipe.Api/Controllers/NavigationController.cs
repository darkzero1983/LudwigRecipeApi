using LudwigsRecipe.Service.Models.Navigation;
using LudwigsRecipe.Service.Services.Navigation;
using System.Web.Http;

namespace LudwigRecipe.Api.Controllers
{
    public class NavigationController : ApiController
	{
		private readonly INavigationService _navigationService;

		public NavigationController(INavigationService navigationService)
		{
			_navigationService = navigationService;
		}
		
		[HttpGet]
		[Route("api/Navigation/Load")]
		public NavigationViewModel Load()
		{
			return _navigationService.LoadNavigation(true, false, false);
		}
	}
}