using System.Collections.Generic;

namespace iknowscore.Services.Core
{
    public class GenericResponse<T>
    {
        public int TotalItems { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}
