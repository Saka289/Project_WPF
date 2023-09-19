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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace test123
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Student> students = new List<Student>()
            {
                new Student()
                {
                    Name = "Test",
                    Number = "2123132"
                },
                new Student()
                {
                    Name = "Tes12313t",
                    Number = "1231231231"
                },
            };
            this.listb.ItemsSource = students;  
        }

        public class Student
        {
            public string Name { get; set; }

            public string Number { get; set; }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
