using Microsoft.EntityFrameworkCore;
using Salon;
using Salon.Models.Data;
using SalonApp.Models.Data;
using SalonApp.Services.Commands;
using SalonApp.Services.PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Windows;
using System.Net;
using SalonApp.View.DutyEdit;
using SalonApp.ViewModel.MainWindowViewModel;
using System.Diagnostics;
using SalonApp.Services.DbCommands;
using System.Threading;
using Microsoft.SqlServer.Management.Smo;
using System.Globalization;
using System.Windows.Controls;
using Calendar = System.Windows.Controls.Calendar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Security.Policy;

namespace SalonApp.View.Duty
{
    public class DutyVM : PropertyChangedBase
    {
        private List<SalonApp.Models.Data.Duty> _dutys;
        public List<SalonApp.Models.Data.Duty> Dutys
        {
            get => _dutys;
            set => Set(ref _dutys, value);
        }
        private List<SalonApp.Models.Data.Duty> _Tdutys;
        public List<SalonApp.Models.Data.Duty> TDutys
        {
            get => _Tdutys;
            set => Set(ref _Tdutys, value);
        }   
        private Salons _selectedSalon;
        public Salons SelectedSalon
        {
            get => _selectedSalon;
            set => Set(ref _selectedSalon,value);
        }
        private string _emailStatus;
        public string EmailStatus
        {
            get => _emailStatus;
            set => Set(ref _emailStatus, value);
        }
        
