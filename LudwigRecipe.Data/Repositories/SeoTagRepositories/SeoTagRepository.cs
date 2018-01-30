using LudwigRecipe.Data.DataContext;
using LudwigsRecipe.Data.DataModels.SeoTag;
using System.Collections.Generic;
using System.Linq;

namespace LudwigsRecipe.Data.Repositories.SeoTagRepositories
{
	public class SeoTagRepository : ISeoTagRepository
	{

		public List<ISeoTagData> LoadSeoTags()
		{
			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
				List<ISeoTagData> seoTags = new List<ISeoTagData>();

				List<SeoTag> dbSeoTags = context.SeoTags.ToList();

				foreach (SeoTag dbSeoTag in dbSeoTags)
				{
					seoTags.Add(new SeoTagData()
					{
						Id = dbSeoTag.Id,
						Name = dbSeoTag.Name
					});
				}

				return seoTags;
			}
		}

		public List<ISeoTagData> LoadSeoTagsFromRecipe(int recipeId)
		{
			/*
			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
				List<ISeoTagData> seoTags = new List<ISeoTagData>();

				List<RecipeToSeoTag> dbSeoTags = ctx.RecipesToSeoTags.Include(x => x.SeoTag).Where(x => x.RecipeId == recipeId).ToList();

				foreach (RecipeToSeoTag dbSeoTag in dbSeoTags)
				{
					seoTags.Add(new SeoTagData()
					{
						Id = dbSeoTag.SeoTag.Id,
						Name = dbSeoTag.SeoTag.Name
					});
				}

				return seoTags;
			}
			*/
			return null;
		}

		public int AddOrSelectSeoTag(ISeoTagData seoTagData)
		{
			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
				seoTagData.Name = seoTagData.Name.Trim();
				if (string.IsNullOrEmpty(seoTagData.Name))
				{
					return 0;
				}

				SeoTag seoTag = context.SeoTags.FirstOrDefault(x => x.Name.ToLower() == seoTagData.Name.ToLower());
				if (seoTag == null)
				{
					seoTag = new SeoTag()
					{
						Name = seoTagData.Name
					};
					context.SeoTags.Add(seoTag);
					context.SaveChanges();
				}
				return seoTag.Id;
			}
		}

		public void AddAndRemoveSeoTagsFromRecipe(List<int> seoTagIds, int recipeId)
		{
			/*
			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
				Recipe recipe = context.Recipes.Include(x => x.RecipesToApplicationUsers).FirstOrDefault(x => x.Id == recipeId);
				if (recipe == null)
				{
					return;
				}
				List<SeoTag> dbSeoTags = context.SeoTags.Where(x => seoTagIds.Contains(x.Id)).ToList();
				List<RecipeToSeoTag> recipesToSeoTags = new List<RecipeToSeoTag>();

				foreach (SeoTag dbSeoTag in dbSeoTags)
				{
					recipesToSeoTags.Add(new RecipeToSeoTag()
					{
						SeoTagId = dbSeoTag.Id,
						SeoTag = dbSeoTag,
						Recipe = recipe,
						RecipeId = recipe.Id
					});
				}

				context.RecipesToSeoTags.RemoveRange(context.RecipesToSeoTags.Where(x => x.RecipeId == recipe.Id).ToList());
				context.SaveChanges();
				context.RecipesToSeoTags.AddRange(recipesToSeoTags);
				context.SaveChanges();
			}
			*/
		}
	}
}