using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VNPT.Framework.CommonType;
using DMS.Core.Services;

namespace DMS.Workflows.DanhMucTinhThanhPhoWorkflows
{
    public class DanhMucTinhThanhPhoDeleteStepHandler : BaseStepHandler
    {
        private readonly IDanhMucTinhThanhPhoService _danhmuctinhthanhphoService;
        private readonly Guid id;
        public DanhMucTinhThanhPhoDeleteStepHandler(Guid _idDanhMucTinhThanhPho)
        {
            id = _idDanhMucTinhThanhPho;
            _danhmuctinhthanhphoService = DependencyResolution.Resolve<IDanhMucTinhThanhPhoService>();
        }
        public override bool Required => true;

        public override async Task<FunctionResult> ExecuteAsync(FunctionResult previousResults, CancellationToken cancellationToken)
        {
            var result = await _danhmuctinhthanhphoService.DeleteDanhMucTinhThanhPhoAsync(id, cancellationToken);
            return result;
        }
    }
}
