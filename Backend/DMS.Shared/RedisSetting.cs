using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Shared
{
    public class RedisSetting
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Hosts { get; set; }
        public int Port { get; set; }
    }
}
