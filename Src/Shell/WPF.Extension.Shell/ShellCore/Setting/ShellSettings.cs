using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace WPF.Extension.Shell.ShellCore
{
    public class ShellSettings
    {
        private string settingsFile = "settings.json";


        public ShellSettings()
        {
            Theme = new ShellTheme();
            MainWindowSetting = new ShellMainWindowSetting();
        }

        public ShellTheme Theme { get; set; }

        public ShellMainWindowSetting MainWindowSetting { get; set; }

        public void UpdateTheme(ThemeType theme)
        {
            ThemeManager.SetTheme(theme);
            Theme.Name = theme.ToString();
        }

        public void UpdateBackgroundVideo(string fullName)
        {
            var fileInfo = new FileInfo(fullName);
            if (fileInfo.Exists)
            {
                ThemeManager.SetBackgroundVideo(fullName);
                Theme.BackgroundVideo = fileInfo.Name;
            }
            else
            {
                ThemeManager.SetBackgroundVideo(string.Empty);
                Theme.BackgroundVideo = string.Empty;
            }
        }

        public void Save()
        {
            var content = JsonConvert.SerializeObject(this);
            File.WriteAllText(settingsFile, content);
        }

        public bool Load()
        {
            if (File.Exists(settingsFile))
            {
                var content = File.ReadAllText(settingsFile);
                var settings = JsonConvert.DeserializeObject<ShellSettings>(content);

                Theme = settings.Theme;
                MainWindowSetting = settings.MainWindowSetting;

                ThemeType theme;
                if (Enum.TryParse(Theme.Name,out theme))
                {
                    UpdateTheme(theme);
                }

                if (!string.IsNullOrWhiteSpace(settings.Theme.BackgroundVideo))
                {
                    var file = ThemeManager.GetVideoFile(settings.Theme.BackgroundVideo);
                    if (file.Exists)
                    {
                        ThemeManager.SetBackgroundVideo(file.FullName);
                    }
                }
                return true;
            }
            return false;
        }
    }

    public class ShellTheme
    {
        public string Name { get; set; }

        public string BackgroundVideo { get; set; }
    }

    public class ShellMainWindowSetting
    {
        public double Height { get; set; }

        public double Width { get; set; }

        public double Left { get; set;}

        public double Top { get; set; }
    }
}
