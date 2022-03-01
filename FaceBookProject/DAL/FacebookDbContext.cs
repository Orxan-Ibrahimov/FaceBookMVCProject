using FaceBookProject.Helpers.Enums;
using FaceBookProject.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookProject.DAL
{
    public class FacebookDbContext : IdentityDbContext<AppUser, IdentityRole, string>
    {
        public FacebookDbContext(DbContextOptions<FacebookDbContext> opt) : base(opt)
        {
        }
        public DbSet<Suggest> Suggests { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Friendship> Friends { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<UserHobby> UserHobbies { get; set; }
        public DbSet<Behavior> Behaviors { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);           
            builder.Entity<Suggest>().
               Property(s => s.CreatedDate).HasDefaultValueSql("dateadd(hour,4,getutcdate())");
            builder.Entity<Message>().
               Property(m => m.CreatedDate).HasDefaultValueSql("dateadd(hour,4,getutcdate())");
            builder.Entity<Friendship>().
               Property(f => f.CreatedDate).HasDefaultValueSql("dateadd(hour,4,getutcdate())");
            builder.Entity<Story>().
              Property(s => s.CreatedDate).HasDefaultValueSql("dateadd(hour,4,getutcdate())");

            builder.Entity<Friendship>()
                .HasOne(d => d.User)
                   .WithMany(p => p.Friends)
                   .HasForeignKey(d => d.UserId);

            builder.Entity<Suggest>()
               .HasOne(d => d.Acceptor)
                  .WithMany(p => p.Suggests)
                  .HasForeignKey(d => d.AcceptorId);

            builder.Entity<Message>()
               .HasOne(d => d.Acceptor)
                  .WithMany(p => p.Messages)
                  .HasForeignKey(d => d.AcceptorId);

            builder.Entity<Behavior>().HasData(
                new Behavior
                {
                    Id = 1,
                    Icon = "happy.png",
                    Text = "happy",
                    EmotionType = EmotionType.Emotions
                },
                 new Behavior
                 {
                     Id = 2,
                     Icon = "loved.png",
                     Text = "loved",
                     EmotionType = EmotionType.Emotions
                 },
                 new Behavior
                 {
                     Id = 3,
                     Icon = "alone.png",
                     Text = "alone",
                     EmotionType = EmotionType.Emotions
                 },
                  new Behavior
                  {
                      Id = 4,
                      Icon = "OK.png",
                      Text = "OK",
                      EmotionType = EmotionType.Emotions
                  },
                 new Behavior
                 {
                     Id = 5,
                     Icon = "sick.png",
                     Text = "sick",
                     EmotionType = EmotionType.Emotions
                 },
                 new Behavior
                 {
                     Id = 6,
                     Icon = "thoughtful.png",
                     Text = "thoughtful",
                     EmotionType = EmotionType.Emotions
                 },
                 new Behavior
                 {
                     Id = 7,
                     Icon = "motivated.png",
                     Text = "motivated",
                     EmotionType = EmotionType.Emotions
                 },
                 new Behavior
                 {
                     Id = 8,
                     Icon = "cool.png",
                     Text = "cool",
                     EmotionType = EmotionType.Emotions
                 },
                 new Behavior
                 {
                     Id = 9,
                     Icon = "thankful.png",
                     Text = "thankful",
                     EmotionType = EmotionType.Emotions
                 },
                  new Behavior
                  {
                      Id = 10,
                      Icon = "inLove.png",
                      Text = "in-love",
                      EmotionType = EmotionType.Emotions
                  },
                 new Behavior
                 {
                     Id = 11,
                     Icon = "crazy.png",
                     Text = "crazy",
                     EmotionType = EmotionType.Emotions
                 },
                 new Behavior
                 {
                     Id = 12,
                     Icon = "relaxed.png",
                     Text = "relaxed",
                     EmotionType = EmotionType.Emotions
                 },
                 new Behavior
                 {
                     Id = 13,
                     Icon = "blissful.png",
                     Text = "blissful",
                     EmotionType = EmotionType.Emotions
                 },
                 new Behavior
                 {
                     Id = 14,
                     Icon = "excited.png",
                     Text = "excited",
                     EmotionType = EmotionType.Emotions
                 },
                 new Behavior
                 {
                     Id = 15,
                     Icon = "festive.png",
                     Text = "festive",
                     EmotionType = EmotionType.Emotions
                 },
                  new Behavior
                  {
                      Id = 16,
                      Icon = "fantastic.png",
                      Text = "fantastic",
                      EmotionType = EmotionType.Emotions
                  },
                 new Behavior
                 {
                     Id = 17,
                     Icon = "grateful.png",
                     Text = "grateful",
                     EmotionType = EmotionType.Emotions
                 },
                 new Behavior
                 {
                     Id = 18,
                     Icon = "blessed.png",
                     Text = "blessed",
                     EmotionType = EmotionType.Emotions
                 },
                 new Behavior
                 {
                     Id = 19,
                     Icon = "lovely.png",
                     Text = "lovely",
                     EmotionType = EmotionType.Emotions
                 },
                 new Behavior
                 {
                     Id = 20,
                     Icon = "wonderful.png",
                     Text = "wonderful",
                     EmotionType = EmotionType.Emotions
                 },
                 new Behavior
                 {
                     Id = 21,
                     Icon = "amused.png",
                     Text = "amused",
                     EmotionType = EmotionType.Emotions
                 },
                  new Behavior
                  {
                      Id = 22,
                      Icon = "silly.png",
                      Text = "silly",
                      EmotionType = EmotionType.Emotions
                  },
                 new Behavior
                 {
                     Id = 23,
                     Icon = "sad.png",
                     Text = "sad",
                     EmotionType = EmotionType.Emotions
                 },
                 new Behavior
                 {
                     Id = 24,
                     Icon = "safe.png",
                     Text = "safe",
                     EmotionType = EmotionType.Emotions
                 },
                 new Behavior
                 {
                     Id = 25,
                     Icon = "worried.png",
                     Text = "worried",
                     EmotionType = EmotionType.Emotions
                 },
                 new Behavior
                 {
                     Id = 26,
                     Icon = "trapped.png",
                     Text = "trapped",
                     EmotionType = EmotionType.Emotions
                 },
                 new Behavior
                 {
                     Id = 27,
                     Icon = "threatened.png",
                     Text = "threatened",
                     EmotionType = EmotionType.Emotions
                 },
                  new Behavior
                  {
                      Id = 28,
                      Icon = "thirsty.png",
                      Text = "thirsty",
                      EmotionType = EmotionType.Emotions
                  },
                 new Behavior
                 {
                     Id = 29,
                     Icon = "super.png",
                     Text = "super",
                     EmotionType = EmotionType.Emotions
                 },
                 new Behavior
                 {
                     Id = 30,
                     Icon = "smart.png",
                     Text = "smart",
                     EmotionType = EmotionType.Emotions
                 },
                 new Behavior
                 {
                     Id = 31,
                     Icon = "scared.png",
                     Text = "scared",
                     EmotionType = EmotionType.Emotions
                 },
                 new Behavior
                 {
                     Id = 32,
                     Icon = "rich.png",
                     Text = "rich",
                     EmotionType = EmotionType.Emotions
                 },
                 new Behavior
                 {
                     Id = 33,
                     Icon = "perplexed.png",
                     Text = "perplexed",
                     EmotionType = EmotionType.Emotions
                 },
                  new Behavior
                  {
                      Id = 34,
                      Icon = "numb.png",
                      Text = "numb",
                      EmotionType = EmotionType.Emotions
                  },
                 new Behavior
                 {
                     Id = 35,
                     Icon = "naked.png",
                     Text = "naked",
                     EmotionType = EmotionType.Emotions
                 },
                 new Behavior
                 {
                     Id = 36,
                     Icon = "invisible.png",
                     Text = "invisible",
                     EmotionType = EmotionType.Emotions
                 },
                 new Behavior
                 {
                     Id = 37,
                     Icon = "inspired.png",
                     Text = "inspired",
                     EmotionType = EmotionType.Emotions
                 },
                 new Behavior
                 {
                     Id = 38,
                     Icon = "furious.png",
                     Text = "furious",
                     EmotionType = EmotionType.Emotions
                 },
                 new Behavior
                 {
                     Id = 39,
                     Icon = "funny.png",
                     Text = "funny",
                     EmotionType = EmotionType.Emotions
                 },
                  new Behavior
                  {
                      Id = 40,
                      Icon = "embarassed.png",
                      Text = "embarassed",
                      EmotionType = EmotionType.Emotions
                  },
                 new Behavior
                 {
                     Id = 41,
                     Icon = "cold.png",
                     Text = "cold",
                     EmotionType = EmotionType.Emotions
                 },
                 new Behavior
                 {
                     Id = 42,
                     Icon = "broken.png",
                     Text = "broken",
                     EmotionType = EmotionType.Emotions
                 },
                 new Behavior
                 {
                     Id = 43,
                     Icon = "hopeful.png",
                     Text = "hopeful",
                     EmotionType = EmotionType.Emotions
                 },
                 new Behavior
                 {
                     Id = 44,
                     Icon = "sarcastic.png",
                     Text = "sarcastic",
                     EmotionType = EmotionType.Emotions
                 },
                 new Behavior
                 {
                     Id = 45,
                     Icon = "heartbroken.png",
                     Text = "heartbroken",
                     EmotionType = EmotionType.Emotions
                 },
                  new Behavior
                  {
                      Id = 46,
                      Icon = "bored.png",
                      Text = "bored",
                      EmotionType = EmotionType.Emotions
                  },
                 new Behavior
                 {
                     Id = 47,
                     Icon = "beautiful.png",
                     Text = "beautiful",
                     EmotionType = EmotionType.Emotions
                 },
                 new Behavior
                 {
                     Id = 48,
                     Icon = "irritated.png",
                     Text = "irritated",
                     EmotionType = EmotionType.Emotions
                 }
                );
        }

        

    }
}
