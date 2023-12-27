using Asp.netCoreMVCIntro.Models;
using Microsoft.EntityFrameworkCore;

namespace Asp.netCoreMVCIntro.Context
{
    public class CollageDbContext:DbContext
    {
        public CollageDbContext(DbContextOptions<CollageDbContext> options) : base(options)
        {
        }
        public DbSet<Collage> Collages { get; set; }
        public DbSet<Student> Students { get; set; }
        // seed database tables with initial data 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                 new Student
                 {
                     Id = 1,
                     First_Name = "Atul",
                     Last_Name = "Thete",
                     Percentage = 90,
                     DOB = new DateTime(2003, 01, 27, 17, 20, 00),
                     CollageId = 1
                 }
             );

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 2,
                    First_Name = "Ankit",
                    Last_Name = "Sharma",
                    Percentage = 85,
                    DOB = new DateTime(2003, 01, 27, 17, 20, 00),
                    CollageId = 1
                }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 3,
                    First_Name = "Pranjal",
                    Last_Name = "Thorat",
                    Percentage = 88,
                    DOB = new DateTime(2002, 07, 02, 06, 50, 00),
                    CollageId = 2
                }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 4,
                    First_Name = "Aditi",
                    Last_Name = "Bhawsar",
                    Percentage = 82,
                    DOB = new DateTime(2002, 11, 06, 23, 20, 00),
                    CollageId = 2
                }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 5,
                    First_Name = "Lalit",
                    Last_Name = "Pagar",
                    Percentage = 89,
                    DOB = new DateTime(2003, 02, 08, 09, 20, 00),
                    CollageId = 3
                }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 6,
                    First_Name = "Abhijeet",
                    Last_Name = "Bhaskar",
                    Percentage = 84,
                    DOB = new DateTime(2002, 04, 06, 15, 20, 00),
                    CollageId = 3
                }
            );

            modelBuilder.Entity<Collage>().HasData(
                new Collage
                {
                    Id = 1,
                    Collage_Name = "MET",
                    Grade = "B++",
                    Address = "Adgoan",
                    Code = 4047
                }
            );

            modelBuilder.Entity<Collage>().HasData(
                new Collage
                {
                    Id = 2,
                    Collage_Name = "NDMVP",
                    Grade = "A++",
                    Address = "Gangapur Road",
                    Code = 4039
                }
            );

            modelBuilder.Entity<Collage>().HasData(
                new Collage
                {
                    Id = 3,
                    Collage_Name = "KKW",
                    Grade = "A++",
                    Address = "Amrutdham",
                    Code = 4043
                }
            );
        }
    }
}
