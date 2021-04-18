using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DMS.Core.Models;
using DMS.Core.Services;
using DMS.Repositories.Helpers;
using DMS.Shared;
using VNPT.Framework.CommonType;

namespace DMS.Workflows.DanhMucTinhThanhPhoWorkflows
{
    class DanhMucTinhThanhPhoCreateNewStepHandler : BaseStepHandler
    {
        private readonly IDanhMucTinhThanhPhoService _danhmuctinhthanhphoService;
        private readonly DMS.Core.Models.DanhMucTinhThanhPho _danhmuctinhthanhpho;
        public DanhMucTinhThanhPhoCreateNewStepHandler(DMS.Core.Models.DanhMucTinhThanhPho danhmuctinhthanhpho)
        {
            
            _danhmuctinhthanhphoService = DependencyResolution.Resolve<IDanhMucTinhThanhPhoService>();
            _danhmuctinhthanhpho = danhmuctinhthanhpho;
        }
        public override bool Required => true;

        public override async Task<FunctionResult> ExecuteAsync(FunctionResult previousResults, CancellationToken cancellationToken)
        {
            var result = await _danhmuctinhthanhphoService.CreateNewDanhMucTinhThanhPhoAsync(_danhmuctinhthanhpho, cancellationToken);
            return result;
        }
    }
}
