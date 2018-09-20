using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolundApp.Model.Backlog
{
    public class TwitchUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int UserLevel { get; set; }

        public List<Poll> VotedInPolls { get; set; }
    }
}
