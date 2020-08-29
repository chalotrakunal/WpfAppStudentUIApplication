using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using Microsoft.Win32;
using StudentXmlApplication;


namespace WpfAppStudentUI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {   
            InitializeComponent();
            StartApplication();
        }
        public void StartApplication()
        {
            StudentParser studentParser = new StudentParser();
            ReadXmlFilePath(studentParser);
            StoreStudentInfoToList(studentParser);
        }
        private void ReadXmlFilePath(StudentParser studentParser)
        {
            string filePath = "c://student.xml";
            studentParser.ReadXmlDetails(filePath);
        }
        private void StoreStudentInfoToList(StudentParser studentParser)
        {
            List<StudentProperties> listOfStudentInfo = new List<StudentProperties>();
            List<StudentInfo> studentInfo = studentParser.GetStudentObject().GetListOfStudentInfo();
            foreach (StudentInfo student in studentInfo)
            {
                listOfStudentInfo.Add(new StudentProperties() { TotalMarks = student.GetMarks(), StudentName = student.GetStudentName(), Color = student.GetPassed() ? "Green" : "Red" });
            }
            itemControl.ItemsSource = listOfStudentInfo;
        }
        private void Sync_Button(object sender, RoutedEventArgs e)
        {
            StartApplication();
        }
    }
}