using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Demo_Webapi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnreg_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            this.Close();
            register.Show();
        }

        private async void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            List<Student> student = await Helper.Getdata();
            
                var login = student.Where(x => x.Student_Name == txtusername.Text & x.RollNumber == Convert.ToInt32(txtroll.Password)).FirstOrDefault();
            if (login != null)
            {
                MessageBox.Show("Login Successfull");
                List list = new List();
                this.Close();
                list.Show();
            }
            else
            {
                MessageBox.Show("Invalid User");
            }
           
        }

        
    }
}