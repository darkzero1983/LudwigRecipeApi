using LudwigRecipe.Api.App_Start;
using LudwigRecipe.Api.Boot;
using LudwigRecipe.Core.Boot;
using Newtonsoft.Json.Serialization;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace LudwigRecipe.Api
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			BootLoader.Boot();

			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);

			GlobalConfiguration.Configuration
			  .Formatters
			  .JsonFormatter
			  .SerializerSettings
			  .ContractResolver = new CamelCasePropertyNamesContractResolver();

			
		}
	}
}
