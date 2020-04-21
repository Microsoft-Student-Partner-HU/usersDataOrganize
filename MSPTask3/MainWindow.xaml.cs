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

namespace MSPTask3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connString = "Data Source=DESKTOP-TMO81QG;Initial Catalog=Person;Integrated Security=True;Pooling=False";

        string name;
        int age;
        string email;

        string namese;
        int agese;
        int ID;
        string emailse;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            name = NameLab.Text;
            age = int.Parse(AgeLab.Text);
            email = EmailLab.Text;
            
            /* Call The Add Function */

            Person p1 = new Person();
            p1.AddToDatabase(name, age, email);

            NameLab.Text = "";
            AgeLab.Text = "";
            EmailLab.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            emailse = EmailSe.Text;
            Person p1 = new Person();
            p1.SearchByEmail(emailse);
            NameSe.Text = p1.Name;
            AgeSe.Text = p1.age.ToString();
            IDSe.Text = p1.ID.ToString();
        }
    }
}
