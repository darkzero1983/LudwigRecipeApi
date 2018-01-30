using LudwigsRecipe.Data.DataModels.User;
using System.Collections.Generic;
using System.Linq;

namespace LudwigsRecipe.Data.Repositories.UserRepositories
{
	public class UserRepository : IUserRepository
	{

		public List<IUserData> LoadAuthors()
		{
			/*
			List<IUserData> authors = new List<IUserData>();

			IdentityRole authorRole = ctx.Roles.FirstOrDefault(x => x.Name == "Author");
			if (authorRole == null)
			{
				return authors;
			}
			List<ApplicationUser> users = ctx.Users.Include(x => x.Roles).ToList();
			foreach (ApplicationUser user in users)
			{
				if (user.Roles.FirstOrDefault(x => x.RoleId == authorRole.Id) != null)
				{
					authors.Add(new UserData()
					{
						Id = user.Id,
						Name = user.AutorDisplayName ?? user.UserName
					});
				};
			}
			return authors;
			*/
			return null;
		}

		public List<IUserData> LoadAuthorsFromRecipe(int recipeId)
		{
			/*
			List<IUserData> authors = new List<IUserData>();

			List<RecipeToApplicationUser> users = ctx.RecipesToApplicationUsers.Include(x => x.ApplicationUser).Where(x => x.RecipeId == recipeId).ToList();
			foreach (RecipeToApplicationUser user in users)
			{
				authors.Add(new UserData() {
					Id = user.ApplicationUser.Id,
					Name = user.ApplicationUser.AutorDisplayName ?? user.ApplicationUser.UserName
				});
			}
			return authors;
			*/
			return null;
		}

		public void AddAndRemoveAuthorsFromRecipe(List<string> authorIds, int recipeId)
		{
			/*
			Recipe recipe = ctx.Recipes.Include(x => x.RecipesToApplicationUsers).FirstOrDefault(x => x.Id == recipeId);
			if(recipe == null)
			{
				return;
			}
			List<ApplicationUser> authors = ctx.Users.Where(x => authorIds.Contains(x.Id)).ToList();
			List<RecipeToApplicationUser> recipesToApplicationUsers = new List<RecipeToApplicationUser>();

			foreach (ApplicationUser author in authors)
			{
				recipesToApplicationUsers.Add(new RecipeToApplicationUser()
				{
					ApplicationUserId = author.Id,
					ApplicationUser = author,
					Recipe = recipe,
					RecipeId = recipe.Id
				});
			}

			ctx.RecipesToApplicationUsers.RemoveRange(ctx.RecipesToApplicationUsers.Where(x => x.RecipeId == recipe.Id).ToList());
			ctx.SaveChanges();
			ctx.RecipesToApplicationUsers.AddRange(recipesToApplicationUsers);
			ctx.SaveChanges();
			*/
		}
	}
}