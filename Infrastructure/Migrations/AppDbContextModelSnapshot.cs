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
                            AuthorId = "2c3542d5-088a-4aed-b8d7-e785ea9ede84",
                            CountOfUnits = 1500,
                            EndDate = new DateTimeOffset(new DateTime(2022, 7, 2, 14, 10, 3, 667, DateTimeKind.Unspecified).AddTicks(8568), new TimeSpan(0, 3, 0, 0, 0)),
                            FrequencyId = 1,
                            IsCompleted = false,
                            IsRegistrationOpened = true,
                            StartDate = new DateTimeOffset(new DateTime(2022, 6, 11, 14, 10, 3, 667, DateTimeKind.Unspecified).AddTicks(7002), new TimeSpan(0, 3, 0, 0, 0)),
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
                            Date = new DateTime(2022, 6, 11, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 50
                        },
                        new
                        {
                            Id = 2,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 12, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 3,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 13, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 4,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 5,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 6,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 16, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 7,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 17, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 8,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 18, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 9,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 10,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 20, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 11,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 21, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 12,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 22, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 13,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 23, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 14,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 15,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 25, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 16,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 26, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 17,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 27, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 18,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 28, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 19,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 29, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 20,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 6, 30, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDone = false,
                            PercentOfDone = 0
                        },
                        new
                        {
                            Id = 21,
                            ChallengeId = 1,
                            CountOfUnitsDone = 0,
                            Date = new DateTime(2022, 7, 1, 0, 0, 0, 0, DateTimeKind.Local),
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
                            Id = "39d1363e-822e-493d-815e-6c2cc82c66df",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a1261fc3-d767-434d-9d46-496d3025e448",
                            Email = "anna.korolchuk@oa.edu.ua",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ANNA.KOROLCHUK@OA.EDU.UA",
                            NormalizedUserName = "ANNA.KOROLCHUK@OA.EDU.UA",
                            PasswordHash = "AQAAAAEAACcQAAAAEJ1IRkBE3YmWZBMr8porMft+iutU1wbqPQmNuvjrI1YISmPA8WY+o2FO/3zvY1U+Bw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "bc5730a6-ac37-49b1-a1ca-f0c8645643b0",
                            TwoFactorEnabled = false,
                            UserName = "a_korolchuk",
                            Points = 0,
                            StatusId = 1
                        },
                        new
                        {
                            Id = "cc210271-921d-48f8-b759-e442547288e1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1de4721c-be9a-4057-b2c5-2968ee742f8e",
                            Email = "antonina.loboda@oa.edu.ua",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ANTONINA.LOBODA@OA.EDU.UA",
                            NormalizedUserName = "ANTONINA.LOBODA@OA.EDU.UA",
                            PasswordHash = "AQAAAAEAACcQAAAAEMJ5pyTBEVpONKpnJHn/VKPGLq2EuWCoOG6EmPkZN0L7n0FB3cmatIegPE2LAbvE9g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "1d8997e4-fe1e-453c-9aac-2f64da4bd5eb",
                            TwoFactorEnabled = false,
                            UserName = "ton4ik",
                            Points = 0,
                            StatusId = 1
                        },
                        new
                        {
                            Id = "2c3542d5-088a-4aed-b8d7-e785ea9ede84",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ac0a6301-5c18-49ea-a994-eed56a70d5ed",
                            Email = "Ramiro.Stehr@hotmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "RAMIRO.STEHR@HOTMAIL.COM",
                            NormalizedUserName = "RAMIRO80",
                            PasswordHash = "AQAAAAEAACcQAAAAEJ23O4cRbvEFnRqd5kIttQaFEyi6xCF/sCOa4/AAOe/+xsIc8dPmq6fxGVpayi2IXg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "1a91f0e1-ce62-4145-88ba-5c26093a50df",
                            TwoFactorEnabled = false,
                            UserName = "Ramiro80",
                            Points = 0,
                            StatusId = 1
                        },
                        new
                        {
                            Id = "55beb5b9-a4d7-447a-9992-6199b7a4b5a5",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d3b6cd54-9c9e-41b1-8270-08a2d3f33900",
                            Email = "Angelo36@hotmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ANGELO36@HOTMAIL.COM",
                            NormalizedUserName = "ANGELO_SATTERFIELD66",
                            PasswordHash = "AQAAAAEAACcQAAAAEJ2cq6r+5yvv/DV0JaP/5MCDi0KpC0jJK9tKx0B3UxdbyjgbdzQwxrwdF0hGyjGSbA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b2b1d776-7966-4fd4-aad8-ca0c12917d5f",
                            TwoFactorEnabled = false,
                            UserName = "Angelo_Satterfield66",
                            Points = 0,
                            StatusId = 1
                        },
                        new
                        {
                            Id = "ff5143a6-8d50-4141-a99a-a465a523e435",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "61b8d12e-e0d2-4624-a648-2a48cf0e0c3a",
                            Email = "Marion79@yahoo.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "MARION79@YAHOO.COM",
                            NormalizedUserName = "MARION_MOEN",
                            PasswordHash = "AQAAAAEAACcQAAAAEOzfOxDnXCEbx77Qb6erElUlMwfAFYFO9efkbQubw2ZM/xZltQoVj086MzgBexaE6g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "030bea92-4330-4ebc-9263-fe3eea6ea49c",
                            TwoFactorEnabled = false,
                            UserName = "Marion_Moen",
                            Points = 0,
                            StatusId = 1
                        },
                        new
                        {
                            Id = "95c04a47-51b9-4669-840f-abea3942cb8a",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "407b6476-90db-444d-b75b-2a1c8646d9f7",
                            Email = "Gwen35@hotmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "GWEN35@HOTMAIL.COM",
                            NormalizedUserName = "GWEN.LANGOSH",
                            PasswordHash = "AQAAAAEAACcQAAAAENwn0OlJaEZkY93Zt+gzpovxr7xnGeNSKEyjEVz31rHrmzqUz+y4/j3rOItX/os7vg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f8965f65-18fd-4be6-9297-2df23ebbecdb",
                            TwoFactorEnabled = false,
                            UserName = "Gwen.Langosh",
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
