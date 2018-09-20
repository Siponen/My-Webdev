using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolundApp.Model.Backlog
{
    public class LowPriorityGame
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
