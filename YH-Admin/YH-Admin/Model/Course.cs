using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YH_Admin.Model
{
    public class Course
    {
        public int CourseId { get; set; }

        public string Name { get; set; }


        public Course(int courseId, string courseName)
        {
            CourseId = courseId;
            Name = courseName;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Course c = obj as Course;
            if ((System.Object)c == null)
                return false;

            // Return true if the fields match:
            return (CourseId == c.CourseId) && (Name == c.Name);
        }

        public override int GetHashCode()
        {
            return CourseId ^ Name.GetHashCode();
        }

        /// <summary>
        /// Default string output.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"CourseId: {CourseId}, Name: {Name}";
        }

        


    }
}
