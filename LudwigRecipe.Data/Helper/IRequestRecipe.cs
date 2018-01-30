namespace LudwigsRecipe.Data.Helper
{
	public interface IRequestRecipe
	{
		int Top { get; set; }
		int Skip { get; set; }
		bool ForPublicWeb { get; set; }
		bool IsFriend { get; set; }
		string CategoryUrl { get; set; }
		string SubCategoryUrl { get; set; }
		string SearchTerm { get; set; }
	}
}
