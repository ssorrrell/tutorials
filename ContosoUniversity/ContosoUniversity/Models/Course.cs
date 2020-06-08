using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public class Course
    {
        //this attribute lets you enter the primary key for the course rather than having the database generate it
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int CourseID { get; set; } //this attribute is user generated instead of db generated

        //The Enrollments property is a navigation property. A Course entity can be related to any
        //number of Enrollment entities.
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Range(0, 5)]
        public int Credits { get; set; }

        public int DepartmentID { get; set; } //foreign key
        // Department navigation property
        public virtual Department Department { get; set; }
        // A course can have any number of students enrolled in it, so the Enrollments navigation property is a collection
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        // A course may be taught by multiple instructors, so the Instructors navigation property is a collection
        public virtual ICollection<Instructor> Instructors { get; set; }
    }
}