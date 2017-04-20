using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using InformaSpexBanner.Entities;

namespace InformaSpexBanner.Entities
{
	public class CustomText
	{
		public int Id { get; set; }
		[DisplayName("Prefix Text")]
		public string FixedText { get; set; }
		[DisplayName("Text Size")]
		public int FontSize { get; set; }
		[DisplayName("Text Color")]
		public string FontColorHex { get; set; }
		[DisplayName("Font")]
		public string FontTypeFace { get; set; }
		public int PositionX { get; set; }
		public int PositionY { get; set; }
		public int BannerId{get;set;}
		[ForeignKey("BannerId")]
		public virtual Banner Banner { get; set; }
	}
}