using DMS.Core.Models;
//using DMS.Core.Models.LogStashModel;
//using DMS.Core.Models.ObjectSearch;
using DMS.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Repositories
{
    public static class DataServiceElastic
    {

        private static HttpClient CreateClient()
        {
            var elasticHost = AppSettings.Instance.ElasticSettings.Hosts;
            var client = new HttpClient()
            {
                BaseAddress = new Uri(elasticHost),
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        //public async static Task<ObjectSearchProfileResult> GetListObjectProfileSearch(string query, int pageNumber, int pageSize, Guid organizationId, int status)
        //{
        //    using (var client = CreateClient())
        //    {
        //        var url = $"api/search/full?pageNumber={pageNumber}&pageSize={pageSize}&query={query}&organizationId={organizationId.GetString()}&status={status.GetString()}";
        //        var response = await client.GetAsync(url);
        //        if (response.IsSuccessStatusCode == false) return ObjectSearchProfileResult.Default;
        //        var responseBody = await response.Content.ReadAsStringAsync();
        //        var result = JsonConvert.DeserializeObject<ObjectSearchProfileResult>(responseBody);
        //        return result;
        //    }

        //}
               
    }
}