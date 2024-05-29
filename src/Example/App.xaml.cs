using System;
using System.Threading.Tasks;
using System.Windows;

namespace Example
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ShutdownMode = ShutdownMode.OnExplicitShutdown;

            Test();

            while (true)
            {
                await Task.Delay(1000);

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private static void Test()
        {
            for (var i = 0; i < 10; i++)
            {
                var window = new MainWindow();
                window.Show();
                window.Close();
            }
        }
    }
}