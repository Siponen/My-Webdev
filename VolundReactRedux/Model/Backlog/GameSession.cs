using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolundApp.Model.Backlog;

namespace VolundReactRedux.Model.Backlog
{
    public class GameSession
    {
        public int Id { get; set; }

        public DateTime StartedGame { get; set; }
        public DateTime FinishedGame { get; set; }
        public float HoursPlayed { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
