using DMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.RestApi.ViewModels
{
    public class ObjectDeleteViewModel : BaseViewModel
    {
        public Guid Id { get; set; }
    }

}
