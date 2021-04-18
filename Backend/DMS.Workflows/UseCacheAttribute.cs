using DMS.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Workflows
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class UseCacheAttribute : Attribute
    {
        public int Seconds { get; set; }
        public UseCacheAttribute(int expireAfterSeconds)
        {
            Seconds = expireAfterSeconds;
        }

        public UseCacheAttribute()
        {
            Seconds = CacheSettings.DefaultRetention;
        }

    }
}
