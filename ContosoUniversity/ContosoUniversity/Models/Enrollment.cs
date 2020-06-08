using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    //Entity Framework interprets a property as a foreign key property if it's named <navigation property
    //name><primary key property name> (for example, StudentID for the Student navigation property since
    //the Student entity's primary key is ID). Foreign key properties can also be named the same simply
    //<primary key property name> (for example, CourseID since the Course entity's primary key is CourseID).
 
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        //The EnrollmentID property will be the primary key; this entity uses the classname ID pattern
        //instead of ID by itself as you saw in the Student entity. Ordinarily you would choose one
        //pattern and use it throughout your data model. Here, the variation illustrates that you can
        //use either pattern.
        public int EnrollmentID { get; set; }

        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }
        // The question mark after the Grade type declaration indicates that the Grade property is nullable.
        // A grade that's null is different from a zero grade — null means a grade isn't known or hasn't been
        // assigned yet.
        // An enrollment record is for a single course, so there's a CourseID foreign key property and a 
        // Course navigation property
        // The CourseID property is a foreign key, and the corresponding navigation property is Course.
        // An Enrollment entity is associated with one Course entity.
        public int CourseID { get; set; }
        public virtual Course Course { get; set; }

        // The StudentID property is a foreign key, and the corresponding navigation property is Student.
        // An Enrollment entity is associated with one Student entity, so the property can only hold a
        // single Student entity (unlike the Student.Enrollments navigation property
        // An enrollment record is for a single student, so there's a StudentID foreign key property and
        // a Student navigation property
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }
    }
}