using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Newtonsoft.Json;
using WPF.Extension.Library.Presentation;

namespace WPF.Extension.Shell.ShellComponents
{
    public class MainMenuBarHost
    {
        public MainMenuBarHost(Panel host)
        {
            this.host = host;
            InitializeEmbeddedMenus();
            InitializeExtensionMenus();
        }

        private readonly Panel host;

        private void InitializeEmbeddedMenus()
        {

        }

        public void InitializeExtensionMenus()
        {
            var menuJson = "";
            var barInfo = JsonConvert.DeserializeObject<SdMenuBarInfo>(menuJson);
            foreach (var menu in barInfo.Menus)
            {
                var menuButton = CreateButton(menu);
                if (menuButton != null)
                {
                    host.Children.Add(menuButton);
                }
            }
        }

        private Button CreateButton(SdMenuInfo menuInfo)
        {
            var button = new Button
            {
                Content = menuInfo.Name,
                Height = 20,
                Width = 60
            };
            button.Click += (o, e) =>
            {
                var contextMenu = CreateContextMenu(button ,menuInfo);
                contextMenu.IsOpen = true;
                contextMenu.StaysOpen = true;
            };

            if (host != null)
            {
                host.Children.Add(host);
            }

            return button;
        }

        private ContextMenu CreateContextMenu(Button parent,SdMenuInfo menuInfo)
        {
            if (parent == null)
                return null;

            var contextMenu = new ContextMenu
            {
                PlacementTarget = parent,
                Placement = PlacementMode.Bottom,
            };

            if (menuInfo != null && menuInfo.Children != null && menuInfo.Children.Count > 0)
            {
                foreach (var child in menuInfo.Children)
                {
                    var subItem = CreateMenuItem(child);
                    contextMenu.Items.Add(subItem);
                }
            }

            return contextMenu;
        }

        private Control CreateMenuItem(SdMenuItemInfo itemInfo)
        {
            if (itemInfo == null)
                return null;

            if(itemInfo.IsSeparator)
                return new Separator();

            var menuItem = new MenuItem
            {
                Header = itemInfo.Name,
                InputGestureText = itemInfo.HotkeyTip,
            };

            if (itemInfo.Children != null)
            {
                foreach (var child in itemInfo.Children)
                {
                    var subItem = CreateSubMenuItem(child);
                    menuItem.Items.Add(subItem);
                }
            }
            return menuItem;
        }

        private Control CreateSubMenuItem(SdMenuItemInfo itemInfo)
        {
            if (itemInfo == null)
                return null;

            if (itemInfo.IsSeparator)
                return new Separator();

            var menuItem = new MenuItem
            {
                Header = itemInfo.Name,
                InputGestureText = itemInfo.HotkeyTip,
                Command = CreateMenuItemCommand(itemInfo)
            };

            if (itemInfo.Children != null)
            {
                foreach (var child in itemInfo.Children)
                {
                    var subItem = CreateSubMenuItem(child);
                    menuItem.Items.Add(subItem);
                }
            }
            return menuItem;
        }

        private RelayCommand CreateMenuItemCommand(SdMenuItemInfo menuItem)
        {
            if (menuItem == null)
                return null;

            return null;
        }
    }
}
