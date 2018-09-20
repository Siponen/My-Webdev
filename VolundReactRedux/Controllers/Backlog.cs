using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VolundApp.Model.Backlog;
using VolundApp.ViewModels;
using VolundApp.DAL;
using Microsoft.EntityFrameworkCore;
using VolundApp.Util;

namespace VolundReact.Controllers
{
    [Route("api/[controller]")]
    public class Backlog : Controller
    {
        private BacklogContext db;
        public Backlog(BacklogContext context)
        {
            db = context;
        }

        [HttpPost("[action]")]
        public MessageResult CreateFinishedGame(CreateFinishedGame data)
        {
            MessageResult result = MessageResult.ErrorMessage("Failed to create");

            try
            {
                if (db.Games.Any(g => g.Name == data.Name))
                {
                    return MessageResult.ErrorMessage($"Game name {data.Name} already exists, can't add game.");
                }

                Game newGame = new Game()
                {
                    Name = data.Name,
                    GenreId = data.GenreId,
                    ImagePath = data.ImagePath,
                    ReleaseDate = data.ReleaseDate,
                };

                db.Games.Add(newGame);
                db.SaveChanges();

                Game addedGame = db.Games.Where(g => g.Name == data.Name)
                    .SingleOrDefault();

                FinishedGame newFinishedGame = new FinishedGame()
                {
                    GameId = addedGame.GameId,
                    DaysPlayed = data.DaysPlayed,
                    HoursPlayed = data.HoursPlayed,
                    GameRatingId = data.GameRatingId,
                    GameStartDate = data.GameStartDate,
                    GameFinishedDate = data.GameFinishedDate,
                };

                db.FinishedGames.Add(newFinishedGame);
                db.SaveChanges();

                result = MessageResult.SuccessMessage($"Game {data.Name} has been added to the Finished games list");
            }
            catch
            {
                throw;
            }

            return result;
        }

        [HttpPost("[action]")]
        public MessageResult CreateBacklogGame(Game game)
        {
            MessageResult result = MessageResult.ErrorMessage($"{game.Name} failed to be created");

            //Is this binding the input data to guard against XSS and other input attacks?
            try
            {
                Game newGame = new Game()
                {
                    GameId = game.GameId,
                    Name = game.Name,
                    GenreId = game.GenreId,
                    ImagePath = game.ImagePath,
                    ReleaseDate = game.ReleaseDate,
                };

                db.Games.Add(newGame);
                db.SaveChanges();

                result = MessageResult.SuccessMessage($"{game.Name} has been created");
            }
            catch
            {
                throw;
            }
            return result;
        }

        [HttpPost("[action]")]
        public int CreateGame(Game game)
        {
            int result = -1;
            try
            {
                var foo = db.Games.Add(game);
                db.SaveChanges();
                result = 1;
            }
            catch
            {
                throw;
            }
            return result;
        }

        [HttpGet("[action]")]
        public int DeleteGame(int gameId)
        {
            var game = db.Games.Find(gameId);
            if (game == null) return -1;

            return 0;
        }

        [HttpGet("[action]")]
        public IEnumerable<GameElement> Games(int page)
        {
            var games = db.Games
                .Include(g => g.Genre)
                .ToArray();

            var viewModel = new List<GameElement>();
            foreach (var game in games)
            {
                string releaseDate = DateToString.GetYearOnly(game.ReleaseDate);
                var elem = new GameElement()
                {
                    Id = game.GameId,
                    Name = game.Name,
                    ReleaseDate = releaseDate,
                    GenreName = game.Genre.Name,
                    ImagePath = Util.GetImageFilePath(game.ImagePath)
                };
                viewModel.Add(elem);
            }

            return viewModel;
        }

