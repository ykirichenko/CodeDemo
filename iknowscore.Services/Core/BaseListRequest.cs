namespace iknowscore.Services.Core
{
    public class BaseListRequest : BaseRequest
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public string Sorting { get; set; }

        public BaseListRequest()
        {
            PageIndex = 1;
            PageSize = 10;
            Sorting = string.Empty;
        }
    }
}
