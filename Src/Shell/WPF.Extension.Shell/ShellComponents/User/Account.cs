using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Extension.Shell.ShellCore.User
{
    public class Account
    {
        public string Name { get; set; }

        public string Avatar { get; set; }

        public string NickName { get; set; }

        public string Mail { get; set; }

        public AccountStatus Status { get; set; }

        public string Token { get; set; }
    }

    public enum AccountStatus
    {
        None,
        Online,
        Offline
    }
}
