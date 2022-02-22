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
        public DbSet<UserMessage> UserMessages { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);           
            builder.Entity<Suggest>().
               Property(s => s.CreatedDate).HasDefaultValueSql("dateadd(hour,4,getutcdate())");
            builder.Entity<Message>().
               Property(m => m.CreatedDate).HasDefaultValueSql("dateadd(hour,4,getutcdate())");
            builder.Entity<Friendship>().
               Property(f => f.CreatedDate).HasDefaultValueSql("dateadd(hour,4,getutcdate())");           

            builder.Entity<Friendship>()
                .HasOne(d => d.User)
                   .WithMany(p => p.Friends)
                   .HasForeignKey(d => d.UserId);

            builder.Entity<Suggest>()
               .HasOne(d => d.Acceptor)
                  .WithMany(p => p.Suggests)
                  .HasForeignKey(d => d.AcceptorId);          

        }

    }
}
