using ExampleDesktop.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace ExampleDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var client = new WebClient() { Encoding = Encoding.UTF8 };
            var response = client.DownloadString("http://localhost:59983/api/Users");
            dtgUsers.ItemsSource = JsonConvert.DeserializeObject<List<User>>(response);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var user = (User)dtgUsers.SelectedItem;
            new UserEditWindow(user).ShowDialog();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            var user = new User();
            new UserEditWindow(user).ShowDialog();
        }
    }
}
