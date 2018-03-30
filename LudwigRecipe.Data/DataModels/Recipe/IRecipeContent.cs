namespace LudwigRecipe.Data.DataModels.Recipe
{
	public interface IRecipeContent
	{
		int Id { get; set; }
		int RecipeContentTypeId { get; set; }
		string Content { get; set; }
		int SortOrder { get; set; }
	}
}
