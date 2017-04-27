using System.Collections.Generic;
using System.Linq;

namespace InformaSpexBanner.Services
{
    public class IpSecuritySettings
    {
        public string AllowedIPs { get; set; }
        public string Hash { get; set; }
        public List<string> AllowedIPsList
        {
            get { return !string.IsNullOrEmpty(AllowedIPs) ? AllowedIPs.Split(',').ToList() : new List<string>(); }
        }

		public string AdminHash
		{
            get { return Hash; }
		}
    }
}
