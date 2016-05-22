using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH_Admin.Model;

namespace YH_Admin.Utils
{
    public class SchoolIO
    {
        public string DirectoryPath { get; set; }

        public SchoolIO(string path)
        {
            DirectoryPath = path;
        }


        public Dictionary<int, string> ReadCourseContentTextFile()
        {
            var path = Path.Combine(DirectoryPath, @"DataFiles\courseContentTexts.txt");
            var texts = new Dictionary<int, string>();
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    var splits = line.Split(new char[] { ' ' }, 2);
                    texts.Add(int.Parse(splits[0]), splits[1]);

                    //Test code: 
                    //Console.WriteLine($"{int.Parse(splits[0])}; {splits[1]}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in creating CourseContentText: " + ex);
                Console.ReadLine();
            }
            //Test code: 
            //Console.ReadLine();

            return texts;
        }

        public void SaveCourseContentTextFile(Dictionary<int, string> texts)
        { 
            // Need to check!
            var path = Path.Combine(DirectoryPath, @"DataFiles\courseContentTexts.txt");
            var lines = texts.OrderBy(t => t.Key).Select(t => t.Value).ToArray();
            File.WriteAllLines(path, lines);
        }

        public List<Grade> ReadGradeFile()
        {
            var path = Path.Combine(DirectoryPath, @"DataFiles\grades.txt");
            var Grades = new List<Grade>();
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    var splits = line.Split(' ');
                    var u = new Grade(int.Parse(splits[0]), int.Parse(splits[1]), int.Parse(splits[2]), splits[3]);
                    Grades.Add(u);

                    //Test code: 
                    //Console.WriteLine(u);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in creating Grades: " + ex);
                Console.ReadLine();
            }
            return Grades;
        }

        public void SaveGradeFile(List<Grade> grades)
        {
            var path = Path.Combine(DirectoryPath, @"DataFiles\grades.txt");
            var lines = grades.OrderBy(g => g.StudentId).Select(g => g.ToString()).ToArray();
            File.WriteAllLines(path, lines);
        }

        internal void SaveCourseContentTexts(Dictionary<int, string> courseContentTexts)
        {
            var path = Path.Combine(DirectoryPath, @"DataFiles\courseContentTexts.txt");
            var lines = courseContentTexts.OrderBy(p => p.Key).Select(p => p.Key.ToString() + " " + p.Value.ToString()).ToArray();
            File.WriteAllLines(path, lines);
        }

        internal void SaveCourseContents(List<CourseContent> courseContents)
        {
            var path = Path.Combine(DirectoryPath, @"DataFiles\CourseContent.txt");
            var lines = courseContents.OrderBy(cc => cc.CourseContentId).Select(cc => cc.ToString()).ToArray();
            File.WriteAllLines(path, lines);
        }

        internal List<CourseContent> ReadCourseContentFile()
        {
            var path = Path.Combine(DirectoryPath, @"DataFiles\CourseContent.txt");
            var contents = new List<CourseContent>();
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    var splits = line.Split(new char[] { ' ' });
                    var content = new CourseContent(int.Parse(splits[0]), int.Parse(splits[1]), int.Parse(splits[2]), int.Parse(splits[3]), int.Parse(splits[4]), int.Parse(splits[5]));
                    contents.Add(content);

                    //Test code: 
                    //Console.WriteLine(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in creating CourseContent: " + ex);
                Console.ReadLine();
            }
            //Test code: 
            //Console.ReadLine();

            return contents;
        }


        public List<User> ReadUserFile()
        {
            var path = Path.Combine(DirectoryPath, @"DataFiles\users.txt");
            var Users = new List<User>();
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    var splits = line.Split(' ');
                    var u = new User(int.Parse(splits[0]), splits[1], splits[2], splits[3], splits[4]);
                    Users.Add(u);

                    //Test code: 
                    //Console.WriteLine(u);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in creating EducationCourses: " + ex);
                Console.ReadLine();
            }
            return Users;
        }

        public List<Education> ReadEducationFile()
        {
            var path = Path.Combine(DirectoryPath, @"DataFiles\education.txt");
            var educations = new List<Education>();
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    var splits = line.Split(' ');
                    var name = splits[1];
                    for (int i = 2; i < splits.Length - 1; i++)
                    {
                        name += " " + splits[i];
                    }
                    var e = new Education(int.Parse(splits[0]), name, int.Parse(splits.Last()));
                    educations.Add(e);

                    //Test code: 
                    //Console.WriteLine(e);
                    //Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in creating Educations: " + ex);
                Console.ReadLine();
            }
            return educations;
        }

        public void SaveStudentFile(List<Student> students)
        {
            var path = Path.Combine(DirectoryPath, @"DataFiles\students.txt");
            var lines = students.OrderBy(s => s.StudentId).Select(g => g.ToString()).ToArray();
            File.WriteAllLines(path, lines);
        }

        public List<Student> ReadStudentFile()
        {
            var path = Path.Combine(DirectoryPath, @"DataFiles\students.txt");
            var students = new List<Student>();
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    var splits = line.Split(' ');
                    var id = int.Parse(splits[0]);
                    var st = new Student(id, splits[1], splits[2], int.Parse(splits[3]));
                    students.Add(st);

                    //Test code: 
                    //Console.WriteLine(st);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in ReadStudentFile: " + ex);
                Console.ReadLine();
            }
            return students;
        }

        public List<SchoolClass> ReadClassFile()
        {
            var path = Path.Combine(DirectoryPath, @"DataFiles\classes.txt");
            var schoolClasses = new List<SchoolClass>();
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    var splits = line.Split(' ');
                    var startDate = DateTime.ParseExact(splits[3], "yyyyMMdd", null);
                    var endDate = DateTime.ParseExact(splits[4], "yyyyMMdd", null);
                    var cl = new SchoolClass(int.Parse(splits[0]), splits[1], int.Parse(splits[2]), startDate, endDate);
                    schoolClasses.Add(cl);

                    //Test code: 
                    //Console.WriteLine(cl);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in creating SchoolClass: " + ex);
                Console.ReadLine();
            }
            return schoolClasses;
        }

        public List<Course> ReadCourseFile()
        {
            var path = Path.Combine(DirectoryPath, @"DataFiles\courses.txt");
            var courses = new List<Course>();
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    var splits = line.Split(' ');
                    var name = splits[1];
                    for (int i = 2; i < splits.Length; i++)
                    {
                        name += " " + splits[i];
                    }
                    var c = new Course(int.Parse(splits[0]), name);
                    courses.Add(c);

                    //Test code: 
                    //Console.WriteLine(c);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in creating Courses: " + ex);
                Console.ReadLine();

            }
            return courses;
        }

        public List<ClassCourse> ReadClassCourseFile()
        {
            var path = Path.Combine(DirectoryPath, @"DataFiles\class_courses.txt");
            var classCourseTable = new List<ClassCourse>();
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    var splits = line.Split(' ');
                    var startDate = DateTime.ParseExact(splits[3], "yyyyMMdd", null);
                    var endDate = DateTime.ParseExact(splits[4], "yyyyMMdd", null);
                    ClassCourse cc = null;

                    if (splits.Length == 5)
                        cc = new ClassCourse(int.Parse(splits[0]), int.Parse(splits[1]), int.Parse(splits[2]), startDate, endDate);
                    else if (splits.Length == 6)
                        cc = new ClassCourse(int.Parse(splits[0]), int.Parse(splits[1]), int.Parse(splits[2]), startDate, endDate, int.Parse(splits[5]));

                    if (cc != null)
                        classCourseTable.Add(cc);

                    //Test code: 
                    //Console.WriteLine(cc);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in creating Courses: " + ex);
                Console.ReadLine();
            }
            return classCourseTable;
        }

        public List<Staffing> ReadTeacherFile()
        {
            var path = Path.Combine(DirectoryPath, @"DataFiles\teachers.txt");
            var teachers = new List<Staffing>();
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    var splits = line.Split(' ');
                    var st = new Staffing(int.Parse(splits[0]), splits[1], splits[2]);
                    teachers.Add(st);

                    //Test code: 
                    //Console.WriteLine(st);
                }
                //Test code: 
                //Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in creating teachers: " + ex);
                Console.ReadLine();

            }
            return teachers;
        }

        public void SaveTeacherFile(List<Staffing> staffs)
        {
            var path = Path.Combine(DirectoryPath, @"DataFiles\teachers.txt");
            var lines = staffs.OrderBy(s => s.StaffingId).Select(g => g.ToString()).ToArray();
            File.WriteAllLines(path, lines);
        }
    }
}
