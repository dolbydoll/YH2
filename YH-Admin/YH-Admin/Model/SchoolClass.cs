using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YH_Admin.Model
{
    public class SchoolClass
    {
        /// <summary>
        /// Identifier to this school class.
        /// </summary>
        public int SchoolClassId { get; set; }

        /// <summary>
        /// Name to this school class.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The education id that this class belongs to.
        /// </summary>
        public int EducationId { get; set; }

        /// <summary>
        /// The starting date of this school class.
        /// </summary>
        private DateTime StartDate { get; set; }

        /// <summary>
        /// The ending date of this school class.
        /// </summary>
        private DateTime EndDate { get; set; }

        public string StartDateString { get { return StartDate.ToString("yyyyMMdd"); } }

        public string EndDateString { get { return EndDate.ToString("yyyyMMdd"); } }

        public string Status { get { return (EndDate < DateTime.Today) ? $"Avslutat {EndDateString}" : "Aktiv"; } }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="name"></param>
        /// <param name="educationId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public SchoolClass(int classId, string name, int educationId, DateTime startDate, DateTime endDate)
        {
            SchoolClassId = classId;
            Name = name;
            EducationId = educationId;
            StartDate = startDate;
            EndDate = endDate;
        }

        ///// <summary>
        ///// Get the start date of this school class as a string.
        ///// </summary>
        ///// <returns></returns>
        //string GetStartDate()
        //{
        //    return StartDate.ToString("yyyyMMdd");
        //}

        ///// <summary>
        ///// Get the end date of this school class as a string.
        ///// </summary>
        ///// <returns></returns>
        //string GetEndDate()
        //{
        //    return EndDate.ToString("yyyyMMdd");
        //}

        /// <summary>
        /// Default string output.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return SchoolClassId + ": " + Name + ", eduId: " + EducationId + "; " + StartDateString + "->" + EndDateString;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            SchoolClass sc = obj as SchoolClass;
            if ((System.Object)sc == null)
                return false;

            // Return true if the fields match:
            return (SchoolClassId == sc.SchoolClassId) && (StartDate == sc.StartDate) && (EndDate == sc.EndDate);
        }

        public override int GetHashCode()
        {
            return SchoolClassId ^ StartDate.GetHashCode() ^ EndDate.GetHashCode();
        }

        /// <summary>
        /// Get of name, start date and whether the class has ended or not.
        /// </summary>
        /// <returns></returns>
        //public string ShowClassStatus()
        //{
        //    string str = "Class: " + Name + "; Startdate: " + GetStartDate();
        //    if (EndDate < DateTime.Today)
        //        return str + ", Status: ended on " + GetEndDate();
        //    else
        //        return str + ", Status: active.";
        //}
    }
}
