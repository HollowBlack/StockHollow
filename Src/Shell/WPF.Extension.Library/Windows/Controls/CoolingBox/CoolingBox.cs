using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF.Extension.Library.Controls
{
    public class CoolingBox: ContentControl
    {
        public CoolingBox()
        {
            DefaultStyleKey = typeof(CoolingBox);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }
    }
}
