using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Extension.Shell.ShellComponents
{
    public class SdMenuInfo
    {
        public string Icon { get; set; }

        public string Name { get; set; }

        public List<SdMenuItemInfo> Children { get; set; }
    }
}
