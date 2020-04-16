using MailKit.Net.Imap;
using MailKit.Search;
using MailMe.Models;
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

namespace MailMe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MailMeHome : Window
    {
        ImapClient client = new ImapClient();
        ImapService service = new ImapService();
        public User user { get; set; }

        public MailMeHome()
        {
            InitializeComponent();
            OpenFolders(client);
        }
        public MailMeHome(User user)
        {
            InitializeComponent();
            this.user = user;
            OpenFolders(client);

        }
        public void OpenFolders(ImapClient client)
        {
            service.Connect(client);

            service.Login(user, client);
            var folder = client.Inbox;
            folder.Open(MailKit.FolderAccess.ReadOnly);

            for(int i = 0; i < folder.Count; i++)
            {
                var message = folder.GetMessage(i);
                EmailListBox.Items.Add(message.From + "     " + message.Subject + "     " + message.Date.Hour + ":" + message.Date.Minute);
            }
        }
    }
}
