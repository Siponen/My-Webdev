using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolundApp.DAL;
using VolundApp.Model.Backlog;

namespace VolundReact.Model
{
    public static class DbInitializer
    {
        public static void Initialize(BacklogContext context)
        {
            context.Database.EnsureCreated();
            if (context.Genres.Any() == false)
            {
                //Genres, we'll most likely use these in production.
                context.Genres.AddRange(
                    new Genre { Name = "Platform" },
                    new Genre { Name = "Shooter" },
                    new Genre { Name = "Fighting" },
                    new Genre { Name = "RPG" },
                    new Genre { Name = "JRPG" },
                    new Genre { Name = "Shooter RPG" },
                    new Genre { Name = "Hack & Slash" },
                    new Genre { Name = "MMORPG" },

                    new Genre { Name = "Stealth" },
                    new Genre { Name = "Horror" },
                    new Genre { Name = "Rhythm" },
                    new Genre { Name = "Visual novel" },
                    new Genre { Name = "Metroidvania" },
                    new Genre { Name = "Point & click" },
                    new Genre { Name = "Roguelike" },
                    new Genre { Name = "Roguelite" },
                    new Genre { Name = "Simulation" },
                    new Genre { Name = "Tycoon" },
                    new Genre { Name = "City Building" },

                    new Genre { Name = "RTS" },
                    new Genre { Name = "4x" },
                    new Genre { Name = "Grand Strategy" },
                    new Genre { Name = "Turn based Strategy" },
                    new Genre { Name = "Real-time Tactics" },
                    new Genre { Name = "MOBA" },
                    new Genre { Name = "Tower Defense" },

                    new Genre { Name = "Racing" },
                    new Genre { Name = "Sport" },
                    new Genre { Name = "Party" },
                    new Genre { Name = "Board game" },
                    new Genre { Name = "Card game" });
                context.SaveChanges();
            }

            if (context.GameRating.Any() == false)
            {
                //Personal game rating seed data, use these in production as well.
                context.GameRating.AddRange(
                new GameRating { Rating = "Abomination" },
                new GameRating { Rating = "Bad" },
                new GameRating { Rating = "Not good"},
                new GameRating { Rating = "Ok" },
                new GameRating { Rating = "Good" },
                new GameRating { Rating = "Great" },
                new GameRating { Rating = "Awesome" },
                new GameRating { Rating = "EPIC AWESOME" }
                );
                context.SaveChanges();
            }

            if (context.Games.Any() == false)
            {
                //Artificial game seed, scrap for production.
                context.Games.AddRange(
                //Not beaten
                new Game { Name = "Doom", GenreId = 1, ReleaseDate = new DateTime(1992, 12, 12), ImagePath="doom.jpg" },
                new Game { Name = "Elex", GenreId = 2, ReleaseDate = new DateTime(2010, 4, 10), ImagePath="" },
                new Game { Name = "Shadow warrior", GenreId = 3, ReleaseDate = new DateTime(2009, 1, 1), ImagePath = "" },
                new Game { Name = "Morrowind", GenreId = 4, ReleaseDate = new DateTime(2003, 2, 7) },
                new Game { Name = "Deponia", GenreId = 5, ReleaseDate = new DateTime(2007, 1, 16), ImagePath = "doom.jpg" },
                new Game { Name = "Bioshock", GenreId = 6, ReleaseDate = new DateTime(2008, 2, 10), ImagePath = "default.png" },
                new Game { Name = "Far cry", GenreId = 7, ReleaseDate = new DateTime(2013, 3, 11), ImagePath = "doom.jpg" },
                new Game { Name = "Fallout", GenreId = 8, ReleaseDate = new DateTime(2009, 1, 1), ImagePath = "default.png" },
                new Game { Name = "Quake", GenreId = 9, ReleaseDate = new DateTime(1998, 1, 1), ImagePath = "default.png" },

                //Broken
                new Game { Name = "Daikatana", GenreId = 2, ReleaseDate = new DateTime(2000, 1, 1), ImagePath = "default.png" },
                new Game { Name = "Operation Flashpoint", GenreId = 3, ReleaseDate = new DateTime(2002, 1, 1), ImagePath = "doom.jpg" },
                new Game { Name = "Freedom Fighters", GenreId = 4, ReleaseDate = new DateTime(2001, 1, 1), ImagePath = "default.png" },

                //Beaten
                new Game { Name = "Chroma Squad", GenreId = 10, ReleaseDate = new DateTime(1980, 1, 1), ImagePath = "default.png" },
                new Game { Name = "Darwinia", GenreId = 1, ReleaseDate = new DateTime(1981, 2, 1), ImagePath = "doom.jpg" },

                //Game discontinued
                new Game { Name = "Settlers 2", GenreId = 2, ReleaseDate = new DateTime(1982, 3, 1), ImagePath = "default.png" },
                new Game { Name = "Septerra Core", GenreId = 3, ReleaseDate = new DateTime(1983, 4, 1), ImagePath = "default.png" },
                new Game { Name = "Crashlands", GenreId = 4, ReleaseDate = new DateTime(1984, 5, 1), ImagePath = "default.png" },

                //Game low priority
                new Game { Name = "Action Henk", GenreId = 5, ReleaseDate = new DateTime(1985, 6, 1), ImagePath = "default.png" },
                new Game { Name = "Age of Wonders", GenreId = 6, ReleaseDate = new DateTime(1986, 7, 1), ImagePath = "default.png" },
                new Game { Name = "Flesh Eaters", GenreId = 7, ReleaseDate = new DateTime(1987, 8, 1), ImagePath = "default.png" }
                );
                context.SaveChanges();
            }

            if (context.BacklogGames.Any() == false)
            {
                //Artificial game backlog seed, scrap heading into production
                context.BacklogGames.AddRange(
                new BacklogGame { GameId = 1 },
                new BacklogGame { GameId = 2 },
                new BacklogGame { GameId = 3 },
                new BacklogGame { GameId = 4 },
                new BacklogGame { GameId = 5 },
                new BacklogGame { GameId = 6 },
                new BacklogGame { GameId = 7 },
                new BacklogGame { GameId = 8 },
                new BacklogGame { GameId = 9 }
                );
                context.SaveChanges();
            }

            if (context.BrokenGames.Any() == false)
            {
                context.BrokenGames.AddRange(
                new BrokenGame { GameId = 10, Comment = "Boss crashing game" },
                new BrokenGame { GameId = 11, Comment = "Final level game breaking bug" },
                new BrokenGame { GameId = 12, Comment = "Game physics broken, can't finish tutorial misison" }
                );
                context.SaveChanges();
            }

            if (context.FinishedGames.Any() == false)
            {
                context.FinishedGames.AddRange(
                new FinishedGame { GameId = 13, GameRatingId = 4, GameStartDate = new DateTime(2017,8,10), GameFinishedDate = new DateTime(2017,9,3), HoursPlayed = 10, DaysPlayed = 2 },
                new FinishedGame { GameId = 14, GameRatingId = 5, GameStartDate = new DateTime(2018, 10, 20), GameFinishedDate = new DateTime(2018, 11, 20), HoursPlayed = 20, DaysPlayed = 4 }
                );
                context.SaveChanges();
            }

            if (context.DiscontinuedGames.Any() == false)
            {
                context.DiscontinuedGames.AddRange(
                new DiscontinuedGame { GameId = 15, Comment = "14 hour long missions" },
                new DiscontinuedGame { GameId = 16, Comment = "So many battles, so many battles, 3 hours battle, 5 minutes story..so many hours" },
                new DiscontinuedGame { GameId = 17, Comment = "Story is watered down with meaningless sandbox crafting the same stuff with different materials. First story arch is good though" }
                );
                context.SaveChanges();
            }

            if (context.LowPriorityGames.Any() == false)
            {
                context.LowPriorityGames.AddRange(
                new LowPriorityGame { GameId = 18, Date = new DateTime(2016, 1, 2) },
                new LowPriorityGame { GameId = 19, Date = new DateTime(2017, 2, 2) },
                new LowPriorityGame { GameId = 20, Date = new DateTime(2018, 2, 2) }
                );
                context.SaveChanges();
            }

            if (context.TwitchUsers.Any() == false)
            {
                //Artificial twitch user data
                context.TwitchUsers.AddRange(
                new TwitchUser { UserName = "SuperFooUser", UserLevel = 1 },
                new TwitchUser { UserName = "AncientAsian", UserLevel = 9 },
                new TwitchUser { UserName = "Dio", UserLevel = 10 },
                new TwitchUser { UserName = "LegendaryHackerDaku", UserLevel = 1 }
                );
                context.SaveChanges();
            }

            if (context.Polls.Any() == false)
            {
                //Artificial poll data
                context.Polls.AddRange(
                new Poll { StartDate = new DateTime(2016, 1, 1), EndDate = new DateTime(2016, 1, 20) },
                new Poll { StartDate = new DateTime(2018, 6, 19), EndDate = null }
                );
                context.SaveChanges();
            }

            if (context.GamesInPoll.Any() == false)
            {
                context.GamesInPoll.AddRange(
                new GameInPoll { GameId = 1, PollId = 1 },
                new GameInPoll { GameId = 2, PollId = 1 },
                new GameInPoll { GameId = 3, PollId = 1 },
                new GameInPoll { GameId = 4, PollId = 1 },
                new GameInPoll { GameId = 5, PollId = 1 },
                new GameInPoll { GameId = 6, PollId = 2 },
                new GameInPoll { GameId = 7, PollId = 2 },
                new GameInPoll { GameId = 8, PollId = 2 },
                new GameInPoll { GameId = 9, PollId = 2 },
                new GameInPoll { GameId = 1, PollId = 2 }
                );
                context.SaveChanges();
            }

            if (context.Votes.Any() == false)
            {
                context.Votes.AddRange(
                new Vote { PollId = 1, UserId = 1, GameId = 1, VoteCount = 1 },
                new Vote { PollId = 1, UserId = 2, GameId = 2, VoteCount = 9 },
                new Vote { PollId = 1, UserId = 3, GameId = 1, VoteCount = 10 },
                new Vote { PollId = 1, UserId = 4, GameId = 3, VoteCount = 1 }
                );
                context.SaveChanges();
            }
            
        }
    }
}
