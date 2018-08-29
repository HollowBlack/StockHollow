using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF.Extension.Library.Presentation;

namespace WPF.Extension.Shell.ShellComponents.ShellCommands
{
    public class CloseCommand: CommandBase
    {
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        protected override void OnExecute(object parameter)
        {
            // TODO
            MessageBox.Show("Do new");
        }
    }
}
