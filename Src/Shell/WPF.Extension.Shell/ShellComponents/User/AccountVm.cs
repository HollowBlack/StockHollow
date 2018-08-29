using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Extension.Library.Presentation;

namespace WPF.Extension.Shell.ShellCore.User
{
    public class AccountVm: NotifyPropertyChanged
    {
        public AccountVm()
        {

        }

        public void Login(string account, string password)
        {

        }

        private bool running;
        public bool Running
        {
            get { return running; }
            set
            {
                if (running != value)
                {
                    running = value;
                    OnPropertyChanged(nameof(Running));
                }
            }
        }

        private AccountStatus status;
        public AccountStatus Status
        {
            get { return status; }
            set
            {
                if (status != value)
                {
                    status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        public void Dispose()
        {

        }
    }
}
