using System.Collections.Generic;

namespace iknowscore.DomainModel.Models
{
    public partial class Country : BaseEntity
    {
        public Country()
        {
            Team = new HashSet<Team>();
            Player = new HashSet<Player>();
        }

        public int CountryId { get; set; }
        public string Name { get; set; }

        public ICollection<Team> Team { get; set; }
        public ICollection<Player> Player { get; set; }
    }
}
