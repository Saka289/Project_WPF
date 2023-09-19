using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_Project.Models;

namespace WPF_Project
{
    /// <summary>
    /// Interaction logic for DemoListBox.xaml
    /// </summary>
    public partial class DemoListBox : Window
    {
        List<Student> students;
        public DemoListBox()
        {
            InitializeComponent();
            students = new List<Student>
            {
                new Student{Id =1 , Name = "A", Gender ="Male"},
                new Student{Id =2, Name = "B", Gender = "Female"},
                new Student{Id =3 , Name = "C", Gender ="Male"},
                new Student{Id =4 , Name = "D", Gender ="Female"}
            };
            lbStudentList.ItemsSource = students;
        }
    }
}
