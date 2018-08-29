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
using System.Windows.Shapes;

namespace WPF.Extension.Shell.ShellCore
{
    /// <summary>
    /// Interaction logic for ShellSettingWindow.xaml
    /// </summary>
    public partial class ShellSettingWindow
    {
        public ShellSettingWindow()
        {
            InitializeComponent();
            Owner = App.Current.MainWindow;
        }
    }
}
