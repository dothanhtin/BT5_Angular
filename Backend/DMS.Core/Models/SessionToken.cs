using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Core.Models
{
    public class SessionToken : BaseModel
    {
        public Guid AccountId { get; set; }
        public string Source { get; set; }
        public string Token { get; set; }
        public string OrgDecentral { get; set; }
        public DateTime ExpiredOn { get; set; }
        public override string Partition => "SessionToken";
    }
}
