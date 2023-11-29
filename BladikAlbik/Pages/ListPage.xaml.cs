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
    /// Логика взаимодействия для ListPage.xaml
    /// </summary>
    public partial class ListPage : Page
    {
        public ListPage()
        {
            InitializeComponent();
            BladikList.ItemsSource = Connection.BD.Exemplar.ToList();
            var type =Connection.BD.Types.ToList();
            type.Insert(0, new Types() { ID_type = 0, Name = "Все" });
            TypeCb.ItemsSource = type.ToList();
            TypeCb.DisplayMemberPath = "Name";

            var exem = Connection.BD.Exemplar.ToList();
            exem.Insert(0, new Exemplar() { ID_ex = 0, Name = "Все" });
            NameCb.ItemsSource = exem.ToList();
            NameCb.DisplayMemberPath = "Name";
        }

        private void NameCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var name = NameCb.SelectedItem as Exemplar;
            var type = TypeCb.SelectedItem as Types;
            BladikList.ItemsSource = Connection.BD.Exemplar.Where(i => i.Name == name.Name).ToList();
        }

        private void TypeCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var type = TypeCb.SelectedItem as Types;
            if (type.ID_type == 0)
            {
                BladikList.ItemsSource = new List<Exemplar>(Connection.BD.Exemplar);
                NameCb.ItemsSource = Connection.BD.Exemplar.ToList();
            }

            else
            {
                BladikList.ItemsSource = new List<Exemplar>(Connection.BD.Exemplar.Where(i => i.ID_type == type.ID_type));
                NameCb.ItemsSource = Connection.BD.Exemplar.Where(j => j.ID_type == type.ID_type).ToList();
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            BladikList.ItemsSource = new List<Exemplar>(Connection.BD.Exemplar.Where(i => i.Name.StartsWith(SearchTb.Text)));
        }
    }
}
