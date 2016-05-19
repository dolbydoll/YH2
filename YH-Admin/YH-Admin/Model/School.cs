using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YH_Admin.Utils;

namespace YH_Admin.Model
{
    public class School
    {
        public SchoolIO SchoolDatabase { get; set; }

        public List<User> Users { get; set; }

        public List<Education> Educations { get; set; }

        public List<SchoolClass> SchoolClasses { get; private set; }

        public List<Staffing> Staffs { get; private set; }

        public List<Student> Students { get; private set; }

        public List<Course> Courses { get; private set; }

        public List<ClassCourse> ClassCourseTable { get; private set; }

        public List<Grade> Grades { get; private set; }

        public List<StaffingCourse> StaffingCourses { get; private set; }

        public Dictionary<int, string> CourseContentTexts { get; private set; }

        public List<CourseContent> CourseContents { get; private set; }


        public School()
        {
            Users = new List<User>();
            Educations = new List<Education>();
            SchoolClasses = new List<SchoolClass>();
            Students = new List<Student>();
            Courses = new List<Course>();
            ClassCourseTable = new List<ClassCourse>();
            Grades = new List<Grade>();
            Staffs = new List<Staffing>();
            CourseContentTexts = new Dictionary<int, string>();
            CourseContents = new List<CourseContent>();

        }

        /// <summary>
        /// Read all the datafiles in a specific folder.
        /// </summary>
        public void LoadData(string soluPath)
        {
            SchoolDatabase = new SchoolIO(soluPath);

            // Read user file
            Users = SchoolDatabase.ReadUserFile();
            // Read student file
            Educations = SchoolDatabase.ReadEducationFile();
            // Read class file
            Students = SchoolDatabase.ReadStudentFile();
            // Read course file
            SchoolClasses = SchoolDatabase.ReadClassFile();
            // Read class-course file
            Courses = SchoolDatabase.ReadCourseFile();
            // Read education file
            ClassCourseTable = SchoolDatabase.ReadClassCourseFile();
            // Read grade file
            Grades = SchoolDatabase.ReadGradeFile();
            // Read staff file
            Staffs = SchoolDatabase.ReadTeacherFile();
            // Read Course Content Text file
            CourseContentTexts = SchoolDatabase.ReadCourseContentTextFile();
            // Read Course Content file
            CourseContents = SchoolDatabase.ReadCourseContentFile();
        }


        public void SaveToFiles()
        {
            SchoolDatabase.SaveStudentFile(GetStudents());
            SchoolDatabase.SaveGradeFile(Grades);
            SchoolDatabase.SaveTeacherFile(Staffs);
        }

        public Grade GetGrade(Student student, ClassCourse classCourse)
        {
            return Grades.Find(g => g.StudentId == student.StudentId && g.ClassCourseId == classCourse.ClassCourseId);
        }

        public List<Student> GetFailers()
        {
            var failList = Grades.Where(g => g.GradeString == "IG");
            var failedStudent = new List<Student>();

            foreach (var grade in failList)
            {
                var student = Students.Find(s => s.StudentId == grade.StudentId);
                if (student != null && !failedStudent.Contains(student))
                    failedStudent.Add(student);
            }

            return failedStudent;
        }

        public void SetGrade(Student student, ClassCourse classCourse, string gradeString)
        {
            var grade = GetGrade(student, classCourse);
            if (grade != null)
                grade.GradeString = gradeString;
            else
            {
                Grades.Add(new Grade(student.StudentId, classCourse.ClassCourseId, gradeString));
            }
        }

        public List<Education> GetEducations(int userId)
        {
            var educations = Educations.Where(e => e.UserId == userId).ToList();
            return educations;
        }

        public List<Education> GetEducations(User user)
        {
            return GetEducations(user.UserId);
        }

        public List<ClassCourse> GetClassCourses(Student student)
        {
            var schoolClass = SchoolClasses.Find(c => c.SchoolClassId == student.ClassId);
            return GetClassCourses(schoolClass);
        }

