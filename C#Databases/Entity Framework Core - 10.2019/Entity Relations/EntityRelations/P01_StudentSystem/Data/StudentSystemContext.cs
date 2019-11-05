namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
        }

        public StudentSystemContext(DbContextOptions dbContextOptions)
            :base(dbContextOptions)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigurationOnStudent(modelBuilder);
            ConfigurationOnCourse(modelBuilder);
            ConfigurationOnResource(modelBuilder);
            ConfigurationOnHomework(modelBuilder);
            ConfigurationOnStudentCourse(modelBuilder);
        }

        private void ConfigurationOnStudentCourse(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<StudentCourse>()
                .HasKey(k => new { k.StudentId, k.CourseId });
        }

        private void ConfigurationOnHomework(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Homework>()
                .HasKey(k => k.HomeworkId);

            modelBuilder
                .Entity<Homework>()
                .Property(p => p.Content)
                .IsRequired();

            modelBuilder
                .Entity<Homework>()
                .Property(p => p.ContentType)
                .IsRequired();

            modelBuilder
                .Entity<Homework>()
                .Property(p => p.SubmissionTime)
                .IsRequired();
        }

        private void ConfigurationOnResource(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Resource>()
                .HasKey(k => k.ResourceId);

            modelBuilder
                .Entity<Resource>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            modelBuilder
                .Entity<Resource>()
                .Property(p => p.Url)
                .IsRequired();

            modelBuilder
                .Entity<Resource>()
                .Property(p => p.ResourceType)
                .IsRequired();
        }

        private void ConfigurationOnCourse(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Course>()
                .HasKey(k => k.CourseId);

            modelBuilder
                .Entity<Course>()
                .Property(p => p.Name)
                .HasMaxLength(80)
                .IsUnicode()
                .IsRequired();

            modelBuilder
                .Entity<Course>()
                .Property(p => p.Description)
                .IsUnicode()
                .IsRequired(false);

            modelBuilder
                .Entity<Course>()
                .Property(p => p.StartDate)
                .IsRequired();

            modelBuilder
                .Entity<Course>()
                .Property(p => p.EndDate)
                .IsRequired();

            modelBuilder
                .Entity<Course>()
                .Property(p => p.Price)
                .IsRequired();

            modelBuilder
                .Entity<Course>()
                .HasMany(s => s.StudentsEnrolled)
                .WithOne(c => c.Course)
                .HasForeignKey(k => k.CourseId);

            modelBuilder
                .Entity<Course>()
                .HasMany(r => r.Resources)
                .WithOne(c => c.Course)
                .HasForeignKey(k => k.CourseId);

            modelBuilder
                .Entity<Course>()
                .HasMany(r => r.HomeworkSubmissions)
                .WithOne(c => c.Course)
                .HasForeignKey(k => k.CourseId);
        }

        private void ConfigurationOnStudent(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Student>()
                .HasKey(k => k.StudentId);

            modelBuilder
                .Entity<Student>()
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsUnicode()
                .IsRequired();

            modelBuilder
                .Entity<Student>()
                .Property(p => p.PhoneNumber)
                .HasDefaultValueSql("CHAR(10)");

            modelBuilder
                .Entity<Student>()
                .Property(p => p.RegisteredOn)
                .IsRequired();

            modelBuilder
                .Entity<Student>()
                .Property(p => p.Birthday);

            modelBuilder
                .Entity<Student>()
                .HasMany(ce => ce.CourseEnrollments)
                .WithOne(s => s.Student)
                .HasForeignKey(k => k.StudentId);

            modelBuilder
                .Entity<Student>()
                .HasMany(hs => hs.HomeworkSubmissions)
                .WithOne(s => s.Student)
                .HasForeignKey(k => k.StudentId);
        }
    }
}
