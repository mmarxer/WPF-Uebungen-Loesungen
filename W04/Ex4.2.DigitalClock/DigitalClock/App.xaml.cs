using System;
using System.Windows;
using System.Windows.Threading;

namespace DigitalClock
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public DispatcherTimer Timer { get; set; }
        public Clock Clock { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            Clock = new Clock();

            Timer = new DispatcherTimer();

            // Send tick event each second:
            Timer.Interval = TimeSpan.FromSeconds(1);
            Timer.Tick += (sender, args) =>
            {
                // Do something...
                Clock.Time = DateTime.Now;
            };
            Timer.Start();

            // here, we do not rely on the "StartupUri" Property of the
            // application class in .xaml but instead instantiate our
            // own instance:
            MainWindow = new DigitalClock.MainWindow();
            // note how the Property "MainWindow" is a predefined
            // property in the "Application" class and that our
            // class definition containing the window's UI does
            // not necessarily need to have the same name.


            // set the data context of the main window, here:
            // ...
            MainWindow.DataContext = Clock;

            MainWindow.Show();
        }
    }
}
