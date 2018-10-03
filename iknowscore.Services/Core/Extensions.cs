using System.Collections.Generic;
using System.Linq;

namespace iknowscore.Services.Core
{
    public static class Extensions
    {
        public static IEnumerable<T> Paginate<T>(this IEnumerable<T> source, BaseListRequest listRequest)
        {
            if (listRequest == null)
            {
                listRequest = new BaseListRequest();
            }

            return source
                .Skip((listRequest.PageIndex - 1) * listRequest.PageSize)
                .Take(listRequest.PageSize)
                .ToList();
        }
    }
}
