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
    class ModelUpdateStepHandler : BaseStepHandler
    {
        private readonly IModelService _employeeService;
        private readonly Model _employee;
        public ModelUpdateStepHandler(Model employee)
        {
            _employeeService = DependencyResolution.Resolve<IModelService>();
            _employee = employee;


        }

        public override bool Required => true;

        public override async Task<FunctionResult> ExecuteAsync(FunctionResult previousResults, CancellationToken cancellationToken)
        {
            var result = await _employeeService.UpdateModelAsync(_employee, cancellationToken);
            return result;
        }
    }
}
