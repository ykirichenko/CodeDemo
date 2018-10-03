using iknowscore.Services.Core;

namespace iknowscore.Services.Requests
{
    public class TeamsRequest : BaseListRequest
    {
        public int? CountryId { get; set; }

        public int? TeamTypeId { get; set; }
    }
}
