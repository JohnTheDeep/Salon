using Microsoft.EntityFrameworkCore;
using Salon;
using Salon.Models.Data;
using Salon.UserControls;
using SalonApp.Models.Data;
using SalonApp.Services.Commands;
using SalonApp.Services.DbCommands;
using SalonApp.Services.PropertyChanged;
using SalonApp.View.AddService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serv = SalonApp.Models.Data;
using System.Windows;
using System.Windows.Controls;
using SalonApp.View.Duty;
using SalonApp.View.AddEmployee;
using SalonApp.View.EditAdmin;
using SalonApp.View.Settings;
using SalonApp.View.EditEmployee;

namespace SalonApp.ViewModel.MainWindowViewModel
{
    internal class MainVM : PropertyChangedBase
    {
        
        private Employees _selectedEmployee;
        public Employees selectedEmployee
        {
            get => _selectedEmployee;
            set => Set(ref _selectedEmployee, value);
        }
        private Users _selectedUser;
        public Users SelectedUser
        {
            get => _selectedUser;
            set => Set(ref _selectedUser, value);
        }
        private List<Users> _admins;
        public List<Users> Admins
        {
            get => _admins;
            set => Set(ref _admins, value);
        }
        public ObservableCollection<object> ViewList { get; set; } = new ObservableCollection<object>();
        private List<ServiceBlock> _blocks;
        public List<ServiceBlock> Blocks
        {
            get => _blocks;
            set => Set(ref _blocks, value);
        }
        private List<Salon_Service> _list;
        public List<Salon_Service> List
        {
            get => _list;
            set => Set(ref _list, value);
        }
        private List<Employees> _employees;
        public List<Employees> Employees
        {
            get => _employees;
            set => Set(ref _employees, value);
        }
        private Users _loggedUser;
        public Users LoggedUser
        {
            get => _loggedUser;
            set => Set(ref _loggedUser, value);
        }
        private Salons _selectedSalon;
        public Salons SelectedSalon
        {
            get => _selectedSalon;
            set => Set(ref _selectedSalon, value);
        }
        private void FillList()
        {
            ViewList.Clear();
            foreach(var item in Controller.GetAllSalonServicess(SelectedSalon.Id))
            {
                ViewList.Add(new ServiceBlock(SelectedSalon, item.Service));
            }
            using(var db = new ApplDbContext())
            {
                var query = db.EmployeesT.Include(el => el.Rank).ToList();
                Employees = query.Select(el => el).Where(el => el.IsAdmin == false && el.Salon_Id == SelectedSalon.Id).ToList();
            }
            using(var db = new ApplDbContext())
            {
                Admins = db.UsersT.Include(el => el.Employee).ToList().Where(el => el.Employee.Salon_Id == SelectedSalon.Id).ToList();
            }

        }
        public MainVM(Users loggedUser,Salons selectedSalon)
        {
            LoggedUser = loggedUser;
            SelectedSalon = selectedSalon;
            FillList();

        }
        private RelayCommand _openEditEmployeeWindow;
        public RelayCommand OpenEditEmployeeWindow
        {
            get
            {
                return _openEditEmployeeWindow ?? (_openEditEmployeeWindow = new RelayCommand(obj =>
                {
                    OpenEditEmployee(this, new EventArgs());
                    FillList();
                }));
            }
        }
        private RelayCommand _openSettingsWindowCommand;
        public RelayCommand OpenSettingsWindowCommand
        {
            get
            {
                return _openSettingsWindowCommand ?? (_openSettingsWindowCommand = new RelayCommand(obj =>
                {
                    OpenSettingsWindow(this, new EventArgs());
                }));
            }
        }
        private RelayCommand _openDutyWindowCommand;
        public RelayCommand OpenDutyWindowCommand
        {
            get
            {
                return _openDutyWindowCommand ?? (_openDutyWindowCommand = new RelayCommand(obj =>
                {
                 OpenDutyView(this, new EventArgs());
                }));
            }
        }
        private RelayCommand _openAddEmployeeWindow;
        public RelayCommand OpenAddEmployeeWindow
        {
            get
            {
                return _openAddEmployeeWindow ?? (_openAddEmployeeWindow = new RelayCommand(obj =>
                {
                    OpenAddEmployee(this, new EventArgs());
                    FillList();
                }));
            }
        }
        private RelayCommand _openActivityEmployeesWindowCommand;
        public RelayCommand OpenActivityEmployeesWindowCommand
        {
            get
            {
                return _openActivityEmployeesWindowCommand ?? (_openActivityEmployeesWindowCommand = new RelayCommand(obj =>
                {
                    OpenActiveEmployeesView(this, new EventArgs());
                    FillList();
                }));
            }
        }
        
        private RelayCommand _openEditAdminCommand;
        public RelayCommand OpenEditAdminCommand
        {
            get
            {
                return _openEditAdminCommand ?? (_openEditAdminCommand = new RelayCommand(obj =>
                {
                    if (SelectedUser != null)
                    {

                        OpenEditAdmin(this, new EventArgs());

                    }
                    else MessageBox.Show("Выберите админа!");
                    FillList();
                }));
            }
        }
        private void OpenEditAdmin(object sender, EventArgs e)
        {
            EditAdminWindow wind = new EditAdminWindow(SelectedUser);
            SetCenterPositionAndOpen(wind);
        }
        private RelayCommand _openActivateServiceWindowCommand;
        public RelayCommand OpenActivateServiceWindowCommand
        {
            get
            {
                return _openActivateServiceWindowCommand ?? (_openActivateServiceWindowCommand = new RelayCommand(obj =>
                {
                    OpenSalonServicesView(this, new EventArgs());
                    FillList();
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
                    OpenServiceWindow(this,new EventArgs());
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
        private void OpenSettingsWindow(object sender, EventArgs e)
        {
            SettingsWindow wind = new SettingsWindow(SelectedSalon);
            SetCenterPositionAndOpen(wind);
        }
        private void OpenEditEmployee(object sender, EventArgs e)
        {
            EditEmployeeWindow wind = new EditEmployeeWindow(SelectedSalon,selectedEmployee);
            SetCenterPositionAndOpen(wind);
        }
        private void OpenServiceWindow(object sender, EventArgs e)
        {
            AddServiceWindow wind = new AddServiceWindow(SelectedSalon);
            SetCenterPositionAndOpen(wind);
        }
        private void OpenSalonServicesView(object sender, EventArgs e)
        {
            View.SalonServicesView.SalonServicesWindow wind = new View.SalonServicesView.SalonServicesWindow(SelectedSalon);
            SetCenterPositionAndOpen(wind);
        }
        private void OpenActiveEmployeesView(object sender, EventArgs e)
        {
            View.ActiveEmployees.ActiveEmployeesWindow wind = new View.ActiveEmployees.ActiveEmployeesWindow(SelectedSalon);
            SetCenterPositionAndOpen(wind);
        }
        private void OpenAddEmployee(object sender, EventArgs e)
        {
            AddEmployee wind = new AddEmployee(SelectedSalon);
            SetCenterPositionAndOpen(wind);
        }
        private void OpenDutyView(object sender, EventArgs e)
        {
            DutyView wind = new DutyView(SelectedSalon,LoggedUser);
            SetCenterPositionAndOpen(wind);
        }
        public MainVM() {
            FillList();
            
        }
    }
}
