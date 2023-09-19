using Lab1.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Lab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Student studen1 = new Student
            {
                Id = 1,
                Name = "Nam",
                Gender = "Male",
                Email = "nam@gmail.com"
            };
            Student studen2 = new Student
            {
                Id = 2,
                Name = "Linh",
                Gender = "Male",
                Email = "linh@gmail.com"
            };
            Student studen3 = new Student
            {
                Id = 3,
                Name = "Khánh Ngu",
                Gender = "Male",
                Email = "khanhngu@gmail.com"
            };
            listBox.Items.Add(studen1);
            listBox.Items.Add(studen2);
            listBox.Items.Add(studen3);
        }


        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            if (checkValidate() == true && checkIdExists())
            {
                Student listStudent = new Student();
                listStudent.Id = Int32.Parse(textbox1.Text);
                listStudent.Name = textbox2.Text;
                if (gender1.IsChecked == true)
                {
                    listStudent.Gender = "Male";
                }
                else
                {
                    listStudent.Gender = "Female";
                }
                listStudent.Email = textbox3.Text;
                listBox.Items.Add(listStudent);
                clearData();
            }
        }

        private bool checkValidate()
        {
            bool check = true;
            if (string.IsNullOrEmpty(textbox1.Text))
            {
                MessageBox.Show("Id is null !!!");
                check = false;
            }
            else
            {
                if (!int.TryParse(textbox1.Text, out int id))
                {
                    MessageBox.Show("Id is not a valid number !!!");
                    check = false;
                }
            }
            if (string.IsNullOrEmpty(textbox2.Text))
            {
                MessageBox.Show("Name is null !!!");
                check = false;
            }
            if (string.IsNullOrEmpty(textbox3.Text))
            {
                MessageBox.Show("Email is null !!!");
                check = false;
            }
            return check;
        }

        private bool checkIdExists()
        {
            if (listBox.Items.Count > 0)
            {
                foreach (var item in this.listBox.Items)
                {
                    string[] s = Convert.ToString(item).Trim().Split("-");
                    string text = Convert.ToString(textbox1.Text).Trim();
                    if (text.Equals(s[0].Trim().ToString()))
                    {
                        MessageBox.Show("Id is exists !!!");
                        clearData();
                        return false;
                    }
                }
            }
            return true;
        }

        private void clearData()
        {
            textbox1.Text = string.Empty;
            textbox2.Text = string.Empty;
            textbox3.Text = string.Empty;
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                Student selectedStudent = listBox.SelectedItem as Student;

                selectedStudent.Id = Int32.Parse(textbox1.Text);
                selectedStudent.Name = textbox2.Text;
                selectedStudent.Email = textbox3.Text;
                selectedStudent.Gender = (gender1.IsChecked == true) ? "Male" : "Female";

                listBox.Items.Refresh();
                clearData();
            }
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] items = listBox.SelectedItem.ToString().Trim().Split('-');
            textbox1.Text = items[0];
            textbox2.Text = items[1];
            string gender = Convert.ToString(items[2]).Trim();
            if (gender.ToLower().Equals("male") == true)
            {
                gender1.IsChecked = true;
            }
            else
            {
                gender2.IsChecked = true;
            }
            textbox3.Text = items[3];
        }
    }
}
