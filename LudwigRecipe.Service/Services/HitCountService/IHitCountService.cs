using LudwigsRecipe.Service.Models.HitCount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LudwigsRecipe.Service.Services.HitCountService
{
	public interface IHitCountService
	{
		void AddHitCount(HitCountViewModel hitCount);
	}
}
