using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YH_Admin.Model
{
    public class CourseContent
    {
        private static int NextCourseContentId { get; set; }

        public int CourseContentId { get; set; }

        public int ObjectivesId { get; set; }

        public int GCriteriaId { get; set; }

        public int VGCriteriaId { get; set; }

        public int Point { get; set; }

        public int ClassCourseId { get; set; }

        public CourseContent(int objectivesId, int gcriteriaId, int vGcriteriaId, int point, int classcourseId) : this(NextCourseContentId, objectivesId, gcriteriaId, vGcriteriaId, point, classcourseId)
        {
        }

        public CourseContent(int courseContentId, int objectivesId, int gcriteriaId, int vGcriteriaId, int point, int classcourseId)
        {
            if (courseContentId >= NextCourseContentId)
                NextCourseContentId = courseContentId + 1;
            CourseContentId = courseContentId;
            ObjectivesId = objectivesId;
            GCriteriaId = gcriteriaId;
            VGCriteriaId = vGcriteriaId;
            Point = point;
            ClassCourseId = classcourseId;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            CourseContent cc = obj as CourseContent;
            if ((System.Object)cc == null)
                return false;

            // Return true if the fields match:
            return (ObjectivesId == cc.ObjectivesId) && (ClassCourseId == cc.ClassCourseId) && (GCriteriaId == cc.GCriteriaId) && (VGCriteriaId == cc.VGCriteriaId);
        }


        public override int GetHashCode()
        {
            return ObjectivesId ^ ClassCourseId ^ GCriteriaId ^ VGCriteriaId;
        }

        public override string ToString()
        {
            return $"{CourseContentId} {ObjectivesId} {GCriteriaId} {VGCriteriaId} {Point} {ClassCourseId}";
        }
    }
}
