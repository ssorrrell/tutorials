using ContosoUniversity.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ContosoUniversity.DAL
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("SchoolContext")
        { //connection string
        }
        // If you don't specify a connection string or the name of one explicitly, Entity Framework
        // assumes that the connection string name is the same as the class name. The default
        // connection string name in this example would then be SchoolContext, the same as what you're
        // specifying explicitly.

        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<Person> People { get; set; }
        // DbSet property for each entity set. In Entity Framework terminology, an entity set
        // typically corresponds to a database table, and an entity corresponds to a row in the table

        // You can omit the DbSet<Enrollment> and DbSet<Course> statements and it would work the same.
        // Entity Framework would include them implicitly because the Student entity references the
        // Enrollment entity and the Enrollment entity references the Course entity.

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // The modelBuilder.Conventions.Remove statement in the OnModelCreating method prevents
            // table names from being pluralized. If you didn't do this, the generated tables in the
            // database would be named Students, Courses, and Enrollments
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Configures the many-to-many join table
            // For the many-to-many relationship between the Instructor and Course entities,
            // the code specifies the table and column names for the join table
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Instructors).WithMany(i => i.Courses)
                .Map(t => t.MapLeftKey("CourseID")
                    .MapRightKey("InstructorID")
                    .ToTable("CourseInstructor"));

            // one-to-zero-or-one relationship line (1 to 0..1) between the Instructor 
            // and OfficeAssignment entities
            modelBuilder.Entity<Instructor>()
                .HasOptional(p => p.OfficeAssignment).WithRequired(p => p.Instructor);

            // Use stored procedures for insert, update, and delete operations on the Department entity
            modelBuilder.Entity<Department>().MapToStoredProcedures();

            // If you prefer to use the fluent API, you can use the IsConcurrencyToken method to specify the tracking property,
            // This was done in the Model
            // modelBuilder.Entity<Department>()
            //    .Property(p => p.RowVersion).IsConcurrencyToken();
        }
    }
}