using DMS.Core.Models;
using DMS.Core.Repositories;
using DMS.Core.Services;
using DMS.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VNPT.Framework.CommonType;

namespace DMS.Services
{
    public class ModelService : IModelService
    {
        private readonly IModelRepository _modelRepository;
        public ModelService(IModelRepository model)
        {
            _modelRepository = model;
        }

        public async Task<FunctionResult> DeleteModelAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = FunctionResult.Success;
            var value = await _modelRepository.DeleteModelAsync(id, cancellationToken);
            if (value == 0) result.Error("Delete Failed");
            return result;
        }

        public async Task<List<Core.Models.Model>> GetListModelsAsync(CancellationToken cancellationToken)
        {
            var modelList = await _modelRepository.GetListModelAsync(cancellationToken);
            return modelList;
        }

        public async Task<FunctionResult> InsertModelAsync(Model model, CancellationToken cancellationToken)
        {
            var result = FunctionResult.Success;
            var value = await _modelRepository.InsertModelAsync(model, cancellationToken);
            if (value == null) result.Error("Insert Fail");
            result.SetData(value);
            return result;
        }

        public async Task<FunctionResult> UpdateModelAsync(Model model, CancellationToken cancellationToken)
        {
            var result = FunctionResult.Success;
            var value = await _modelRepository.UpdateModelAsync(model, cancellationToken);
            if (value == null) result.Error("Update failed");
            result.SetData(value);
            return result;
        }
    }
}
