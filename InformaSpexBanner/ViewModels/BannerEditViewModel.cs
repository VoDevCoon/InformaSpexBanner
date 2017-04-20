using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing.Text;

namespace InformaSpexBanner.ViewModels
{
	public class BannerEditViewModel
	{
		[Required]
		public string Name { get; set; }
		public int ExhibitionId { get; set; }
		public IFormFile Image { get; set; }
		public string ExhibitionName { get; set; }

		public int Id { get; set; }
		public string ImageBase64String { get; set; }

		public string FixedText { get; set; }
		public int FontSize { get; set; }
		public string FontColorHex { get; set; }
		public string FontTypeFace { get; set; }
		public int PositionX { get; set; }
		public int PositionY { get; set; }

		public List<SelectListItem> FontList => GetInstalledFontList();

		private List<SelectListItem> GetInstalledFontList()
		{
			var fontList = new List<SelectListItem>();
            //InstalledFontCollection fonts = new InstalledFontCollection();
            //var fontFamilies = fonts.Families;

            //foreach (var font in fontFamilies)
            //{
            //	fontList.Add(new SelectListItem { Text = font.Name, Value = font.Name });
            //}
            fontList.Add(new SelectListItem { Text = "Arial", Value = "Arial" });
            fontList.Add(new SelectListItem { Text = "Arial Black", Value = "Arial Black" });
            fontList.Add(new SelectListItem { Text = "Century Gothic", Value = "Century Gothic" });
			fontList.Add(new SelectListItem { Text = "Courier New", Value = "Courier New" });
            fontList.Add(new SelectListItem { Text = "DejaVu Sans Mono", Value = "DejaVu Sans Mono" });
            fontList.Add(new SelectListItem { Text = "Lucida Sans Unicode", Value = "Lucida Sans Unicode" });
            fontList.Add(new SelectListItem { Text = "Verdana", Value = "Verdana" });

			return fontList;
		}
	}
}