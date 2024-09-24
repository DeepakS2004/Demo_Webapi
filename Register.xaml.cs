using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private async void btnreg_Click(object sender, RoutedEventArgs e)
        {
           Student student = new Student(); 
           student.Student_Name=txtname.Text;
           student.RollNumber   =Convert.ToInt32( txtroll.Text);
            student.Department=txtdep.Text;
            student.Student_Email=txtemail.Text;
            student.Student_Phone=txtphn.Text;
            student.Student_Address=txtloc.Text;
            string message = $"{student.Student_Name} Registered Sucessfully to the webSite";
            string title = $"{student.RollNumber} Registeration";
           
            await Sendemail(message, title);
            bool val =await Helper.Postdata(student);
            if (val )
            {
                MessageBox.Show("Success");
               
                
                MainWindow mainWindow = new MainWindow();
                this.Close();
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("failed");
            }

        }
        public async Task Sendemail(string message, string title)
        {
            SmtpClient smtp = new SmtpClient("smtp-mail.outlook.com");
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("jsazure730@outlook.com", "Jsapril730");
            smtp.EnableSsl = true;
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("Jsbuild730@outlook.com");
            mailMessage.Subject = title;
            mailMessage.Body = $"<h1>{message}</h1> ";
            mailMessage.IsBodyHtml = true;
            mailMessage.To.Add("deepakdeepak517109@gmail.com");
            mailMessage.Bcc.Add("deepaksenthil1604@gmail.com");
            try
            {
                await smtp.SendMailAsync(mailMessage);
                MessageBox.Show("Mail send Succesfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
