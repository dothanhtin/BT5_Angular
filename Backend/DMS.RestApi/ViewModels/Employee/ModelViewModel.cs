using DMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.RestApi.ViewModels.Employee
{
  public class ModelViewModel : BaseViewModel
  {
    public Guid id { get; set; }
    public string code { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string image { get; set; }
    public string address { get; set; }
    public DateTime birthday { get; set; }
    public Model GetModel()
    {
      var employee = new Model
      {
        Id = this.id == Guid.Empty ? Guid.NewGuid() : this.id,
        name = this.name,
        email = this.email,
        image = this.image,
        birthday = this.birthday,
        code = this.code,
        address = this.address
      };
      return employee;
    }
  }
}
