using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LudwigsRecipe.Data.DataModels.Category
{
	public class SubCategoryData : ISubCategoryData
	{
		public int Id { get; set; }

		public int CategoryId { get; set; }

		public string Name { get; set; }

		public string Url { get; set; }

		public int Order { get; set; }
	}
}
