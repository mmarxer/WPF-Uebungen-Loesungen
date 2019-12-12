using System.Linq;
using System.Windows.Input;
using AutoUi.Core.Commands;
using AutoUi.Core.Services;

namespace AutoUi.Core.ViewModels
{
    // Unser App ViewModel ist diese Woche noch im WPF-Projekt,
    // da wir von hier aus ja direkt WPF-Objekte erstellen
    // (resp. Fenster erstellen und öffnen).
    // Nächste Woche besprechen wir noch, wie wir das noch
    // besser lösen können (mit Interfaces, konkreten Implementationen
    // davon und Dependency Injection)
    public class AppVm
    {
        public AutoListVm AutoListModel { get; set; }
        public AutoVm DemoAuto { get; set; }
        public CustomerVm DemoCustomer { get; set; }

        // Die Commands brauchen wir nur zu lesen
        // (werden nur im Konstruktor geschrieben, daher 
        // können wir auf einen Setter verzichten)
        public ICommand ShowAutoListCommand { get; }
        public ICommand EditAutoCommand { get; }
        public ICommand EditCustomerCommand { get; }

        // die konkrete IModelDataService-Implementation übergeben
        // wir im Konstruktor, daher hier nur ein Auto-Getter
        public IModelDataService ModelDataService { get; }

        // die konkrete INavigationService-Implementation übergeben
        // wir im Konstruktor, daher hier nur ein Auto-Getter
        public INavigationService NavigationService { get; }

        public AppVm(IModelDataService modelService, INavigationService navigationService)
        {
            ModelDataService = modelService;
            NavigationService = navigationService;

            // Ohne Parameter, daher direkt RelayCommand
            ShowAutoListCommand = new RelayCommand(ShowAutoList);

            // Mit dem jeweiligen ViewModel als Command Parameter,
            // daher RelayCommand<T>
            EditAutoCommand = new RelayCommand<AutoVm>(EditAuto);
            EditCustomerCommand = new RelayCommand<CustomerVm>(EditCustomer);

            // unsere ViewModels (mit Beispieldaten)
            AutoListModel = new AutoListVm()
            {
                Autos = modelService.GetAutos()
            };
            DemoAuto = modelService.GetAutos().First();
            DemoCustomer = modelService.GetCustomers().First();

        }


        public void ShowAutoList()
        {
            NavigationService.Show(AutoListModel);
        }

        public void EditAuto(AutoVm auto)
        {
            NavigationService.Show(auto);
        }

        public void EditCustomer(CustomerVm customer)
        {
            NavigationService.Show(customer);
        }
    }
}
