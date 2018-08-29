using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Extension.Library.Presentation;
using WPF.Extension.Shell.Utility;

namespace WPF.Extension.Shell.ShellCore
{
    public class ThemeVm : NotifyPropertyChanged
    {
        public ThemeVm()
        {
            Themes = new ObservableCollection<EnumDisplayable<ThemeType>>();
            Videos = new ObservableCollection<string>();
            Initialize();
        }

        private void Initialize()
        {
            var settings = Singleton<ShellSettings>.Instance;
            InitializeTheme(settings);
            InitializeBackgroundVideo(settings);
        }

        private void InitializeTheme(ShellSettings settings)
        {
            foreach (var item in EnumDisplayable<ThemeType>.GetEnumDisplayItems())
            {
                if (item.EnumValue == ThemeType.Glasses)
                    continue;
                Themes.Add(item);
            }

            selectedTheme = Themes.FirstOrDefault();

            if (!string.IsNullOrWhiteSpace(settings.Theme.Name))
            {
                ThemeType theme;
                if (Enum.TryParse(settings.Theme.Name, out theme))
                {
                    SelectedTheme = Themes.FirstOrDefault(i => i.EnumValue == theme);
                    OnPropertyChanged(nameof(SelectedTheme));
                }
            }
        }

        private void InitializeBackgroundVideo(ShellSettings settings)
        {
            var defaultItem = "None";
            var dir = ThemeManager.GetVideoDir();
            if (dir != null)
            {
                var mediaFiles = dir.GetFiles();
                foreach (var mediaFile in mediaFiles)
                {
                    Videos.Add(mediaFile.Name);
                }

                if (!string.IsNullOrWhiteSpace(settings.Theme.BackgroundVideo))
                {
                    SelectedVideo = settings.Theme.BackgroundVideo;
                }
                else
                {
                    SelectedVideo = defaultItem;
                }

                if (Videos.Count > 0)
                {
                    Videos.Insert(0, defaultItem);
                }
            }
        }

        public ObservableCollection<EnumDisplayable<ThemeType>> Themes { get; private set; }

        private EnumDisplayable<ThemeType> selectedTheme;
        public EnumDisplayable<ThemeType> SelectedTheme
        {
            get { return selectedTheme; }
            set
            {
                if (selectedTheme != value)
                {
                    selectedTheme = value;
                    UpdateTheme(value.EnumValue);
                    OnPropertyChanged(nameof(SelectedTheme));
                }
            }
        }

        private bool isCustomized;
        public bool IsCustomized
        {
            get { return isCustomized; }
            set
            {
                if (isCustomized == value)
                {
                    isCustomized = value;
                    OnPropertyChanged(nameof(IsCustomized));
                }
            }
        }

        public ObservableCollection<string> Videos { get; private set; }

        private string selectedVideo;
        public string SelectedVideo
        {
            get { return selectedVideo; }
            set
            {
                if (selectedVideo != value)
                {
                    selectedVideo = value;
                    UpdateBackgroundVideo(value);
                    OnPropertyChanged(nameof(SelectedVideo));
                }
            }
        }

        private void UpdateTheme(ThemeType theme)
        {
            Singleton<ShellSettings>.Instance.UpdateTheme(theme);
        }

        private void UpdateBackgroundVideo(string videoName)
        {
            var file = ThemeManager.GetVideoFile(videoName);
            if (file != null)
            {
                Singleton<ShellSettings>.Instance.UpdateBackgroundVideo(file.FullName);
            }
            else
            {
                Singleton<ShellSettings>.Instance.UpdateBackgroundVideo(string.Empty);
            }
        }

    }
}
