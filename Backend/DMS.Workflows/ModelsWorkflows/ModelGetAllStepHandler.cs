using DMS.Core.Models;
using DMS.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VNPT.Framework.CommonType;

namespace DMS.Workflows.ModelsWorkflows
{
    class ModelGetAllStepHandler : BaseStepHandler
    {
        private readonly IModelService _employeeService;
        //private readonly Employee _employee;

        public ModelGetAllStepHandler()
        {
            _employeeService = DependencyResolution.Resolve<IModelService>();
        }

        public override bool Required => true;

        public override async Task<FunctionResult> ExecuteAsync(FunctionResult previousResults, CancellationToken cancellationToken)
        {
            var result = FunctionResult.Success;
            var employeeLst = await _employeeService.GetListModelsAsync(cancellationToken);
            result.SetData(employeeLst);
            return result;
        }
    }
}
