using System.Collections.Generic;

namespace LudwigsRecipe.Data.DataModels.Category
{
	public interface ICategorySelectData
	{
		int Id { get; set; }
		string Name { get; set; }
		bool IsSelected { get; set; }
		List<ISubCategorySelectData> SubCategoryDatas { get; set; }
	}
}
