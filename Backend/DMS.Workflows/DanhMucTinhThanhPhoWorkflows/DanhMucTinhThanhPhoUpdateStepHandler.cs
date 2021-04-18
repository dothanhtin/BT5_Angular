using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VNPT.Framework.CommonType;
using DMS.Core.Services;
using DMS.Core.Models;

namespace DMS.Workflows.DanhMucTinhThanhPhoWorkflows
{
    public class DanhMucTinhThanhPhoUpdateStepHandler : BaseStepHandler
    {
        private readonly IDanhMucTinhThanhPhoService _danhmuctinhthanhphoService;
        private readonly DMS.Core.Models.DanhMucTinhThanhPho _danhmuctinhthanhpho;
        public DanhMucTinhThanhPhoUpdateStepHandler(DMS.Core.Models.DanhMucTinhThanhPho danhmuctinhthanhpho)
        {
            _danhmuctinhthanhpho = danhmuctinhthanhpho;
            _danhmuctinhthanhphoService = DependencyResolution.Resolve<IDanhMucTinhThanhPhoService>();
        }
        public override bool Required => true;

        public override async Task<FunctionResult> ExecuteAsync(FunctionResult previousResults, CancellationToken cancellationToken)
        {
            var resultValid = previousResults;
            if (!resultValid.Succeed) return previousResults;

            var result = await _danhmuctinhthanhphoService.UpdateDanhMucTinhThanhPhoAsync(_danhmuctinhthanhpho, cancellationToken);
            return result;
        }
    }
}
