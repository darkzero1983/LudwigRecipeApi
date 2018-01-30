using LudwigsRecipe.Service.Models.SeoTag;
using System.Collections.Generic;

namespace LudwigsRecipe.Service.Services.SeoTag
{
	public interface ISeoTagService
	{
		List<SeoTagViewModel> LoadSeoTags();
	}
}
