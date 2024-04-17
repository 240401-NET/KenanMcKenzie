using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using p1.Model;
using server.Model;
namespace server.Data;

public partial class FreeDbContext : IdentityDbContext<User>
{
    public FreeDbContext(DbContextOptions<FreeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<QuestionOption> QuestionOptions { get; set; }

    public virtual DbSet<Quiz> Quizzes { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__Question__2EC21549A14D8346");

            entity.ToTable("Question", "quiz_schema");

            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.BelongsTo).HasColumnName("belongsTo");
            entity.Property(e => e.Example)
                .HasMaxLength(120)
                .HasColumnName("example");
            entity.Property(e => e.QuestionText)
                .HasMaxLength(100)
                .HasColumnName("questionText");

            entity.HasOne(d => d.BelongsToNavigation).WithMany(p => p.Questions)
                .HasForeignKey(d => d.BelongsTo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Question__belong__6754599E");
        });

        modelBuilder.Entity<QuestionOption>(entity =>
        {
            entity.HasKey(e => e.OptionId).HasName("PK__Question__F4EACE1B7816C194");

            entity.ToTable("QuestionOption", "quiz_schema");

            entity.Property(e => e.OptionId).HasColumnName("option_id");
            entity.Property(e => e.BelongsToQuestion).HasColumnName("belongsToQuestion");
            entity.Property(e => e.IsAnswer).HasColumnName("isAnswer");
            entity.Property(e => e.OptionText)
                .HasMaxLength(100)
                .HasColumnName("optionText");

            entity.HasOne(d => d.BelongsToQuestionNavigation).WithMany(p => p.QuestionOptions)
                .HasForeignKey(d => d.BelongsToQuestion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__QuestionO__belon__6A30C649");
        });

        modelBuilder.Entity<Quiz>(entity =>
        {
            entity.HasKey(e => e.QuizId).HasName("PK__Quiz__2D7053ECAAC4642E");

            entity.ToTable("Quiz", "quiz_schema");

            entity.Property(e => e.QuizId).HasColumnName("quiz_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.Description)
                .HasMaxLength(30)
                .HasColumnName("description");
            entity.Property(e => e.Title)
                .HasMaxLength(20)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Quizzes)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Quiz__createdBy__5EBF139D");

            entity.HasMany(d => d.Tags).WithMany(p => p.Quizzes)
                .UsingEntity<Dictionary<string, object>>(
                    "QuizTag",
                    r => r.HasOne<Tag>().WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__QuizTag__tagId__6477ECF3"),
                    l => l.HasOne<Quiz>().WithMany()
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__QuizTag__quizId__6383C8BA"),
                    j =>
                    {
                        j.HasKey("QuizId", "TagId").HasName("PK__QuizTag__AAFA8C28895FA0CE");
                        j.ToTable("QuizTag", "quiz_schema");
                        j.IndexerProperty<int>("QuizId").HasColumnName("quizId");
                        j.IndexerProperty<int>("TagId").HasColumnName("tagId");
                    });
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.TagId).HasName("PK__Tag__4296A2B6D2A25651");

            entity.ToTable("Tag", "quiz_schema");

            entity.Property(e => e.TagId).HasColumnName("tag_id");
            entity.Property(e => e.TagName)
                .HasMaxLength(20)
                .HasColumnName("tagName");
        });





        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
