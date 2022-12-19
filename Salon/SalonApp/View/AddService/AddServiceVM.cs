using Salon;
using Salon.Models.Data;
using SalonApp.Services.Commands;
using SalonApp.Services.DbCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Data = SalonApp.Models.Data;
namespace SalonApp.View.AddService
{
    internal class AddServiceVM : Services.PropertyChanged.PropertyChangedBase
    {
        private Salons _selectedSalon;
        public Salons SelectedSalon
        {
            get => _selectedSalon;
            set => Set(ref _selectedSalon, value);
        }
        private Data.Services _selectedService;
        public Data.Services SelectedService
        {
            get => _selectedService;
            set => Set(ref _selectedService, value);
        }
        public AddServiceVM(Salons selectedSalon)
        {
            FillList();
            SelectedSalon = selectedSalon;
        }
        private List<Data.Services> _servicesList;
        public List<Data.Services> ServicesList
        {
            get => _servicesList;
            set => Set(ref _servicesList, value);
        }
        private void FillList()
        {
            using (var db = new ApplDbContext())
                ServicesList = db.ServicesT.ToList();
        }
        private RelayCommand _openEditServiceWindowCommand;
        public RelayCommand OpenEditServiceWindowCommand
        {
            get
            {
                return _openEditServiceWindowCommand ?? (_openEditServiceWindowCommand = new RelayCommand(obj =>
                {
                    if (SelectedService != null)
                    {
                        OpenEditServiceWindow(this, new EventArgs());
                        FillList();
                    }
                    else MessageBox.Show("Выберите услугу!","Ошибка",MessageBoxButton.OK,MessageBoxImage.Warning);
                }));
            }
        }
        private RelayCommand _openServiceWindowCommand;
        public RelayCommand OpenServiceWindowCommand
        {
            get
            {
                return _openServiceWindowCommand ?? (_openServiceWindowCommand = new RelayCommand(obj =>
                {
                    OpenServiceWindow(this, new EventArgs());
                    FillList();
                }));
            }
        }
        private RelayCommand _deleteServiceCommand;
        public RelayCommand DeleteServiceCommand
        {
            get
            {
                return _deleteServiceCommand ?? (_deleteServiceCommand = new RelayCommand(obj =>
                {
                    if (SelectedService != null)
                    {
                        if (MessageBox.Show("Вы уверены что хотите удалить услугу?\n Все взаимосвязанные данные будут удалены!", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                Controller.DeleteService(SelectedService);
                                FillList();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                    else MessageBox.Show("Выберите услугу!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }));
            }
        }
        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
        private void OpenServiceWindow(object sender, EventArgs e)
        {
            AddServiceService wind = new AddServiceService(SelectedSalon);
            SetCenterPositionAndOpen(wind);
        }
        private void OpenEditServiceWindow(object sender, EventArgs e)
        {
            EditService.EditServiceWindow wind = new EditService.EditServiceWindow(SelectedService);
            SetCenterPositionAndOpen(wind);
        }
    }
}
