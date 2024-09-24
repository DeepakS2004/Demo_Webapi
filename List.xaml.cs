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

namespace Demo_Webapi
{
    /// <summary>
    /// Interaction logic for List.xaml
    /// </summary>
    public partial class List : Window
    {
        public   List()
        {
            InitializeComponent();
           
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Student> students = await Helper.Getdata();
            cmblist.ItemsSource = students;
            cmblist.DisplayMemberPath = "Student_Name";
            cmblist.SelectedValuePath = "Id";
        }

        private async void cmblist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Student student = cmblist.SelectedItem as Student;
            txtname.Text = student.Student_Name;
            int rollnumber = Convert.ToInt32(student.RollNumber);
            txtroll.Text = rollnumber.ToString();
            txtdep.Text = student.Department;
            txtemail.Text =student.Student_Email;
            txtphn.Text = student.Student_Phone;
            txtloc.Text = student.Student_Address;         
        }

        private void btnedit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
