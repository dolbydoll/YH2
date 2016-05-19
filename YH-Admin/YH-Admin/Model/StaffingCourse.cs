using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YH_Admin.Model
{
    public class StaffingCourse
    {
        public int StaffingCourseId { get; set; }

        public int CourseId { get; set; }

        public int StaffingId { get; set; }

        public DateTime StartDate { get; set; }

        //okpublic string None { get; set; }

        public string StartDateString { get { return StartDate.ToString("yyyyMMdd"); } }

        public bool IsNotAssign { get; set; }

        public string Status { get { return IsNotAssign ? "Tillsättas" : "Tillsatt"; } } // Status har du här, du behöver inte ShowStaffingStatus()

        public StaffingCourse(int staffingCourseId, int courseId, int staffingId, DateTime startDate)
        {
            StaffingCourseId = courseId;
            CourseId = courseId;
            StaffingId = staffingId;
            StartDate = startDate;
        }

        public string GetStartDate()
        {
            return StartDate.ToString("yyyyMMdd");
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            StaffingCourse sc = obj as StaffingCourse;
            if ((System.Object) sc == null)
                return false;
            return (StaffingCourseId == sc.StaffingCourseId) && (CourseId == sc.CourseId) && (StaffingId == sc.StaffingId);
        }

        public override int GetHashCode()
        {
            return StaffingCourseId ^ CourseId ^ StaffingId;
        }

        public override string ToString()
        {
            return StaffingCourseId + " " + CourseId + " " + StaffingId + " " + GetStartDate();
        }

        //public string ShowStaffingStatus()
        //{
        //    return GetStartDate() + "->" + IsNotAssign() + "Status: " + 
        //}
    }
}
