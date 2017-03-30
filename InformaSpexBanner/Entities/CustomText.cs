using System.ComponentModel.DataAnnotations.Schema;
using InformaSpexBanner.Entities;

namespace InformaSpexBanner.Entities
{
	public class CustomText
	{
		public int Id { get; set; }
		public string FixedText { get; set; }
		public int FontSize { get; set; }
		public string FontColorHex { get; set; }
		public string FontTypeFace { get; set; }
		public int PositionX { get; set; }
		public int PositionY { get; set; }
		public int BannerId{get;set;}
		[ForeignKey("BannerId")]
		public virtual Banner Banner { get; set; }
	}
}