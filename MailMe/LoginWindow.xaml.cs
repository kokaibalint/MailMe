using MailKit.Net.Imap;
using MailMe.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MailMe
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        ImapClient client = new ImapClient();
        ImapService service = new ImapService();
        User user;


        public LoginWindow()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if (client.IsConnected)
            {
                client.Disconnect(true);
            }

            service.Connect(client);
            user = new User(EmailBox.Text, PasswordBox.Text);

            if (service.Login(user, client))
            {
                MailMeHome mailMeHome = new MailMeHome(user);
                mailMeHome.Show();
                this.Close();

            }
        }
    }
}
