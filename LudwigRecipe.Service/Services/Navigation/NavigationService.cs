using LudwigsRecipe.Data.DataModels.Category;
using LudwigsRecipe.Data.Repositories.CategoryRepository;
using LudwigsRecipe.Service.Models.Navigation;
using System.Collections.Generic;
using System.Linq;

namespace LudwigsRecipe.Service.Services.Navigation
{
	public class NavigationService : INavigationService
	{
		#region ctor
		private readonly ICategoryRepository _catgeoryRepository;

		public NavigationService(ICategoryRepository catgeoryRepository)
		{
			_catgeoryRepository = catgeoryRepository;
		}
		#endregion
		
		public NavigationViewModel LoadNavigation(bool isFriend, bool isAdminOrAuthor, bool cmsVersion)
		{
			NavigationViewModel navigation = new NavigationViewModel();

			List<ICategoryData> categories = _catgeoryRepository.LoadCategoriesWithRecipes(isFriend);

			foreach (ICategoryData category in categories.OrderBy(x => x.Order))
			{
				List<NavigationItemViewModel> subCategoryViewModels = new List<NavigationItemViewModel>();
				
				foreach (ISubCategoryData subCategory in category.SubCategories.OrderBy(x => x.Order))
				{
					subCategoryViewModels.Add(new NavigationItemViewModel() { 
						Name = subCategory.Name,
						RouteName = "SubCategoryOverview",
						SubCategoryUrl = subCategory.Url
					});
				}
				NavigationGroupViewModel categoryViewModels = new NavigationGroupViewModel()
				{
					Name = category.Name,
					RouteName = "CategoryOverview",
					CategoryUrl = category.Url,
					Items = subCategoryViewModels
				};

				if (category.IsMainMenu)
				{
					navigation.MainNavigation.Add(categoryViewModels);
				}
				else
				{
					navigation.SubNavigation.Add(categoryViewModels);
				}
			}

			if(isAdminOrAuthor)
			{
				if(cmsVersion)
				{
					List<NavigationItemViewModel> subCategoryViewModels = new List<NavigationItemViewModel>();
					subCategoryViewModels.Add(new NavigationItemViewModel()
					{
						Name = "Rezepte",
						RouteName = "CMS_RecipeOverview"
					});
					subCategoryViewModels.Add(new NavigationItemViewModel()
					{
						Name = "Kategorien",
						RouteName = "CategoryEdit"
					});
					NavigationGroupViewModel categoryViewModels = new NavigationGroupViewModel()
					{
						Name = "CMS",
						RouteName = "CMS_RecipeOverview",
						Items = subCategoryViewModels
					};

					navigation.MainNavigation.Add(categoryViewModels);
				}
				else
				{
					navigation.MainNavigation.Add(new NavigationGroupViewModel() { Href = "/CMS/Rezepte", Name = "CMS" });
				}
			}
			return navigation;
		}
	}
}
