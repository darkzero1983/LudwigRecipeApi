namespace LudwigRecipe.Data.DataModels.Recipe
{
	public class RecipeContent: IRecipeContent
	{
		public int Id { get; set; }
		public int RecipeContentTypeId { get; set; }
		public string Content { get; set; }
		public int SortOrder { get; set; }
	}
}