        public List<string> GetCourses(int classId)
        {
            var ccs = ClassCourseTable.Where(c => c.ClassId == classId);
            var sorted = ccs.OrderBy(c => c.StartDate);
            var output = new List<string>();
            foreach (var cc in sorted)
            {
                var course = Courses.Find(c => c.CourseId == cc.CourseId);
                output.Add(course.ToString() + " | " + cc.ShowCourseStatus());
            }
            return output;
        }

        public List<string> GetCourses(SchoolClass schoolClass)
        {
            return GetCourses(schoolClass.SchoolClassId);
        }

        public List<ClassCourse> GetClassCourses(SchoolClass schoolClass)
        {
            return ClassCourseTable.Where(c => c.ClassId == schoolClass.SchoolClassId).OrderBy(c => c.StartDate).ToList();
        }

        public int? GetClassId(string className)
        {
            return SchoolClasses.Find(c => c.Name == className)?.SchoolClassId;
        }

        /// <summary>
        /// Get the classes within an education with educationId.
        /// </summary>
        /// <param name="educationId"></param>
        /// <returns></returns>
        public List<SchoolClass> GetClasses(int educationId)
        {
            var classes = SchoolClasses.Where(s => s.EducationId == educationId).ToList();
            return classes;
        }

        public List<SchoolClass> GetClasses(Education education)
        {
            return GetClasses(education.EducationId);
        }

        /// <summary>
        /// Get students from a class with classId.
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public List<Student> GetStudents(int classId)
        {
            var students = GetStudents().Where(s => s.ClassId == classId).ToList();
            return students;
        }

        /// <summary>
        /// Get students from a class with schoolClass.
        /// </summary>
        /// <param name="schoolClass"></param>
        /// <returns></returns>
        public List<Student> GetStudents(SchoolClass schoolClass)
        {
            return GetStudents(schoolClass.SchoolClassId);
        }

        /// <summary>
        /// Return all students in school as a list.
        /// </summary>
        /// <returns></returns>
        public List<Student> GetStudents()
        {
            return Students.OrderBy(s => s.ClassId).ThenBy(s => s.FirstName).ToList();
        }

        /// <summary>
        /// Add student to list without checking the studentId.
        /// If student is instantiated correctly, there is no need to check .
        /// </summary>
        /// <param name="student"></param>
        public void AddStudents(Student student)
        {
            Students.Add(student);
        }

        /// <summary>
        /// Get ClassCourses that does not have a teacher appointed.
        /// </summary>
        /// <returns></returns>
        public List<ClassCourse> GetCoursesWithoutTeacher()
        {
            List<ClassCourse> noTeacherCourses = new List<ClassCourse>();
            foreach (var cc in ClassCourseTable)
            {
                if (cc.HasTeacher)
                    noTeacherCourses.Add(cc);
            }
            return noTeacherCourses;
        }


        public List<Grade> GetGradesFromCourseId(int classCourseId)
        {
            List<Grade> GradesFromCourse = new List<Grade>();
            foreach (var c in Grades)
            {
                if (c.ClassCourseId == classCourseId)
                    GradesFromCourse.Add(c);
            }
            return GradesFromCourse;
        }

        public string GetStudentName(int studentId)
        {
            var student = Students.SingleOrDefault(s => s.StudentId == studentId);
            //var students =  Students.Find(s => s.StudentId == studentId);
            if (student != null)
                return student.Name;
            return "No matching studentId:" + studentId;
        }

        public List<CourseContent> GetCourseContent(int classCourseId)
        {
            return CourseContents.Where(cc => cc.ClassCourseId == classCourseId).ToList();
        }

        /// <summary>
        /// Return the string from CourseContentTexts with a certain textId.
        /// Return null if the textId is not found.
        /// </summary>
        /// <param name="textId"></param>
        /// <returns></returns>
        public string GetText(int textId)
        {
            string str;
            if (CourseContentTexts.TryGetValue(textId, out str))
            {
                return str;
            }
            else
            {
                return null;
            }
        }
    }
}
