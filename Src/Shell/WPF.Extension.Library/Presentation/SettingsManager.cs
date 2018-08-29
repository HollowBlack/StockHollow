using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;

namespace WPF.Extension.Library.Presentation
{
    public class SettingsManager
    {
        public static string RegPath = @"Software\WindowMask\WindowBounds\";

        public static void SaveSettings(Window window)
        {
            if (window == null)
                return;

            RegistryKey key= Registry.CurrentUser.CreateSubKey(RegPath + window.Name);
            if (key != null)
            {
                //key.SetValue("Bounds", window.RestoreBounds.ToString());
                key.SetValue("Bounds", window.RestoreBounds.ToString(CultureInfo.InvariantCulture));
                key.SetValue("Theme", ThemeManager.GetTheme());
            }

            //Rect bounds= Properties.Settings.Default.WindowsPosition;
        }

        public static void LoadSettings(Window window)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(RegPath + window.Name);
            if (key != null)
            {
                Rect bounds = Rect.Parse(key.GetValue("Bounds").ToString());
                window.Top = bounds.Top;
                window.Left = bounds.Left;

                if (window.SizeToContent == SizeToContent.Manual)
                {
                    window.Width = bounds.Width;
                    window.Height = bounds.Height;
                }

                var theme = key.GetValue("Theme").ToString();
                ThemeType type;
                if (ThemeType.TryParse(theme, out type))
                {
                    ThemeManager.SetTheme(type);
                }
            }
        }
    }
}
