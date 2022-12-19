using Microsoft.EntityFrameworkCore;
using Salon;
using Salon.Models.Data;
using SalonApp.Models.Data;
using SalonApp.Services.Commands;
using SalonApp.Services.PropertyChanged;
using SalonApp.View.AddRank;
using SalonApp.View.AddReminde;
using SalonApp.View.AddService;
using SalonApp.View.EditRank;
using SalonApp.View.Settings.AddEnrollment;
using SalonApp.View.Settings.EditEnrollment;
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
        private SalonApp.Models.Data.Services _selectedService;
        public SalonApp.Models.Data.Services SelectedService
        {
            get => _selectedService;
            set => Set(ref _selectedService, value);
        }
        
        private RelayCommand _openEditServiceEmpCommand;
        public RelayCommand OpenEditServiceEmpCommand
        {
            get 
            {
                return _openEditServiceEmpCommand ?? (_openEditServiceEmpCommand = new RelayCommand(obj => 
                {
                    if (SelectedEmployee != null && SelectedEnrollment != null)
                    {
                        OpenEditEnrollWindow(this, new EventArgs());
                    }
                    else MessageBox.Show("Выберите мастера и (или) услугу");
                    FIllList();
                }));
            }
        }
        private RelayCommand _openAddRankWindowCommand;
        public RelayCommand OpenAddRankWindowCommand
        {
            get 
            {
                return _openAddRankWindowCommand ?? (_openAddRankWindowCommand = new RelayCommand(obj => 
                {

                    OpenAddRankWindow(this, new EventArgs());
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
        private void OpenEditEnrollWindow(object sender, EventArgs e)
        {
            EditEnrollmentWindow wind = new EditEnrollmentWindow(SelectedEmployee,(Enrollment)SelectedEnrollment);
            SetCenterPositionAndOpen(wind);
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
        private void OpenAddReminders(object sender, EventArgs e)
        {
            AddReminderWindow wind = new AddReminderWindow();
            SetCenterPositionAndOpen(wind);
        }
        private RelayCommand _deleteEmployees;
        public RelayCommand DeleteEmployees
        {
            get
            {
                return _deleteEmployees ?? (_deleteEmployees = new RelayCommand(obj =>
                {
                    if (MessageBox.Show("Вы действительно хотите удалить выбранную услугу?\nВсе связанные данные будут удалены!", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        if (SelectedEmployee != null)
                        {
                            using (var db = new ApplDbContext())
                            {
                                Employees enrl = db.EmployeesT.FirstOrDefault(el => el.Id == SelectedEmployee.Id);
                                db.EmployeesT.Remove(enrl);
                                db.SaveChanges();
                            }
                        }
                        else MessageBox.Show("Выберите сотрудника");
                        FIllList();
                    }

                }));
            }
        }
        private RelayCommand _deleteEmployeeService;
        public RelayCommand DeleteEmployeeService
        {
            get
            {
                return _deleteEmployeeService ?? (_deleteEmployeeService = new RelayCommand(obj =>
                {
                    if (MessageBox.Show("Вы действительно хотите удалить выбранную услугу?\nВсе связанные данные будут удалены!", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        if (SelectedEnrollment != null)
                        {
                            using (var db = new ApplDbContext())
                            {
                                Enrollment enrl = db.Enrollments.FirstOrDefault(el => el.Id == SelectedEnrollment.Id);
                                db.Enrollments.Remove(enrl);
                                db.SaveChanges();
                            }
                        }
                        else MessageBox.Show("Выберите услугу");
                        FIllList();
                    }

                }));
            }
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
        private RelayCommand _deleteReminder;
        public RelayCommand DeleteReminder
        {
            get
            {
                return _deleteReminder ?? (_deleteReminder = new RelayCommand(obj =>
                {
                    var dialog = MessageBox.Show("Вы действительно хотите удалить выбранное напоминание?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (dialog == MessageBoxResult.Yes)
                    {
                        if (SelectedReminder != null)
                        {
                            using (var db = new ApplDbContext())
                            {
                                db.ReminderT.Remove(SelectedReminder);
                                db.SaveChanges();
                                FillReminders();
                            }
                        }
                        else MessageBox.Show("Выберите напоминание");
                    }

                }));
            }
        }
        private RelayCommand _openAddReminder;
        public RelayCommand OpenAddReminder
        {
            get
            {
                return _openAddReminder ?? (_openAddReminder = new RelayCommand(obj =>
                {
                    if (SelectedSalon != null)
                    {
                        OpenAddReminders(this, new EventArgs());
                        FillReminders();
                    }
                    else MessageBox.Show("Выберите салон!");

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
            using (var db = new ApplDbContext())
            {
                var query = db.EmployeesT.Include(el => el.Rank).Include(el => el.Enrollments).Include(el => el.Services).ToList();
                Employees = query.Select(el => el).Where(el => el.IsAdmin == false && el.Salon_Id == SelectedSalon.Id).ToList();
            }
        }
        public void FillListServ()
        {
            using (var db = new ApplDbContext())
            {
                if(SelectedEmployee != null)
                    ServicesList = (db.Enrollments.Include(el => el.Employee).ThenInclude(el => el.Services).ToList().Where(el => el.EmployeeId == SelectedEmployee?.Id)).Select(el => el.Service).ToList();
            }
        }
        private Enrollment _selectedEnrollment;
        public Enrollment SelectedEnrollment
        {
            get => _selectedEnrollment;
            set
            {
                Set(ref _selectedEnrollment, value);
                FillListServ();
            }
        }
        private List<Reminder> _reminders;
        public List<Reminder> Reminders
        {
            get => _reminders;
            set
            {
                Set(ref _reminders, value);
            }
        }
        private Reminder _selectedReminder;
        public Reminder SelectedReminder
        {
            get => _selectedReminder;
            set => Set(ref _selectedReminder, value);
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
            FillReminders();
        }
        private void FillReminders()
        {
            using (var db = new ApplDbContext())
            {
                Reminders = db.ReminderT.Include(el=>el.Salon).ToList();
            }
        }
    }
}
