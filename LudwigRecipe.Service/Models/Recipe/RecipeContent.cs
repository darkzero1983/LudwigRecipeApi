namespace LudwigRecipe.Service.Models.Recipe
{
	public class RecipeContent
	{
		public int Id { get; set; }
		public RecipeContentType ContentType { get; set; }
		public string Content { get; set; }
		public int SortOrder { get; set; }
	}
}
