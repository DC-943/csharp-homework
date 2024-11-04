using michael_3038EFWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace michael_3038EFWebAPI.Data
{
    public class HomeworkDBContext: DbContext
    {

        public HomeworkDBContext(DbContextOptions<HomeworkDBContext> options) : base(options)
        {

        }
        public DbSet<Category> Category { get;  set; }

        public DbSet<Course> Course { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().ToTable("Categorys");
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
