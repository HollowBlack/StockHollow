using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace WPF.Extension.Library.Animation.Effect
{
    public class EfWipe : EfBase
    {
        public async Task WideUp(UIElement ue, int millSeconds)
        {
            await RunEffect(ue, millSeconds, () =>
            {
                var brush = new LinearGradientBrush
                {
                    StartPoint = new Point(0, 0),
                    EndPoint = new Point(0, 1)
                };
                brush.GradientStops.Add(new GradientStop(Colors.Black, 0));
                brush.GradientStops.Add(new GradientStop(Colors.Black, 0.9));
                brush.GradientStops.Add(new GradientStop(Colors.Transparent, 1));
                brush.GradientStops.Add(new GradientStop(Colors.Transparent, 1));
                ue.OpacityMask = brush;

                var stop1 = brush.GradientStops[1];
                var offsetAnimation1 = new DoubleAnimation
                {
                    From = 0.9,
                    To = 0,
                    Duration = TimeSpan.FromMilliseconds(millSeconds - 200)
                };
                stop1.BeginAnimation(GradientStop.OffsetProperty, offsetAnimation1);
                var stop2 = brush.GradientStops[2];
                var offsetAnimation2 = new DoubleAnimation
                {
                    From = 1,
                    To = 0,
                    Duration = TimeSpan.FromMilliseconds(millSeconds)
                };
                stop2.BeginAnimation(GradientStop.OffsetProperty, offsetAnimation2);
            });
        }
    }
}
