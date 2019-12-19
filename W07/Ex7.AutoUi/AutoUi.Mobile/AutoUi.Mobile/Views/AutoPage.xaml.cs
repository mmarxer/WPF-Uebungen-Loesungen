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
    public partial class AutoPage : ContentPage
    {
        public AutoPage()
        {
            InitializeComponent();
        }

        public static void Display(AutoVm vm)
        {
            var page = new AutoPage();
            page.BindingContext = vm;
            page.Title = vm.Name;

            App.Current.MainPage.Navigation.PushAsync(page, true);
        }
    }
}