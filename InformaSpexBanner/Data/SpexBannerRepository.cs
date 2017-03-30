using System.Collections.Generic;
using System.Linq;
using InformaSpexBanner.Data;
using InformaSpexBanner.Entities;

namespace InformaSpexBanner.Data
{
	public class SpexBannerRepository : ISpexBannerRepository
	{
		private InformaSS1DbContext _dbcontext;

		public SpexBannerRepository(InformaSS1DbContext dbContext)
		{
			_dbcontext = dbContext;
		}

		public IEnumerable<Exhibition> GetAllExhibition()
		{
			return _dbcontext.Exhibitions;
		}

		public Exhibition GetExhibition(int Id)
		{
			return _dbcontext.Exhibitions.FirstOrDefault(e => e.Id == Id);
		}

		public IEnumerable<Banner> GetAllBanner(int exhibitionId)
		{
			return _dbcontext.Banners.Where(b => b.ExhibitionId == exhibitionId);
		}

		public Banner GetBanner(int Id)
		{
			return _dbcontext.Banners.FirstOrDefault(b => b.Id == Id);
		}
	}
}