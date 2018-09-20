﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VolundApp.DAL;

namespace VolundReactRedux.Migrations
{
    [DbContext(typeof(BacklogContext))]
    partial class BacklogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VolundApp.Model.Backlog.BacklogGame", b =>
                {
                    b.Property<int>("BacklogGameId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GameId");

                    b.HasKey("BacklogGameId");

                    b.HasIndex("GameId")
                        .IsUnique();

                    b.ToTable("BacklogGames");
                });

            modelBuilder.Entity("VolundApp.Model.Backlog.BrokenGame", b =>
                {
                    b.Property<int>("BrokenGameId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment");

                    b.Property<int>("GameId");

                    b.HasKey("BrokenGameId");

                    b.HasIndex("GameId")
                        .IsUnique();

                    b.ToTable("BrokenGames");
                });

            modelBuilder.Entity("VolundApp.Model.Backlog.DiscontinuedGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment");

                    b.Property<int>("GameId");

                    b.HasKey("Id");

                    b.HasIndex("GameId")
                        .IsUnique();

                    b.ToTable("DiscontinuedGames");
                });

            modelBuilder.Entity("VolundApp.Model.Backlog.FavouriteGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GameId");

                    b.HasKey("Id");

                    b.HasIndex("GameId")
                        .IsUnique();

                    b.ToTable("FavouriteGame");
                });

            modelBuilder.Entity("VolundApp.Model.Backlog.FinishedGame", b =>
                {
                    b.Property<int>("FinishedGameId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DaysPlayed");

                    b.Property<DateTime>("GameFinishedDate");

                    b.Property<int>("GameId");

                    b.Property<int>("GameRatingId");

                    b.Property<DateTime>("GameStartDate");

                    b.Property<int>("HoursPlayed");

                    b.HasKey("FinishedGameId");

                    b.HasIndex("GameId")
                        .IsUnique();

                    b.HasIndex("GameRatingId");

                    b.ToTable("BeatenGames");
                });

            modelBuilder.Entity("VolundApp.Model.Backlog.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GenreId");

                    b.Property<string>("ImagePath");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("ReleaseDate");

                    b.HasKey("GameId");

                    b.HasIndex("GenreId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("VolundApp.Model.Backlog.GameInPoll", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GameId");

                    b.Property<int>("NumVotes");

                    b.Property<int>("PollId");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PollId");

                    b.ToTable("GamesInPoll");
                });

            modelBuilder.Entity("VolundApp.Model.Backlog.GameRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Rating");

                    b.HasKey("Id");

                    b.ToTable("GameRating");
                });

            modelBuilder.Entity("VolundApp.Model.Backlog.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("VolundApp.Model.Backlog.LowPriorityGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("GameId");

                    b.HasKey("Id");

                    b.HasIndex("GameId")
                        .IsUnique();

                    b.ToTable("LowPriorityGames");
                });

            modelBuilder.Entity("VolundApp.Model.Backlog.Poll", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.Property<int?>("TwitchUserId");

                    b.Property<int>("WinningGameId");

                    b.HasKey("Id");

                    b.HasIndex("TwitchUserId");

                    b.ToTable("Polls");
                });

            modelBuilder.Entity("VolundApp.Model.Backlog.TwitchUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserLevel");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("TwitchUsers");
                });

            modelBuilder.Entity("VolundApp.Model.Backlog.Vote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GameId");

                    b.Property<int>("PollId");

                    b.Property<int>("UserId");

                    b.Property<int>("VoteCount");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PollId");

                    b.HasIndex("UserId");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("VolundApp.Model.Backlog.BacklogGame", b =>
                {
                    b.HasOne("VolundApp.Model.Backlog.Game", "Game")
                        .WithOne("BacklogGame")
                        .HasForeignKey("VolundApp.Model.Backlog.BacklogGame", "GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VolundApp.Model.Backlog.BrokenGame", b =>
                {
                    b.HasOne("VolundApp.Model.Backlog.Game", "Game")
                        .WithOne("GameBroken")
                        .HasForeignKey("VolundApp.Model.Backlog.BrokenGame", "GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VolundApp.Model.Backlog.DiscontinuedGame", b =>
                {
                    b.HasOne("VolundApp.Model.Backlog.Game", "Game")
                        .WithOne("DiscontinuedGame")
                        .HasForeignKey("VolundApp.Model.Backlog.DiscontinuedGame", "GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VolundApp.Model.Backlog.FavouriteGame", b =>
                {
                    b.HasOne("VolundApp.Model.Backlog.Game", "Game")
                        .WithOne("GameFavourite")
                        .HasForeignKey("VolundApp.Model.Backlog.FavouriteGame", "GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VolundApp.Model.Backlog.FinishedGame", b =>
                {
                    b.HasOne("VolundApp.Model.Backlog.Game", "Game")
                        .WithOne("FinishedGame")
                        .HasForeignKey("VolundApp.Model.Backlog.FinishedGame", "GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VolundApp.Model.Backlog.GameRating", "GameRating")
                        .WithMany("GamesRatedAs")
                        .HasForeignKey("GameRatingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VolundApp.Model.Backlog.Game", b =>
                {
                    b.HasOne("VolundApp.Model.Backlog.Genre", "Genre")
                        .WithMany("GamesInGenre")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VolundApp.Model.Backlog.GameInPoll", b =>
                {
                    b.HasOne("VolundApp.Model.Backlog.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VolundApp.Model.Backlog.Poll")
                        .WithMany("GameList")
                        .HasForeignKey("PollId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VolundApp.Model.Backlog.LowPriorityGame", b =>
                {
                    b.HasOne("VolundApp.Model.Backlog.Game", "Game")
                        .WithOne("LowPriorityGame")
                        .HasForeignKey("VolundApp.Model.Backlog.LowPriorityGame", "GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VolundApp.Model.Backlog.Poll", b =>
                {
                    b.HasOne("VolundApp.Model.Backlog.TwitchUser")
                        .WithMany("VotedInPolls")
                        .HasForeignKey("TwitchUserId");
                });

            modelBuilder.Entity("VolundApp.Model.Backlog.Vote", b =>
                {
                    b.HasOne("VolundApp.Model.Backlog.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VolundApp.Model.Backlog.Poll", "Poll")
                        .WithMany("Voters")
                        .HasForeignKey("PollId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VolundApp.Model.Backlog.TwitchUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}