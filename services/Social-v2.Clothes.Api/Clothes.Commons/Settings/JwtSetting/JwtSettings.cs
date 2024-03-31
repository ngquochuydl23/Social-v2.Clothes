using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Commons.Settings.JwtSetting
{
    public class JwtSettings
    {
        public const string SectionName = "Logging";
        public string SecretKey { get; set; }
        public int ExpiryDays { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
