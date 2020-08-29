using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StudentXmlApplication
{
   public class StudentParser
    {
        XmlDocument docLoad = new XmlDocument();
        StudentData result;
        public StudentData GetStudentObject()
        {
            return result;
        }
        public void ReadXmlDetails(string xmlFileName)
        {
            StudentData studentData = new StudentData();
            docLoad.Load(xmlFileName);
            XmlNodeList studentInfoNodes = docLoad.SelectNodes("//StudentData/StudentInfo");
            result = GetListOfSudentInfo(studentInfoNodes);
        }
        private StudentData GetListOfSudentInfo(XmlNodeList studInfoNodes)
        {
            StudentData studentData = new StudentData();
            foreach (XmlNode studInfoNode in studInfoNodes)
            {
                string name = studInfoNode.SelectSingleNode("StudentName").InnerText;
                StudentInfo refstudentInfo = new StudentInfo(name);
                XmlNode subjects = studInfoNode.SelectSingleNode("Subjects");
                Subjects res = GetMarksOfAllSubjects(subjects);
                refstudentInfo.Add(res);
                studentData.Add(refstudentInfo);
            }
            return studentData;
        }
        private Subjects GetMarksOfAllSubjects(XmlNode subjects)
        {
            int physicsMarks = int.Parse(subjects.SelectSingleNode("Physics").InnerText);
            int chemistryMarks = int.Parse(subjects.SelectSingleNode("Chemistry").InnerText);
            int mathMarks = int.Parse(subjects.SelectSingleNode("Math").InnerText);
            int biologyMarks = int.Parse(subjects.SelectSingleNode("Biology").InnerText);
            int totalMarks = physicsMarks + chemistryMarks + mathMarks + biologyMarks;
            bool isPassed = true;
            if (physicsMarks < 40 || chemistryMarks < 40 || mathMarks < 40 || biologyMarks < 40)
            {
                isPassed = false;
            }
            Subjects marks = new Subjects(totalMarks, isPassed, physicsMarks, mathMarks, chemistryMarks, biologyMarks);
            return marks;
        }
    }
}
