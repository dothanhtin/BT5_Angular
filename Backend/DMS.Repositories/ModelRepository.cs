using Couchbase;
using Couchbase.N1QL;
using DMS.Core.Models;
using DMS.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DMS.Repositories
{
  public class ModelRepository : IModelRepository
  {
    private static CouchbaseDataAccess dataAccess = CouchbaseDataAccess.Instance;
    private Couchbase.Core.IBucket bucket = dataAccess.DanhMucTinhThanhPhoBucket;

    public async Task<Model> GetModelByIdAsync(Guid id, CancellationToken cancellationToken)
    {
      var statement = $"SELECT bucketname.* FROM {bucket.Name} AS bucketname WHERE `partition` = $_partition AND bucketname.id = $_id";
      var query = new QueryRequest(statement)
                      .AddNamedParameter("_id", id)
                      .AddNamedParameter("_partition", "Model");
      var result = await bucket.QueryAsync<Model>(query);
      return result.Rows.FirstOrDefault();
    }

    public async Task<int> DeleteModelAsync(Guid id, CancellationToken cancellationToken)
    {
      var result = await bucket.RemoveAsync(id.ToString());
      return result.Success ? 1 : 0;
    }

    public async Task<List<Model>> GetListModelAsync(CancellationToken cancellationToken)
    {
      var statement = $"SELECT bucketname.* FROM {bucket.Name} AS bucketname WHERE `partition` = $_partition ";
      var query = new QueryRequest(statement)
                      .AddNamedParameter("_partition", "Model");

      var result = await bucket.QueryAsync<Model>(query);
      return result.Rows;
    }

    public async Task<Model> InsertModelAsync(Model model, CancellationToken cancellationToken)
    {
      var dtNow = DateTime.Now;
      model.CreatedOn = dtNow;
      model.UpdatedOn = dtNow;
      var document = new Document<Model>
      {
        Content = model,
        Id = model.Id.ToString()
      };
      var result = await bucket.InsertAsync(document);
      return result.Success ? model : null;
    }

    public async Task<Model> UpdateModelAsync(Model model, CancellationToken cancellationToken)
    {
      Model oldModel = await GetModelByIdAsync(model.Id, cancellationToken);
      oldModel.code = model.code;
      oldModel.name = model.name;
      oldModel.email = model.email;
      oldModel.address = model.address;
      oldModel.birthday = model.birthday;
      oldModel.image = model.image;
      oldModel.UpdatedOn = DateTime.Now;
      var document = new Document<Model>
      {
        Content = oldModel,
        Id = model.Id.ToString()
      };
      //var result = await bucket.UpsertAsync(document);
      var result = await bucket.ReplaceAsync(document);
      //await Task.Delay(200);
      return result.Success ? model : null;
    }
  }
}
