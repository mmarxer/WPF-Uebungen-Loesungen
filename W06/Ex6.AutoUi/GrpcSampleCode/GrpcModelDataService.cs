using System;
using System.Collections.ObjectModel;
using System.Linq;
using AutoReservation.Service.Grpc;
using AutoUi.Core.Services;
using AutoUi.Core.ViewModels;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;

namespace AutoUi.Services
{
    public class GrpcModelDataService : IModelDataService
    {
        public GrpcChannel Channel { get; }

        public AutoService.AutoServiceClient AutoClient { get; }
        public KundeService.KundeServiceClient CustomerClient { get; }
        

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="serverAdress">Die Server-Adresse, falls nicht übergebe
        /// wird "https://localhost:5001" benutzt</param>
        public GrpcModelDataService(string serverAdress = "https://localhost:5001")
        {
            Channel = GrpcChannel.ForAddress(serverAdress);

            AutoClient = new AutoService.AutoServiceClient(Channel);
            CustomerClient = new KundeService.KundeServiceClient(Channel);
        }

        public ObservableCollection<AutoVm> GetAutos()
        {
            // mit dem Grpc-Client die Autos holen (Typ AutoDto)
            var autos = AutoClient.GetAutos(new Empty(), new CallOptions()).Autos.ToList();

            // in ViewModels konvertieren
            var vms = autos.Select(x => new AutoVm()
            {
                Id = x.Id,
                Autoklasse = (AutoklasseEnum)(int)x.AutoKlasse,
                Name = x.Marke,
                Tagestarif = x.Tagestarif,
            }).ToList();

            // gekapselt in einer ObservableCollection zurückgeben
            return new ObservableCollection<AutoVm>(vms);
        }

        public ObservableCollection<CustomerVm> GetCustomers()
        {
            // mit dem Grpc-Client die Kundendaten holen (Typ KundeDto)
            var autos = CustomerClient.GetKunden(new Empty(), new CallOptions()).Kunden.ToList();

            // in ViewModels konvertieren
            var vms = autos.Select(x => new CustomerVm()
            {
                Id = x.Id,
                Vorname = x.Vorname,
                Nachname = x.Nachname,
                Geburtstag = x.Geburtsdatum.ToDateTime()
            }).ToList();

            // gekapselt in einer ObservableCollection zurückgeben
            return new ObservableCollection<CustomerVm>(vms);
        }

        public void UpdateAuto(AutoVm vm)
        {
            // aus DB laden
            var dto = AutoClient.GetAuto(new GetAutoRequest() {AutoId = vm.Id});

            // properties kopieren
            dto.Marke = vm.Name;
            dto.Tagestarif = (int)vm.Tagestarif;
            dto.AutoKlasse = (AutoKlasse) (int) vm.Autoklasse;

            // in DB schreiben
            AutoClient.UpdateAuto(dto, Metadata.Empty);
        }

        public void UpdateCustomer(CustomerVm vm)
        {
            // aus DB laden
            var dto = CustomerClient.GetKunde(new GetKundeRequest() { KundeId = vm.Id});

            // properties kopieren
            dto.Nachname = vm.Nachname;
            dto.Vorname = vm.Vorname;
            dto.Geburtsdatum = vm.Geburtstag.ToTimestamp();

            // in DB schreiben
            CustomerClient.UpdateKunde(dto, Metadata.Empty);
        }
    }
}
