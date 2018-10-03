using System.Collections.Generic;

namespace iknowscore.DomainModel.Models
{
    public partial class Team : BaseEntity
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public int? CountryId { get; set; }
        public string City { get; set; }
        public byte[] ImageFile { get; set; }

        public Country Country { get; set; }
        public ICollection<TeamTournament> TeamTournament { get; set; }
    }
}
