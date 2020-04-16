using MailKit.Net.Imap;
using MailKit.Search;
using MailMe.Models;
using MailMe.Services.IServices;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Text;
using System.Windows;

namespace MailMe
{
    class ImapService : IImapService
    {
        private bool logged = false;
        User user;
        public void Connect(ImapClient client)
        {
            try
            {
                client.Connect("imap.gmail.com", 993, true);
            }
            catch (MailKit.ProtocolException e)
            {
                throw e;
            }
        }

        public bool Login(User user, ImapClient client)
        {
            try
            {
                client.Authenticate(user.email, user.password);
                if (client.IsAuthenticated)
                {
                    logged = true;
                }
            }
            catch (MailKit.Security.AuthenticationException e)
            {
                MessageBox.Show("Credentials are not in the Gmail database");
            }
            return logged;
        }

    }
}
