using Couchbase;
using Couchbase.N1QL;
using DMS.Core.Models;
using DMS.Core.Repositories;
using DMS.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DMS.Repositories
{
    public class DanhMucTinhThanhPhoRepository : IDanhMucTinhThanhPhoRepository
    {
        private static CouchbaseDataAccess dataAccess = CouchbaseDataAccess.Instance;
        private Couchbase.Core.IBucket bucket = dataAccess.DanhMucTinhThanhPhoBucket;

        public async Task<int> DeleteDanhMucTinhThanhPhoByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await bucket.RemoveAsync(id.ToString());
            return result.Success? 1: 0;
        }

        public async Task<DanhMucTinhThanhPho> GetDanhMucTinhThanhPhoByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var statement = $"SELECT bucketname.* FROM {bucket.Name} AS bucketname WHERE `partition` = $_partition AND bucketname.id = $_id";
            var query = new QueryRequest(statement)
                            .AddNamedParameter("_id", id)
                            .AddNamedParameter("_partition", "DanhMucTinhThanhPho");
            var result = await bucket.QueryAsync<DanhMucTinhThanhPho>(query);
            return result.Rows.FirstOrDefault();
        }

        public async Task<List<DanhMucTinhThanhPho>> GetListDanhMucTinhThanhPhoAsync(CancellationToken cancellationToken)
        {
            var statement = $"SELECT bucketname.* FROM {bucket.Name} AS bucketname WHERE `partition` = $_partition ";
            var query = new QueryRequest(statement)
                            .AddNamedParameter("_partition", "DanhMucTinhThanhPho");

            var result = await bucket.QueryAsync<DanhMucTinhThanhPho>(query);
            return result.Rows;
        }

        public async Task<DanhMucTinhThanhPho> InsertDanhMucTinhThanhPhoAsync(DanhMucTinhThanhPho danhmuctinhthanhpho, CancellationToken cancellationToken)
        {
            var document = new Document<DanhMucTinhThanhPho>
            {
                Content = danhmuctinhthanhpho,
                Id = danhmuctinhthanhpho.Id.GetString()
            };
            var result = await bucket.InsertAsync(document);
            return result.Success ? danhmuctinhthanhpho : null;
        }

        public async Task<int> InsertMultiDanhMucTinhThanhPhoAsync(List<DanhMucTinhThanhPho> listDanhMuc, CancellationToken cancellationToken )
        {
            var itemDanhMuc = new Dictionary<string, DanhMucTinhThanhPho>();
            foreach (var doc in listDanhMuc)
            {
                itemDanhMuc.Add(doc.Id.GetString(), doc);
            }
            var result = bucket.Upsert(itemDanhMuc);
            return (result != null) ? 1 : 0;
        }

        public async Task<DanhMucTinhThanhPho> UpdateDanhMucTinhThanhPhoAsync(DanhMucTinhThanhPho danhmuctinhthanhpho, CancellationToken cancellationToken)
        {
            var danhmuc = await GetDanhMucTinhThanhPhoByIdAsync(danhmuctinhthanhpho.Id, cancellationToken);
            if (danhmuc == null) return null;
            else danhmuctinhthanhpho = danhmuctinhthanhpho.MixBaseObject(danhmuc);

            var document = new Document<DanhMucTinhThanhPho>
            {
                Content = danhmuctinhthanhpho,
                Id = danhmuctinhthanhpho.Id.GetString()
            };
            var result = await bucket.UpsertAsync(document);
            return result.Success ? danhmuctinhthanhpho : null;
        }
    }
}
