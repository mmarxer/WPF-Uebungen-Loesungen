﻿using System.Windows;
using AutoUi.Core.Services;
using AutoUi.Services;
using AutoUi.ViewModels;

namespace AutoUi
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public AppVm Vm { get; set; }

        public IModelDataService ModelDataService { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ModelDataService = new MockModelDataService();
            // soll nun anstelle des Mock Services der echte
            // gRPC-Service verwendet werden, muss nur diese
            // Zeile geändert werden in:
            //
            //   ModelDataService = new GrpcModelDataService();
            //
            // Der ganze Rest der App bleibt 100% unverändert!


            // hier den Glue Code ergänzen (DataContext von MainWindow,
            // sowie ViewModels etc.):
            // ...          

            Vm = new AppVm(ModelDataService);

            MainWindow = new MainWindow();
            MainWindow.DataContext = Vm;
            MainWindow.Show();

            // ... und nicht vergessen, im App.xaml die Property
            // StartupUri zu entfernen, falls das MainWindow hier
            // erzeugt und angezeigt wird (wie z.B. in Ü4).
        }
    }
}
