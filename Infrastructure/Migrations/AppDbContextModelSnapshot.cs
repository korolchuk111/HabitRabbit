﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChallengeUser", b =>
                {
                    b.Property<int>("ChallengesId")
                        .HasColumnType("int");

                    b.Property<string>("UsersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ChallengesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("ChallengeUser");
                });

            modelBuilder.Entity("Core.Entities.Challenge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CountOfUnits")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("EndDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("FrequencyId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCompleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool?>("IsRegistrationOpened")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTimeOffset>("StartDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("FrequencyId");

                    b.HasIndex("UnitId");

                    b.ToTable("Challenges");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = "7b41e6cd-2c5c-43b9-906f-fbafa2d93565",
                            CountOfUnits = 1500,
                            EndDate = new DateTimeOffset(new DateTime(2022, 7, 1, 23, 7, 23, 435, DateTimeKind.Unspecified).AddTicks(8956), new TimeSpan(0, 3, 0, 0, 0)),
                            FrequencyId = 1,
                            IsCompleted = false,
                            IsRegistrationOpened = true,
                            StartDate = new DateTimeOffset(new DateTime(2022, 6, 10, 23, 7, 23, 435, DateTimeKind.Unspecified).AddTicks(8014), new TimeSpan(0, 3, 0, 0, 0)),
                            Title = "Drink water",
                            UnitId = 5
                        });
                });

            modelBuilder.Entity("Core.Entities.DailyTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChallengeId")
                        .HasColumnType("int");

                    b.Property<int>("CountOfUnitsDone")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDone")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("PercentOfDone")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChallengeId");

                    b.ToTable("DailyTasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ChallengeId = 1,
                            CountOfUnitsDone = 750,
                            Date = new DateTime(2022, 6, 10, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 50
                        },
                        new
                        {
                            Id = 2,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 11, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 3,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 12, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 4,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 13, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 5,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 6,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 7,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 16, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 8,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 17, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 9,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 18, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 10,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 11,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 20, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 12,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 21, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 13,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 22, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 14,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 23, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 15,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 16,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 25, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 17,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 26, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 18,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 27, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 19,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 28, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 20,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 29, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 21,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 30, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        });
                });

            modelBuilder.Entity("Core.Entities.Frequency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Frequencies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Per Day"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Per Week"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Per Month"
                        });
                });

            modelBuilder.Entity("Core.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Beginner"
                        });
                });

            modelBuilder.Entity("Core.Entities.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ShortType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Units");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ShortType = "times",
                            Type = "times"
                        },
                        new
                        {
                            Id = 2,
                            ShortType = "min",
                            Type = "minutes"
                        },
                        new
                        {
                            Id = 3,
                            ShortType = "m",
                            Type = "meters"
                        },
                        new
                        {
                            Id = 4,
                            ShortType = "km",
                            Type = "kilometers"
                        },
                        new
                        {
                            Id = 5,
                            ShortType = "ml",
                            Type = "milliliters"
                        },
                        new
                        {
                            Id = 6,
                            ShortType = "pages",
                            Type = "pages"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<int>("Points")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasIndex("StatusId");

                    b.HasDiscriminator().HasValue("User");

                    b.HasData(
                        new
                        {
                            Id = "5ebf1a19-de68-4470-87a8-2f06d680eed3",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "0191c9e2-e9ad-41fb-b9b6-83abe33e1ae2",
                            Email = "anna.korolchuk@oa.edu.ua",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ANNA.KOROLCHUK@OA.EDU.UA",
                            NormalizedUserName = "ANNA.KOROLCHUK@OA.EDU.UA",
                            PasswordHash = "AQAAAAEAACcQAAAAEB2UOI/WL4H05a8j3QVQjir/SbyNDrr1ed+sCvV3O3rMeG6LNAPlv6MGFG9cWkVRtw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "826ad51e-05c1-49df-b87c-8b6e61d4f015",
                            TwoFactorEnabled = false,
                            UserName = "a_korolchuk",
                            Points = 0,
                            StatusId = 1
                        },
                        new
                        {
                            Id = "67137e42-0065-4c39-ba67-79e4b39fe271",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5ca8e916-56a2-4466-8db2-0722416e65ee",
                            Email = "antonina.loboda@oa.edu.ua",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ANTONINA.LOBODA@OA.EDU.UA",
                            NormalizedUserName = "ANTONINA.LOBODA@OA.EDU.UA",
                            PasswordHash = "AQAAAAEAACcQAAAAEOK5ZujKZhjXYDr2BTgU5OH/QqauMofCCPlnslokB6oqI+LIVzL/TPVdXDnDIFHM+w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5556c459-6e11-400b-8aa4-64ebf061dbae",
                            TwoFactorEnabled = false,
                            UserName = "ton4ik",
                            Points = 0,
                            StatusId = 1
                        },
                        new
                        {
                            Id = "7b41e6cd-2c5c-43b9-906f-fbafa2d93565",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e99d9145-1408-458a-9635-f95f27415c9c",
                            Email = "Ignacio.Gislason@yahoo.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "IGNACIO.GISLASON@YAHOO.COM",
                            NormalizedUserName = "IGNACIO22",
                            PasswordHash = "AQAAAAEAACcQAAAAECaB1k7Lxpft+FQ49Gl1HQ88bTp41dXO5sP0uOt4FFO7sANfJltb81fbjvT/nexNqg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "1e3864df-6175-4a61-9567-4baba69997b1",
                            TwoFactorEnabled = false,
                            UserName = "Ignacio22",
                            Points = 0,
                            StatusId = 1
                        },
                        new
                        {
                            Id = "ee9c456e-d353-4a89-a50f-939bf502038d",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e15d3bcc-f504-4a80-b073-86e0129007c6",
                            Email = "Josh54@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "JOSH54@GMAIL.COM",
                            NormalizedUserName = "JOSH.MCKENZIE79",
                            PasswordHash = "AQAAAAEAACcQAAAAEMOJT1gejl0kSBKc/zzE0IopVHDGHuc/Ef9NPY1/9nHgw+/aI/MdpIbVN+wdORfIsA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "1bc89770-e87b-4ff0-8bb4-a68555ab7af5",
                            TwoFactorEnabled = false,
                            UserName = "Josh.McKenzie79",
                            Points = 0,
                            StatusId = 1
                        },
                        new
                        {
                            Id = "a83cac00-3f7d-4305-9705-3d04e8e6b240",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "9e69fe23-ad50-4e77-9f39-0c445127d2f2",
                            Email = "Jamie.Shanahan71@hotmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "JAMIE.SHANAHAN71@HOTMAIL.COM",
                            NormalizedUserName = "JAMIE_SHANAHAN",
                            PasswordHash = "AQAAAAEAACcQAAAAENBahM449LLLDciZiWv5kP11eprSYsQsC+P6MctyMAg9nu8OruypLiPDgU+zNekfLA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e931502f-2477-45aa-80f7-846e5e7bb859",
                            TwoFactorEnabled = false,
                            UserName = "Jamie_Shanahan",
                            Points = 0,
                            StatusId = 1
                        },
                        new
                        {
                            Id = "db7098a4-fcf4-47a2-9f79-8c784df75066",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c066bcce-906c-4782-9b86-a88d1b2322d4",
                            Email = "Ruby21@yahoo.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "RUBY21@YAHOO.COM",
                            NormalizedUserName = "RUBY18",
                            PasswordHash = "AQAAAAEAACcQAAAAEHtIpDVAdTjVKAReqHJKOHb6shMytDvsptYGlkGFlD6/e5fAeD2f/vZp48dDxkNgkA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5f2d42b3-9c76-4952-b567-a6cdf4455b65",
                            TwoFactorEnabled = false,
                            UserName = "Ruby18",
                            Points = 0,
                            StatusId = 1
                        });
                });

            modelBuilder.Entity("ChallengeUser", b =>
                {
                    b.HasOne("Core.Entities.Challenge", null)
                        .WithMany()
                        .HasForeignKey("ChallengesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.Challenge", b =>
                {
                    b.HasOne("Core.Entities.User", "Author")
                        .WithMany("AuthoredChallenges")
                        .HasForeignKey("AuthorId");

                    b.HasOne("Core.Entities.Frequency", "Frequency")
                        .WithMany("Challenges")
                        .HasForeignKey("FrequencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Unit", "Unit")
                        .WithMany("Challenges")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Frequency");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("Core.Entities.DailyTask", b =>
                {
                    b.HasOne("Core.Entities.Challenge", "Challenge")
                        .WithMany("DailyTasks")
                        .HasForeignKey("ChallengeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Challenge");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.HasOne("Core.Entities.Status", "Status")
                        .WithMany("Users")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Core.Entities.Challenge", b =>
                {
                    b.Navigation("DailyTasks");
                });

            modelBuilder.Entity("Core.Entities.Frequency", b =>
                {
                    b.Navigation("Challenges");
                });

            modelBuilder.Entity("Core.Entities.Status", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Core.Entities.Unit", b =>
                {
                    b.Navigation("Challenges");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Navigation("AuthoredChallenges");
                });
#pragma warning restore 612, 618
        }
    }
}
