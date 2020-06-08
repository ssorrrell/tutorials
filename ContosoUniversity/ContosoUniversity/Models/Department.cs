using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")] //decimal type would map to decimal sql type and we want money
        public decimal Budget { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        // A department may or may not have an administrator, and an administrator is always an 
        // instructor. Therefore the InstructorID property is included as the foreign key to the 
        // Instructor entity, and a question mark is added after the int type designation to mark 
        // the property as nullable.The navigation property is named Administrator but holds an 
        // Instructor entity
        // If you didn't define the Department.InstructorID property as nullable, you'd get the 
        // following exception message: "The referential relationship will result in a cyclical 
        // reference that's not allowed."
        [Display(Name = "Administrator")]
        public int? InstructorID { get; set; }
        public virtual Instructor Administrator { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        // A department may have many courses, so there's a Courses navigation property
        public virtual ICollection<Course> Courses { get; set; }
    }
}