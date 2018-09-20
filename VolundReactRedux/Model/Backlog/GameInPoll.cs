using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VolundApp.Model.Backlog
{
    public class GameInPoll
    {
        public int Id { get; set; }
        public int PollId { get; set; }
        public int NumVotes { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