        private Users _loggedUser;
        public Users LoggedUser
        {
            get => _loggedUser;
            set => Set(ref _loggedUser, value);
        }
        private void FillList()
        {
            using(var db = new ApplDbContext())
            {
                Dutys = db.DutyT.
                    Include(el => el.User).
                    Where(el => el.Salon_Id == SelectedSalon.Id).
                    OrderByDescending(el => el.DutyDate).ToList();

                TDutys = db.DutyT.
                     Include(el => el.User).
                    Where(el => el.Salon_Id == SelectedSalon.Id).
                    OrderByDescending(el => el.DutyDate).ToList();
                SelectedMonth = DateTime.Today.Month;
                SelectedYear = DateTime.Today.Year;
            }
        }
        bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
        private RelayCommand _CloseDuty;
        public RelayCommand CloseDuty
        {
            get
            {
                return _CloseDuty ?? (_CloseDuty = new RelayCommand(async obj => 
                {
                    using(var db = new ApplDbContext())
                    {
                        try
                        {
                            if (SelectedDuty != null)
                            {
                                if (MessageBox.Show("Вы уверены что хотите закрыть смену?", "Подтвреждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                                {
                                    Models.Data.Duty 
                                        duty = db.DutyT.
                                        FirstOrDefault(el => el.DutyDate == SelectedDuty.DutyDate && el.Salon_Id == SelectedSalon.Id);

                                    if (duty != null)
                                    {
                                        IsEnabled = false;
                                        IsVisible = true;
                                        IsVisibility = Visibility.Visible;
                                        await Task.Run(() =>
                                        {
                                            Controller.Bench(SelectedSalon, db);
                                            Controller.CalculateEmployeesTotal(SelectedSalon, db);
                                            Controller.CalculcateAdminsTotal(SelectedSalon, db);
                                            if (duty.IsArrived == false)
                                            {
                                                MailAddress from = new MailAddress("loveis.zp007@gmail.com", "LZRobot");
                                                Employees[] empl = db.StatisticT.
                                                    Include(el => el.Employee).Include(EL => EL.Duty).ToList().
                                                    Where(el => el.Duty.Id == duty.Id && el.IsAdmin == false).
                                                    DistinctBy(el => el.Employee).
                                                    Select(el => el.Employee).ToArray();

                                                foreach (Employees item in empl)
                                                {
                                                    if (item.IsEmail == true)
                                                    {
                                                        Models.Data.Statistic stat = db.StatisticT
                                                            .FirstOrDefault(el => el.Employee_Id == item.Id && el.Duty_Id == duty.Id);

                                                        if (item.Email != null && IsValidEmail(item.Email))
                                                        {
                                                            MailAddress to = new MailAddress(item.Email);
                                                            MailMessage m = new MailMessage(from, to);
                                                            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                                                            smtp.Credentials = new NetworkCredential("loveis.zp007@gmail.com", "jjmfpvdeywyfruhf");
                                                            m.Subject = "Заработная плата";
                                                            if(stat.Salary != null && stat.Salary != 0)
                                                            {
                                                                m.Body = $"<h2> {item.FullName} за {duty.DutyDate} вы заработали {stat.Salary} злотых.</h2>";
                                                            }
                                                            else
                                                            {
                                                                m.Body = $"<h2> {item.FullName} за {duty.DutyDate} вы заработали {stat.Total} злотых.</h2>";

                                                            }
                                                            m.IsBodyHtml = true;
                                                            smtp.EnableSsl = true;
                                                            smtp.Send(m);
                                                            Thread.Sleep(500);
                                                        }
                                                    }
                                                }
                                                Employees[] admins = db.StatisticT.
                                                    Include(el => el.Employee).Include(EL => EL.Duty).ToList().
                                                    Where(el => el.Duty.Id == duty.Id && el.IsAdmin == true).
                                                    DistinctBy(el => el.Employee).
                                                    Select(el => el.Employee).ToArray();

                                                foreach (Employees item in admins)
                                                {
                                                    if (item.IsEmail == true)
                                                    {
                                                        Models.Data.Statistic stat = db.StatisticT.
                                                            FirstOrDefault(el => el.Employee_Id == item.Id && el.Duty_Id == duty.Id);
                                                        if (item.Email != null && IsValidEmail(item.Email))
                                                        {
                                                            MailAddress to = new MailAddress(item.Email);
                                                            MailMessage m = new MailMessage(from, to);
                                                            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                                                            smtp.Credentials = new NetworkCredential("loveis.zp007@gmail.com", "jjmfpvdeywyfruhf");
                                                            m.Subject = "Test";

                                                            m.Body = $"<h2> {item.FullName} за {duty.DutyDate} вы заработали {stat.BaseBid + stat.VirtualAdminBid + stat.Total} злотых.</h2>";
                                                            m.IsBodyHtml = true;
                                                            smtp.EnableSsl = true;
                                                            smtp.Send(m);
                                                            Thread.Sleep(500);
                                                        }
                                                    }
                                                }
                                                duty.IsArrived = true;
                                                db.SaveChanges();
                                                {
                                                    Models.Data.CashBox cashbox = db.CashBoxT.
                                                        Include(el=>el.Salon).
                                                        FirstOrDefault(el => el.SalonId == duty.Salon_Id);
                                                    MailAddress to = new MailAddress("kotvmeshke007@gmail.com");
                                                    MailMessage m = new MailMessage(from, to);
                                                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                                                    smtp.Credentials = new NetworkCredential("loveis.zp007@gmail.com", "jjmfpvdeywyfruhf");
                                                    m.Subject = "Test";
                                                    m.Body =
                                                    $"<h2> {cashbox.Salon.SalonName} за {duty.DutyDate} ИТОГ:\n " +
                                                    $"Наличка - {duty.CashPerDay}\n  " +
                                                    $"Безнал - {duty.NonCashPerDay} " +
                                                    $"Итого в кассе - {cashbox.amountCash}</h2>";
                                                    m.IsBodyHtml = true;
                                                    smtp.EnableSsl = true;
                                                    smtp.Send(m);
                                                }
                                                IsEnabled = true;
                                                IsVisible = false;
                                                IsVisibility = Visibility.Hidden;
                                                Controller.CreateBackUp("CloseDuty", true);
                                                MessageBox.Show("Сообщения успешно разосланы.\nСмена на текущий день успешно закрыта!");
                                            }
                                            else
                                            {
                                                MessageBox.Show("Смена уже закрыта!");
                                            }
                                        });
                                        IsEnabled = true;
                                        IsVisible = false;
                                        IsVisibility = Visibility.Hidden;
                                    }

                                }
                                else MessageBox.Show("Необходимо выбрать смену!");
                            }
    
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            IsEnabled = true;
                            IsVisible = false;
                            IsVisibility = Visibility.Hidden;
                        }
                        
                    }
                }));
            }
        }
        private RelayCommand _deleteDuty;
        public RelayCommand DeleteDuty
        {
            get
            {
                return _deleteDuty ?? (_deleteDuty = new RelayCommand(obj=>
                {
                    if (MessageBox.Show("Вы уверены что хотите удалить данную смену?\nВсе связанные записи будут удалены!", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        using (var db = new ApplDbContext())
                        {
                            var duty = db.DutyT.FirstOrDefault(el => el.Id == SelectedDuty.Id);
                            db.DutyT.Remove(duty);
                            db.SaveChanges();
                            FillList();
                            mainVM?.Upp();
                        }
                    }
           
                }));
            }
        }
        private RelayCommand _editDuty;
        public RelayCommand EditDuty
        {
            get
            {
                return _editDuty ?? (_editDuty = new RelayCommand(obj => 
                {
                    if(SelectedDuty != null)
                    {
                        using(var db = new ApplDbContext())
                        {
                            if(LoggedUser.UserType != "Директор")
                            {
                                string date = DateTime.Today.ToString("dd/MM/yyyy");
                                if(SelectedDuty.DutyDate != date)
                                    MessageBox.Show("В роли админа возможно редактировать только текущий день!");
                                else if(SelectedDuty.DutyDate == date)
                                {
                                    OpenSettingsWindow(this, new EventArgs());
                                    mainVM?.Upp3();
                                }
                            }
                            else if(LoggedUser.UserType == "Директор")
                            {
                                OpenSettingsWindow(this, new EventArgs());
                                mainVM?.Upp3();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выберите смену!");
                    }
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
            EditDuty wind = new EditDuty(SelectedDuty);
            SetCenterPositionAndOpen(wind);
        }
        private RelayCommand _changeStatus;
        public RelayCommand ChangeStatus
        {
            get
            {
                return _changeStatus ?? (_changeStatus = new RelayCommand(obj =>
                {
                    if (SelectedDuty.IsVirtualAdmin is true)
                    {
                        using (var db = new ApplDbContext())
                        {
                            var itemAdmin = db.StatisticT.Where(el => el.Duty.DutyDate == SelectedDuty.DutyDate).FirstOrDefault(el => el.Employee_Id == db.UsersT.First(el => el.Id == SelectedDuty.User_Id).Employee_Id);
                            var itemUser = db.UsersT.First(el => el.Id == SelectedDuty.User_Id);
                            var dut = db.DutyT.FirstOrDefault(el => el.Id == SelectedDuty.Id);
                            dut.IsVirtualAdmin = false;
                            itemAdmin.VirtualAdminBid = 0;
                            itemAdmin.IsVirtualAdmin = false;
                            db.SaveChanges();
                        }
                    }
                    else if (SelectedDuty.IsVirtualAdmin is false)
                    {
                        using (var db = new ApplDbContext())
                        {
                            var itemAdmin = db.StatisticT.Where(el => el.Duty.DutyDate == SelectedDuty.DutyDate).FirstOrDefault(el => el.Employee_Id == db.UsersT.First(el => el.Id == SelectedDuty.User_Id).Employee_Id);
                            var itemUser = db.UsersT.First(el => el.Id == SelectedDuty.User_Id);
                            var dut = db.DutyT.FirstOrDefault(el => el.Id == SelectedDuty.Id);
                            dut.IsVirtualAdmin = true;
                            itemAdmin.IsVirtualAdmin = true;
                            itemAdmin.VirtualAdminBid = (dut.IsVirtualAdmin ? (decimal)itemUser.VirtualAdminBid : 0);
                            db.SaveChanges();

                        }
                    }
                    FillList();
                }));
            }
        }
        private RelayCommand _openDutyCommand;
        public RelayCommand OpenDutyCommand
        {
            get
            {
                return _openDutyCommand ?? (_openDutyCommand = new RelayCommand(obj => 
                {
                    using (var db = new ApplDbContext())
                    {
                        string today = DateTime.Today.ToString("dd/MM/yyyy");
                        var isExist = db.DutyT.FirstOrDefault(el => el.DutyDate == today && el.Salon_Id == SelectedSalon.Id);
                        if (isExist != null)
                        {
                            MessageBox.Show("Смена на текущий день уже открыта!");
                        }
                        else
                        {
                            if (LoggedUser.UserType == "Админ" || LoggedUser.UserType == "Виртуальный админ" || LoggedUser.UserType == "Владелец" || LoggedUser.UserType == "Директор")
                            {
                                var dialog = MessageBox.Show($"Вы вошли под учетной записью " +
                                    $"{LoggedUser.NickName}, тип учетной записи {LoggedUser.UserType}.\nВы уверены что хотите открыть смену под текущим админом?\nИзменить админа будет невозможно.", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Information);
                                if (dialog == MessageBoxResult.Yes)
                                {
                                    Open();
                                }
                            }
                        }
                    }
                }));
            }
        }
        private async Task Open()
        {
            try
            {
                IsEnabled = false;
                IsVisible = true;
                IsVisibility = Visibility.Visible;
                await Task.Run(() =>
                {
                    using (var db = new ApplDbContext())
                    {
                        db.DutyT.Add(new Models.Data.Duty
                        {
                            DutyDate = DateTime.Today.ToString("dd/MM/yyyy"),
                            Salon_Id = SelectedSalon.Id,
                            User_Id = LoggedUser.Id,
                            IsVirtualAdmin = LoggedUser.UserType == "Виртуальный админ" ? true : false,
                            CashPerDay = 0,
                            NonCashPerDay = 0
                        }) ;
                        db.SaveChanges();
                        Thread.Sleep(500);
                    }
                });
                FillList();
                Application.Current.Dispatcher.Invoke(() =>
                {
                    mainVM?.Upp();
                });
                IsEnabled = true;
                IsVisible = false;
                IsVisibility = Visibility.Hidden;
                MessageBox.Show("Смена успешно открыта!");
            }
            catch(Exception ex)
            {
                IsEnabled = true;
                IsVisible = false;
                IsVisibility = Visibility.Hidden;
                MessageBox.Show(ex.Message);

            }
            
        }
        private Visibility _IsDeleteVisible;
        public Visibility IsDeleteVisible
        {
            get => _IsDeleteVisible;
            set => Set(ref _IsDeleteVisible, value);
        }
        private Models.Data.Duty _selectedDuty;
        public Models.Data.Duty SelectedDuty
        {
            get => _selectedDuty;
            set
            {
                Set(ref _selectedDuty, value);
                if (SelectedDuty != null)
                {
                    EmailStatus = SelectedDuty.IsArrived ? "Емейлы высланы!" : "Емейлы не высланы";
                }


            }
        }

        MainVM mainVM;
        private bool _isEnabled;
        public bool IsEnabled
        {
            get => _isEnabled;
            set => Set(ref _isEnabled, value);
        }
        private bool _isvisible;
        public bool IsVisible
        {
            get => _isvisible;
            set => Set(ref _isvisible, value);
        }
        private Visibility _isVisibility;
        public Visibility IsVisibility
        {
            get => _isVisibility;
            set => Set(ref _isVisibility, value);
        }
        private async Task LoadVM(Salons selectedSalon, Models.Data.Users loggedUser, MainVM v)
        {
            mainVM = v;
            SelectedSalon = selectedSalon;
            LoggedUser = loggedUser;
            if (loggedUser.UserType != "Директор")
                IsDeleteVisible = Visibility.Hidden;
            FillList();
        }

        private RelayCommand _selectedItemChanged;
        public RelayCommand SelectedItemChanged
        {
            get
            {
                return _selectedItemChanged ?? (_selectedItemChanged = new RelayCommand(obj => 
                {
                    try
                    {

                                Dutys = TDutys.Where(el =>
                            Convert.ToDateTime(el.DutyDate).Month == SelectedMonth && Convert.ToDateTime(el.DutyDate).Year == SelectedYear).ToList();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }));
            }
        }

        public async void Exec(Salons selectedSalon, Models.Data.Users loggedUser, MainVM v)
        {
            var task = LoadVM(selectedSalon, loggedUser, v);
            task.Wait();
            
        }
        private RelayCommand _onLoaded;
        public RelayCommand OnLoaded
        {
            get
            {
                return _onLoaded ?? (_onLoaded = new RelayCommand(obj => 
                {
                    Calendar calObj = obj as Calendar;
                    calObj.DisplayMode = CalendarMode.Year;

                    calObj.DisplayModeChanged += new EventHandler<CalendarModeChangedEventArgs>(Calendar_DisplayModeChanged);
                }));
            }
        }
        private int _selectedYear = 0;
        public int SelectedYear
        {
            get => _selectedYear;
            set 
            {
                Set(ref _selectedYear, value);
                Dutys = TDutys.Where(el => Convert.ToDateTime(el.DutyDate).Month == SelectedMonth && Convert.ToDateTime(el.DutyDate).Year == SelectedYear).ToList();
            }
        }
        private int _selectedMonth = 0;
        public int SelectedMonth
        {
            get => _selectedMonth;
            set => Set(ref _selectedMonth, value);
        }
        private void Calendar_DisplayModeChanged(object sender,
                                         CalendarModeChangedEventArgs e)
        {
            Calendar calObj = sender as Calendar;

            calObj.DisplayMode = CalendarMode.Year;
            var s = ((DateTime)calObj.DisplayDate);
            SelectedMonth = s.Month;
            SelectedYear = s.Year;
        }
        private Window window;
        public DutyVM(Salons selectedSalon, Models.Data.Users loggedUser, MainVM v,Window win)
        {
            window = win;
            SelectedSalon = selectedSalon;
            LoggedUser = loggedUser;
            mainVM = v;
            IsEnabled = false;
            IsVisible = true;
            IsVisibility = Visibility.Visible;
            Exec(SelectedSalon, LoggedUser, mainVM);

            IsEnabled = true;
            IsVisible = false;
            IsVisibility = Visibility.Hidden;
            DateTime _today = DateTime.Today;
            SelectedMonth = _today.Month;
            SelectedYear = _today.Year;
        }
    }
}
