using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Core.Models
{
  public abstract class BaseModel
  {
    public Guid Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
    public Guid CreatedBy { get; set; }
    public abstract string Partition { get; }

  }
}
