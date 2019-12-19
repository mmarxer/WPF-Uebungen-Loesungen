using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoUi.Mobile;
using AutoUi.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoUi.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AutoListPage : ContentPage
    {
        public AutoListPage()
        {
            InitializeComponent();
        }

        public static void Display(AutoListVm vm)
        {
            var page = new AutoListPage();
            page.BindingContext = vm;
            page.Title = "Verfügbare Autos";

            Application.Current.MainPage.Navigation.PushAsync(page, true);
        }

        private void Autos_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var vm = this.BindingContext as AutoListVm;
            vm.EditAuto();
        }
    }
}