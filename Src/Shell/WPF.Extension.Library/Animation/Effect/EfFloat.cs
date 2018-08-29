using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace WPF.Extension.Library.Animation.Effect
{
    public class EfFloat : EfBase
    {
        public async Task FloatOut(UIElement ue, int millSeconds = 400)
        {
            await RunEffect(ue, millSeconds, () =>
            {
                var storyboard = new Storyboard();

                var opacityAnimation = new DoubleAnimation
                {
                    From = 1,
                    To = 0,
                    Duration = TimeSpan.FromMilliseconds(millSeconds)
                };
                Storyboard.SetTarget(opacityAnimation, ue);
                Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath("Opacity"));
                storyboard.Children.Add(opacityAnimation);

                var movementAnimation = new DoubleAnimation
                {
                    By = -20,
                    Duration = TimeSpan.FromMilliseconds(millSeconds)
                };
                Storyboard.SetTarget(movementAnimation, ue);
                Storyboard.SetTargetProperty(movementAnimation, new PropertyPath("(Canvas.Top)"));
                storyboard.Children.Add(movementAnimation);

                storyboard.Begin();
            });

            ue.Visibility = Visibility.Collapsed;
        }
    }
}
