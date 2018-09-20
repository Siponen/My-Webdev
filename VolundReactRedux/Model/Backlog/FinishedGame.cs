using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VolundApp.Model.Backlog
{
    public class FinishedGame
    {
        public int FinishedGameId { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }

        public DateTime? GameStartDate { get; set; }
        public DateTime? GameFinishedDate { get; set; }
        public int HoursPlayed { get; set; }
        public int DaysPlayed { get; set; }

        public int GameRatingId { get; set; }
        public GameRating GameRating { get; set; }
    }
}