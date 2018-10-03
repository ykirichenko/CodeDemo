using System.Linq;
using System.Reflection;

namespace iknowscore.Repositories.Helpers
{
    public static class Extensions
    {
        public static IQueryable<T> SortBy<T>(this IQueryable<T> source, string sortField)
        {
            if (string.IsNullOrEmpty(sortField))
            {
                return source;
            }

            var desc = false;

            if (sortField.StartsWith("-"))
            {
                desc = true;
                sortField = sortField.Remove(0, 1);
            }

            var sortProperty = typeof(T).GetProperty(sortField, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (string.IsNullOrEmpty(sortField) || sortProperty == null)
            {
                return source;
            }

            return desc ? source.OrderByDescending(s => sortProperty.GetValue(s, null)) : source.OrderBy(s => sortProperty.GetValue(s, null));
        }
    }
}
