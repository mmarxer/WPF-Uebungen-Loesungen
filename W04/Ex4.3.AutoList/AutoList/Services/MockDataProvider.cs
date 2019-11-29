using System;
using System.Collections.ObjectModel;
using AutoList.ViewModels;

namespace AutoList.Services
{
    public class MockDataProvider
    {
        public static ObservableCollection<AutoVm> BeispielAutos = new ObservableCollection<AutoVm>()
        {
            new AutoVm() { Name = "Skoda Octavia", Autoklasse = AutoklasseEnum.Mittelklasse, IstNeu = true, Tagestarif = 199},
            new AutoVm() { Name = "VW Golf", Autoklasse = AutoklasseEnum.Standardklasse, IstNeu = false, Tagestarif = 129},
            new AutoVm() { Name = "Audi e-Tron", Autoklasse = AutoklasseEnum.Luxusklasse, IstNeu = true, Tagestarif = 399},
            new AutoVm() { Name = "Porsche Taycan-e", Autoklasse = AutoklasseEnum.Luxusklasse, IstNeu = true, Tagestarif = 1199}
        };

        public static ObservableCollection<CustomerVm> BeispielKunden = new ObservableCollection<CustomerVm>()
        {
            new CustomerVm() { Vorname = "Bill", Nachname = "Gates", Geburtstag = DateTime.Parse("1955-10-28") },
            new CustomerVm() { Vorname = "Jeff", Nachname = "Bezos", Geburtstag = DateTime.Parse("1964-01-12") },
            new CustomerVm() { Vorname = "Elon", Nachname = "Musk", Geburtstag = DateTime.Parse("1971-06-28") },
        };

    }
}
