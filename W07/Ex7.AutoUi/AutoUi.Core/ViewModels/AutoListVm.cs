﻿using System.Collections.ObjectModel;
using System.Linq;
using AutoUi.Core.Services;

namespace AutoUi.Core.ViewModels
{
    public class AutoListVm : BindableBase
    {
        private ObservableCollection<AutoVm> _autos;

        public ObservableCollection<AutoVm> Autos
        {
            get { return _autos; }
            set { SetProperty(ref _autos, value); }
        }

        public int AnzahlAutos => Autos.Count;

        public int AnzahlNeueAutos => Autos.Count(x => x.IstNeu);


        private AutoVm _selectedAuto;

        public AutoVm SelectedAuto
        {
            get { return _selectedAuto; }
            set { SetProperty(ref _selectedAuto, value); }
        }

        public INavigationService NavigationService { get; set; }
        public AutoListVm(INavigationService navService)
        {
            NavigationService = navService;
        }

        public void EditAuto()
        {
            NavigationService.Show(SelectedAuto);
        }
    }
}
