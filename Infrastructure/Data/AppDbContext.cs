using Domain.Model;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<CoordinatorCategory> CoordinatorCategories { get; set; }
        public DbSet<RemovedQuestion> RemovedQuestions { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<CurrentAffair> CurrentAffairs { get; set; }
        public DbSet<ExamSchedule> ExamSchedules { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<ExamAttempt> ExamAttempts { get; set; }
        public DbSet<ExamAnswer> ExamAnswers { get; set; }


        public DbSet<ExamQuestion> ExamQuestions { get; set; }


        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletTransaction> WalletTransactions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Exam>()
                .HasOne(e => e.Category)
                .WithMany(c => c.Exams)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Question>().Property(q => q.Text).IsRequired();
            modelBuilder.Entity<Question>().Property(q => q.OptionA).IsRequired();
            modelBuilder.Entity<Question>().Property(q => q.OptionB).IsRequired();
            modelBuilder.Entity<Question>().Property(q => q.OptionC).IsRequired();
            modelBuilder.Entity<Question>().Property(q => q.OptionD).IsRequired();
            modelBuilder.Entity<Question>().Property(q => q.CorrectOption).IsRequired();

            modelBuilder.Entity<Question>()
                .HasOne(q => q.Exam)
                .WithMany(e => e.Questions)
                .HasForeignKey(q => q.ExamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.CoordinatorCategories)
                .WithOne(cc => cc.Coordinator)
                .HasForeignKey(cc => cc.CoordinatorId);

            modelBuilder.Entity<CurrentAffair>(entity =>
            {
                entity.ToTable("CurrentAffairs");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Title).IsRequired().HasMaxLength(255);
                entity.Property(c => c.Content).IsRequired();
                entity.Property(c => c.PublishedDate).IsRequired();
                entity.Property(c => c.IsPublic).HasDefaultValue(true);
            });

            modelBuilder.Entity<ExamSchedule>()
                .HasOne(e => e.Exam)
                .WithMany()
                .HasForeignKey(e => e.ExamId);

            modelBuilder.Entity<ExamAttempt>(entity =>
            {
                entity.HasKey(ea => ea.Id);

                entity.HasOne(ea => ea.User)
                      .WithMany(u => u.ExamAttempts)
                      .HasForeignKey(ea => ea.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(ea => ea.Exam)
                      .WithMany()
                      .HasForeignKey(ea => ea.ExamId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ExamAnswer>(entity =>
            {
                entity.HasKey(ea => ea.Id);

                entity.HasOne(ea => ea.ExamAttempt)
                      .WithMany(attempt => attempt.Answers)
                      .HasForeignKey(ea => ea.ExamAttemptId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(ea => ea.Question)
                      .WithMany()
                      .HasForeignKey(ea => ea.QuestionId)
                      .OnDelete(DeleteBehavior.Restrict);
            });


            modelBuilder.Entity<ExamQuestion>()
               .HasKey(eq => new { eq.ExamId, eq.QuestionId });

            modelBuilder.Entity<ExamQuestion>()
                .HasOne(eq => eq.Exam)
                .WithMany(e => e.ExamQuestions)
                .HasForeignKey(eq => eq.ExamId);

            modelBuilder.Entity<ExamQuestion>()
                .HasOne(eq => eq.Question)
                .WithMany(q => q.ExamQuestions)
                .HasForeignKey(eq => eq.QuestionId);
        }
    }
}
