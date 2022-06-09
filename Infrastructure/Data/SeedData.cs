using System;
using System.Collections.Generic;
using Bogus;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public static class SeedData
    {
        private static readonly PasswordHasher<User> PasswordHasher = new();

        private static readonly Faker Faker = new();

        public static void Seed(this ModelBuilder builder)
        {
            SeedStatus(builder);
            SeedUser(builder);
            SeedUnit(builder);
            SeedFrequency(builder);
            SeedChallenge(builder);
            SeedDailyTask(builder);
        }

        #region Status

        private static void SeedStatus(ModelBuilder builder)
        {
            builder.Entity<Status>()
                .HasData(new Status{ Name = "Beginner"});
        }

        #endregion
        
        #region User

        private static readonly string User0Id = Guid.NewGuid().ToString();
        private static readonly string User1Id = Guid.NewGuid().ToString();
        private static readonly string User2Id = Guid.NewGuid().ToString();
        private static readonly string User3Id = Guid.NewGuid().ToString();
        private static readonly string ToniaId = Guid.NewGuid().ToString();
        private static readonly string AnnaId = Guid.NewGuid().ToString();

        private static void SeedUser(ModelBuilder builder)
        {
            var emails = new List<string>();
            for (var i = 0; i < 4; i++)
            {
                emails.Add(Faker.Person.Email);
            }
            
            var user0 = new User
            {
                Id = User0Id,
                UserName = Faker.Person.UserName,
                NormalizedEmail = emails[0].ToUpper(),
                NormalizedUserName = emails[0].ToUpper(),
                Email = emails[0],
                StatusId = 1
            };
            var user1 = new User
            {
                Id = User1Id,
                UserName = Faker.Person.UserName,
                NormalizedEmail = emails[1].ToUpper(),
                NormalizedUserName = emails[1].ToUpper(),
                Email = emails[1],
                StatusId = 1
            };
            var user2 = new User
            {
                Id = User2Id,
                UserName = Faker.Person.UserName,
                NormalizedEmail = emails[2].ToUpper(),
                NormalizedUserName = emails[2].ToUpper(),
                Email = emails[2],
                StatusId = 1
            };
            var user3 = new User
            {
                Id = User3Id,
                UserName = Faker.Person.UserName,
                NormalizedEmail = emails[3].ToUpper(),
                NormalizedUserName = emails[3].ToUpper(),
                Email = emails[3],
                StatusId = 1
            };
            var userTonia = new User
            {
                Id = ToniaId,
                UserName = "ton4ik",
                NormalizedEmail = "antonina.loboda@oa.edu.ua".ToUpper(),
                NormalizedUserName = "antonina.loboda@oa.edu.ua".ToUpper(),
                Email = "antonina.loboda@oa.edu.ua",
                StatusId = 1
            };
            var userAnna = new User
            {
                Id = AnnaId,
                UserName = "a_korolchuk",
                NormalizedEmail = "anna.korolchuk@oa.edu.ua".ToUpper(),
                NormalizedUserName = "anna.korolchuk@oa.edu.ua".ToUpper(),
                Email = "anna.korolchuk@oa.edu.ua",
                StatusId = 1
            };
            user0.PasswordHash = PasswordHasher.HashPassword(user0, "Password_1");
            user1.PasswordHash = PasswordHasher.HashPassword(user1, "Password_1");
            user2.PasswordHash = PasswordHasher.HashPassword(user2, "Password_1");
            user3.PasswordHash = PasswordHasher.HashPassword(user3, "Password_1");
            userTonia.PasswordHash = PasswordHasher.HashPassword(userTonia, "Password_1");
            userAnna.PasswordHash = PasswordHasher.HashPassword(userAnna, "Password_1");
            builder.Entity<User>().HasData(userAnna, userTonia, user0, user1, user2, user3);
        }

        #endregion
        
        #region Unit

        private static void SeedUnit(ModelBuilder builder)
        {
            builder.Entity<Unit>()
                .HasData(
                    new Unit { Type = "times", ShortType = "times"},
                    new Unit { Type = "minutes", ShortType = "min"},
                    new Unit { Type = "meters", ShortType = "m"},
                    new Unit { Type = "kilometers", ShortType = "km"},
                    new Unit { Type = "milliliters", ShortType = "ml"},
                    new Unit { Type = "pages", ShortType = "pages"}
                    );
        }

        #endregion

        #region Frequency

        private static void SeedFrequency(ModelBuilder builder)
        {
            builder.Entity<Frequency>()
                .HasData(
                    new Frequency{Type = "Per Day"},
                    new Frequency{Type = "Per Week"},
                    new Frequency{Type = "Per Month"}
                    );
        }

        #endregion

        #region Challenge

        private static void SeedChallenge(ModelBuilder builder)
        {
            builder.Entity<Challenge>()
                .HasData(
                    new Challenge
                    {
                        Id = 1,
                        Title = "Drink water",
                        AuthorId = User0Id,
                        UnitId = 5,
                        FrequencyId = 1,
                        CountOfUnits = 1500,
                        StartDate = DateTimeOffset.Now.AddDays(1),
                        EndDate = DateTimeOffset.Now.AddDays(22),
                        IsRegistrationOpened = true,
                        IsCompleted = false
                    }
                    );
        }

        #endregion

        #region DailyTask

        private static void SeedDailyTask(ModelBuilder builder)
        {
            var tasks = new List<DailyTask>
            {
                new()
                {
                    ChallengeId = 1,
                    Date = DateTime.Today.AddDays(1),
                    CountOfUnitsDone = 750,
                    PercentOfDone = 50,
                    IsDone = false
                }
            };
            for (var i = 2; i < 22; i++)
            {
                var task = new DailyTask
                {
                    ChallengeId = 1,
                    Date = DateTime.Today.AddDays(i),
                    CountOfUnitsDone = 0,
                    PercentOfDone = 0,
                    IsDone = false
                };
                tasks.Add(task);
            }

            builder.Entity<DailyTask>()
                .HasData(tasks);
        }

        #endregion
    }
}