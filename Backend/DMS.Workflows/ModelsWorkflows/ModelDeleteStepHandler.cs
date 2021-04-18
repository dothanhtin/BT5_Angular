using DMS.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VNPT.Framework.CommonType;

namespace DMS.Workflows.ModelsWorkflows
{
    class ModelDeleteStepHandler : BaseStepHandler
    {
        private readonly IModelService _employeeService;
        private readonly Guid _id;

        public override bool Required => true;
        public ModelDeleteStepHandler(Guid id)
        {
            _employeeService = DependencyResolution.Resolve<IModelService>();
            _id = id;
        }


        public override async Task<FunctionResult> ExecuteAsync(FunctionResult previousResults, CancellationToken cancellationToken)
        {
            var result = FunctionResult.Success;
            var resultExecution = await _employeeService.DeleteModelAsync(_id,cancellationToken);
            result.SetData(resultExecution);
            return result;
        }
    }
}
