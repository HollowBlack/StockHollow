using WPF.Extension.Library.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Extension.Library.Controls;

namespace WPF.Extension.Library.Navigation
{
    /// <summary>
    /// Defines the base navigation event arguments.
    /// </summary>
    public abstract class NavigationBaseEventArgs
        : EventArgs
    {
        /// <summary>
        /// Gets the frame that raised this event.
        /// </summary>
        public ModernFrame Frame { get; internal set; }
        /// <summary>
        /// Gets the source uri for the target being navigated to.
        /// </summary>
        public Uri Source { get; internal set; }
    }
}
