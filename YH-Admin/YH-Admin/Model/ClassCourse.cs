using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YH_Admin.Model
{
    public class ClassCourse
    {
        public int ClassCourseId { get; set; }

        public int ClassId { get; set; }

        public int CourseId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string StartDateString { get { return StartDate.ToString("yyyyMMdd"); } }

        public string EndDateString { get { return EndDate.ToString("yyyyMMdd"); } }

        public bool IsFinished { get { return EndDate < DateTime.Today; } }

        public string Status { get { return IsFinished ? "Avslutad" : "Aktiv"; } }

        public int StaffingId { get; set; }

        public bool HasTeacher { get { return StaffingId >= 0; } }

       
        /// <summary>
        /// Skapa en ClassCourse som inte ha en lärare bemannad.
        /// </summary>
        /// <param name="classCourseId"></param>
        /// <param name="classId"></param>
        /// <param name="courseId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public ClassCourse(int classCourseId, int classId, int courseId, DateTime startDate, DateTime endDate) : this (classCourseId, classId, courseId, startDate,
            endDate, -1)
        { }

        /// <summary>
        /// Skapa en ClassCourse med bemanning.
        /// </summary>
        /// <param name="classCourseId"></param>
        /// <param name="classId"></param>
        /// <param name="courseId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="staffingId">Lärarens id</param>
        public ClassCourse(int classCourseId, int classId, int courseId, DateTime startDate, DateTime endDate, int staffingId)
        {
            ClassCourseId = classCourseId;
            ClassId = classId;
            CourseId = courseId;
            StartDate = startDate;
            EndDate = endDate;
            StaffingId = staffingId;
        }

        /// <summary>
        /// Get the start date of this course as a string.
        /// </summary>
        /// <returns></returns>
        public string GetStartDate()
        {
            return StartDate.ToString("yyyyMMdd");
        }

        /// <summary>
        /// Get the end date of this course as a string.
        /// </summary>
        /// <returns></returns>
        public string GetEndDate()
        {
            return EndDate.ToString("yyyyMMdd");
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            ClassCourse cc = obj as ClassCourse;
            if ((System.Object)cc == null)
                return false;

            // Return true if the fields match:
            return (ClassCourseId == cc.ClassCourseId) && (ClassId == cc.ClassId) && (CourseId == cc.CourseId);
        }

        public override int GetHashCode()
        {
            return ClassCourseId ^ ClassId ^ CourseId;
        }

        /// <summary>
        /// Default string output.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ClassCourseId + " " + ClassId + " " + CourseId + "; " + GetStartDate() + "->" + GetEndDate();

        }

        public string ShowCourseStatus()
        {
            return GetStartDate() + "->" + GetEndDate() + " Status: " + (IsFinished ? "Avslutat" : "Pågående");
        }

    }
}
