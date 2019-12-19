using System;
using System.Collections.Generic;
using System.Text;
using AutoUi.Core.Services;
using AutoUi.Core.ViewModels;
using AutoUi.Mobile.Views;

namespace AutoUi.Mobile.Services
{
    public class XfNavigationService:INavigationService
    {
        public readonly Dictionary<Type, Action<object>> PageFactory 
            = new Dictionary<Type, Action<object>>();

        public XfNavigationService()
        {
            PageFactory.Add(typeof(AutoListVm), vm => AutoListPage.Display(vm as AutoListVm));
            PageFactory.Add(typeof(AutoVm), vm => AutoPage.Display(vm as AutoVm));
        }

        public void Show<T>(T vm)
        {
            var factoryAction = PageFactory[typeof(T)];

            // Zur Sicherheit wrappen wir den Aufruf der
            // jeweiligen Display-Methoden in einem Aufruf
            // an Dispatcher.Invoke(...), um sicherzustellen,
            // dass dies im UI Thread erfolgt und nicht 
            // aus Versehen aus einem Background Thread
            // heraus...
            App.Current.Dispatcher.BeginInvokeOnMainThread(() => factoryAction(vm));
        }
    }
}
