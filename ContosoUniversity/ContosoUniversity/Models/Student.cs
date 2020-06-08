using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    //The Enrollments property is a navigation property.Navigation properties hold other entities that
    //are related to this entity.In this case, the Enrollments property of a Student entity will hold all
    //of the Enrollment entities that are related to that Student entity.In other words, if a given Student
    //row in the database has two related Enrollment rows (rows that contain that student's primary key
    //value in their StudentID foreign key column), that Student entity's Enrollments navigation property
    //will contain those two Enrollment entities.

    //If a navigation property can hold multiple entities(as in many-to-many or one-to-many relationships), 
    //its type must be a list in which entries can be added, deleted, and updated, such as ICollection.

    public class Student : Person
    {
        /*
        Turned Off
        public int ID { get; set; }
        [Required]
        [StringLength(50)] // MaxLength attribute provides similar functionality to the StringLength attribute but doesn't provide client side validation
        [Display(Name = "Last Name")] //Label
        public string LastName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Display(Name = "First Name")] //Label
        public string FirstMidName { get; set; }
        */

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        // DataType Enumeration provides for many data types, such as Date, Time, PhoneNumber, Currency, EmailAddress and more
        [Display(Name = "Enrollment Date")] //Label
        public DateTime EnrollmentDate { get; set; }

        /*
        Turned Off
        [Display(Name = "Full Name")] //Label
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }
        */

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}