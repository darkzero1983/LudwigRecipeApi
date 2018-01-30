using LudwigsRecipe.Data.DataModels.HitCount;
using LudwigsRecipe.Data.Repositories.HitCountRepositories;
using LudwigsRecipe.Service.Models.HitCount;
using System;

namespace LudwigsRecipe.Service.Services.HitCountService
{
	public class HitCountService : IHitCountService
	{
		#region ctor
		private readonly IHitCountRepository _hitCountRepository;

		public HitCountService(IHitCountRepository hitCountRepository)
		{
			_hitCountRepository = hitCountRepository;
		}
		#endregion

		public void AddHitCount(HitCountViewModel hitCount)
		{
			_hitCountRepository.AddHitCount(new HitCountData()
			{
				HitDate = DateTime.Now,
				RecipeId = hitCount.RecipeId,
				Url = hitCount.Url,
				Ip = hitCount.Ip,
				UserName = hitCount.UserName
			});
		}
	}
}
