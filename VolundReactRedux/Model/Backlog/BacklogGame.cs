using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolundApp.Model.Backlog
{
    public class BacklogGame
    {
        public int BacklogGameId { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}