using System;
using System.Collections.Generic;
using System.Text;


namespace DMS.Core.Models
{
    public class DanhMucTinhThanhPho : BaseModel
    {
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string TenTiengAnh { get; set; }
        public string Cap { get; set; }
        public string MaQH { get; set; }
        public string QuanHuyen { get; set; }
        public string MaTP { get; set; }
        public string TinhTP { get; set; }
        public override string Partition => "DanhMucTinhThanhPho";
        public DanhMucTinhThanhPho MixBaseObject( DanhMucTinhThanhPho danhmuctinhthanhpho)
        {
            var danhmuc = danhmuctinhthanhpho;
            if (!String.IsNullOrEmpty(Ma)) danhmuc.Ma = Ma;
            if (!String.IsNullOrEmpty(Ten)) danhmuc.Ten = Ten;
            if (!String.IsNullOrEmpty(TenTiengAnh)) danhmuc.TenTiengAnh = TenTiengAnh;
            if (!String.IsNullOrEmpty(Cap)) danhmuc.Cap = Cap;
            if (!String.IsNullOrEmpty(MaQH)) danhmuc.MaQH = MaQH;
            if (!String.IsNullOrEmpty(QuanHuyen)) danhmuc.QuanHuyen = QuanHuyen;
            if (!String.IsNullOrEmpty(MaTP)) danhmuc.MaTP = MaTP;
            if (!String.IsNullOrEmpty(TinhTP)) danhmuc.TinhTP = TinhTP;
            return danhmuc;
        }

    }
}
