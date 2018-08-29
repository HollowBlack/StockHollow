using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace WPF.Extension.Library.Animation.Effect
{
    public class EfBase
    {
        public async Task RunEffect(UIElement ue, int millSeconds, Action action)
        {
            if (ue == null)
                return;

            ue.Dispatcher.Invoke(action);

            await Task.Delay(millSeconds);
        }
    }
}
