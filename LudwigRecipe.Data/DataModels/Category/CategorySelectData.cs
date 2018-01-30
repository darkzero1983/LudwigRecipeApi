using System.Collections.Generic;

namespace LudwigsRecipe.Data.DataModels.Category
{
	public class CategorySelectData : ICategorySelectData
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public bool IsSelected { get; set; }
		public List<ISubCategorySelectData> SubCategoryDatas { get; set; }
	}
}
