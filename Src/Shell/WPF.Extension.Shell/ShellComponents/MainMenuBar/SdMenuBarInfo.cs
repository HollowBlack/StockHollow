using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Extension.Shell.ShellInterface;

namespace WPF.Extension.Shell.ShellComponents
{
    public class SdMenuBarInfo
    {
        public SdMenuBarInfo()
        {
            Menus = new List<SdMenuInfo>();
        }

        public List<SdMenuInfo> Menus { get; private set; }
    }
}
