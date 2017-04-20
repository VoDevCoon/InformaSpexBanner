using System;
using System.Collections.Generic;
using System.Linq;
using InformaSpexBanner.Data;
using InformaSpexBanner.Entities;
using Microsoft.EntityFrameworkCore;

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
			return _dbcontext.Exhibitions.Include(e => e.Banners).ThenInclude(b => b.Text);
		}

		public Exhibition GetExhibition(int Id)
		{
			return _dbcontext.Exhibitions.Include(e=>e.Banners).ThenInclude(b=>b.Text).FirstOrDefault(e => e.Id == Id);
		}

		public IEnumerable<Banner> GetAllBanner(int exhibitionId)
		{
			return _dbcontext.Banners.Include(b => b.Text).Where(b => b.ExhibitionId == exhibitionId);
		}

		public Exhibition AddExhibition(Exhibition exhibition)
		{
			_dbcontext.Exhibitions.Add(exhibition);
			_dbcontext.SaveChanges();

			return exhibition;
		}

		public Exhibition UpdateExhition(Exhibition exhibition)
		{
			_dbcontext.Exhibitions.Update(exhibition);
			_dbcontext.SaveChanges();

			return exhibition;
		}

		public Banner GetBanner(int Id)
		{
			return _dbcontext.Banners.Include(b => b.Text).FirstOrDefault(b => b.Id == Id);
		}

		public CustomText GetBannerText(int Id)
		{
			return _dbcontext.CustomTexts.FirstOrDefault(ct => ct.Id == Id);
		}

		public bool BannerExists(int id)
		{
			return _dbcontext.Banners.Find(id) != null;
		}

		public Banner AddBanner(Banner banner)
		{
			_dbcontext.Banners.Add(banner);
			_dbcontext.SaveChanges();

			return banner;
		}

		public Banner UpdateBanner(Banner banner)
		{
			_dbcontext.Banners.Update(banner);
			_dbcontext.SaveChanges();

			return banner;
		}

		public void DeleteBanner(int Id)
		{
			var banner = _dbcontext.Banners.SingleOrDefault(b => b.Id == Id);
			_dbcontext.Banners.Remove(banner);
			_dbcontext.SaveChanges();

		}

		public void DeleteExhibition(int Id, string name)
		{
			var exhibition = _dbcontext.Exhibitions.SingleOrDefault(e => e.Id == Id && e.Name == name);

			_dbcontext.Exhibitions.Remove(exhibition);
			_dbcontext.SaveChanges();
		}
	}
}