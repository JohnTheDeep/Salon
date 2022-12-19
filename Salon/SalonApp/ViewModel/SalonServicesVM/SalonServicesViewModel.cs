using Salon.Models.Data;
using SalonApp.Models.Data;
using SalonApp.Services.DbCommands;
using SalonApp.Services.PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salon.Models.Data;
using SalonApp.Services.Commands;

namespace SalonApp.ViewModel.SalonServicesVM
{
    public class SalonServicesViewModel : PropertyChangedBase
    {
        private Salons _selectedSalon;
        public Salons SelectedSalon
        {
            get => _selectedSalon;
            set => Set(ref _selectedSalon,value);
        }
        private List<Salon_Service> _list;
        public List<Salon_Service> List
        {
            get => _list;
            set => Set(ref _list, value);
        }
        private SalonApp.Models.Data.Salon_Service _selectedServices;
        public SalonApp.Models.Data.Salon_Service SelectedServices
        {
            get => _selectedServices;
            set => Set(ref _selectedServices, value);
        }
        public SalonServicesViewModel(Salons selectedSalon)
        {
            SelectedSalon = selectedSalon; 
            FillList(SelectedSalon.Id);
        }

        private RelayCommand _setActivityCommandTrue;
        public RelayCommand SetActivityCommandTrue
        {
            get
            {
                return _setActivityCommandTrue ?? (_setActivityCommandTrue = new RelayCommand(obj =>
                {
                    Controller.SetActivity(_selectedServices, true);
                    FillList(SelectedSalon.Id); 
                }));
            }
        }
        private RelayCommand _setActivityCommandFalse;
        public RelayCommand SetActivityCommandFalse
        {
            get
            {
                return _setActivityCommandFalse ?? (_setActivityCommandFalse = new RelayCommand(obj =>
                {
                    Controller.SetActivity(_selectedServices, false);
                    FillList(SelectedSalon.Id);
                }));
            }
        }
        private void FillList(int id)
        {
            List = Controller.GetAllSalonServices(id);
        }
    }
}
