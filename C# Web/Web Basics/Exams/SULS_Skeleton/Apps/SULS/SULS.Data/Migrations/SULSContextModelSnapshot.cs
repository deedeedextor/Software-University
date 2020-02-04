﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SULS.Data;

namespace SULS.Data.Migrations
{
    [DbContext(typeof(SULSContext))]
    partial class SULSContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SULS.Models.Problem", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("Points");

                    b.HasKey("Id");

                    b.ToTable("Problems");
                });

            modelBuilder.Entity("SULS.Models.Submission", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AchievedResult");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(800);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("ProblemId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ProblemId");

                    b.HasIndex("UserId");

                    b.ToTable("Submissions");
                });

            modelBuilder.Entity("SULS.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SULS.Models.Submission", b =>
                {
                    b.HasOne("SULS.Models.Problem", "Problem")
                        .WithMany("Submissions")
                        .HasForeignKey("ProblemId");

                    b.HasOne("SULS.Models.User", "User")
                        .WithMany("Submissions")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}