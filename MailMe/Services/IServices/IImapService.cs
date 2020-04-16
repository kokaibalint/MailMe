using MailKit.Net.Imap;
using MailMe.Models;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailMe.Services.IServices
{
    public interface IImapService
    {
        void Connect(ImapClient client);

        bool Login(User user, ImapClient client);

    }
}
