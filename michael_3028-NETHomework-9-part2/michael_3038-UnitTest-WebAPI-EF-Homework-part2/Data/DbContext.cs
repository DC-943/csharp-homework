using michael_3038EFWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace michael_3038EFWebAPI.Data
{
    public class HomeworkDBContext: DbContext
    {

        public HomeworkDBContext(DbContextOptions<HomeworkDBContext> options) : base(options)
        {

        }
        public HomeworkDBContext() { }
        public virtual DbSet<Category> Categories { get;  set; }

        public virtual DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Category>(c =>
            {
                c.HasKey(x => x.Id);
                c.Property(x => x.CategoryName).IsRequired().HasMaxLength(200);
                c.HasMany(x => x.Courses);
            });

            modelBuilder.Entity<Course>().ToTable("Courses");
            modelBuilder.Entity<Course>(c =>
            {
                c.HasKey(x => x.Id);
                c.Property(x => x.CourseName).IsRequired().HasMaxLength(200);
                c.Property(x => x.Description).IsRequired().HasMaxLength(200);
                c.HasOne(x => x.Category);
            });

        }


    }
}