        [HttpGet("[action]")]
        public IEnumerable<GameElement> UnfinishedGames(int foo)
        {
            var unfinishedGames = db.BacklogGames
                .Include(g => g.Game)
                .ThenInclude(g => g.Genre)
                .ToArray();

            var viewModel = new List<GameElement>();
            foreach (var unfinished in unfinishedGames)
            {
                var releaseDate = DateToString.GetYearOnly(unfinished.Game.ReleaseDate);
                var elem = new GameElement()
                {
                    Id = unfinished.BacklogGameId,
                    Name = unfinished.Game.Name,
                    GenreName = unfinished.Game.Genre.Name,
                    ReleaseDate = releaseDate,
                    ImagePath = Util.GetImageFilePath(unfinished.Game.ImagePath)
                };
                viewModel.Add(elem);
            }
            return viewModel;
        }

        [HttpGet("[action]")]
        public IEnumerable<GameElement> FinishedGames(int page)
        {
            var finishedArray = db.FinishedGames
                .Include(g => g.GameRating)
                .Include(g => g.Game)
                .ThenInclude(g => g.Genre)
                .ToArray();

            var viewModel = new List<GameElement>();
            foreach (var finished in finishedArray)
            {
                string releaseDate = DateToString.GetYearOnly(finished.Game.ReleaseDate);
                var elem = new GameElement()
                {
                    Id = finished.GameId,
                    GenreName = finished.Game.Genre.Name,
                    ImagePath = Util.GetImageFilePath(finished.Game.ImagePath),
                    Name = finished.Game.Name,
                    ReleaseDate = releaseDate
                };
                viewModel.Add(elem);
            }

            return viewModel;
        }

        [HttpGet("[action]")]
        public IEnumerable<GameElement> BrokenGames(int page)
        {
            var brokenArray = db.BrokenGames
                .Include(g => g.Game)
                .ThenInclude(g => g.Genre)
                .ToArray();

            var viewModel = new List<GameElement>();
            foreach (var broken in brokenArray)
            {
                string releaseDate = DateToString.GetYearOnly(broken.Game.ReleaseDate);
                var elem = new GameElement()
                {
                    Id = broken.GameId,
                    GenreName = broken.Game.Genre.Name,
                    ImagePath = Util.GetImageFilePath(broken.Game.ImagePath),
                    Name = broken.Game.Name,
                    ReleaseDate = releaseDate
                };
                viewModel.Add(elem);
            }

            return viewModel;
        }

        [HttpGet("[action]")]
        public IEnumerable<GameElement> DiscontinuedGames(int page)
        {
            var discontinuedArray = db.DiscontinuedGames
                .Include(g => g.Game)
                .ThenInclude(g => g.Genre)
                .ToArray();

            var viewModel = new List<GameElement>();
            foreach (var game in discontinuedArray)
            {
                string releaseDate = DateToString.GetYearOnly(game.Game.ReleaseDate);
                var elem = new GameElement()
                {
                    Id = game.GameId,
                    GenreName = game.Game.Genre.Name,
                    ImagePath = Util.GetImageFilePath(game.Game.ImagePath),
                    Name = game.Game.Name,
                    ReleaseDate = releaseDate
                };
                viewModel.Add(elem);
            }
            return viewModel;
        }

        [HttpGet("[action]")]
        public IEnumerable<GameElement> LowPriorityGames(int page)
        {
            var lowPrioArray = db.LowPriorityGames
                .Include(g => g.Game)
                .ThenInclude(g => g.Genre)
                .ToArray();

            var viewModel = new List<GameElement>();
            foreach (var low in lowPrioArray)
            {
                string releaseDate = DateToString.GetYearOnly(low.Game.ReleaseDate);
                var elem = new GameElement()
                {
                    Id = low.Game.GameId,
                    GenreName = low.Game.Genre.Name,
                    ImagePath = Util.GetImageFilePath(low.Game.ImagePath),
                    Name = low.Game.Name,
                    ReleaseDate = releaseDate
                };
                viewModel.Add(elem);
            }

            return viewModel;
        }
    }
}
