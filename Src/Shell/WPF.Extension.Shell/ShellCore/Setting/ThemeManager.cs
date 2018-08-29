using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using WPF.Extension.Library.Controls;
using WPF.Extension.Library.Presentation;

namespace WPF.Extension.Shell.ShellCore
{
    public enum ThemeType
    {
        Light,
        Dark,
        Glasses,
    }

    public static class ThemeManager
    {
        private static ThemeType currentTheme;

        public static void SetTheme(ThemeType type)
        {
            Uri uri = null;
            currentTheme = type;
            switch (type)
            {
                case ThemeType.Dark:
                    uri = new Uri("/WPF.Extension.Library;component/Assets/UI.Dark.xaml", UriKind.Relative);
                    break;
                case ThemeType.Light:
                    uri = new Uri("/WPF.Extension.Library;component/Assets/UI.Light.xaml", UriKind.Relative);
                    break;
                case ThemeType.Glasses:
                    uri = new Uri("/WPF.Extension.Library;component/Assets/UI.Aero.xaml", UriKind.Relative);
                    //SetThemeUri(uri);
                    //foreach (Window win in Application.Current.Windows)
                    //{
                    //    win.Background = Brushes.Transparent;
                    //    VistaGlassHelper.ExtendGlass(win, -1, -1, -1, -1);
                    //}
                    break;
            }
            SetThemeUri(uri);
        }

        public static ThemeType GetTheme()
        {
            return currentTheme;
        }

        public static void SetBackgroundVideo(string fullName)
        {
            if (File.Exists(fullName))
            {
                var uri = new Uri(fullName, UriKind.RelativeOrAbsolute);
                var mediaElement = new MediaElement
                {
                    LoadedBehavior = MediaState.Manual,
                    Stretch = Stretch.Fill,
                    Opacity = 0.3,
                    Source = uri,
                    IsMuted = true,
                };
                mediaElement.MediaEnded += (o, e) =>
                {
                    mediaElement.Position = TimeSpan.FromSeconds(0);
                    mediaElement.Play();
                };
                mediaElement.Play();

                Panel.SetZIndex(mediaElement, -1);
                var maskWin = Application.Current.MainWindow as MaskWindow;
                if (maskWin != null)
                {
                    maskWin.BackgroundContent = mediaElement;
                }
            }
            else
            {
                var maskWin = Application.Current.MainWindow as MaskWindow;
                if (maskWin != null)
                {
                    maskWin.BackgroundContent = null;
                }
            }
        }

        public static DirectoryInfo GetVideoDir()
        {
            var path = @"ShellAssets/Videos";
            if (Directory.Exists(path))
            {
                var fullPath = Path.Combine(Environment.CurrentDirectory, path);
                return new DirectoryInfo(fullPath);
            }
            return null;
        }

        public static FileInfo GetVideoFile(string name)
        {
            var path = @"ShellAssets/Videos";
            if (Directory.Exists(path))
            {
                var fullPath = Path.Combine(Environment.CurrentDirectory, path, name);
                return new FileInfo(fullPath);
            }
            return null;
        }

        private static void SetThemeUri(Uri source)
        {
            if (source == null)
                return;

            var oldThemeDict = GetThemeDictionary();
            var dictionaries = Application.Current.Resources.MergedDictionaries;
            var themeDict = new ResourceDictionary { Source = source };
            if (oldThemeDict != null)
            {
                dictionaries.Remove(oldThemeDict);
            }
            dictionaries.Add(themeDict);
        }

        private static ResourceDictionary GetThemeDictionary()
        {
            // determine the current theme by looking at the app resources and return the first dictionary having the resource key 'WindowBackground' defined.
            return (from dict in Application.Current.Resources.MergedDictionaries
                    where dict.Contains("WindowBackground")
                    select dict).FirstOrDefault();
        }
    }
}
