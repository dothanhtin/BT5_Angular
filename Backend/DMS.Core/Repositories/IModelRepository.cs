using DMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DMS.Core.Repositories
{
    public interface IModelRepository
    {
        Task<List<Model>> GetListModelAsync(CancellationToken cancellationToken);

        Task<Model> InsertModelAsync(Model model, CancellationToken cancellationToken);

        Task<Model> UpdateModelAsync(Model model, CancellationToken cancellationToken);

        Task<int> DeleteModelAsync(Guid id, CancellationToken cancellationToken);
    }
}
