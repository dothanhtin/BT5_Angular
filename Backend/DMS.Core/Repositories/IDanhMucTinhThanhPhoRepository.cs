using DMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DMS.Core.Repositories
{
    public interface IDanhMucTinhThanhPhoRepository
    {
        Task<DanhMucTinhThanhPho> InsertDanhMucTinhThanhPhoAsync(DanhMucTinhThanhPho danhmuctinhthanhpho, CancellationToken cancellationToken);
        Task<DanhMucTinhThanhPho> UpdateDanhMucTinhThanhPhoAsync(DanhMucTinhThanhPho danhmuctinhthanhpho, CancellationToken cancellationToken);
        Task<int> DeleteDanhMucTinhThanhPhoByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<DanhMucTinhThanhPho> GetDanhMucTinhThanhPhoByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<DanhMucTinhThanhPho>> GetListDanhMucTinhThanhPhoAsync( CancellationToken cancellationToken);
        Task<int> InsertMultiDanhMucTinhThanhPhoAsync(List<DanhMucTinhThanhPho> listDanhMuc, CancellationToken cancellationToken);
    }
}
