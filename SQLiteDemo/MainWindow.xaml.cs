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

namespace SQLiteDemo
{

    public partial class MainWindow : Window
    {
        People myPeople = new People();
        public MainWindow()
        {
            InitializeComponent();

            listView1.ItemsSource = myPeople;
            txtNumberofPeople.Text = myPeople.NumberOfPeople.ToString();

            LoadDatabase();

        }
        public void btn_Add(object sender, RoutedEventArgs e)
        {
            string first = txtFirstName.Text;
            string last = txtLastName.Text;
            if (first == null || first == "") return;
            if (last == null || last == "") return;

            Person p = myPeople.AddRandomPerson();
            using (var db = new DBModel())
            {
                db.Add(p);
                db.SaveChanges();
            }

            txtNumberofPeople.Text = myPeople.NumberOfPeople.ToString();
        }
        public void btn_Remove(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new DBModel())
                {

                    List<Person> temp = new List<Person>();
                    foreach (Person p in listView1.SelectedItems)
                    {
                        temp.Add(p);
                    }

                    foreach (Person p in temp)
                    {
                        myPeople.RemovePerson(p);
                        db.Remove(p);
                    }
                    db.SaveChanges();
                    txtNumberofPeople.Text = myPeople.NumberOfPeople.ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void btn_AddRandom(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtRandomPeople.Text, out int number))
            {
                List<Person> pl = myPeople.AddRandomPeople(number);
                using (var db = new DBModel())
                {
                    foreach (Person p in pl)
                    {
                        db.Add(p);
                    }
                    db.SaveChanges();
                }
            }
            txtNumberofPeople.Text = myPeople.NumberOfPeople.ToString();

        }
        private void listView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtNumberSelected.Text = listView1.SelectedItems.Count.ToString();
        }

        private void LoadDatabase()
        {
            try
            {
                using (var db = new DBModel())
                {
                    foreach (Person p in db.People)
                    {
                        myPeople.Add(p);
                    }
                }
                txtNumberofPeople.Text = myPeople.NumberOfPeople.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
