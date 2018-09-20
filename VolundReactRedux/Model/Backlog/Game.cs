using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolundApp.Model.Backlog
{
    public class Game
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public BacklogGame BacklogGame { get; set; }
        public FinishedGame FinishedGame { get; set; }
        public FavouriteGame GameFavourite { get; set; }
        public LowPriorityGame LowPriorityGame { get; set; }
        public DiscontinuedGame DiscontinuedGame { get; set; }
        public BrokenGame GameBroken { get; set; }
    }
}