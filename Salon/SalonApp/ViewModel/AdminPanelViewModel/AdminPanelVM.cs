    using Salon;
using SalonApp.Models.Data;
using SalonApp.Services.Commands;
using SalonApp.Services.DbCommands;
using SalonApp.Services.PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SalonApp.View.AddUser;
using Salon.Models.Data;
using SalonApp.View;

namespace SalonApp.ViewModel.AdminPanelViewModel
{
    public class AdminPanelVM : PropertyChangedBase
    {
        private List<Salons> _salons;
        public List<Salons> Salons
        {
            get => _salons;
            set => Set(ref _salons, value);
        }
        private Salons _selectedSalon;
        public Salons SelectedSalon
        {
            get => _selectedSalon;
            set => Set(ref _selectedSalon, value);
        }
        private void FillList()
        {
            using(var db = new ApplDbContext())
                Salons = db.SalonsT.ToList();
        }
        public AdminPanelVM() 
        {
            FillList();
        }
        
        private RelayCommand _openSalary;
        public RelayCommand OpenSalary
        {
            get
            {
                return _openSalary ?? (_openSalary = new RelayCommand(obj =>
                {
                    OpenSalaryTre(this, new EventArgs());
                    FillList();
                }));
            }
        }
        private RelayCommand _openAddSalonWindowCommand;
        public RelayCommand OpenAddSalonWindowCommand
        {
            get
            {
                return _openAddSalonWindowCommand ?? (_openAddSalonWindowCommand = new RelayCommand(obj =>
                {
                    OpenAddSalonWindow(this, new EventArgs());
                    FillList();
                }));
            }
        }
        private RelayCommand _deleteSalonCommand;
        public RelayCommand DeleteSalonCommand
        {
            get
            {
                return _deleteSalonCommand ?? (_deleteSalonCommand = new RelayCommand(obj =>
                {
                    var dialog = MessageBox.Show("Вы уверены что хотите удалить салон?\nУдаляя данную запись, все связанные данные будут удалены!", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (dialog == MessageBoxResult.Yes)
                    {
                        try
                        {
                            Controller.DeleteSalon(SelectedSalon);
                            FillList();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                        
                    }
                }));
            }
        }
        private RelayCommand _openSalonViewWindowCommand;
        public RelayCommand OpenSalonViewWindowCommand
        {
            get
            {
                return _openSalonViewWindowCommand ?? (_openSalonViewWindowCommand = new RelayCommand(obj =>
                {
                    if (SelectedSalon != null)
                    {
                        OpenSalonViewWindow(this, new EventArgs());
                        FillList();
                    }
                    else MessageBox.Show("Выберите салон!");
                }));
            }
        }
        private RelayCommand _editSalonCommand;
        public RelayCommand EditSalonCommand
        {
            get
            {
                return _editSalonCommand ?? (_editSalonCommand = new RelayCommand(obj => 
                {
                    OpenEditSalonWindow(this, new EventArgs());
                    FillList();
                }));
            }
        }
        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
        private void OpenSalonViewWindow(object sender, EventArgs e)
        {
            View.Salon.SalonView userWind = new View.Salon.SalonView(SelectedSalon);
            SetCenterPositionAndOpen(userWind);

        }
        private void OpenSalaryTre(object sender, EventArgs e)
        {
            TresholdView userWind = new TresholdView();
            SetCenterPositionAndOpen(userWind);

        }
        private void OpenAddSalonWindow(object sender, EventArgs e)
        {
            View.AddSalon.AddSalonWindow window = new View.AddSalon.AddSalonWindow();
            SetCenterPositionAndOpen(window);

        }
        private void OpenEditSalonWindow(object sender, EventArgs e)
        {
            View.EditSalon.EditSalonWindow window = new View.EditSalon.EditSalonWindow(SelectedSalon);
            SetCenterPositionAndOpen(window);
        }
    }
}
