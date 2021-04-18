using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VNPT.Framework.CommonType;
using DMS.Core.Services;
using DMS.Repositories.Helpers;

namespace DMS.Workflows.DanhMucTinhThanhPhoWorkflows
{
    public class DanhMucTinhThanhPhoGetListByOrganizationStepHandler : BaseStepHandler
    {
        private readonly IDanhMucTinhThanhPhoService _danhmuctinhthanhphoService;
        private readonly string _token;
        public DanhMucTinhThanhPhoGetListByOrganizationStepHandler(string token)
        {
            _token = token;
            _danhmuctinhthanhphoService = DependencyResolution.Resolve<IDanhMucTinhThanhPhoService>();
        }
        public override bool Required => true;

        public override async Task<FunctionResult> ExecuteAsync(FunctionResult previousResults, CancellationToken cancellationToken)
        {
            var result = FunctionResult.Success;
            var listDanhMucTinhThanhPho = await _danhmuctinhthanhphoService.GetListDanhMucTinhThanhPhoAsync(cancellationToken);
            result.SetData(listDanhMucTinhThanhPho);
            return result;
        }
    }
}
