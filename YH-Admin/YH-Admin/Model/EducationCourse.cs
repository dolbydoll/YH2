using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YH_Admin.Model
{
    public class EducationCourse
    {
        public int EducationCourseId { get; set; }

        public int EducationId { get; set;} 

        public int CourseId { get; set; }

        public EducationCourse(int ecId, int eId, int cId)
        {
            EducationCourseId = ecId;
            EducationId = eId;
            CourseId = cId;
        }

        public override string ToString()
        {
            return EducationCourseId + " " + EducationId + " " + CourseId;
        }
    }
}
