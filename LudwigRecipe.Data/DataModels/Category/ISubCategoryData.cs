using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LudwigsRecipe.Data.DataModels.Category
{
	public interface ISubCategoryData
	{
		int Id { get; set; }

		int CategoryId { get; set; }

		string Name { get; set; }

		string Url { get; set; }
		
		int Order { get; set; }
	}
}
