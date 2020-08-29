using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace StudentXmlApplication
{
    class StudentParserNew
    {
        XmlDocument docLoad = new XmlDocument();

        StudentData res;
        public void ReadXmlDetails(string xmlFileName)
        {
            StudentData studentData = new StudentData();
            docLoad.Load(xmlFileName);
            XmlNodeList node = docLoad.SelectNodes("//StudentData/StudentInfo");
             res = GetListOfSudentInfo(node);   
        }
        public StudentData GetStudentObject()
        {
            return res;
        }
        private StudentData GetListOfSudentInfo(XmlNodeList node)
        {
            StudentData studentData = new StudentData();
            foreach (XmlNode studInfo in node)
            {
                string name = studInfo.SelectSingleNode("StudentName").InnerText;
                StudentInfo refstudInfo = new StudentInfo(name);
                XmlNode subjects = studInfo.SelectSingleNode("Subjects");
                var res = GetAllMarksOfSubjects(subjects);
                refstudInfo.Add(res);
                studentData.Add(refstudInfo);
            }
            return studentData;
        }
        private Subjects GetAllMarksOfSubjects(XmlNode subjects)
        {
            int physicsMarks = int.Parse(subjects.SelectSingleNode("Physics").InnerText);
            int chemistryMarks = int.Parse(subjects.SelectSingleNode("Chemistry").InnerText);
            int mathMarks = int.Parse(subjects.SelectSingleNode("Math").InnerText);
            int biologyMarks = int.Parse(subjects.SelectSingleNode("Biology").InnerText);
            int totalMarks = physicsMarks + chemistryMarks + mathMarks + biologyMarks;
            bool isPassed = true;
            if(physicsMarks<40|| chemistryMarks<40|| mathMarks<40|| biologyMarks<40)
            {
                isPassed = false;
            }
            Subjects marks = new Subjects(totalMarks, isPassed);
            return marks;
        }
    }
}
