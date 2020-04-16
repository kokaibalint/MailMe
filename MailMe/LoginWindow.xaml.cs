using MailKit.Net.Imap;
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

        public LoginWindow()
        {
            InitializeComponent();
        }

        public String GetEmail(TextBox text)
        {
            string email = text.Text;
            return email;
        }
        public String GetPassword(TextBox text)
        {
            string password = text.Text;
            return password;
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {

            if (client.IsConnected)
            {
                client.Disconnect(true);
            }

            service.Connect(client);
            if(service.Login(GetEmail(EmailBox), GetPassword(PasswordBox), client))
            {
                MailMeHome mailMeHome = new MailMeHome();
                this.Content = mailMeHome;
            }
        }
    }
}
