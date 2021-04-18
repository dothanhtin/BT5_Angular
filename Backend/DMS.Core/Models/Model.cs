using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Core.Models
{
  public class Model : BaseModel
  {
    public string code { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string image { get; set; }
    public string address { get; set; }
    public DateTime birthday { get; set; }

    public override string Partition => "Model";
  }
}
