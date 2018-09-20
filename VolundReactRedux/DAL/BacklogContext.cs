using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolundApp.Model.Backlog;

namespace VolundApp.DAL
{
    public class BacklogContext : DbContext
    {
        public BacklogContext(DbContextOptions<BacklogContext> options) 
            : base(options)
        { }

        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<FinishedGame> FinishedGames { get; set; }
        public DbSet<BrokenGame> BrokenGames { get; set; }
        public DbSet<DiscontinuedGame> DiscontinuedGames { get; set; }
        public DbSet<LowPriorityGame> LowPriorityGames { get; set; }
        public DbSet<BacklogGame> BacklogGames { get; set; }
        public DbSet<GameRating> GameRating { get; set; }

        public DbSet<GameInPoll> GamesInPoll { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<TwitchUser> TwitchUsers { get; set; }
    }
}
