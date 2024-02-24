using ExampleDesktop.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Shapes;

namespace ExampleDesktop
{
    /// <summary>
    /// Interaction logic for UserEditWindow.xaml
    /// </summary>
    public partial class UserEditWindow : Window
    {
        public UserEditWindow(User user)
        {
            InitializeComponent();
            var client = new WebClient { Encoding = Encoding.UTF8 };
            DataContext = user;
            cbxRole.ItemsSource = JsonConvert.DeserializeObject<List<Role>>(client.DownloadString("http://localhost:59983/api/Roles"));
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var client = new WebClient() { Encoding = Encoding.UTF8 };
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            var user = (User)DataContext;
            user.Role = null;
            if (user.Id == 0)
                client.UploadString("http://localhost:59983/api/Users", JsonConvert.SerializeObject(user));
            else
                client.UploadString("http://localhost:59983/api/Users", "PUT", JsonConvert.SerializeObject(user));
        }
    }
}
