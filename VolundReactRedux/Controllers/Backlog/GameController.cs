using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolundApp.DAL;
using VolundApp.Model.Backlog;
using VolundApp.ViewModels;
using VolundApp.Util;

namespace VolundReactRedux.Controllers.Backlog
{
    [Route("api/Backlog/[controller]")]
    public class GameController
    {
        private BacklogContext db;

        public GameController(BacklogContext context)
        {
            db = context;
        }

        [HttpPost("[action]")]
        public MessageResult Remove(int gameId)
        {
            var game = db.Games.Find(gameId);
            if (game == null) return MessageResult.ErrorMessage($"Removal incomplete, game id {gameId} doesn't exist");

            try
            {
                db.Games.Remove(game);
                db.SaveChanges();
                return MessageResult.SuccessMessage($"{game.Name} has been removed");
            }

            catch
            {
                throw;
            }
        }

        [HttpPost("[action]")]
        public MessageResult Update(Game game)
        {
            try
            {
                //Should be a better more secure way to do this
                //We want to confirm that each variable in game fulfills the constraints
                //and to deny any sort of hacks through the input
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return MessageResult.SuccessMessage($"{game.Name} has been updated");
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("[action]")]
        public GameDetails Details(int gameId)
        {
            var game = db.Games.Where(g => g.GameId == gameId)
                .Include(f => f.Genre)
                .Include(f => f.DiscontinuedGame)
                .Include(f => f.GameBroken)
                .Include(f => f.GameFavourite)
                .Include(f => f.LowPriorityGame)
                .Include(f => f.BacklogGame)
                .Include(f => f.FinishedGame)
                .ThenInclude(bg => bg.GameRating)
                .SingleOrDefault();

            if (game == null) return null; //Error! TODO Should send a redirect instead

            string gameRating = "N/A";
            bool hasFinishedGame = false;
            string finishedDate = "N/A";
            int hoursPlayed = 0;
            int daysPlayed = 0;

            if (game.FinishedGame != null)
            {
                var finishedGame = game.FinishedGame;
                gameRating = finishedGame.GameRating.Rating;
                hasFinishedGame = true;
                finishedDate = DateToString.GetFullDate(finishedGame.GameFinishedDate);
                hoursPlayed = finishedGame.HoursPlayed;
                daysPlayed = finishedGame.DaysPlayed;
            }

            var elem = new GameDetails()
            {
                Id = game.GameId,
                GameName = game.Name,
                GenreName = game.Genre.Name,
                ReleaseDate = DateToString.GetYearMonth(game.ReleaseDate),
                ImagePath = Util.GetImageFilePath(game.ImagePath),
                IsFavourite = game.GameFavourite != null,
                GameRating = gameRating,
                HasFinishedGame = hasFinishedGame,
                FinishedGameDate = finishedDate,
                HoursPlayed = hoursPlayed,
                DaysPlayed = daysPlayed
            };

            return elem;
        }
    }
}
