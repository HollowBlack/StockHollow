using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace WPF.Extension.Library.Animation.Effect
{
    public class EfFade: EfBase
    {
        public async Task FadeOut(UIElement ue, int millSeconds)
        {
            await RunEffect(ue, millSeconds, () =>
            {
                var opacityAnimation = new DoubleAnimation
                {
                    From = 1,
                    To = 0,
                    Duration = TimeSpan.FromMilliseconds(millSeconds)
                };
                ue.BeginAnimation(UIElement.OpacityProperty, opacityAnimation);
            });
            ue.Visibility = Visibility.Collapsed;
        }

        public async Task FadeIn(UIElement ue, int millSeconds)
        {
            ue.Visibility = Visibility.Visible;
            await RunEffect(ue, millSeconds, () =>
            {
                var opacityAnimation = new DoubleAnimation
                {
                    From = 0,
                    To = 1,
                    Duration = TimeSpan.FromMilliseconds(millSeconds)
                };
                ue.BeginAnimation(UIElement.OpacityProperty, opacityAnimation);
            });
        }
    }
}
