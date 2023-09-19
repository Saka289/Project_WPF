using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WPF_Project.Models;

namespace WPF_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Student student;
        public MainWindow()
        {
            student = new Student { Id = 1, Name = "Le Hoai Nam", Gender = "Male" };
            InitializeComponent();
            Binding binding = new Binding();
            binding.Source = student;
            //binding.ElementName = "Name"; hai cái là như nhau
            binding.Path = new PropertyPath("Name");
            binding.Mode = BindingMode.TwoWay;
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            Textbox2.SetBinding(TextBox.TextProperty, binding);
            //cach1
            //Binding cho MyPanel
            //Binding binding1 = new Binding();
            //binding1.Source = student;
            //binding1.Mode = BindingMode.OneWay;
            //myPanel.SetBinding(Panel.DataContextProperty, binding1);

            
            //cach2
            //myPanel.DataContext = student;
            this.DataContext = student; // gắn dữ liệu cho cả windown

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Student:{ student.Id}, {student.Name}, {student.Gender}");
        }
    }
}
