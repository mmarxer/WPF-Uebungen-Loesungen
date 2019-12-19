using System;
using AutoUi.Core.Services;
using AutoUi.Core.ViewModels;
using AutoUi.Mobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoUi.Mobile
{
    public partial class App : Application
    {
        public AppVm Vm { get; set; }

        public IModelDataService ModelDataService { get; private set; }
        public INavigationService NavigationService { get; private set; }

        public App()
        {
            InitializeComponent();

            ConfigureServices();

            Vm = new AppVm(ModelDataService, NavigationService);

            var page = new MainPage();
            page.BindingContext = Vm;

            var nav = new NavigationPage(page);

            MainPage = nav;

        }

        public void ConfigureServices()
        {
            NavigationService = new XfNavigationService();
            ModelDataService = new MockModelDataService();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
