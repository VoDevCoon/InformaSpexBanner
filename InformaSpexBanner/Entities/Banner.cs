using System.ComponentModel.DataAnnotations.Schema;
using InformaSpexBanner.Entities;

namespace InformaSpexBanner.Entities
{
	public class Banner
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public CustomText Text { get; set; }
		public byte[] Image { get; set; }
		public int ExhibitionId { get; set; }
		[ForeignKey("ExhibitionId")]
		public virtual Exhibition Exhibition { get; set; }
	}
}