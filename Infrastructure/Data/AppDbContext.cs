using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }

        public DbSet<CoordinatorCategory> CoordinatorCategories { get; set; }

        public DbSet<RemovedQuestion> RemovedQuestions { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);

            });

            {
                modelBuilder.Entity<Exam>()
                    .HasOne(e => e.Category)
                    .WithMany(c => c.Exams)
                    .HasForeignKey(e => e.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade);
            }
             {
            modelBuilder.Entity<Question>().Property(q => q.Text).IsRequired();
            modelBuilder.Entity<Question>().Property(q => q.OptionA).IsRequired();
            modelBuilder.Entity<Question>().Property(q => q.OptionB).IsRequired();
            modelBuilder.Entity<Question>().Property(q => q.OptionC).IsRequired();
            modelBuilder.Entity<Question>().Property(q => q.OptionD).IsRequired();
            modelBuilder.Entity<Question>().Property(q => q.CorrectOption).IsRequired();
             }
            {
                base.OnModelCreating(modelBuilder);

                // Configure one-to-many relationship
                modelBuilder.Entity<Question>()
                    .HasOne(q => q.Exam)
                    .WithMany(e => e.Questions)
                    .HasForeignKey(q => q.ExamId)
                    .OnDelete(DeleteBehavior.Restrict);
            }
            {
                modelBuilder.Entity<User>()
                    .HasMany(u => u.CoordinatorCategories)
                    .WithOne(cc => cc.Coordinator)
                    .HasForeignKey(cc => cc.CoordinatorId);
            }


        }

        



        //}
    }
}
