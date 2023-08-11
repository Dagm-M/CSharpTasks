﻿// <auto-generated />
using System;
using BlogApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BlogApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230808201707_inital Migration")]
    partial class initalMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BlogApp.Models.BlogPost", b =>
                {
                    b.Property<int>("BlogPostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BlogPostId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("BlogPostId");

                    b.ToTable("BlogPosts");
                });

            modelBuilder.Entity("BlogApp.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CommentId"));

                    b.Property<int>("BlogPostId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CommentId");

                    b.HasIndex("BlogPostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("BlogApp.Models.Comment", b =>
                {
                    b.HasOne("BlogApp.Models.BlogPost", "BlogPost")
                        .WithMany("Comment")
                        .HasForeignKey("BlogPostId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BlogPost");
                });

            modelBuilder.Entity("BlogApp.Models.BlogPost", b =>
                {
                    b.Navigation("Comment");
                });
#pragma warning restore 612, 618
        }
    }
}
