using LudwigRecipe.Data.DataContext;
using LudwigsRecipe.Data.DataModels.HitCount;
using System.Linq;

namespace LudwigsRecipe.Data.Repositories.HitCountRepositories
{
	public class HitCountRepository : IHitCountRepository
	{
		public void AddHitCount(IHitCountData hitCountData)
		{
			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
				Recipe recipe = null;
				if (hitCountData.RecipeId != 0)
				{
					recipe = context.Recipes.FirstOrDefault(x => x.Id == hitCountData.RecipeId);
				}
				AspNetUser user = null;
				if (!string.IsNullOrEmpty(hitCountData.UserName))
				{
					user = context.AspNetUsers.FirstOrDefault(x => x.UserName == hitCountData.UserName);
				}

				HitCount hitCount = new HitCount()
				{
					HitDate = hitCountData.HitDate,
					Ip = hitCountData.Ip,
					Url = hitCountData.Url,
					UserId = user.Id,
					Recipe = recipe
				};
				context.HitCounts.Add(hitCount);
				context.SaveChanges();
			}
		}
	}
}
