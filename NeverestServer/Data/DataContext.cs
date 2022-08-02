using NeverestServer.Models;
using Microsoft.EntityFrameworkCore;

namespace NeverestServer.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Advisor> Advisors { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Quest> Quests { get; set; }
        public DbSet<CharacterSkill> CharacterSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>().HasData(
                new Job()
                {
                    JobId = 1,
                    JobName = "Software Developer Trainee"
                },
                new Job()
                {
                    JobId = 2,
                    JobName = "Software Developer",
                    PrevJobId = 1
                },
                new Job()
                {
                    JobId = 3,
                    JobName = "Senior Software Developer",
                    PrevJobId = 2
                },
                new Job()
                {
                    JobId = 4,
                    JobName = "Assistance System Analyst",
                    PrevJobId = 3
                },
                new Job()
                {
                    JobId = 5,
                    JobName = "System Analyst",
                    PrevJobId = 4
                },
                new Job()
                {
                    JobId = 6,
                    JobName = "Project Manager",
                    PrevJobId = 5
                }
            );
            modelBuilder.Entity<Skill>().HasData(
                new Skill()
                {
                    SkillId = 1,
                    SkillName = "HTML",
                    SkillGroup = "Frontend",
                    MaxSkillLevel = 2
                },
                new Skill()
                {
                    SkillId = 2,
                    SkillName = "CSS",
                    SkillGroup = "Frontend",
                    MaxSkillLevel = 1
                },
                new Skill()
                {
                    SkillId = 3,
                    SkillName = "JavaScript",
                    SkillGroup = "Frontend",
                    MaxSkillLevel = 2
                },
                new Skill()
                {
                    SkillId = 4,
                    SkillName = "TypeScript",
                    SkillGroup = "Frontend",
                    MaxSkillLevel = 2
                },
                new Skill()
                {
                    SkillId = 5,
                    SkillName = "Angular",
                    SkillGroup = "Frontend",
                    MaxSkillLevel = 3
                },
                new Skill()
                {
                    SkillId = 6,
                    SkillName = "C#",
                    SkillGroup = "Backend",
                    MaxSkillLevel = 2
                },
                new Skill()
                {
                    SkillId = 7,
                    SkillName = "Asp.Net",
                    SkillGroup = "Backend",
                    MaxSkillLevel = 3
                },
                new Skill()
                {
                    SkillId = 8,
                    SkillName = "Java",
                    SkillGroup = "Backend",
                    MaxSkillLevel = 2
                },
                new Skill()
                {
                    SkillId = 9,
                    SkillName = "Python",
                    SkillGroup = "Backend",
                    MaxSkillLevel = 2
                }
            );

            modelBuilder.Entity<CharacterSkill>().HasOne<Character>(cs => cs.Character)
                .WithMany(c => c.CharacterSkills)
                .HasForeignKey(cs => cs.CharacterId);

            modelBuilder.Entity<CharacterSkill>().HasOne<Skill>(cs => cs.Skill)
                .WithMany(c => c.CharacterSkills)
                .HasForeignKey(cs => cs.SkillId);

            modelBuilder.Entity<Character>().HasOne<User>(u => u.User).WithOne(u => u.Character).HasForeignKey<Character>(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);
                
        }
    }
}
