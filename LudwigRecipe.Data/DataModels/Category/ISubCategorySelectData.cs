namespace LudwigsRecipe.Data.DataModels.Category
{
	public interface ISubCategorySelectData
	{
		int Id { get; set; }
		string Name { get; set; }
		bool IsSelected { get; set; }
	}
}
