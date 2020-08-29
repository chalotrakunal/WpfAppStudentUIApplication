using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentXmlApplication
{
    public class Subjects
    {
        private int _totalMarks;
        private bool _isPassed;
        private int _physics;
        private int _math;
        private int _chemistry;
        private int _biology;
        public Subjects( int totalMarks, bool isPassed, int physics, int math, int chemistry, int biology)
        {
            _physics = physics;
            _totalMarks = totalMarks;
            _isPassed = isPassed;
            _chemistry = chemistry;
            _math = math;
            _biology = biology;
        }
        public int GetTotalMarks()
        {
            return _totalMarks;
        }
        public bool IsPassed()
        {
            return _isPassed;
        }
    }
   public class StudentInfo
    {
        private Subjects _referSubjects;
        private string _studentName;
        public StudentInfo(string studentName)
        {
            _studentName = studentName;
        }
        public void Add(Subjects subjects)
        {
            _referSubjects = subjects;
        }
        public string GetStudentName()
        {
            return _studentName;
        }
        public int  GetMarks()
        {     
           return _referSubjects.GetTotalMarks();
        }
        public bool GetPassed()
        {
           return _referSubjects.IsPassed();
        }
    }
   public class StudentData
    {
        private List<StudentInfo> _students;
        public StudentData()
        {
            _students = new List<StudentInfo>();
        }
        public void Add(StudentInfo studentInfo)
        {
            _students.Add(studentInfo);
        }
        public List<StudentInfo> GetListOfStudentInfo()
        {
            return _students;
        }
    }
}
