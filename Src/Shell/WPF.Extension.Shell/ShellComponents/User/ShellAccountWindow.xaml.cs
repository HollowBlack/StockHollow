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

namespace WPF.Extension.Shell.ShellComponents
{
    /// <summary>
    /// Interaction logic for ShellAccountWindow.xaml
    /// </summary>
    public partial class ShellAccountWindow
    {
        public ShellAccountWindow()
        {
            InitializeComponent();
            Owner = App.Current.MainWindow;
        }

        private async  void loginButton_Click(object sender, RoutedEventArgs e)
        {
            busyIndicator.IsBusy = true;

            await Task.Delay(3000);

            busyIndicator.IsBusy = false;
        }
    }
}
