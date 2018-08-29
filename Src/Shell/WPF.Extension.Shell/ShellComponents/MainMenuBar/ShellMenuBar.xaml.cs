using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF.Extension.Shell.ShellComponents
{
    /// <summary>
    /// Interaction logic for ShellMenuBar.xaml
    /// </summary>
    public partial class ShellMenuBar : UserControl
    {
        public ShellMenuBar()
        {
            InitializeComponent();
        }

        private bool IsChecked { get; set; }

        private ToggleButton FocusElement { get; set; }

        private void FileMenu_OnChecked(object sender, RoutedEventArgs e)
        {
            HandleMenuButton(sender as ToggleButton);
        }

        private void EditMenu_OnChecked(object sender, RoutedEventArgs e)
        {
            HandleMenuButton(sender as ToggleButton);
        }

        private void HandleMenuButton(ToggleButton button)
        {
            if (button != null && button.IsChecked.HasValue && button.IsChecked.Value)
            {
                IsChecked = true;
                FocusElement = button;
                CreatePopupMenu(button);
            }
        }

        private void CreatePopupMenu(UIElement target)
        {
            //var popup = new Popup
            //{
            //    PlacementTarget = target,
            //    Placement = PlacementMode.Bottom,
            //    IsOpen = true,
            //    StaysOpen = true,
            //    //Style = (Style)Application.Current.FindResource("SystemMenuItemStyleKey")
            //};
            ////var btn =  new MenuItem() { Header = "Text" };
            //var btn = CreateMenuItem("new");
            //btn.BorderThickness = new Thickness(0);
            //popup.Child = btn;

             var contextMenu = new ContextMenu
             {
                 PlacementTarget = target,
                 Placement = PlacementMode.Bottom,
                 IsOpen = true,
                 StaysOpen = true,
                 Style = (Style)Application.Current.FindResource("SystemMenuItemStyleKey")
             };
             contextMenu.Items.Add(CreateMenuItem("New"));
             contextMenu.Items.Add(CreateMenuItem("Open"));
             contextMenu.Items.Add(CreateMenuItem("Close"));
             contextMenu.LostMouseCapture += ContextMenu_LostMouseCapture;
             contextMenu.MouseMove += ContextMenu_MouseMove;
             contextMenu.MouseLeave += ContextMenu_MouseLeave;
        }

        private void ContextMenu_MouseLeave(object sender, MouseEventArgs e)
        {
            var contextMenu = e.Source as ContextMenu;
            if (contextMenu != null)
            {
                var button = contextMenu.PlacementTarget as ToggleButton;
                if (button != null)
                {
                    if (IsChecked && FocusElement != null)
                    {
                        if (FocusElement == null)
                            return;

                        if (FocusElement.Name.Equals(button.Name))
                            return;

                        FocusElement.IsChecked = false;
                        button.IsChecked = true;
                        FocusElement = button;
                    }
                }
            }
        }

        private void ContextMenu_MouseMove(object sender, MouseEventArgs e)
        {
            var contextMenu = e.Source as ContextMenu;
            if (contextMenu != null)
            {
                var button = contextMenu.PlacementTarget as ToggleButton;
                if (button != null)
                {
                    if (IsChecked && FocusElement != null)
                    {
                        if (FocusElement == null)
                            return;

                        if (FocusElement.Name.Equals(button.Name))
                            return;

                        FocusElement.IsChecked = false;
                        button.IsChecked = true;
                        FocusElement = button;
                    }
                }
            }
        }

        private MenuItem CreateMenuItem(string name, string tip = "", bool isEnabled = true, bool isChecked = false)
        {
            var menu = new MenuItem
            {
                Header = name,
                InputGestureText = tip,
                IsEnabled = isEnabled,
                IsChecked = isChecked,
                Style = (Style)Application.Current.FindResource("SystemMenuItem")
            };
            return menu;
        }

        private void ContextMenu_LostMouseCapture(object sender, MouseEventArgs e)
        {
            var contextMenu = sender as ContextMenu;
            if (contextMenu != null)
            {
                var button  = contextMenu.PlacementTarget as ToggleButton;
                if (button != null)
                {
                    button.IsChecked = false;
                    FocusElement = null;
                }
            }
        }

        private void UIElement_OnMouseMove(object sender, MouseEventArgs e)
        {
            var source = e.Source as ToggleButton;
            if (source != null)
            {
                if (IsChecked && FocusElement!=null )
                {
                    if (FocusElement == null)
                        return;

                    if (FocusElement.Name.Equals(source.Name))
                        return;

                    FocusElement.IsChecked = false;
                    source.IsChecked = true;
                    FocusElement = source;
                }
            }
        }
    }
}
