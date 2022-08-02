﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NeverestServer.Data;

#nullable disable

namespace NeverestServer.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220802041404_testData")]
    partial class testData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NeverestServer.Models.Advisor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AdvisorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Advisors");
                });

            modelBuilder.Entity("NeverestServer.Models.Character", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CharacterId"), 1L, 1);

                    b.Property<int>("AdvisorId")
                        .HasColumnType("int");

                    b.Property<string>("CharacterName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataCreated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("JobId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CharacterId");

                    b.HasIndex("AdvisorId");

                    b.HasIndex("JobId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("NeverestServer.Models.CharacterSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("LearningLevel")
                        .HasColumnType("int");

                    b.Property<string>("LearningStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("SkillId");

                    b.ToTable("CharacterSkills");
                });

            modelBuilder.Entity("NeverestServer.Models.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobId"), 1L, 1);

                    b.Property<string>("JobName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrevJobId")
                        .HasColumnType("int");

                    b.HasKey("JobId");

                    b.ToTable("Jobs");

                    b.HasData(
                        new
                        {
                            JobId = 1,
                            JobName = "Software Developer Trainee",
                            PrevJobId = 0
                        },
                        new
                        {
                            JobId = 2,
                            JobName = "Software Developer",
                            PrevJobId = 1
                        },
                        new
                        {
                            JobId = 3,
                            JobName = "Senior Software Developer",
                            PrevJobId = 2
                        },
                        new
                        {
                            JobId = 4,
                            JobName = "Assistance System Analyst",
                            PrevJobId = 3
                        },
                        new
                        {
                            JobId = 5,
                            JobName = "System Analyst",
                            PrevJobId = 4
                        },
                        new
                        {
                            JobId = 6,
                            JobName = "Project Manager",
                            PrevJobId = 5
                        });
                });

            modelBuilder.Entity("NeverestServer.Models.Quest", b =>
                {
                    b.Property<int>("QuestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestId"), 1L, 1);

                    b.Property<string>("QuestDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("QuestFinished")
                        .HasColumnType("datetime2");

                    b.Property<string>("QuestName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("QuestRecieved")
                        .HasColumnType("datetime2");

                    b.HasKey("QuestId");

                    b.ToTable("Quests");
                });

            modelBuilder.Entity("NeverestServer.Models.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SkillId"), 1L, 1);

                    b.Property<int?>("JobId")
                        .HasColumnType("int");

                    b.Property<int>("MaxSkillLevel")
                        .HasColumnType("int");

                    b.Property<string>("SkillGroup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SkillLevel")
                        .HasColumnType("int");

                    b.Property<string>("SkillName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SkillId");

                    b.HasIndex("JobId");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            SkillId = 1,
                            MaxSkillLevel = 2,
                            SkillGroup = "Frontend",
                            SkillLevel = 0,
                            SkillName = "HTML"
                        },
                        new
                        {
                            SkillId = 2,
                            MaxSkillLevel = 1,
                            SkillGroup = "Frontend",
                            SkillLevel = 0,
                            SkillName = "CSS"
                        },
                        new
                        {
                            SkillId = 3,
                            MaxSkillLevel = 2,
                            SkillGroup = "Frontend",
                            SkillLevel = 0,
                            SkillName = "JavaScript"
                        },
                        new
                        {
                            SkillId = 4,
                            MaxSkillLevel = 2,
                            SkillGroup = "Frontend",
                            SkillLevel = 0,
                            SkillName = "TypeScript"
                        },
                        new
                        {
                            SkillId = 5,
                            MaxSkillLevel = 3,
                            SkillGroup = "Frontend",
                            SkillLevel = 0,
                            SkillName = "Angular"
                        },
                        new
                        {
                            SkillId = 6,
                            MaxSkillLevel = 2,
                            SkillGroup = "Backend",
                            SkillLevel = 0,
                            SkillName = "C#"
                        },
                        new
                        {
                            SkillId = 7,
                            MaxSkillLevel = 3,
                            SkillGroup = "Backend",
                            SkillLevel = 0,
                            SkillName = "Asp.Net"
                        },
                        new
                        {
                            SkillId = 8,
                            MaxSkillLevel = 2,
                            SkillGroup = "Backend",
                            SkillLevel = 0,
                            SkillName = "Java"
                        },
                        new
                        {
                            SkillId = 9,
                            MaxSkillLevel = 2,
                            SkillGroup = "Backend",
                            SkillLevel = 0,
                            SkillName = "Python"
                        });
                });

            modelBuilder.Entity("NeverestServer.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NeverestServer.Models.Advisor", b =>
                {
                    b.HasOne("NeverestServer.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("NeverestServer.Models.Character", b =>
                {
                    b.HasOne("NeverestServer.Models.Advisor", "Advisor")
                        .WithMany("Characters")
                        .HasForeignKey("AdvisorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NeverestServer.Models.Job", "Job")
                        .WithMany()
                        .HasForeignKey("JobId");

                    b.HasOne("NeverestServer.Models.User", "User")
                        .WithOne("Character")
                        .HasForeignKey("NeverestServer.Models.Character", "UserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Advisor");

                    b.Navigation("Job");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NeverestServer.Models.CharacterSkill", b =>
                {
                    b.HasOne("NeverestServer.Models.Character", "Character")
                        .WithMany("CharacterSkills")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NeverestServer.Models.Skill", "Skill")
                        .WithMany("CharacterSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("NeverestServer.Models.Skill", b =>
                {
                    b.HasOne("NeverestServer.Models.Job", null)
                        .WithMany("Skills")
                        .HasForeignKey("JobId");
                });

            modelBuilder.Entity("NeverestServer.Models.Advisor", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("NeverestServer.Models.Character", b =>
                {
                    b.Navigation("CharacterSkills");
                });

            modelBuilder.Entity("NeverestServer.Models.Job", b =>
                {
                    b.Navigation("Skills");
                });

            modelBuilder.Entity("NeverestServer.Models.Skill", b =>
                {
                    b.Navigation("CharacterSkills");
                });

            modelBuilder.Entity("NeverestServer.Models.User", b =>
                {
                    b.Navigation("Character");
                });
#pragma warning restore 612, 618
        }
    }
}
