using System;
using System.Collections.Generic;
using System.Text;
using DMS.Core.Models;
using System.Threading;
using System.Threading.Tasks;
using VNPT.Framework.CommonType;

namespace DMS.Core.Services
{
    public interface IDanhMucTinhThanhPhoService
    {
        Task<FunctionResult> CreateNewDanhMucTinhThanhPhoAsync(DanhMucTinhThanhPho danhmuctinhthanhpho, CancellationToken cancellationToken);
        Task<FunctionResult> UpdateDanhMucTinhThanhPhoAsync(DanhMucTinhThanhPho danhmuctinhthanhpho, CancellationToken cancellationToken);
        Task<FunctionResult> DeleteDanhMucTinhThanhPhoAsync(Guid id, CancellationToken cancellationToken);
        Task<DanhMucTinhThanhPho> GetDanhMucTinhThanhPhoByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<DanhMucTinhThanhPho>> GetListDanhMucTinhThanhPhoAsync(CancellationToken cancellationToken);
        Task<FunctionResult> CreateListDanhMucTinhThanhPhoAsync(List<DanhMucTinhThanhPho> listDanhMuc, CancellationToken cancellationToken);
    }
}
