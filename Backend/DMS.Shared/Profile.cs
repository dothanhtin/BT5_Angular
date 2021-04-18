using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudDinary_BaseUsing.Models
{
    public class ProfileSetting
    {
        public static Profile _profileSetting { get; set; }
    }
    public class Profile
    {
        public string cloudName { get; set; }
        public string apiKey { get; set; }
        public string apiSecret { get; set; }
    }
}
