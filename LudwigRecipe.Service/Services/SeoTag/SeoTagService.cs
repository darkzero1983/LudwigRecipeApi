using LudwigsRecipe.Data.DataModels.SeoTag;
using LudwigsRecipe.Data.Repositories.SeoTagRepositories;
using LudwigsRecipe.Service.Models.SeoTag;
using System.Collections.Generic;

namespace LudwigsRecipe.Service.Services.SeoTag
{
	public class SeoTagService : ISeoTagService
	{
		#region ctor
		private readonly ISeoTagRepository _seoTagRepository;

		public SeoTagService(ISeoTagRepository seoTagRepository)
		{
			_seoTagRepository = seoTagRepository;
		}
		#endregion

		public List<SeoTagViewModel> LoadSeoTags()
		{
			List<SeoTagViewModel> seoTags = new List<SeoTagViewModel>();
			List<ISeoTagData> seoTagDatas = _seoTagRepository.LoadSeoTags();
			foreach (ISeoTagData seoTagData in seoTagDatas)
			{
				seoTags.Add(new SeoTagViewModel()
				{
					Id = seoTagData.Id,
					Name = seoTagData.Name
				});
			}
			return seoTags;
		}
	}
}
