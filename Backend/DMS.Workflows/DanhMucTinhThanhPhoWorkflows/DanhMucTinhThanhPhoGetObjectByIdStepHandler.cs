using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VNPT.Framework.CommonType;
using DMS.Core.Services;

namespace DMS.Workflows.DanhMucTinhThanhPhoWorkflows
{
    public class DanhMucTinhThanhPhoGetObjectByIdStepHandler : BaseStepHandler
    {
        private readonly IDanhMucTinhThanhPhoService _danhmuctinhthanhphoService;
        private readonly Guid _idDanhMucTinhThanhPho;
        public DanhMucTinhThanhPhoGetObjectByIdStepHandler(Guid id)
        {
            _idDanhMucTinhThanhPho = id;
            _danhmuctinhthanhphoService = DependencyResolution.Resolve<IDanhMucTinhThanhPhoService>();
        }
        public override bool Required => true;

        public override async Task<FunctionResult> ExecuteAsync(FunctionResult previousResults, CancellationToken cancellationToken)
        {
            var result = FunctionResult.Success;
            var danhmuc = await _danhmuctinhthanhphoService.GetDanhMucTinhThanhPhoByIdAsync(_idDanhMucTinhThanhPho, cancellationToken);
            result.SetData(danhmuc);
            return result;
        }
    }
}
