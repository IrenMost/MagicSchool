using BackendMagic.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Reflection.Emit;


namespace BackendMagic.Data
{
    public class SchoolContext : DbContext
    {
        public DbSet<Grade> Grade {  get; set; }
        
        public DbSet<House> Houses { get; set; }
        public DbSet<HouseElf> HousesElves { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<School> Schools { get; set; } 

        
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            

            // primary keys model
            modelBuilder.Entity<Grade>().HasKey(h => h.GradeId);
            modelBuilder.Entity<House>().HasKey(h => h.HouseId);
            modelBuilder.Entity<HouseElf>().HasKey(h => h.HouseElfId);
            modelBuilder.Entity<Room>().HasKey(h => h.RoomId);
            modelBuilder.Entity<Student>().HasKey(h => h.StudentId);
            modelBuilder.Entity<Teacher>().HasKey(h => h.TeacherId);
            modelBuilder.Entity<School>().HasKey(h => h.SchoolId);



            // relations

            // STUDENT 1 house, 1 room, 1 grade
            // a diáknak van 1 háza (house has student list)
            modelBuilder.Entity<Student>()
                .HasOne(s => s.House)
                .WithMany(h => h.Students)
                .HasForeignKey(s => s.HouseId)
                .OnDelete(DeleteBehavior.NoAction);

            // a diáknak van 1 szobája (room has student list)
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Room)
                .WithMany(r => r.Students)
                .HasForeignKey(s => s.RoomId)
                .OnDelete(DeleteBehavior.NoAction);

            // a diáknak van 1 osztálya (grade has student list)
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Grade)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.GradeId)
               .OnDelete(DeleteBehavior.NoAction);

            // ROOM 1 háza (mert a történetben így van, mert egy helyen vannak a szobák)
            // (house has room list)
            modelBuilder.Entity<Room>()
                .HasOne(r => r.House)
                .WithMany(h => h.Rooms)
                .HasForeignKey(r => r.HouseId)
                .OnDelete(DeleteBehavior.NoAction);

            // HOUSE 1 tanára(osztályfönök) de nem kölcsönös,
            modelBuilder.Entity<House>()
                .HasOne(h => h.HeadMaster)
                .WithMany() // mert a tanárnak nincs házlistája
                .HasForeignKey(h => h.TeacherId)
                .OnDelete(DeleteBehavior.NoAction);

            // TANÁROSZTÁLY class join table List<grade> osztályok listája
            // Define the many-to - many relationship between Teacher and Grade using TeacherGrade entity
            modelBuilder.Entity<TeacherGrade>()
                .HasKey(tg => new { tg.TeacherId, tg.GradeId }); // Composite primary key

            modelBuilder.Entity<TeacherGrade>()
                .HasOne(tg => tg.Teacher)
                .WithMany(t => t.TeacherGrades)
                .HasForeignKey(tg => tg.TeacherId);

            modelBuilder.Entity<TeacherGrade>()
                .HasOne(tg => tg.Grade)
                .WithMany(g => g.TeacherGrades)
                .HasForeignKey(tg => tg.GradeId);





        }

    }
}
