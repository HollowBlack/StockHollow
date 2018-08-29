using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Extension.Shell.ShellComponents
{
    public class SdMenuItemInfo
    {
        public string Icon { get; set; }

        public string Name { get; set; }

        public string HotkeyTip { get; set; }

        public List<SdMenuItemInfo> Children { get; set; }

        public string ExecuteCommand { get; set; }

        public string CanExecuteCommand { get; set; }

        public bool IsSeparator { get; set; }
    }
}
