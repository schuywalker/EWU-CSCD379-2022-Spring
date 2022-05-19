﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wordle.Api.Data;

#nullable disable

namespace Wordle.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GamePlayer", b =>
                {
                    b.Property<int>("GamesGameId")
                        .HasColumnType("int");

                    b.Property<int>("PlayersPlayerId")
                        .HasColumnType("int");

                    b.HasKey("GamesGameId", "PlayersPlayerId");

                    b.HasIndex("PlayersPlayerId");

                    b.ToTable("GamePlayer");
                });

            modelBuilder.Entity("Wordle.Api.Data.DateWord", b =>
                {
                    b.Property<int>("DateWordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DateWordId"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("WordId")
                        .HasColumnType("int");

                    b.HasKey("DateWordId");

                    b.HasIndex("WordId");

                    b.ToTable("DateWords");
                });

            modelBuilder.Entity("Wordle.Api.Data.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameId"), 1L, 1);

                    b.Property<DateTime?>("DateEnded")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStarted")
                        .HasColumnType("datetime2");

                    b.Property<int>("WordId")
                        .HasColumnType("int");

                    b.HasKey("GameId");

                    b.HasIndex("WordId");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            GameId = 1,
                            DateStarted = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            WordId = 1
                        },
                        new
                        {
                            GameId = 2,
                            DateStarted = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            WordId = 2
                        },
                        new
                        {
                            GameId = 3,
                            DateStarted = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            WordId = 3
                        });
                });

            modelBuilder.Entity("Wordle.Api.Data.Guess", b =>
                {
                    b.Property<int>("GuessId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GuessId"), 1L, 1);

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GuessId");

                    b.HasIndex("GameId");

                    b.ToTable("Guess");
                });

            modelBuilder.Entity("Wordle.Api.Data.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlayerId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Wordle.Api.Data.ScoreStat", b =>
                {
                    b.Property<int>("ScoreStatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScoreStatId"), 1L, 1);

                    b.Property<int>("AverageSeconds")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int>("TotalGames")
                        .HasColumnType("int");

                    b.HasKey("ScoreStatId");

                    b.ToTable("ScoreStats");

                    b.HasData(
                        new
                        {
                            ScoreStatId = 1,
                            AverageSeconds = 0,
                            Score = 1,
                            TotalGames = 0
                        },
                        new
                        {
                            ScoreStatId = 2,
                            AverageSeconds = 0,
                            Score = 2,
                            TotalGames = 0
                        },
                        new
                        {
                            ScoreStatId = 3,
                            AverageSeconds = 0,
                            Score = 3,
                            TotalGames = 0
                        },
                        new
                        {
                            ScoreStatId = 4,
                            AverageSeconds = 0,
                            Score = 4,
                            TotalGames = 0
                        },
                        new
                        {
                            ScoreStatId = 5,
                            AverageSeconds = 0,
                            Score = 5,
                            TotalGames = 0
                        },
                        new
                        {
                            ScoreStatId = 6,
                            AverageSeconds = 0,
                            Score = 6,
                            TotalGames = 0
                        });
                });

            modelBuilder.Entity("Wordle.Api.Data.Word", b =>
                {
                    b.Property<int>("WordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WordId"), 1L, 1);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WordId");

                    b.ToTable("Words");

                    b.HasData(
                        new
                        {
                            WordId = 1,
                            Value = "thing"
                        },
                        new
                        {
                            WordId = 2,
                            Value = "think"
                        },
                        new
                        {
                            WordId = 3,
                            Value = "thong"
                        },
                        new
                        {
                            WordId = 4,
                            Value = "throb"
                        },
                        new
                        {
                            WordId = 5,
                            Value = "thunk"
                        },
                        new
                        {
                            WordId = 6,
                            Value = "wrong"
                        });
                });

            modelBuilder.Entity("GamePlayer", b =>
                {
                    b.HasOne("Wordle.Api.Data.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wordle.Api.Data.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayersPlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Wordle.Api.Data.DateWord", b =>
                {
                    b.HasOne("Wordle.Api.Data.Word", "Word")
                        .WithMany()
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Word");
                });

            modelBuilder.Entity("Wordle.Api.Data.Game", b =>
                {
                    b.HasOne("Wordle.Api.Data.Word", "Word")
                        .WithMany()
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Word");
                });

            modelBuilder.Entity("Wordle.Api.Data.Guess", b =>
                {
                    b.HasOne("Wordle.Api.Data.Game", "Game")
                        .WithMany("Guesses")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("Wordle.Api.Data.Game", b =>
                {
                    b.Navigation("Guesses");
                });
#pragma warning restore 612, 618
        }
    }
}
