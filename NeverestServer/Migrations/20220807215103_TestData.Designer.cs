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
    [Migration("20220807215103_TestData")]
    partial class TestData
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

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Advisors");
                });

            modelBuilder.Entity("NeverestServer.Models.Character", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CharacterId"), 1L, 1);

                    b.Property<int>("CharacterQuestsId")
                        .HasColumnType("int");

                    b.Property<int>("CharacterSkillsId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CharacterId");

                    b.HasIndex("JobId")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("NeverestServer.Models.CharacterQuest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("QuestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("QuestId");

                    b.ToTable("CharacterQuests");
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

            modelBuilder.Entity("NeverestServer.Models.JobSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.HasIndex("SkillId");

                    b.ToTable("JobSkills");
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

                    b.Property<int>("MaxSkillLevel")
                        .HasColumnType("int");

                    b.Property<string>("SkillGroup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SkillName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SkillId");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            SkillId = 1,
                            MaxSkillLevel = 2,
                            SkillGroup = "Frontend",
                            SkillName = "HTML"
                        },
                        new
                        {
                            SkillId = 2,
                            MaxSkillLevel = 1,
                            SkillGroup = "Frontend",
                            SkillName = "CSS"
                        },
                        new
                        {
                            SkillId = 3,
                            MaxSkillLevel = 2,
                            SkillGroup = "Frontend",
                            SkillName = "JavaScript"
                        },
                        new
                        {
                            SkillId = 4,
                            MaxSkillLevel = 2,
                            SkillGroup = "Frontend",
                            SkillName = "TypeScript"
                        },
                        new
                        {
                            SkillId = 5,
                            MaxSkillLevel = 3,
                            SkillGroup = "Frontend",
                            SkillName = "Angular"
                        },
                        new
                        {
                            SkillId = 6,
                            MaxSkillLevel = 2,
                            SkillGroup = "Backend",
                            SkillName = "C#"
                        },
                        new
                        {
                            SkillId = 7,
                            MaxSkillLevel = 3,
                            SkillGroup = "Backend",
                            SkillName = "Asp.Net"
                        },
                        new
                        {
                            SkillId = 8,
                            MaxSkillLevel = 2,
                            SkillGroup = "Backend",
                            SkillName = "Java"
                        },
                        new
                        {
                            SkillId = 9,
                            MaxSkillLevel = 2,
                            SkillGroup = "Backend",
                            SkillName = "Python"
                        });
                });

            modelBuilder.Entity("NeverestServer.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ResetPasswordToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TokenExpired")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("VerifiedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NeverestServer.Models.Advisor", b =>
                {
                    b.HasOne("NeverestServer.Models.User", "User")
                        .WithOne("Advisor")
                        .HasForeignKey("NeverestServer.Models.Advisor", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("NeverestServer.Models.Character", b =>
                {
                    b.HasOne("NeverestServer.Models.Job", "Job")
                        .WithOne("Character")
                        .HasForeignKey("NeverestServer.Models.Character", "JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NeverestServer.Models.User", "User")
                        .WithOne("Character")
                        .HasForeignKey("NeverestServer.Models.Character", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NeverestServer.Models.CharacterQuest", b =>
                {
                    b.HasOne("NeverestServer.Models.Character", "Character")
                        .WithMany("CharacterQuests")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NeverestServer.Models.Quest", "Quest")
                        .WithMany("CharacterQuests")
                        .HasForeignKey("QuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Quest");
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

            modelBuilder.Entity("NeverestServer.Models.JobSkill", b =>
                {
                    b.HasOne("NeverestServer.Models.Job", "Job")
                        .WithMany("JobSkills")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NeverestServer.Models.Skill", "Skill")
                        .WithMany("JobSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("NeverestServer.Models.Character", b =>
                {
                    b.Navigation("CharacterQuests");

                    b.Navigation("CharacterSkills");
                });

            modelBuilder.Entity("NeverestServer.Models.Job", b =>
                {
                    b.Navigation("Character");

                    b.Navigation("JobSkills");
                });

            modelBuilder.Entity("NeverestServer.Models.Quest", b =>
                {
                    b.Navigation("CharacterQuests");
                });

            modelBuilder.Entity("NeverestServer.Models.Skill", b =>
                {
                    b.Navigation("CharacterSkills");

                    b.Navigation("JobSkills");
                });

            modelBuilder.Entity("NeverestServer.Models.User", b =>
                {
                    b.Navigation("Advisor");

                    b.Navigation("Character");
                });
#pragma warning restore 612, 618
        }
    }
}
