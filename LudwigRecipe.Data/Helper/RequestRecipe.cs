namespace LudwigsRecipe.Data.Helper
{
	public class RequestRecipe : IRequestRecipe
	{
		public int Top { get; set; }
		public int Skip { get; set; }
		public bool ForPublicWeb { get; set; }
		public bool IsFriend { get; set; }
		public string CategoryUrl { get; set; }
		public string SubCategoryUrl { get; set; }
		public string SearchTerm { get; set; }
	}
}
