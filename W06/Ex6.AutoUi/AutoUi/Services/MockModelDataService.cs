using System.Collections.ObjectModel;
using AutoUi.Core.Services;
using AutoUi.Core.ViewModels;

namespace AutoUi.Services
{

    /// <summary>
    /// Unsere Mock Model Service Implementation, welche nur
    /// Beispieldaten zurückgibt (In-Memory-Daten)
    /// </summary>
    public class MockModelDataService : IModelDataService
    {
        public ObservableCollection<AutoVm> GetAutos()
        {
            return MockDataProvider.BeispielAutos;
        }

        public ObservableCollection<CustomerVm> GetCustomers()
        {
            return MockDataProvider.BeispielKunden;
        }
    }
}
