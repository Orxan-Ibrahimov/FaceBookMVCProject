// <auto-generated />
using System;
using FaceBookProject.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FaceBookProject.Migrations
{
    [DbContext(typeof(FacebookDbContext))]
    partial class FacebookDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FaceBookProject.Models.Entity.Album", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("FaceBookProject.Models.Entity.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cover")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Profile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("FaceBookProject.Models.Entity.Behavior", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmotionType")
                        .HasColumnType("int");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Behaviors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmotionType = 1,
                            Icon = "happy.png",
                            Text = "happy"
                        },
                        new
                        {
                            Id = 2,
                            EmotionType = 1,
                            Icon = "loved.png",
                            Text = "loved"
                        },
                        new
                        {
                            Id = 3,
                            EmotionType = 1,
                            Icon = "alone.png",
                            Text = "alone"
                        },
                        new
                        {
                            Id = 4,
                            EmotionType = 1,
                            Icon = "OK.png",
                            Text = "OK"
                        },
                        new
                        {
                            Id = 5,
                            EmotionType = 1,
                            Icon = "sick.png",
                            Text = "sick"
                        },
                        new
                        {
                            Id = 6,
                            EmotionType = 1,
                            Icon = "thoughtful.png",
                            Text = "thoughtful"
                        },
                        new
                        {
                            Id = 7,
                            EmotionType = 1,
                            Icon = "motivated.png",
                            Text = "motivated"
                        },
                        new
                        {
                            Id = 8,
                            EmotionType = 1,
                            Icon = "cool.png",
                            Text = "cool"
                        },
                        new
                        {
                            Id = 9,
                            EmotionType = 1,
                            Icon = "thankful.png",
                            Text = "thankful"
                        },
                        new
                        {
                            Id = 10,
                            EmotionType = 1,
                            Icon = "inLove.png",
                            Text = "in-love"
                        },
                        new
                        {
                            Id = 11,
                            EmotionType = 1,
                            Icon = "crazy.png",
                            Text = "crazy"
                        },
                        new
                        {
                            Id = 12,
                            EmotionType = 1,
                            Icon = "relaxed.png",
                            Text = "relaxed"
                        },
                        new
                        {
                            Id = 13,
                            EmotionType = 1,
                            Icon = "blissful.png",
                            Text = "blissful"
                        },
                        new
                        {
                            Id = 14,
                            EmotionType = 1,
                            Icon = "excited.png",
                            Text = "excited"
                        },
                        new
                        {
                            Id = 15,
                            EmotionType = 1,
                            Icon = "festive.png",
                            Text = "festive"
                        },
                        new
                        {
                            Id = 16,
                            EmotionType = 1,
                            Icon = "fantastic.png",
                            Text = "fantastic"
                        },
                        new
                        {
                            Id = 17,
                            EmotionType = 1,
                            Icon = "grateful.png",
                            Text = "grateful"
                        },
                        new
                        {
                            Id = 18,
                            EmotionType = 1,
                            Icon = "blessed.png",
                            Text = "blessed"
                        },
                        new
                        {
                            Id = 19,
                            EmotionType = 1,
                            Icon = "lovely.png",
                            Text = "lovely"
                        },
                        new
                        {
                            Id = 20,
                            EmotionType = 1,
                            Icon = "wonderful.png",
                            Text = "wonderful"
                        },
                        new
                        {
                            Id = 21,
                            EmotionType = 1,
                            Icon = "amused.png",
                            Text = "amused"
                        },
                        new
                        {
                            Id = 22,
                            EmotionType = 1,
                            Icon = "silly.png",
                            Text = "silly"
                        },
                        new
                        {
                            Id = 23,
                            EmotionType = 1,
                            Icon = "sad.png",
                            Text = "sad"
                        },
                        new
                        {
                            Id = 24,
                            EmotionType = 1,
                            Icon = "safe.png",
                            Text = "safe"
                        },
                        new
                        {
                            Id = 25,
                            EmotionType = 1,
                            Icon = "worried.png",
                            Text = "worried"
                        },
                        new
                        {
                            Id = 26,
                            EmotionType = 1,
                            Icon = "trapped.png",
                            Text = "trapped"
                        },
                        new
                        {
                            Id = 27,
                            EmotionType = 1,
                            Icon = "threatened.png",
                            Text = "threatened"
                        },
                        new
                        {
                            Id = 28,
                            EmotionType = 1,
                            Icon = "thirsty.png",
                            Text = "thirsty"
                        },
                        new
                        {
                            Id = 29,
                            EmotionType = 1,
                            Icon = "super.png",
                            Text = "super"
                        },
                        new
                        {
                            Id = 30,
                            EmotionType = 1,
                            Icon = "smart.png",
                            Text = "smart"
                        },
                        new
                        {
                            Id = 31,
                            EmotionType = 1,
                            Icon = "scared.png",
                            Text = "scared"
                        },
                        new
                        {
                            Id = 32,
                            EmotionType = 1,
                            Icon = "rich.png",
                            Text = "rich"
                        },
                        new
                        {
                            Id = 33,
                            EmotionType = 1,
                            Icon = "perplexed.png",
                            Text = "perplexed"
                        },
                        new
                        {
                            Id = 34,
                            EmotionType = 1,
                            Icon = "numb.png",
                            Text = "numb"
                        },
                        new
                        {
                            Id = 35,
                            EmotionType = 1,
                            Icon = "naked.png",
                            Text = "naked"
                        },
                        new
                        {
                            Id = 36,
                            EmotionType = 1,
                            Icon = "invisible.png",
                            Text = "invisible"
                        },
                        new
                        {
                            Id = 37,
                            EmotionType = 1,
                            Icon = "inspired.png",
                            Text = "inspired"
                        },
                        new
                        {
                            Id = 38,
                            EmotionType = 1,
                            Icon = "furious.png",
                            Text = "furious"
                        },
                        new
                        {
                            Id = 39,
                            EmotionType = 1,
                            Icon = "funny.png",
                            Text = "funny"
                        },
                        new
                        {
                            Id = 40,
                            EmotionType = 1,
                            Icon = "embarassed.png",
                            Text = "embarassed"
                        },
                        new
                        {
                            Id = 41,
                            EmotionType = 1,
                            Icon = "cold.png",
                            Text = "cold"
                        },
                        new
                        {
                            Id = 42,
                            EmotionType = 1,
                            Icon = "broken.png",
                            Text = "broken"
                        },
                        new
                        {
                            Id = 43,
                            EmotionType = 1,
                            Icon = "hopeful.png",
                            Text = "hopeful"
                        },
                        new
                        {
                            Id = 44,
                            EmotionType = 1,
                            Icon = "sarcastic.png",
                            Text = "sarcastic"
                        },
                        new
                        {
                            Id = 45,
                            EmotionType = 1,
                            Icon = "heartbroken.png",
                            Text = "heartbroken"
                        },
                        new
                        {
                            Id = 46,
                            EmotionType = 1,
                            Icon = "bored.png",
                            Text = "bored"
                        },
                        new
                        {
                            Id = 47,
                            EmotionType = 1,
                            Icon = "beautiful.png",
                            Text = "beautiful"
                        },
                        new
                        {
                            Id = 48,
                            EmotionType = 1,
                            Icon = "irritated.png",
                            Text = "irritated"
                        });
                });

            modelBuilder.Entity("FaceBookProject.Models.Entity.Comment", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CommentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StoryId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("StoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("FaceBookProject.Models.Entity.Friendship", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("dateadd(hour,4,getutcdate())");

                    b.Property<string>("FriendId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("FriendId");

                    b.HasIndex("UserId");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("FaceBookProject.Models.Entity.Hobby", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hobby");
                });

            modelBuilder.Entity("FaceBookProject.Models.Entity.Image", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlbumId")
                        .HasColumnType("int");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("FaceBookProject.Models.Entity.Like", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("StoryId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("StoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("FaceBookProject.Models.Entity.Message", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AcceptorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("dateadd(hour,4,getutcdate())");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("SenderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AcceptorId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("FaceBookProject.Models.Entity.Story", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("dateadd(hour,4,getutcdate())");

                    b.Property<int?>("EmotionId")
                        .HasColumnType("int");

                    b.Property<string>("Header")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShareCount")
                        .HasColumnType("int");

                    b.Property<int?>("ShareId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("EmotionId");

                    b.HasIndex("ShareId");

                    b.HasIndex("UserId");

                    b.ToTable("Stories");
                });

            modelBuilder.Entity("FaceBookProject.Models.Entity.Suggest", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AcceptorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("dateadd(hour,4,getutcdate())");

                    b.Property<string>("SenderId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AcceptorId");

                    b.HasIndex("SenderId");

                    b.ToTable("Suggests");
                });

            modelBuilder.Entity("FaceBookProject.Models.Entity.UserHobby", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HobbyId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HobbyId1")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("HobbyId1");

                    b.HasIndex("UserId");

                    b.ToTable("UserHobbies");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
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

            modelBuilder.Entity("FaceBookProject.Models.Entity.Album", b =>
                {
                    b.HasOne("FaceBookProject.Models.Entity.AppUser", "User")
                        .WithMany("Albums")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FaceBookProject.Models.Entity.Comment", b =>
                {
                    b.HasOne("FaceBookProject.Models.Entity.Story", "Story")
                        .WithMany("Comments")
                        .HasForeignKey("StoryId");

                    b.HasOne("FaceBookProject.Models.Entity.AppUser", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FaceBookProject.Models.Entity.Friendship", b =>
                {
                    b.HasOne("FaceBookProject.Models.Entity.AppUser", "Friend")
                        .WithMany()
                        .HasForeignKey("FriendId");

                    b.HasOne("FaceBookProject.Models.Entity.AppUser", "User")
                        .WithMany("Friends")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FaceBookProject.Models.Entity.Image", b =>
                {
                    b.HasOne("FaceBookProject.Models.Entity.Album", "Album")
                        .WithMany("Pictures")
                        .HasForeignKey("AlbumId");
                });

            modelBuilder.Entity("FaceBookProject.Models.Entity.Like", b =>
                {
                    b.HasOne("FaceBookProject.Models.Entity.Story", "Story")
                        .WithMany("Likes")
                        .HasForeignKey("StoryId");

                    b.HasOne("FaceBookProject.Models.Entity.AppUser", "User")
                        .WithMany("Likes")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FaceBookProject.Models.Entity.Message", b =>
                {
                    b.HasOne("FaceBookProject.Models.Entity.AppUser", "Acceptor")
                        .WithMany("Messages")
                        .HasForeignKey("AcceptorId");

                    b.HasOne("FaceBookProject.Models.Entity.AppUser", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId");
                });

            modelBuilder.Entity("FaceBookProject.Models.Entity.Story", b =>
                {
                    b.HasOne("FaceBookProject.Models.Entity.Behavior", "Emotion")
                        .WithMany("Stories")
                        .HasForeignKey("EmotionId");

                    b.HasOne("FaceBookProject.Models.Entity.Story", "Share")
                        .WithMany()
                        .HasForeignKey("ShareId");

                    b.HasOne("FaceBookProject.Models.Entity.AppUser", "User")
                        .WithMany("Stories")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FaceBookProject.Models.Entity.Suggest", b =>
                {
                    b.HasOne("FaceBookProject.Models.Entity.AppUser", "Acceptor")
                        .WithMany("Suggests")
                        .HasForeignKey("AcceptorId");

                    b.HasOne("FaceBookProject.Models.Entity.AppUser", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId");
                });

            modelBuilder.Entity("FaceBookProject.Models.Entity.UserHobby", b =>
                {
                    b.HasOne("FaceBookProject.Models.Entity.Hobby", "Hobby")
                        .WithMany("UserHobbies")
                        .HasForeignKey("HobbyId1");

                    b.HasOne("FaceBookProject.Models.Entity.AppUser", "User")
                        .WithMany("UserHobbies")
                        .HasForeignKey("UserId");
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
                    b.HasOne("FaceBookProject.Models.Entity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FaceBookProject.Models.Entity.AppUser", null)
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

                    b.HasOne("FaceBookProject.Models.Entity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FaceBookProject.Models.Entity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
