using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MovieNowAPI.Entities
{
    public partial class MovienowDbContext : DbContext
    {
        public MovienowDbContext()
        {
        }

        public MovienowDbContext(DbContextOptions<MovienowDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Follower> Followers { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<ProfilePrivacySetting> ProfilePrivacySettings { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<SystemMessage> SystemMessages { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Follower>(entity =>
            {
                entity.ToTable("followers");

                entity.HasIndex(e => e.UserId, "userId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FollowerId).HasColumnName("followerId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Followers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("followers_ibfk_1");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("movies");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Genre)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("genre");

                entity.Property(e => e.Poster)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("poster");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("title");

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("year");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("profiles");

                entity.HasIndex(e => e.UserId, "userId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .HasColumnName("gender");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .HasColumnName("surname");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Profiles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("profiles_ibfk_1");
            });

            modelBuilder.Entity<ProfilePrivacySetting>(entity =>
            {
                entity.ToTable("profileprivacysettings");

                entity.HasIndex(e => e.UserId, "userId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FollowersOnly).HasColumnName("followersOnly");

                entity.Property(e => e.Private).HasColumnName("private");

                entity.Property(e => e.Public).HasColumnName("public");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProfilePrivacySettings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("profileprivacysettings_ibfk_1");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("ratings");

                entity.HasIndex(e => e.MovieId, "movieId");

                entity.HasIndex(e => e.UserId, "userId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MovieId).HasColumnName("movieId");

                entity.Property(e => e.RatingNumber).HasColumnName("ratingNumber");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("ratings_ibfk_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("ratings_ibfk_1");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("reviews");

                entity.HasIndex(e => e.MovieId, "movieId");

                entity.HasIndex(e => e.UserId, "userId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MovieId).HasColumnName("movieId");

                entity.Property(e => e.ReviewText)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("reviewText");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("reviews_ibfk_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("reviews_ibfk_1");
            });

            modelBuilder.Entity<SystemMessage>(entity =>
            {
                entity.ToTable("systemmessages");

                entity.HasIndex(e => e.UserId, "userId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("text");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SystemMessages)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("systemmessages_ibfk_1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
