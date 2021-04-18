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
    class ModelInsertStepHandler : BaseStepHandler
    {
        private readonly IModelService _modelService;
        private readonly Model _model;
        public ModelInsertStepHandler(Model model)
        {
            _modelService = DependencyResolution.Resolve<IModelService>();
            _model = model;
        }
        public override bool Required => true;

        public override async Task<FunctionResult> ExecuteAsync(FunctionResult previousResults, CancellationToken cancellationToken)
        {
            var result = await _modelService.InsertModelAsync(_model, cancellationToken);
            return result;
        }
    }
}
