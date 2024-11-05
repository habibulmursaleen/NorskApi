﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NorskApi.Infrastructure.Persistance.DBContext;

#nullable disable

namespace NorskApi.Infrastructure.Migrations
{
    [DbContext(typeof(NorskApiDbContext))]
    partial class NorskApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NorskApi.Domain.DictationAggregate.Dictation", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DifficultyLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("EssayId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Dictations", (string)null);
                });

            modelBuilder.Entity("NorskApi.Domain.DiscussionAggregate.Discussion", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DifficultyLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiscussionEssays")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<Guid>("EssayId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Discussions", (string)null);
                });

            modelBuilder.Entity("NorskApi.Domain.LocalExpressionAggregate.LocalExpression", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LocalExpressionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MeaningInEnglish")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("MeaningInNorsk")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("LocalExpressions", (string)null);
                });

            modelBuilder.Entity("NorskApi.Domain.PodcastAggregate.Podcast", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descriptions")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("DifficultyLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("EssayId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFeatured")
                        .HasColumnType("bit");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Podcasts", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
