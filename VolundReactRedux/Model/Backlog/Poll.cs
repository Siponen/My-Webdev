using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolundApp.Model.Backlog
{
    public class Poll
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public int WinningGameId { get; set; }

        public List<GameInPoll> GameList { get; set; }
        public List<Vote> Voters { get; set; }
    }
}
