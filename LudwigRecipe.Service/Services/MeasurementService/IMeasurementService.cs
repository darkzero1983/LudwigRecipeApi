using LudwigsRecipe.Service.Models.Measurement;
using System.Collections.Generic;

namespace LudwigsRecipe.Service.Services.MeasurementService
{
	public interface IMeasurementService
	{
		List<MeasurementViewModel> LoadMeasurements();
	}
}
