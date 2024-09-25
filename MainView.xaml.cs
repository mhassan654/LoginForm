using System;
using System.Windows;
using System.Windows.Input;
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace LoginForm
{
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void PnlControlPanel_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        private void PnlControlPanel_OnMouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void BtnClose_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnMaximize_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.WindowState== WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }

           
        }

        private void BtnMinimize_OnClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        
        // Handle the Checked event (Sidebar Expanded)
        // private void SidebarToggleButton_Checked(object sender, RoutedEventArgs e)
        // {
        //     Sidebar.Visibility = Visibility.Visible;
        // }
        //
        // // Handle the Unchecked event (Sidebar Collapsed)
        // private void SidebarToggleButton_Unchecked(object sender, RoutedEventArgs e)
        // {
        //     Sidebar.Visibility = Visibility.Collapsed;
        // }
        private void SidebarToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            if (Sidebar != null)  // Null check to prevent exceptions
            {
                Sidebar.Visibility = Visibility.Visible;
                // Expand the sidebar to its original width (250 in this case)
                SidebarColumn.Width = new GridLength(250);
                MainContentColumn.Width = new GridLength(1, GridUnitType.Star); // Main content adjusts to remaining space
            }
        }

        private void SidebarToggleButton_OnUnchecked(object sender, RoutedEventArgs e)
        {
            if (Sidebar != null)  // Null check to prevent exceptions
            {
                Sidebar.Visibility = Visibility.Collapsed;
                // Collapse the sidebar by setting its width to 0
                SidebarColumn.Width = new GridLength(0);
                MainContentColumn.Width = new GridLength(1, GridUnitType.Star); // Main content takes full width
            }
        }
    }
}