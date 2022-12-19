using Salon.Models.Data;
using Salon;
using SalonApp.Services.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SalonApp.Services.PropertyChanged;
using SalonApp.Services.DbCommands;

namespace SalonApp.ViewModel.EditSalon
{
    internal class EditSalonVM : PropertyChangedBase
    {
        private Window window;
        private Salons _selectedSalon;
        public Salons SelectedSalon
        {
            get => _selectedSalon;
            set => Set(ref _selectedSalon, value);
        }
        
        private string _salonName;
        public string SalonName
        {
            get => _salonName;
            set => Set(ref _salonName, value);
        }
        private string _director;
        public string Director
        {
            get => _director;
            set => Set(ref _director, value);
        }
        public EditSalonVM(Window wind,Salons selectedSalon)
        {
            window = wind;
            SelectedSalon = selectedSalon;
        }

        private RelayCommand _addSalonCommand;
        public RelayCommand AddSalonCommand
        {
            get
            {
                return _addSalonCommand ?? (_addSalonCommand = new RelayCommand(obj =>
                {
                    Controller.EditSalon(SelectedSalon,new Salons { SalonName = SelectedSalon.SalonName, Director = SelectedSalon.Director });
                    window.Close();
                }));
            }
        }
    }
}
