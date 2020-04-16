using MailKit.Net.Imap;
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

        public bool Login(string email, string password, ImapClient client)
        {
            try
            {
                client.Authenticate(email, password);
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
