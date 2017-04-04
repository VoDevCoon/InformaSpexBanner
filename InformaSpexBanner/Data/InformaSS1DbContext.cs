using Microsoft.EntityFrameworkCore;
using InformaSpexBanner.Entities;

namespace InformaSpexBanner.Data
{
	public class InformaSS1DbContext : DbContext
	{
		public InformaSS1DbContext(DbContextOptions<InformaSS1DbContext> options) : base(options)
		{
			Database.Migrate();
		}

		public DbSet<Exhibition> Exhibitions { get; set; }
		public DbSet<Banner> Banners { get; set; }
		public DbSet<CustomText> CustomTexts { get; set; }
	}
}