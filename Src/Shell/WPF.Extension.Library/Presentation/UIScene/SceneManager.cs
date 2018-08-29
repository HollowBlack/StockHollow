using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using WPF.Extension.Library.Animation.Effect;

namespace WPF.Extension.Library.Presentation
{
    public class SceneManager
    {
        public SceneManager(Panel container)
        {
            Container = container;
            Scenes = new List<Scene>();
        }

        public Panel Container { get; private set; }
        public List<Scene> Scenes { get; private set; }
        public Scene Currrent { get; private set; }

        private bool isLoading;
        public bool IsLoading
        {
            get { return isLoading; }
            private set
            {
                isLoading = value;
                if (Container != null)
                    Container.IsEnabled = false;
            }
        }

        public async Task Back()
        {
            if (Currrent == null)
                return;

            if (Currrent.PrevScene == null)
                return;

            await LoadScene(Currrent.PrevScene);
        }

        public async Task Forward()
        {
            if (Currrent == null)
                return;

            var post = Scenes.FirstOrDefault(i => i.PrevScene == Currrent);
            if (post != null)
                await LoadScene(post);
        }

        public bool CanForward()
        {
            if (Currrent == null)
                return false;

            if (Currrent.PrevScene == null)
                return false;

            return Scenes.Any(i => i.PrevScene == Currrent);
        }

        public async Task LoadScene(Uri uri)
        {
            if (uri == null)
                return;

            var scene = Scenes.FirstOrDefault(i => i.Uri.Equals(uri));
            if (Currrent != null && scene == Currrent)
                return;

            if (scene == null)
                scene = await Scene.CreateSceneAsync(uri, this, Currrent);

            if (scene != null)
                await LoadScene(scene);
        }

        protected async Task LoadScene(Scene scene)
        {
            if (scene == null)
                return;

            if (!Scenes.Contains(scene))
            {
                Scenes.Add(scene);
                scene.PrevScene = Currrent;
            }

            IsLoading = true;

            // await UnloadUIComponent();
            // Currrent = scene;
            // await LoadUIComponent(scene.Content as UIElement);

            await SwitchComponentInSlide(scene.Content as UIElement);
            Currrent = scene;

            IsLoading = false;
        }

        protected async Task LoadUIComponent(UIElement ue)
        {
            if (ue == null)
                return;

            ue.Opacity = 0;
            if (!Container.Children.Contains(ue))
            {
                Container.Children.Add(ue);
            }
            var ef = new EfFade();
            await ef.FadeIn(ue, 700);
        }

        protected async Task UnloadUIComponent()
        {
            if (Currrent == null)
                return;

            var ue = Currrent.Content as UIElement;
            if (ue == null)
                return;

            var ef = new EfFade();
            await ef.FadeOut(ue, 500);
        }

        protected async Task SwitchComponentInFade(UIElement ue)
        {
            var sb = new Storyboard();

            // Fade out
            if (Currrent != null)
            {
                var cur = Currrent.Content as UIElement;
                RemoveUIElement(cur);
                var fadeOut = new DoubleAnimation
                {
                    From = 1,
                    To = 0,
                    Duration = TimeSpan.FromMilliseconds(500)
                };
                fadeOut.Completed += (o, e) => cur.Visibility = Visibility.Collapsed;
                Storyboard.SetTarget(fadeOut, cur);
                Storyboard.SetTargetProperty(fadeOut, new PropertyPath("Opacity"));
                sb.Children.Add(fadeOut);
            }

            // Fade in
            if (ue != null)
            {
                ue.Opacity = 0;
                AddUIElement(ue);
                ue.Visibility = Visibility.Visible;
                var fadeIn = new DoubleAnimation
                {
                    From = 0,
                    To = 1,
                    Duration = TimeSpan.FromMilliseconds(700)
                };
                Storyboard.SetTarget(fadeIn, ue);
                Storyboard.SetTargetProperty(fadeIn, new PropertyPath("Opacity"));
                sb.Children.Add(fadeIn);
            }
            Container.Dispatcher.Invoke(() => sb.Begin());
            await Task.Delay(700);
        }

        protected async Task SwitchComponentInSlide(UIElement ue)
        {
            var sb = new Storyboard();

            // slide out
            if (Currrent != null)
            {
                var cur = Currrent.Content as UIElement;
                RemoveUIElement(cur);
            }

            if (ue != null)
            {
                // Fade in
                ue.Opacity = 0;
                AddUIElement(ue);
                ue.Visibility = Visibility.Visible;
                var fadeIn = new DoubleAnimation
                {
                    From = 0,
                    To = 1,
                    Duration = TimeSpan.FromMilliseconds(200)
                };
                Storyboard.SetTarget(fadeIn, ue);
                Storyboard.SetTargetProperty(fadeIn, new PropertyPath("Opacity"));
                sb.Children.Add(fadeIn);

                // slide in
                var slidein = new DoubleAnimation
                {
                    From = -20,
                    To = 1,
                    Duration = TimeSpan.FromMilliseconds(200)
                };
                Storyboard.SetTarget(slidein, ue);
                Storyboard.SetTargetProperty(slidein, new PropertyPath("(Canvas.Left)"));
                sb.Children.Add(slidein);
            }
            Container.Dispatcher.Invoke(() => sb.Begin());
            await Task.Delay(200);
        }

        protected void AddUIElement(UIElement ue)
        {
            if (ue != null && Container != null)
            {
                if (!Container.Children.Contains(ue))
                {
                    Container.Children.Add(ue);
                }
            }
        }

        protected void RemoveUIElement(UIElement ue)
        {
            if (ue == null)
                return;

            ue.Visibility = Visibility.Collapsed;

            if (Container != null && Container.Children.Contains(ue))
            {
                Container.Children.Remove(ue);
            }
        }
    }
}
