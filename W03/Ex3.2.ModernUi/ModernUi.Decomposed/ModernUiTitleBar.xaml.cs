using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ModernUi.Decomposed
{
    /// <summary>
    /// Interaction logic for ModernUiTitleBar.xaml
    /// </summary>
    public partial class ModernUiTitleBar : UserControl
    {

        public ModernUiTitleBar()
        {
            InitializeComponent();
        }

        private Window GetWindow() => Window.GetWindow(this);

        private void TitlePanel_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GetWindow()?.DragMove();
        }

        private void CloseCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void MaximizeCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            var win = GetWindow();
            if (win == null) return;
            e.CanExecute = win.WindowState != WindowState.Maximized;
        }

        private void RestoreCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            var win = GetWindow();
            if (win == null) return;
            e.CanExecute = win.WindowState == WindowState.Maximized;
        }

        private void MinimizeCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            var win = GetWindow();
            if (win == null) return;
            e.CanExecute = win.WindowState != WindowState.Minimized;
        }

        private void CloseCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.CloseWindow(GetWindow());
        }

        private void MaximizeCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var win = GetWindow();
            if (win == null) return;
            SystemCommands.MaximizeWindow(win);
        }

        private void RestoreCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var win = GetWindow();
            if (win == null) return;
            SystemCommands.RestoreWindow(win);
        }

        private void MinimizeCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var win = GetWindow();
            if (win == null) return;
            SystemCommands.MinimizeWindow(win);
        }

        private void TitlePanel_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var win = GetWindow();
            if (win == null) return;

            if (e.ClickCount == 2 && win.WindowState == WindowState.Maximized)
            {
                SystemCommands.RestoreWindow(win);
            }
            else if (e.ClickCount == 2 && win.WindowState == WindowState.Normal)
            {
                SystemCommands.MaximizeWindow(win);
            }
        }

    }
}
