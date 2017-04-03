﻿using System;
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
			return _dbcontext.Exhibitions;
		}

		public Exhibition GetExhibition(int Id)
		{
			return _dbcontext.Exhibitions.FirstOrDefault(e => e.Id == Id);
		}

		public IEnumerable<Banner> GetAllBanner(int exhibitionId)
		{
			return _dbcontext.Banners.Include(b => b.Text).Where(b => b.ExhibitionId == exhibitionId);
		}

		public Banner GetBanner(int Id)
		{
			return _dbcontext.Banners.Include(b=>b.Text).FirstOrDefault(b => b.Id == Id);
		}

		public Exhibition AddExhibition(Exhibition exhibition)
		{
			_dbcontext.Exhibitions.Add(exhibition);
			_dbcontext.SaveChanges();

			return exhibition;
		}

		public Banner AddBanner(Banner banner)
		{
			_dbcontext.Banners.Add(banner);
			_dbcontext.SaveChanges();

			return banner;
		}

		public CustomText GetBannerText(int Id)
		{
			return _dbcontext.CustomTexts.FirstOrDefault(ct => ct.Id == Id);
		}
	}
}