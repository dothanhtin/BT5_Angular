using DMS.Core.Models;
using DMS.Core.Repositories;
using DMS.Core.Services;
using DMS.Repositories.Helpers;
using DMS.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VNPT.Framework.CommonType;
namespace DMS.Services
{
    public class DanhMucTinhThanhPhoService : IDanhMucTinhThanhPhoService
    {
        private readonly IDanhMucTinhThanhPhoRepository _danhmuctinhthanhphoRepository;
        public DanhMucTinhThanhPhoService (IDanhMucTinhThanhPhoRepository danhmuc)
        {
            _danhmuctinhthanhphoRepository = danhmuc;
        }

        public async Task<FunctionResult> CreateListDanhMucTinhThanhPhoAsync(List<DanhMucTinhThanhPho> listDanhMuc, CancellationToken cancellationToken)
        {
            var result = FunctionResult.Success;
            var value = await _danhmuctinhthanhphoRepository.InsertMultiDanhMucTinhThanhPhoAsync(listDanhMuc, cancellationToken);
            if (value == null) result.Error(ErrorCodeCollection.DanhMucTinhThanhPho.DanhMucTinhThanhPhoCreateFail);
            result.SetData(value);
            return result;
        }

        public async Task<FunctionResult> CreateNewDanhMucTinhThanhPhoAsync(DanhMucTinhThanhPho danhmuctinhthanhpho, CancellationToken cancellationToken)
        {
            var result = FunctionResult.Success;
            var value = await _danhmuctinhthanhphoRepository.InsertDanhMucTinhThanhPhoAsync(danhmuctinhthanhpho, cancellationToken);
            if (value == null) result.Error(ErrorCodeCollection.DanhMucTinhThanhPho.DanhMucTinhThanhPhoCreateFail);
            result.SetData(value);
            return result;
        }

        public async Task<FunctionResult> DeleteDanhMucTinhThanhPhoAsync(Guid id, CancellationToken cancellationToken)
        {
            
            var result = FunctionResult.Success;
            var value = await _danhmuctinhthanhphoRepository.DeleteDanhMucTinhThanhPhoByIdAsync(id, cancellationToken);
            if (value == 0) result.Error(ErrorCodeCollection.DanhMucTinhThanhPho.DanhMucTinhThanhPhoDeleteFail);
            return result;
        }

        public async Task<DanhMucTinhThanhPho> GetDanhMucTinhThanhPhoByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var danhmuc = await _danhmuctinhthanhphoRepository.GetDanhMucTinhThanhPhoByIdAsync(id, cancellationToken);
            return danhmuc;
        }

        public async Task<List<DanhMucTinhThanhPho>> GetListDanhMucTinhThanhPhoAsync( CancellationToken cancellationToken)
        {
            var listDanhMucTinhThanhPho = await _danhmuctinhthanhphoRepository.GetListDanhMucTinhThanhPhoAsync(cancellationToken);       
            return listDanhMucTinhThanhPho;
          
        }

        public async Task<FunctionResult> UpdateDanhMucTinhThanhPhoAsync(DanhMucTinhThanhPho danhmuctinhthanhpho, CancellationToken cancellationToken)
        {
            var result = FunctionResult.Success;
            var value = await _danhmuctinhthanhphoRepository.UpdateDanhMucTinhThanhPhoAsync(danhmuctinhthanhpho, cancellationToken);
            if (value == null) result.Error(ErrorCodeCollection.AccountError.AccountUpdateFailed);
            result.SetData(value);
            return result;
        }
    }
}
