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
using BladikAlbik.Bdshka;

namespace BladikAlbik.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationService.xaml
    /// </summary>
    public partial class AuthorizationService : Page
    {
        public static List<Users> users { get; set; }
        public AuthorizationService()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = loginTb.Text.Trim();
            string password = passwordTb.Password.Trim();
            users = new List<Users>(Connection.BD.Users.ToList());
            Users currentUser = users.FirstOrDefault(i => i.Login == login && i.Password == password);
            if (currentUser != null)
                NavigationService.Navigate(new AddPage());
            else
                MessageBox.Show("Такого сотрудника нет!!!");
        }

        
    }
}
