using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Shared
{
    public static class GuidExtension
    {
        public static string GetString(this Guid source)
        {
            return $"{source}";
        }
    }
}
