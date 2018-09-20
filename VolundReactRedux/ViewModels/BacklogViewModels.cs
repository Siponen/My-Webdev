using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VolundApp.ViewModels
{
    public enum GameStatus { Backlog = 1, Finished, LowPriority, Broken, Discontinued }

    public class GameElement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GenreName { get; set; }
        public string ReleaseDate { get; set; }
        public string ImagePath { get; set; }
    }

    public class CreateFinishedGame
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int GenreId { get; set; }

        public DateTime? GameStartDate { get; set; }
        public DateTime? GameFinishedDate { get; set; }
        public int HoursPlayed { get; set; }
        public int DaysPlayed { get; set; }
        public int GameRatingId { get; set; }
    }

    public class CreateBacklogGame
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int GenreId { get; set; }
    }

    public class GameDetails
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public string GenreName { get; set; }
        public string ReleaseDate { get; set; }
        public string ImagePath { get; set; }
        public bool IsFavourite { get; set; }

        public string GameRating { get; set; }

        public bool HasFinishedGame { get; set; }
        public string FinishedGameDate { get; set; }
        public int HoursPlayed { get; set; }
        public int DaysPlayed { get; set; }
        
        //public List<PollData> Polls { get; set; }
    }

    public class PollData
    {
        public string PollDate { get; set; }
        public string WinnerGame { get; set; }
        public bool HasWon { get; set; }
    }
}
