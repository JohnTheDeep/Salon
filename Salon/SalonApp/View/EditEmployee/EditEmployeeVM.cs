using Salon.Models.Data;
using Salon;
using SalonApp.Models.Data;
using SalonApp.Services.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SalonApp.Services.PropertyChanged;
using Microsoft.EntityFrameworkCore;
using SalonApp.View.Settings.AddEnrollment;
using SalonApp.View.Settings.EditEnrollment;

namespace SalonApp.View.EditEmployee
{
    public class EditEmployeeVM : PropertyChangedBase
    {
        private Window window;
        private Ranks _selectedRank;
        public Ranks SelectedRank
        {
            get => _selectedRank;
            set => Set(ref _selectedRank, value);
        }
        private string _fullname;
        public string FullName
        {
            get => _fullname;
            set => Set(ref _fullname, value);
        }
        private List<Ranks> _ranks;
        public List<Ranks> Ranks
        {
            get => _ranks;
            set => Set(ref _ranks, value);
        }
        private string _email;
        public string Email
        {
            get => _email;
            set => Set(ref _email, value);
        }
        private decimal _ppackage;
        public decimal Ppackage
        {
            get => _ppackage;
            set => Set(ref _ppackage, value);
        }

        private decimal _paddit;
        public decimal Paddit
        {
            get => _paddit;
            set => Set(ref _paddit, value);
        }
        private decimal _pfictive;
        public decimal Pfictive
        {
            get => _pfictive;
            set => Set(ref _pfictive, value);
        }
        private decimal _bid;
        public decimal Bid
        {
            get => _bid;
            set => Set(ref _bid, value);
        }
        private decimal _entryTreshold;
        public decimal EntryTreshold
        {
            get => _entryTreshold;
            set => Set(ref _entryTreshold, value);
        }
        private decimal _psertificate;
        public decimal Psertificate
        {
            get => _psertificate;
            set => Set(ref _psertificate, value);
        }
        private Salons selectedSalon;
        private List<Employees> _empl;
        public List<Employees> Employees
        {
            get => _empl;
            set => Set(ref _empl, value);
        }
        private decimal _phandjob;
        public decimal Phandjob
        {
            get => _phandjob;
            set => Set(ref _phandjob, value);
        }
        private void FillList()
        {
            using (var db = new ApplDbContext())
            {
                Employees = db.EmployeesT.Include(el => el.Rank).Where(el => el.Salon_Id == selectedSalon.Id).ToList();
                Ranks = db.RanksT.ToList();
            }
        }
        private RelayCommand _save;
        public RelayCommand Save
        {
            get
            {
                return _save ?? (_save = new RelayCommand(obj =>
                {
                    if (FullName != "" && SelectedRank != null)
                    {
                        try
                        {
                            using (var db = new ApplDbContext())
                            {
                                var emp1 = db.EmployeesT.FirstOrDefault(el => el.Id == SelectedEmp.Id);
                                var rank = db.RanksT.FirstOrDefault(el => el.Id == SelectedRank.Id);
                                emp1.FullName = FullName;
                                emp1.Rank_Id = SelectedRank.Id;
                                emp1.Email = Email;
                                emp1.Ppackage = Ppackage;
                                emp1.Paddit = Paddit;
                                emp1.Pfictive = Pfictive;
                                emp1.Bid = Bid;
                                emp1.EntryTreshold = EntryTreshold;
                                emp1.Phandjob = Phandjob;
                                emp1.IsEmail = SelectedEmp.IsEmail;
                                db.SaveChanges();
                                window.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                    else { MessageBox.Show("Заполните все данные!"); }
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
                    if (SelectedEmp != null && SelectedEmp.FullName != "")
                    {
                        OpenAddEnrollment(this, new EventArgs());
                        FIllList();
                    }
                    else MessageBox.Show("Выберите мастера!");

                }));
            }
        }
        public void FIllList()
        {
            using (var db = new ApplDbContext())
            {
                SelectedEmp = db.EmployeesT.Include(el => el.Enrollments).Include(el => el.Services).Include(el => el.Rank).FirstOrDefault(el => el.Id == SelectedEmp.Id);
            }

        }
        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
        private void OpenAddEnrollment(object sender, EventArgs e)
        {
            AddEnrollmentWindow wind = new AddEnrollmentWindow(SelectedEmp);
            SetCenterPositionAndOpen(wind);
        }
        private Employees _selectedEmp;
        public Employees SelectedEmp
        {
            get => _selectedEmp;
            set => Set(ref _selectedEmp, value);
        }
        private RelayCommand _openEditServiceEmpCommand;
        public RelayCommand OpenEditServiceEmpCommand
        {
            get
            {
                return _openEditServiceEmpCommand ?? (_openEditServiceEmpCommand = new RelayCommand(obj =>
                {
                    if (SelectedEmp != null && SelectedEnrollment != null)
                    {
                        OpenEditEnrollWindow(this, new EventArgs());
                    }
                    else MessageBox.Show("Выберите мастера и (или) услугу");
                    FIllList();
                }));
            }
        }
        private Enrollment _selectedEnrollment;
        public Enrollment SelectedEnrollment
        {
            get => _selectedEnrollment;
            set
            {
                Set(ref _selectedEnrollment, value);
            }
        }
        private void OpenEditEnrollWindow(object sender, EventArgs e)
        {
            EditEnrollmentWindow wind = new EditEnrollmentWindow(SelectedEmp, (Enrollment)SelectedEnrollment);
            SetCenterPositionAndOpen(wind);
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
    public EditEmployeeVM(Window wind, Salons selected,Employees selectedEmp)
        {
            try
            {
                window = wind;
                selectedSalon = selected;
                using (var db = new ApplDbContext())
                {
                    SelectedEmp = db.EmployeesT.Include(el => el.Enrollments).Include(el => el.Services).Include(el => el.Rank).FirstOrDefault(el => el.Id == selectedEmp.Id);
                }

                FillList();
                FullName = selectedEmp.FullName;
                SelectedRank = selectedEmp.Rank;
                foreach (var v in Ranks)
                {
                    if (v.Id == selectedEmp.Rank_Id)
                    {
                        SelectedRank = v;
                    }
                }
                Email = selectedEmp.Email;
                Ppackage = selectedEmp.Ppackage;
                Paddit = selectedEmp.Paddit;
                Pfictive = selectedEmp.Pfictive;
                Bid = selectedEmp.Bid;
                EntryTreshold = selectedEmp.EntryTreshold;
                Phandjob = selectedEmp.Phandjob;
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
