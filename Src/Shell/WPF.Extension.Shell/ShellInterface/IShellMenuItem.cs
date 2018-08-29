using System;
using System.Collections.Generic;

namespace WPF.Extension.Shell.ShellInterface
{
    public interface IShellMenuItem
    {
        string Name { get; set; }

        string Icon { get; set; }

        string HotKeyTip { get; set; }

        IEnumerable<IShellMenuItem> Children { get;}

        WeakReference<Action> ExecuteCommand { get; set; }

        WeakReference<Predicate<object>> CanExecuteCommand { get; set; }
    }
}
