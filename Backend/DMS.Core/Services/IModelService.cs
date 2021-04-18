using DMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VNPT.Framework.CommonType;

namespace DMS.Core.Services
{
    public interface IModelService
    {
        Task<List<Model>> GetListModelsAsync(CancellationToken cancellationToken);
        Task<FunctionResult> InsertModelAsync(Model model, CancellationToken cancellationToken);
        Task<FunctionResult> UpdateModelAsync(Model model, CancellationToken cancellationToken);
        Task<FunctionResult> DeleteModelAsync(Guid id, CancellationToken cancellationToken);
    }
}
