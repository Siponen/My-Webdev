using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolundApp.Model.Backlog
{
    public class GameRating
    {
        public int Id { get; set; }
        public string Rating { get; set; }

        public List<FinishedGame> GamesRatedAs { get; set; }
    }
}
