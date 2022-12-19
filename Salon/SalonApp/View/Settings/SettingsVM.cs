using Microsoft.EntityFrameworkCore;
using Salon;
using Salon.Models.Data;
using SalonApp.Models.Data;
using SalonApp.Services.Commands;
using SalonApp.Services.PropertyChanged;
using SalonApp.View.AddRank;
using SalonApp.View.AddService;
using SalonApp.View.EditRank;
using SalonApp.View.Settings.AddEnrollment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalonApp.View.Settings
{
    public class SettingsVM : PropertyChangedBase
    {
        private List<SalonApp.Models.Data.Services> _serv;
        public List<SalonApp.Models.Data.Services> ServicesList
        {
            get => _serv;
            set => Set(ref _serv, value);
        }
        private List<Employees> _empl;
        public List<Employees> Employees
        {
            get => _empl;
            set => Set(ref _empl, value);
        }
        private List<Ranks> _ranks;
        public List<Ranks> Ranks
        {
            get => _ranks;
            set => Set(ref _ranks, value);
        }
        private Ranks _selectedRank;
        public Ranks SelectedRank
        {
            get => _selectedRank;
            set => Set(ref _selectedRank,value);
        }
        private RelayCommand _openAddRankWindowCommand;
        public RelayCommand OpenAddRankWindowCommand
        {
            get 
            {
                return _openAddRankWindowCommand ?? (_openAddRankWindowCommand = new RelayCommand(obj => 
                {
                    if (SelectedRank != null)
                    {
                        OpenAddRankWindow(this, new EventArgs());
                    }
                    else MessageBox.Show("Выберите должность");
                    FIllList();
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
            EditRankWindow wind = new EditRankWindow(SelectedRank);
            SetCenterPositionAndOpen(wind);
        }
        private void OpenAddRankWindow(object sender, EventArgs e)
        {
            AddRank.AddRankWindow wind = new AddRank.AddRankWindow();
            SetCenterPositionAndOpen(wind);
        }
        private void OpenAddEnrollment(object sender, EventArgs e)
        {
            AddEnrollmentWindow wind = new AddEnrollmentWindow(SelectedEmployee);
            SetCenterPositionAndOpen(wind);
        }
        private RelayCommand _deleteRankCommand;
        public RelayCommand DeleteRankCommand
        {
            get
            {
                return _deleteRankCommand ?? (_deleteRankCommand = new RelayCommand(obj =>
                {
                var dialog = MessageBox.Show("Вы действительно хотите удалить выбранную должность?\nВсе связанные данные будут удалены!", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (dialog == MessageBoxResult.Yes)
                {
                    if (SelectedRank != null)
                    {
                        using (var db = new ApplDbContext())
                            {
                                db.EmployeesT.Select(el => el).Where(el => el.Rank_Id == SelectedRank.Id).ToList().ForEach(el => el.Rank_Id = null);
                                db.SaveChanges();
                                db.RanksT.Remove(SelectedRank);
                                db.SaveChanges();
                            }
                        }
                    else MessageBox.Show("Выберите должность");
                    FIllList();
                    }

                }));
            }
        }
        
        private RelayCommand _openAddServiceEmpCommand;
        public RelayCommand OpenAddServiceEmpCommand
        {
            get
            {
                return _openAddServiceEmpCommand ?? (_openAddServiceEmpCommand = new RelayCommand(obj =>
                {
                    if (SelectedEmployee != null && SelectedEmployee.FullName != "")
                    {
                        OpenAddEnrollment(this, new EventArgs()); FIllList();
                    }
                    else MessageBox.Show("Выберите мастера!");
                    
                }));
            }
        }
        private RelayCommand _openEditRankWindowCommand;
        public RelayCommand OpenEditRankWindowCommand
        {
            get
            {
                return _openEditRankWindowCommand ?? (_openEditRankWindowCommand = new RelayCommand(obj =>
                {
                    if (SelectedRank != null && SelectedRank.RankName !="")
                    {
                        OpenServiceWindow(this, new EventArgs());
                    }
                    else MessageBox.Show("Выберите должность");
                    FIllList();
                }));
            }
        }
       
        public void FIllList()
        {
            using(var db = new ApplDbContext())
            {
                Ranks = db.RanksT.ToList();
                Employees = db.EmployeesT.Include(el => el.Rank).Where(el => el.IsAdmin == false && el.Salon_Id == SelectedSalon.Id).ToList();
            }
        }
        public void FillListServ()
        {
            using (var db = new ApplDbContext())
            {
                ServicesList = db.ServicesT.Include(empa => empa.Employees).ThenInclude(el => el.Enrollments).Where(el => el.Id == SelectedEmployee.Id).ToList();
            }
        }
        
        private Salons _selectedSalon;
        public Salons SelectedSalon
        {
            get => _selectedSalon;
            set => Set(ref _selectedSalon,value);
        }
        private Employees _selectedEmployee;
        public Employees SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                Set(ref _selectedEmployee, value); 
                FillListServ();
            }
        }
        public SettingsVM(Salons selected)
        {
            SelectedSalon = selected;

            FIllList();
        }
    }
}
