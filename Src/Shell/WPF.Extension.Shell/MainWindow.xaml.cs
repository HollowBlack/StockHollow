using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.Extension.Shell.ShellComponents;
using WPF.Extension.Shell.ShellCore;
using WPF.Extension.Shell.Utility;

namespace WPF.Extension.Shell
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
            Closing += MainWindow_Closing;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (Singleton<ShellSettings>.Instance.Load())
            {
                Width = Singleton<ShellSettings>.Instance.MainWindowSetting.Width;
                Height = Singleton<ShellSettings>.Instance.MainWindowSetting.Height;
                Left = Singleton<ShellSettings>.Instance.MainWindowSetting.Left;
                Top = Singleton<ShellSettings>.Instance.MainWindowSetting.Top;
            }
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Singleton<ShellSettings>.Instance.MainWindowSetting.Width = ActualWidth;
            Singleton<ShellSettings>.Instance.MainWindowSetting.Height = ActualHeight;
            Singleton<ShellSettings>.Instance.MainWindowSetting.Left = Left;
            Singleton<ShellSettings>.Instance.MainWindowSetting.Top = Top;
            Singleton<ShellSettings>.Instance.Save();
        }

        private void UserButton_OnClick(object sender, RoutedEventArgs e)
        {
            new ShellAccountWindow().ShowDialog();
        }

        private void SettingButton_OnClick(object sender, RoutedEventArgs e)
        {
            new ShellSettingWindow().ShowDialog();
        }
    }
}
