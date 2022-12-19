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
namespace SalonApp.ViewModel.EditService
{
    internal class EditServiceVM : PropertyChangedBase
    {
        private Window window;
        public EditServiceVM(Window wind,Data.Services selected)
        {
            window = wind;
            SelectedService = selected;
        }
        private Data.Services _selectedService;
        public Data.Services SelectedService
        {
            get => _selectedService;
            set => Set(ref _selectedService,value);
        }
        private string _serviceName;
        public string ServiceName
        {
            get => _serviceName;
            set => Set(ref _serviceName, value);
        }
        private RelayCommand _editServiceCommand;
        public RelayCommand EditServiceCommand
        {
            get
            {
                return _editServiceCommand ?? (_editServiceCommand = new RelayCommand(obj =>
                {
                    Controller.EditService(SelectedService,new Data.Services { ServiceName = SelectedService.ServiceName });
                    window?.Close();
                }));
            }
        }
    }
}
