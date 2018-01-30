using LudwigRecipe.Api.Boot;
using LudwigRecipe.Core.Boot;
using Newtonsoft.Json.Serialization;
using System.Web.Http;
using System.Web.Mvc;

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
			
			GlobalConfiguration.Configuration
			  .Formatters
			  .JsonFormatter
			  .SerializerSettings
			  .ContractResolver = new CamelCasePropertyNamesContractResolver();

			
		}
	}
}
