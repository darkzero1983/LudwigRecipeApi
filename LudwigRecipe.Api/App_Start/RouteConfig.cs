using System.Web.Mvc;
using System.Web.Routing;

namespace LudwigRecipe.Api.App_Start
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			routes.MapRoute(
				name: "Default",
				url: "api/Drucken/Rezept/{id}",
				defaults: new { controller = "Print", action = "Recipe" }
			);
		}
	}
}