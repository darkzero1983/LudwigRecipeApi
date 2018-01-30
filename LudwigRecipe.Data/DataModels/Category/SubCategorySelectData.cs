namespace LudwigsRecipe.Data.DataModels.Category
{
	public class SubCategorySelectData : ISubCategorySelectData
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public bool IsSelected { get; set; }
	}
}
