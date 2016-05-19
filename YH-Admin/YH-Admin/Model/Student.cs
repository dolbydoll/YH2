using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YH_Admin.Model
{
    public class Student
    {
        public static int NextStudentId { get; set; }

        /// <summary>
        /// Identifier to this student.
        /// </summary>  
        public int StudentId { get; set; }

        /// <summary>
        /// First name of this student.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of this student.
        /// </summary>
        public String LastName { get; set; }

        public String Name { get { return $"{FirstName} {LastName}"; } }

        /// <summary>
        /// The class id that this student belongs to.
        /// </summary>
        public int ClassId { get; set; }

        public Student(string firstName, string lastName, int classId) : this(NextStudentId, firstName, lastName, classId)
        {
        }

        public Student(int studentId, string firstName, string lastName, int classId)
        {
            if (studentId >= NextStudentId)
                NextStudentId = studentId + 1;
            StudentId = studentId;
            FirstName = firstName;
            LastName = lastName;
            ClassId = classId;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Student sc = obj as Student;
            if ((System.Object)sc == null)
                return false;

            // Return true if the fields match:
            return (StudentId == sc.StudentId) && (Name == sc.Name) && (ClassId == sc.ClassId);
        }

        public override int GetHashCode()
        {
            return StudentId ^ Name.GetHashCode() ^ ClassId;
        }

        /// <summary>
        /// Default string output.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{StudentId} {FirstName} {LastName} {ClassId}";
        }

    }
}
