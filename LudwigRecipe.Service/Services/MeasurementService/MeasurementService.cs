using LudwigsRecipe.Data.DataModels.Measurement;
using LudwigsRecipe.Data.Repositories.MeasurementRepository;
using LudwigsRecipe.Service.Models.Measurement;
using System.Collections.Generic;

namespace LudwigsRecipe.Service.Services.MeasurementService
{
	public class MeasurementService : IMeasurementService
	{
		#region ctor
		private readonly IMeasurementRepository _MeasurementRepository;

		public MeasurementService(IMeasurementRepository MeasurementRepository)
		{
			_MeasurementRepository = MeasurementRepository;
		}
		#endregion

		public List<MeasurementViewModel> LoadMeasurements()
		{
			List<MeasurementViewModel> Measurements = new List<MeasurementViewModel>();

			List<IMeasurementData> MeasurementDatas = _MeasurementRepository.LoadMeasurements();

			foreach (IMeasurementData MeasurementData in MeasurementDatas)
			{
				Measurements.Add(new MeasurementViewModel()
				{
					Id = MeasurementData.Id,
					Name = MeasurementData.Name
				});
			}

			return Measurements;
		}
	}
}
