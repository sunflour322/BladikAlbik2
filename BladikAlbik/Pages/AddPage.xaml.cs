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
using Microsoft.Win32;
using System.IO;
namespace BladikAlbik.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        public AddPage()
        {
            InitializeComponent();
            var typee = Connection.BD.Types.ToList();
            //typee.Insert(0, new BDSHKA.Type_Prod() { ID_type = 0, Name_type = "Все" });
            TypeCb.ItemsSource = typee.ToList();
            TypeCb.DisplayMemberPath = "Name";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Exemplar exem = new Exemplar()
            {
                Name = NameTb.Text.Trim(),
                ID_type = Convert.ToInt32((TypeCb.SelectedItem as Types).ID_type)
            };
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg"
            };
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                exem.Photo = File.ReadAllBytes(openFileDialog.FileName);
                ImgBlad.Source = new BitmapImage(new Uri(openFileDialog.FileName));

                Connection.BD.Exemplar.Add(exem);
                Connection.BD.SaveChanges();
            }
        }

        private void Button_Next(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListPage());
        }
    }
}
