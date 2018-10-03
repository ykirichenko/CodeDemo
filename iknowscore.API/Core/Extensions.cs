using System.Collections.Generic;
using iknowscore.Services.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iknowscore.API.Core
{
    public static class Extensions
    {
        public static OkObjectResult CreateOkListResult(this HttpResponse response, IEnumerable<object> list, int totalItems)
        {
            response.Headers.Add("X-Total-Count", totalItems.ToString());

            return new OkObjectResult(list);
        }
    }
}
