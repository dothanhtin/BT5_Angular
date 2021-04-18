using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VNPT.Framework.Extensions;

namespace DMS.RestApi
{
    public static class HttpRequestExtension
    {
        public static string GetHeaderValue(this HttpRequest request, string header)
        {
            if (request == null) return string.Empty;

            var successful = request.Headers.TryGetValue(header, out StringValues headerValue);
            return successful ? headerValue.First() : string.Empty;
        }

        public static string GetQueryString(this HttpRequest request, string param)
        {
            if (request == null) return string.Empty;

            var value= request.Query[param];
            return value;
        }

        public static string GetTokenValue(this HttpRequest request)
        {
            var value = GetHeaderValue(request, "token");
            if (value.IsNullOrEmpty()) value = GetQueryString(request, "token");
            return value;
        }

        public static string GetPolicyValue(this HttpRequest request)
        {
            var value = GetHeaderValue(request, "policyid");
            if (value.IsNullOrEmpty()) value = GetQueryString(request, "policyid");
            return value;
        }

        public static string GetMenuItemValue(this HttpRequest request)
        {
            var value = GetHeaderValue(request, "menuitemid");
            if (value.IsNullOrEmpty()) value = GetQueryString(request, "menuitemid");
            return value;
        }
    }
}
