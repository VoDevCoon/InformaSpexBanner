using System.Collections.Generic;
using System.ComponentModel;

namespace InformaSpexBanner.Entities
{
	public class Exhibition
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		[DisplayName("Embed URL")]
		public string WebUrl { get; set; }
		public bool Active { get; set; }
		public virtual ICollection<Banner> Banners { get; set; }
	}
}