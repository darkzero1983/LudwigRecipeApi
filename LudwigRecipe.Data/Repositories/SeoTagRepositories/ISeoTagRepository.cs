using LudwigsRecipe.Data.DataModels.SeoTag;
using System.Collections.Generic;

namespace LudwigsRecipe.Data.Repositories.SeoTagRepositories
{
	public interface ISeoTagRepository
	{
		List<ISeoTagData> LoadSeoTags();
		List<ISeoTagData> LoadSeoTagsFromRecipe(int recipeId);
		int AddOrSelectSeoTag(ISeoTagData seoTagData);
		void AddAndRemoveSeoTagsFromRecipe(List<int> seoTagIds, int recipeId);
	}
}
