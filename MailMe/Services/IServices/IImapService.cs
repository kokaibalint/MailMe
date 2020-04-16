using MailKit.Net.Imap;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailMe.Services.IServices
{
    public interface IImapService
    {
        void Connect(ImapClient client);

        bool Login(string email, string password, ImapClient client);

    }
}
