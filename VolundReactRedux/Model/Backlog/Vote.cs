using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolundApp.Model.Backlog
{
    public class Vote
    {
        public int Id { get; set; }
        public int VoteCount { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }

        public int UserId { get; set; }
        public TwitchUser User { get; set; }

        public int PollId { get; set; }
        public Poll Poll { get; set; }
    }
}
