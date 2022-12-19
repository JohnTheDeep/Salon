using Salon.Models.Data;
using SalonApp.Services.Commands;
using SalonApp.Services.DbCommands;
using SalonApp.Services.PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Data = SalonApp.Models.Data;
namespace SalonApp.View.AddService
{
    public class ServiceServiceVM : PropertyChangedBase
    {
        private Window window;
        private Salons _selectedSalon;
        public Salons SelectedSalon
        {
            get => _selectedSalon;
            set => Set(ref _selectedSalon,value);
        }
        public ServiceServiceVM(Window wind, Salons selectedSalon)
        {
            window = wind;
            SelectedSalon = selectedSalon;
        }
        private string _serviceName;
        public string ServiceName 
        {
            get => _serviceName;
            set => Set(ref _serviceName, value);
        }
        private RelayCommand _addServiceCommand;
        public RelayCommand AddServiceCommand
        {
            get
            {
                return _addServiceCommand ?? (_addServiceCommand = new RelayCommand(obj =>
                {
                    Controller.AddService(new Data.Services { ServiceName = ServiceName },SelectedSalon);
                    window?.Close();
                }));
            }
        }

    }
}
