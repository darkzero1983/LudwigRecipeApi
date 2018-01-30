using LudwigsRecipe.Data.DataModels.HitCount;

namespace LudwigsRecipe.Data.Repositories.HitCountRepositories
{
	public interface IHitCountRepository
	{
		void AddHitCount(IHitCountData hitCountData);
	}
}