using System.Collections.Generic;
using InformaSpexBanner.Entities;

namespace InformaSpexBanner.Data
{
	public interface ISpexBannerRepository
	{
		IEnumerable<Exhibition> GetAllExhibition();
		Exhibition GetExhibition(int Id);
		IEnumerable<Banner> GetAllBanner(int exhibitionId);
		Banner GetBanner(int Id);
	}
}