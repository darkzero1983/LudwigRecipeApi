using LudwigRecipe.Data.DataContext;
using LudwigsRecipe.Data.DataModels.Measurement;
using System.Collections.Generic;
using System.Linq;

namespace LudwigsRecipe.Data.Repositories.MeasurementRepository
{
	public class MeasurementRepository : IMeasurementRepository
	{
		public int FindOrAddMeasurement(string measurement)
		{
			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
				Measurement dbMeasurement = context.Measurements.FirstOrDefault(x => x.Name.ToLower() == measurement.ToLower().Trim());

				if (dbMeasurement == null)
				{
					dbMeasurement = new Measurement()
					{
						Name = measurement
					};
					context.Measurements.Add(dbMeasurement);
					context.SaveChanges();
				}
				return dbMeasurement.Id;
			}
		}

		public List<IMeasurementData> LoadMeasurements()
		{
			using (LudwigRecipeContext context = new LudwigRecipeContext())
			{
				List<IMeasurementData> measurements = new List<IMeasurementData>();

				List<Measurement> dbMeasurements = context.Measurements.OrderBy(x => x.Name).ToList();
				foreach (Measurement dbMeasurement in dbMeasurements)
				{
					measurements.Add(new MeasurementData()
					{
						Id = dbMeasurement.Id,
						Name = dbMeasurement.Name
					});
				}
				return measurements;
			}
		}
	}
}
