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
        private string _titleService;
        public string TitleService
        {
            get => _titleService;
            set => Set(ref _titleService, value);
        }
        private string _titleHandJob;
        public string TitleHandJob
        {
            get => _titleHandJob;
            set => Set(ref _titleHandJob, value);
        }
        private string _serviceType;
        public string ServiceType
        {
            get => _serviceType;
            set => Set(ref _serviceType, value);
        }
        private RelayCommand _addServiceCommand;
        public RelayCommand AddServiceCommand
        {
            get
            {
                return _addServiceCommand ?? (_addServiceCommand = new RelayCommand(obj =>
                {
                    if (ServiceName != "" && ServiceName != null)
                    {
                        try
                        {
                            Controller.AddService(new Data.Services { ServiceName = ServiceName , TitleHandJob = this.TitleHandJob, TitleService = this.TitleService , ServiceType = this.ServiceType}, SelectedSalon);
                            window?.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                    else MessageBox.Show("Введите все данные!");
                }));
            }
        }

    }
}
