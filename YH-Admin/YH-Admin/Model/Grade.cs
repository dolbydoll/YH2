using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YH_Admin.Model
{
    public class Grade
    {
        private static int NextGradeId { get; set; }

        public int GradeId { get; set; }

        public int StudentId { get; set; }

        public int ClassCourseId { get; set; }

        public string GradeString { get; set; }

        public bool GradeSet { get; set; }

        public Grade (int studentId, int classCourseId, string grade) : this (NextGradeId, studentId, classCourseId, grade)
        { 
}

        public Grade(int gradeId, int studentId, int classCourseId, string grade)
        {
            if (gradeId >= NextGradeId)
                NextGradeId = gradeId + 1;
            GradeId = gradeId;
            StudentId = studentId;
            ClassCourseId = classCourseId;
            GradeString = grade;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Grade gr = obj as Grade;
            if (gr == null)
                return false;

            // Return true if the fields match:
            return (StudentId == gr.StudentId) && (ClassCourseId == gr.ClassCourseId);
        }

        public override int GetHashCode()
        {
            return StudentId ^ ClassCourseId;
        }

        public override string ToString()
        {
            return $"{GradeId} {StudentId} {ClassCourseId} {GradeString}";
        }
    }
}
