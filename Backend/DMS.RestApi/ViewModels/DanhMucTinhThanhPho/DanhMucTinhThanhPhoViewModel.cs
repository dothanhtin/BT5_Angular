
using DMS.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DMS.RestApi.ViewModels
{
    public class DanhMucTinhThanhPhoViewModel : BaseViewModel
    {
        public Guid ID { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string TenTiengAnh { get; set; }
        public string Cap { get; set; }
        public string MaQH { get; set; }
        public string QuanHuyen { get; set; }
        public string MaTP { get; set; }
        public string TinhTP { get; set; }
        public DMS.Core.Models.DanhMucTinhThanhPho InsertGetModel()
        {
            var danhmuc = new DMS.Core.Models.DanhMucTinhThanhPho
            {
                Id = Guid.NewGuid(),
                Ma = Ma,
                Ten = Ten,
                TenTiengAnh = TenTiengAnh,
                Cap = Cap,
                MaQH = MaQH,
                QuanHuyen = QuanHuyen,
                MaTP = MaTP,
                TinhTP = TinhTP
            };
            return danhmuc;
        }
        public DMS.Core.Models.DanhMucTinhThanhPho UpdateGetModel()
        {
            var danhmuc = new DMS.Core.Models.DanhMucTinhThanhPho{
                Id = ID,
                Ma = Ma,
                Ten = Ten,
                TenTiengAnh = TenTiengAnh,
                Cap = Cap,
                MaQH = MaQH,
                QuanHuyen = QuanHuyen,
                MaTP = MaTP,
                TinhTP = TinhTP
            };
            return danhmuc;
        }
        
    }
}
