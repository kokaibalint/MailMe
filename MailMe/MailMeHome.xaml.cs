using MailKit;
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
        private ImapClient client = new ImapClient();
        private ImapService service = new ImapService();
        private List<string> email = new List<string>();
        private int emailIndex;
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



        //Csinálj egy Interface-t az összes open folderses megjelenítésre(Elsődleges, elküldött, etc.)
        public void OpenFolders(ImapClient client)
        {
            service.Connect(client);

            service.Login(user, client);
            var folder = client.Inbox;
            folder.Open(FolderAccess.ReadOnly);


            foreach (var uid in folder.Search(SearchQuery.GMailRawSearch("Category:Primary")))
            {
                var message = folder.GetMessage(uid);

                EmailListView.Items.Add(message.From + "     " + message.Subject + "     " + message.Date.Hour + ":" + message.Date.Minute);

                email.Add(message.TextBody);
            }
        }

        private void PrimaryButton_Click(object sender, RoutedEventArgs e)
        {

            var folder = client.Inbox;
            folder.Open(FolderAccess.ReadOnly);

            EmailListView.Items.Clear();

            foreach (var uid in folder.Search(SearchQuery.GMailRawSearch("Category:Primary")))
            {
                var message = folder.GetMessage(uid);
                EmailListView.Items.Add(message.From + "     " + message.Subject + "     " + message.Date.Hour + ":" + message.Date.Minute);
            }
        }

        private void SocialButton_Click(object sender, RoutedEventArgs e)
        {


            var folder = client.Inbox;
            folder.Open(FolderAccess.ReadOnly);

            EmailListView.Items.Clear();


            foreach (var uid in folder.Search(SearchQuery.GMailRawSearch("Category:Social")))
            {
                var message = folder.GetMessage(uid);
                EmailListView.Items.Add(message.From + "     " + message.Subject + "     " + message.Date.Hour + ":" + message.Date.Minute);
            }
        }

        private void PromotionsButton_Click(object sender, RoutedEventArgs e)
        {

            var folder = client.Inbox;
            folder.Open(FolderAccess.ReadOnly);

            EmailListView.Items.Clear();

            foreach (var uid in folder.Search(SearchQuery.GMailRawSearch("Category:Promotions")))
            {
                var message = folder.GetMessage(uid);
                EmailListView.Items.Add(message.From + "     " + message.Subject + "     " + message.Date.Hour + ":" + message.Date.Minute);
            }

        }

        private void SentButton_Click(object sender, RoutedEventArgs e)
        {

            var folder = client.Inbox;
            folder.Open(FolderAccess.ReadOnly);

            EmailListView.Items.Clear();

            foreach (var uid in folder.Search(SearchQuery.GMailRawSearch("Category:Sent")))
            {
                var message = folder.GetMessage(uid);
                EmailListView.Items.Add(message.From + "     " + message.Subject + "     " + message.Date.Hour + ":" + message.Date.Minute);
            }
        }

        private void SpamButton_Click(object sender, RoutedEventArgs e)
        {

            var folder = client.Inbox;
            folder.Open(FolderAccess.ReadOnly);

            EmailListView.Items.Clear();

            foreach (var uid in folder.Search(SearchQuery.GMailRawSearch("Category:Spam")))
            {
                var message = folder.GetMessage(uid);
                EmailListView.Items.Add(message.From + "     " + message.Subject + "     " + message.Date.Hour + ":" + message.Date.Minute);
            }
        }

        private void EmailListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedIndex = EmailListView.SelectedIndex;


            EmailListView.Items.Clear();


            EmailListView.Items.Add(email[selectedIndex]);
        }

    }
}
