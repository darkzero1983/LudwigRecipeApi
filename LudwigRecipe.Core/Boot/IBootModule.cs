namespace LudwigRecipe.Core.Boot
{
	public interface IBootModule
	{
		int Priority { get; }
		void Boot();
	}
}
