using LudwigsRecipe.Data.DataModels.User;
using LudwigsRecipe.Data.Repositories.UserRepositories;
using LudwigsRecipe.Service.Models.User;
using System.Collections.Generic;

namespace LudwigsRecipe.Service.Services.User
{
	public class UserService : IUserService
	{
		#region ctor

		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		#endregion

		public List<AuthorViewModel> LoadAuthors()
		{
			List<AuthorViewModel> authors = new List<AuthorViewModel>();
			List<IUserData> authorDatas = _userRepository.LoadAuthors();
			foreach (IUserData author in authorDatas)
			{
				authors.Add(new AuthorViewModel()
				{
					Id = author.Id,
					Name = author.Name
				});
			}
			return authors;
		}
	}
}