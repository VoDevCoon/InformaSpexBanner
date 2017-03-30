using System.Collections.Generic;

namespace InformaSpexBanner.Entities
{
	public class Exhibition
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string WebUrl { get; set; }
		public virtual ICollection<Banner> Banners { get; set; }
	}
}