using Microsoft.EntityFrameworkCore;
using DoConnectBackend.Models;

namespace DoConnectBackend.Data
{
    public class DoConnectContext : DbContext
    {
        public DoConnectContext(DbContextOptions<DoConnectContext> options)
            : base(options)
        {
        }

        // Define DbSets for your models here
        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.HasKey(a => a.AnswerId);

                entity.HasOne(a => a.User)
                      .WithMany(u => u.Answers)
                      .HasForeignKey(a => a.UserId)
                      .OnDelete(DeleteBehavior.Restrict);  // ❌ Prevent cascade here

                entity.HasOne(a => a.Question)
                      .WithMany(q => q.Answers)
                      .HasForeignKey(a => a.QuestionId)
                      .OnDelete(DeleteBehavior.Cascade);   // ✅ Keep cascade here
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(q => q.QuestionId);

                entity.HasOne(q => q.User)
                      .WithMany(u => u.Questions)
                      .HasForeignKey(q => q.UserId)
                      .OnDelete(DeleteBehavior.Cascade);   // ✅ Keep cascade here
            });
        }
    }
}