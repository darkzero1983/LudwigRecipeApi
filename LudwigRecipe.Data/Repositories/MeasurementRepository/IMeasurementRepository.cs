using LudwigsRecipe.Data.DataModels.Measurement;
using System.Collections.Generic;

namespace LudwigsRecipe.Data.Repositories.MeasurementRepository
{
	public interface IMeasurementRepository
	{
		int FindOrAddMeasurement(string measurement);
		List<IMeasurementData> LoadMeasurements();
	}
}
