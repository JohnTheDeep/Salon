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
using SalonApp.View.Additionaly;
using SalonApp.View.JournalView;
using System.Diagnostics;
using System.Reflection;
using ReportViewerProject;
using ReportViewerProject.Reports;
using SalonApp.View.AddLess;
using SalonApp.View.AddAvancie;
using SalonApp.View.CashBox;
using SalonApp.View.EditLess;
using System.ComponentModel;
using System.Threading;
using System.Windows.Media;
using Salon.View.Salary;
using SalonApp.View.EditAvac;
using System.Windows.Documents;
using System.Globalization;
using SalonApp.View.Incomming;
using BenchmarkDotNet.Attributes;
using System.Windows.Markup;
using BenchmarkDotNet.Running;
using Calendar = System.Windows.Controls.Calendar;
using Microsoft.Data.SqlClient;

namespace SalonApp.ViewModel.MainWindowViewModel
{
    public class MainVM : PropertyChangedBase
    {
        private List<StatisticDTO> _statisticList;
        public List<StatisticDTO> StatisticList
        {
            get => _statisticList;
            set => Set(ref _statisticList, value);
        }
        private object _statisticSelectedDate;
        public object StatisticSelectedDate
        {
            get => _statisticSelectedDate;
            set
            {
                Set(ref _statisticSelectedDate, value);
                FillStatisticList(); 

            }
        }
        private string _dateStat;
        public string DateStat
        {
            get => _dateStat;
            set => Set(ref _dateStat, value);
        }
        private void FillStatisticList()
        {
            try
            {
                using (var db = new ApplDbContext())
                {
                    StatisticList = new List<StatisticDTO>();
                    DateStat = StatisticSelectedDate is null ? DateTime.Today.ToString("dd/MM/yyyy") : ((DateTime)StatisticSelectedDate).ToString("dd/MM/yyyy");
                    foreach (var item in db.StatisticT.Include(el => el.Duty).Include(el => el.Employee).Where(el => el.Duty.DutyDate == DateStat && el.Duty.Salon_Id == SelectedSalon.Id).ToList())
                    {
                        StatisticList.Add(new StatisticDTO { Stat = item, Total = item.Total + item.BaseBid + item.VirtualAdminBid });
                    }
                    StatDuty = db.DutyT.Include(el => el.User).ThenInclude(el => el.Employee).FirstOrDefault(el => el.DutyDate == DateStat);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private List<Lesses> _lessHistory;
        public List<Lesses> LessHistory
        {
            get => _lessHistory;
            set => Set(ref _lessHistory, value);
        }
        private List<Lesses> _lessesList;
        public List<Lesses> LessesList
        {
            get => _lessesList;
            set => Set(ref _lessesList, value);
        }
        private SalonApp.Models.Data.Services _selectedReportSService;
        public SalonApp.Models.Data.Services SelectedReportSService
        {
            get => _selectedReportSService;
            set => Set(ref _selectedReportSService, value);
        }
        
        private Ranks _selectedReportRank;
        public Ranks SelectedReportRank
        {
            get => _selectedReportRank;
            set => Set(ref _selectedReportRank, value);
        }
        


        private DateTime _selectedDateInAdminReport = DateTime.Today;
        public DateTime SelectedDateInAdminReport
        {
            get => _selectedDateInAdminReport;
            set => Set(ref _selectedDateInAdminReport, value);
        }
        private DateTime _selectedDateOutAdminReport = DateTime.Today;
        public DateTime SelectedDateOutAdminReport
        {
            get => _selectedDateOutAdminReport;
            set => Set(ref _selectedDateOutAdminReport, value);
        }


        private DateTime _selectedReportRankDateIn = DateTime.Today;
        public DateTime SelectedReportRankDateIn
        {
            get => _selectedReportRankDateIn;
            set => Set(ref _selectedReportRankDateIn, value);
        }
        private DateTime _selectedReportRankDateOut = DateTime.Today;
        public DateTime SelectedReportRankDateOut
        {
            get => _selectedReportRankDateOut;
            set => Set(ref _selectedReportRankDateOut, value);
        }

        private DateTime _selectedReportESDateOut = DateTime.Today;
        public DateTime SelectedReportESDateOut 
        {
            get => _selectedReportESDateOut;
            set => Set(ref _selectedReportESDateOut, value);
        }
        private DateTime _selectedReportESDateIn = DateTime.Today;
        public DateTime SelectedReportESDateIn
        {
            get => _selectedReportESDateIn;
            set => Set(ref _selectedReportESDateIn, value);
        }
        private DateTime _selectedReportSDateOut = DateTime.Today;
        public DateTime SelectedReportSDateOut
        {
            get => _selectedReportSDateOut;
            set => Set(ref _selectedReportSDateOut, value);
        }
        private DateTime _selectedReportSDateIn= DateTime.Today;
        public DateTime SelectedReportSDateIn
        {
            get => _selectedReportSDateIn;
            set => Set(ref _selectedReportSDateIn, value);
        }
        private List<Serv.Services> reportServ2;
        public List<Serv.Services> ReportServ2
        {
            get => reportServ2;
            set => Set(ref reportServ2, value);
        }
        private Employees _selectedReportEmployee;
        public Employees SelectedReportEmployee
        {
            get => _selectedReportEmployee;
            set 
            {
                Set(ref _selectedReportEmployee, value);
                try
                {
                    using (var db = new ApplDbContext())
                    {
                        List<Serv.Services> va = new List<Serv.Services>();
                        ReportServices = new List<Serv.Services>();
                        if(SelectedReportEmployee != null)
                        {
                            foreach (var v in db.Enrollments.Include(el => el.Service).Where(el => el.EmployeeId == SelectedReportEmployee.Id).ToList().DistinctBy(el => el.Service.ServiceType).ToList())
                            {
                                va.Add(v.Service);
                            }
                            ReportServices = va;
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private Employees _selectedEmployees;
        public Employees SelectedEmployees
        {
            get => _selectedEmployees;
            set => Set(ref _selectedEmployees, value);
        }

        private  SalonApp.Models.Data.Services _selectedReportService;
        public SalonApp.Models.Data.Services SelectedReportService
        {
            get => _selectedReportService;
            set => Set(ref _selectedReportService, value);
        }
        
        private List<Employees> _reportEmployees;
        public List<Employees> ReportEmployees
        {
            get => _reportEmployees;
            set => Set(ref _reportEmployees, value);
        }
        private List<SalonApp.Models.Data.Services> _reportServices;
        public List<SalonApp.Models.Data.Services> ReportServices
        {
            get => _reportServices;
            set => Set(ref _reportServices, value);
        }
        private List<SalonApp.Models.Data.Ranks> _reportRanks;
        public List<SalonApp.Models.Data.Ranks> ReportRanks
        {
            get => _reportRanks;
            set => Set(ref _reportRanks, value);
        }
        private void FillLessHistory()
        {
            using (var db = new ApplDbContext())
            {
                LessHistory = db.LessesT.Include(el => el.Duty).Where(el => el.Duty.Salon_Id == SelectedSalon.Id).ToList();
                CashBoxOperationsList = db.CashBoxOperationsT.Include(el => el.CashBox).Where(el => el.CashBox.SalonId == SelectedSalon.Id).ToList();
            }
        }
        private void FillReportCombo()
        {
            using (var db = new ApplDbContext())
            {
                ReportEmployees = db.EmployeesT.Include(el => el.Salon).Where(el => el.Salon_Id == SelectedSalon.Id && el.IsAdmin == false).ToList();
                ReportRanks = db.RanksT.ToList();
                ReportServices = db.ServicesT.ToList();
                ReportServ2 = db.ServicesT.ToList();
                ReportAdmins = db.EmployeesT.Include(el => el.Salon).Where(el => el.Salon_Id == SelectedSalon.Id && el.IsAdmin == true).ToList();
            }

        }
        private Employees _selectedEmployee;
        public Employees selectedEmployee
        {
            get => _selectedEmployee;
            set => Set(ref _selectedEmployee, value);
        }
        private List<Statistic> _adminUserStatisticList;
        public List<Statistic> AdminUserStatisticList
        {
            get => _adminUserStatisticList;
            set => Set(ref _adminUserStatisticList, value);
        }
        private Employees admin;
        public Employees Admin
        {
            get => admin;
            set => Set(ref admin, value);
        }
        private object _selectedDate;
        public Object SelectedDate
        {
            get => _selectedDate;
            set
            {
                Set(ref _selectedDate, value);
                using(var db = new ApplDbContext())
                {
                    FillAnother(db);
                }

            }
        }
        public delegate void CheckAdminDelegate();
        private object _selectedDate2;
        public event EventHandler evnt;
        public Object SelectedDate2
        {
            get => _selectedDate2;
            set
            {
                Set(ref _selectedDate2, value);
                UpdateAnother();
                UpdateCheck();
                Update();
            }
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
        private ObservableCollection<object> _viewList;

        public ObservableCollection<object> ViewList
        {
            get => _viewList;
            set
            {
                Set(ref _viewList, value);
            }
        }
        public ObservableCollection<object> ViewList2 { get; set; } = new ObservableCollection<object>();
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
        private decimal _adminTotal;
        public decimal AdminTotal
        {
            get => _adminTotal;
            set => Set(ref _adminTotal, value);
        }

        private void FillAv()
        {
            using (var db = new ApplDbContext())
            {
                ListA = db.AvanciesT.Include(el => el.Employee).Where(el => el.Employee.Salon_Id == SelectedSalon.Id).ToList();
            }

        }
        private BackgroundWorker backgroundWorker6 = new BackgroundWorker();
        private void backgroundWorker6_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                StartAnimation();
                using (var db = new ApplDbContext())
                {
                    Controller.Bench(SelectedSalon, db);

                    FillCashBox(db);
                    FillLessesHistory(db);
                    FillReportCombo(db);
                    
                }
                StopAnimation();
            }
            catch(Exception ex)
            {
                StopAnimation();
                MessageBox.Show(ex.Message);
            }

        }
        private void FillIncommingStatistic(ApplDbContext db)
        {
            if(Duty != null)
            CurrentIncomming = db.IncommingsT.Include(el => el.CashBox).
                    Where(el => el.CashBox.SalonId == SelectedSalon.Id && el.Type == "Наличка" && el.When == Duty.DutyDate).
                    Sum(el => el.Total);
        }
        private BackgroundWorker backgroundWorker9 = new BackgroundWorker();
        private Duty _serviceDuty;
        public Duty ServiceDuty
        {
            get => _serviceDuty;
            set => Set(ref _serviceDuty, value);
        }
        private void FillAnother(ApplDbContext db)
        {
            string date = SelectedDate is null ?
                    DateTime.Today.ToString("dd/MM/yyyy") : ((DateTime)SelectedDate).ToString("dd/MM/yyyy");

            string date2 = SelectedDate2 is null ?
                DateTime.Today.ToString("dd/MM/yyyy") : ((DateTime)SelectedDate2).ToString("dd/MM/yyyy");

            string today = DateTime.Today.ToString("dd/MM/yyyy");

            Journal[] journals = db.JournalT.
                Include(EL => EL.Employee).
                Include(EL => EL.Service).
                Include(EL => EL.Duty).
                Where(el => el.Duty.DutyDate == date && el.Duty.Salon_Id == SelectedSalon.Id).ToArray();

            AdminUserStatisticList = new List<Statistic>();

            foreach (Statistic _statisticItem in db.StatisticT.
                Include(el => el.Duty).
                Include(el => el.Employee).
                Where(el => el.IsAdmin == true && el.Duty.DutyDate == date2 && el.Duty.Salon_Id == SelectedSalon.Id))
            {
                AdminUserStatisticList.Add(_statisticItem);
            }

            Admin = AdminUserStatisticList.FirstOrDefault()?.Employee;

            Duty = db.DutyT.
                Include(el => el.Statistics).
                Include(el => el.Salon).
                Include(el => el.User).
                Include(el => el.Journals).
                ThenInclude(el => el.Service).
                FirstOrDefault(el => el.DutyDate == today && el.Salon_Id == SelectedSalon.Id);
            List<Journal> temporaryJournal = new List<Journal>();
            List<DutyStat> dutyStatistic = new List<DutyStat>();

            foreach (Journal item in journals.DistinctBy(el => new { el.Service.ServiceName, el.Employee_id }))
            {
                foreach (Journal i in journals)
                {
                    if (i.Service.ServiceName == item.Service.ServiceName && i.Employee_id == item.Employee_id && i.Duty.DutyDate == date)
                    {
                        temporaryJournal = new List<Journal>();
                        temporaryJournal.Add(i);
                        dutyStatistic.Add(new Serv.DutyStat
                        {
                            ServicesId = i.Service.Id,
                            Service = i.Service,
                            EmployeeId = i.Employee.Id,
                            Employee = i.Employee,
                            Journals = temporaryJournal,
                            TotalCash = i.Cash,
                            TotalNonCash = i.NonCash,
                            TotalFictive = i.Fictive
                        });
                    }
                }
            }
            decimal totalCash = 0, totalNonCash = 0, TotalFictive = 0, totalSert = 0;
            List<DutyStat> dutyDistinctStatistic = new List<DutyStat>();
            foreach (var item in dutyStatistic.DistinctBy(el => new { el.EmployeeId, el.Service.Id }))
            {
                foreach (var i in item.Journals)
                {
                    totalCash += i.Cash;
                    totalNonCash += i.NonCash;
                    TotalFictive += i.Fictive;
                    totalSert += i.Sertificate;
                }
                dutyDistinctStatistic.Add(new Serv.DutyStat
                {
                    Journals = item.Journals,
                    ServicesId = item.ServicesId,
                    Service = item.Service,
                    EmployeeId = item.EmployeeId,
                    Employee = item.Employee,
                    TotalCash = totalCash,
                    TotalNonCash = totalNonCash,
                    TotalFictive = TotalFictive,
                    TotalSertificates = totalSert
                });
            }
            DutyStat[] _dutyDistStat = dutyDistinctStatistic.ToArray();
            string date3 = SelectedDate is null ?
                DateTime.Today.ToString("dd/MM/yyyy") : ((DateTime)SelectedDate).ToString("dd/MM/yyyy");

            Duty _duty = db.DutyT.
                Include(el => el.Statistics).
                Include(el => el.Salon).
                Include(el => el.User).
                ThenInclude(el=>el.Employee).
                Include(el => el.Journals).
                ThenInclude(el => el.Service).
                FirstOrDefault(el => el.DutyDate == date3 && el.Salon_Id == SelectedSalon.Id);
            ServiceDuty = db.DutyT.
                Include(el => el.Statistics).
                Include(el => el.Salon).
                Include(el => el.User).
                ThenInclude(el => el.Employee).
                Include(el => el.Journals).
                ThenInclude(el => el.Service).
                FirstOrDefault(el => el.DutyDate == date && el.Salon_Id == SelectedSalon.Id);

            int[] _array = dutyDistinctStatistic.
                DistinctBy(el => el.ServicesId).
                Select(el => el.ServicesId).
                ToArray();

            Application.Current.Dispatcher.Invoke(() =>
            {
                ViewList2.Clear();

                foreach (int item in _array)
                {
                    ViewList2.Add(
                        new CheckBlock(_dutyDistStat.Where(el => el.ServicesId == item).ToArray(), _duty, SelectedSalon));
                }
            });
        }
        private void FillCheck(ApplDbContext db)
        {
            string fillcheckDate = SelectedDate2 is null ?
                    DateTime.Today.ToString("dd/MM/yyyy") : ((DateTime)SelectedDate2).ToString("dd/MM/yyyy");

            ListOfAdditional = new List<Additional>();

            foreach (Additional _additionalItem in db.AdditionalsT.
                Include(el => el.User).
                Where(el => el.Duty.DutyDate == fillcheckDate))
            {
                ListOfAdditional.Add(_additionalItem);
            }

            foreach (Additional _additionalItem in db.AdditionalsT.
                Include(el => el.User).
                Where(el => el.Duty.DutyDate == fillcheckDate && el.User.Id == LoggedUser.Id))
            {
                TotalAdditNonCashPerDay += _additionalItem.NonCash;
                TotalAdditCashPerDay += _additionalItem.Cash;
            }
        }
        private void CheckAdminTotalAddit(ApplDbContext db)
        {
            string checkAdminTotalAddit = SelectedDate2 is null ?
                DateTime.Today.ToString("dd/MM/yyyy") : ((DateTime)SelectedDate2).ToString("dd/MM/yyyy");
            AdminTotalAddit = 0;

            Duty _dut = db.DutyT.
                FirstOrDefault(el => el.DutyDate == checkAdminTotalAddit && el.Salon_Id == SelectedSalon.Id);

            if (_dut != null)
            {
                Users user = db.UsersT.FirstOrDefault(el => el.Id == _dut.User_Id);

                List<Additional> _additionals = new List<Additional>();

                foreach (Additional _additionalItem in db.AdditionalsT.
                    Where(el => el.UserId == user.Id && el.Duty.DutyDate == checkAdminTotalAddit))
                {
                    _additionals.Add(_additionalItem);
                    AdminTotalAddit += (((_additionalItem.Cash + _additionalItem.NonCash) / 100) * (decimal)user.Paddit);
                }

            }
        }
        private void CheckServices(ApplDbContext db)
        {
            List<Serv.Services> _servicesList = db.ServicesT.ToList();

            List<Salon_Service> listThisSalon = db.Salon_Service.
                Include(el => el.Salon).
                ToList();

            List<Serv.Services> list2 = listThisSalon.
                Where(el => el.Salon_id == SelectedSalon.Id).
                Select(el => el.Service).
                ToList();

            List<Serv.Services> list3 = _servicesList.
                Except(list2).
                ToList();

            foreach (Serv.Services _service in list3)
            {
                db.Salon_Service.Add(new Salon_Service { IsActive = false, Salon_id = SelectedSalon.Id, Service_Id = _service.Id });
            }
            db.SaveChanges();
        }
        private void FillReportCombo(ApplDbContext db)
        {
            ReportEmployees = db.EmployeesT.
                Include(el => el.Salon).
                Where(el => el.Salon_Id == SelectedSalon.Id && el.IsAdmin == false).ToList();
            ReportRanks = new List<Ranks>();
            ReportServices = new List<Serv.Services>();
            ReportServ2 = new List<Serv.Services>();
            ReportAdmins = db.EmployeesT.
                Include(el => el.Salon).
                Where(el => el.Salon_Id == SelectedSalon.Id && el.IsAdmin == true).ToList();

            foreach (Ranks _rankItem in db.RanksT)
            {
                ReportRanks.Add(_rankItem);
            }

            foreach (Serv.Services _serviceItem in db.ServicesT)
            {
                ReportServices.Add(_serviceItem);
                ReportServ2.Add(_serviceItem);
            }
        }
        private void FillLessesList(ApplDbContext db)
        {
            LessesList = (db.LessesT.Include(el => el.Duty).Where(el => el.Duty.Salon_Id == SelectedSalon.Id).ToList().Where(el => Convert.ToDateTime(el.Duty.DutyDate).Month == MinusSelectedDate.Month && Convert.ToDateTime(el.Duty.DutyDate).Year == MinusSelectedDate.Year)).
                OrderByDescending(el=>el.Duty.DutyDate).
                ToList();
        }
        private void FillLessesHistory(ApplDbContext db)
        {
            LessHistory = new List<Lesses>();
            CashBoxOperationsList = new List<CashBoxOperations>();

            foreach (Lesses _lessesItem in db.LessesT.Include(el => el.Duty).
                Where(el => el.Duty.Salon_Id == SelectedSalon.Id))
            {
                LessHistory.Add(_lessesItem);
            }

            CashBoxOperationsList = db.CashBoxOperationsT.
                Include(el => el.CashBox).
                Where(el => el.CashBox.SalonId == SelectedSalon.Id).
                OrderByDescending(el => el.Date).ToList().Where(el => Convert.ToDateTime(el.Date).Month == CashSelectedDate.Month && Convert.ToDateTime(el.Date).Year == CashSelectedDate.Year).ToList();
        }
        private void FillAv(ApplDbContext db)
        {

            Application.Current.Dispatcher.Invoke(() =>
            {
                ListA = new List<Avancies>();
                Avancies[] temp = db.AvanciesT.Include(el=>el.Employee).
                Include(el => el.Employee).
                Where(el => el.Employee.Salon_Id == SelectedSalon.Id).OrderByDescending(el=>el.WhenString).ToArray();
                if(temp.Length != 0)
                {
                    ListA = temp.Where(el => Convert.ToDateTime(el.WhenString).Month == AvSelectedDate.Month && Convert.ToDateTime(el.WhenString).Year == AvSelectedDate.Year).ToList();

                }
            });

        }
        private DateTime _avSelectedDate = DateTime.Today;
        public DateTime AvSelectedDate
        {
            get => _avSelectedDate;
            set
            {
                Set(ref _avSelectedDate, value);
                using(var db = new ApplDbContext())
                {
                    FillAv(db);
                }
            }
        }
        private Duty _statDuty;
        public Duty StatDuty
        {
            get => _statDuty;
            set => Set(ref _statDuty, value);
        }
        private void FillStatistic(ApplDbContext db)
        {
            StatisticList = new List<StatisticDTO>();
            DateStat = StatisticSelectedDate is null ? DateTime.Today.ToString("dd/MM/yyyy") : ((DateTime)StatisticSelectedDate).ToString("dd/MM/yyyy");
            foreach (var item in db.StatisticT.Include(el => el.Duty).Include(el => el.Employee).Where(el => el.Duty.DutyDate == DateStat && el.Duty.Salon_Id == SelectedSalon.Id).ToList())
            {
                StatisticList.Add(new StatisticDTO { Stat = item, Total = item.Total + item.BaseBid + item.VirtualAdminBid });
            }
            StatDuty = db.DutyT.Include(el => el.User).ThenInclude(el => el.Employee).FirstOrDefault(el => el.DutyDate == DateStat);
        }
        private void FillReminders(ApplDbContext db)
        {
            DayOfWeek day = DateTime.Today.DayOfWeek;
            TodayRemind = db.ReminderT.
                FirstOrDefault(el => el.Salon_Id == SelectedSalon.Id && el.Day == day.
                ToString());
        }
        private void FillCashBox(ApplDbContext db)
        {
            CurrentCashBox = db.CashBoxT.FirstOrDefault(el => el.SalonId == SelectedSalon.Id);

            if (CurrentCashBox is null)
            {
                db.CashBoxT.Add(new CashBox { SalonId = SelectedSalon.Id });
                db.SaveChanges();
                CurrentCashBox = db.CashBoxT.FirstOrDefault(el => el.SalonId == SelectedSalon.Id);
            }
            Application.Current.Dispatcher.Invoke(() =>
            {
                if (Duty != null)
                {
                    if (Duty.IsVirtualAdmin)
                    {
                        YesCheck = true;
                    }

                    else
                    {
                        NoCheck = true;
                    }
                    if (Duty.IsArrived)
                    {
                        DutyStat = "Смена закрыта!";
                        DutyStatusColor = new SolidColorBrush(Colors.Red);
                    }
                    else if (!Duty.IsArrived)
                    {
                        DutyStat = "Смена открыта!";
                        DutyStatusColor = new SolidColorBrush(Colors.Green);
                    }

                }
                else if (Duty == null)
                {
                    DutyStat = "Смена не открыта!";
                    DutyStatusColor = new SolidColorBrush(Colors.Silver);
                }
            });
        }
        private void backgroundWorker9_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                using (var db = new ApplDbContext())
                {
                    StartAnimation();
                    DateTime _today = DateTime.Today;
                    SelectedMonth = _today.Month;
                    SelectedYear = _today.Year;
                    Duty = db.DutyT.Include(el => el.Statistics).Include(el => el.Salon).Include(el => el.User).Include(el => el.Journals).ThenInclude(el => el.Service).FirstOrDefault(el => el.DutyDate == _today.ToString("dd/MM/yyyy") && el.Salon_Id == SelectedSalon.Id);
                    Controller.Bench(SelectedSalon, db);

                    FillStatistic(db);
                    FillReminders(db);
                    FillReportCombo(db);
                    FillCashBox(db);
                    FillAnother(db);
                    FillList(db);
                    StopAnimation();
                    FillCheck(db);
                    CheckAdminTotalAddit(db);
                    CheckServices(db);
                    FillLessesList(db);
                    FillLessesHistory(db);
                    FillAv(db);
                    FillIncommingStatistic(db);
                    Controller.CalculateEmployeesTotal(SelectedSalon, db);
                    Controller.CalculcateAdminsTotal(SelectedSalon, db);
                }
            }
            catch(Exception ex)
            {
                StopAnimation();
                MessageBox.Show(ex.Message);
            }
        }
        private void backgroundWorker2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            using(var db = new ApplDbContext())
            {
                Controller.Bench(SelectedSalon, db);
                FillCashBox(db);
                FillAv(db);
                string today = DateTime.Today.ToString("dd/MM/yyyy");
                Duty = db.DutyT.
                Include(el => el.Statistics).
                Include(el => el.Salon).
                Include(el => el.User).
                Include(el => el.Journals).
                ThenInclude(el => el.Service).
                FirstOrDefault(el => el.DutyDate == today && el.Salon_Id == SelectedSalon.Id);
            }
        }

        BackgroundWorker backgroundWorker2 = new BackgroundWorker();
        BackgroundWorker backgroundWorker8 = new BackgroundWorker();
        private void backgroundWorker8_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string today = DateTime.Today.ToString("dd/MM/yyyy");
            using (var db = new ApplDbContext())
            {
                Controller.Bench(SelectedSalon,db);
                Duty = db.DutyT.Include(el => el.Statistics).Include(el => el.Salon).Include(el => el.User).Include(el => el.Journals).ThenInclude(el => el.Service).FirstOrDefault(el => el.DutyDate == today && el.Salon_Id == SelectedSalon.Id);
            }
            CheckCashBox();
        }

        public void Upp3()
        {
            try
            {
                IsEnabled = false;
                IsVisible = true;
                IsVisibility = Visibility.Visible;
                backgroundWorker9 = new BackgroundWorker();
                backgroundWorker9.DoWork += backgroundWorker9_DoWork;
                backgroundWorker9.RunWorkerAsync();

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
                IsEnabled = true;
                IsVisible = false;
                IsVisibility = Visibility.Hidden;
            }
        }
        public async void Upp2()
        {
            try
            {
                backgroundWorker8 = new BackgroundWorker();
                backgroundWorker8.DoWork += backgroundWorker8_DoWork;
                backgroundWorker8.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                IsEnabled = true;
                IsVisible = false;
                IsVisibility = Visibility.Hidden;
                MessageBox.Show(ex.Message);

            }

        }
        public async void Upp()
        {
            try
            {
                StartAnimation();
                backgroundWorker2.RunWorkerAsync();
                StopAnimation();
            }
            catch (Exception ex)
            {
                StopAnimation();
                MessageBox.Show(ex.Message);
            }
        }
        private void FillLessList()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start(); 
            if (Duty != null)
            {
                using (var db = new ApplDbContext())
                {
                    LessesList = db.LessesT.Where(el => el.Duty_Id == Duty.Id).ToList();
                }
            }
            watch.Stop();
            Debug.WriteLine($"FillLessesList is {watch.Elapsed}");


        }
        BackgroundWorker backgroundWorker5 = new BackgroundWorker();
        private void backgroundWorker5_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            FillAdminsAndEmployees();
        }
        private void FillAdminsAndEmployees()
        {
            using(var db = new ApplDbContext())
            {
                Employees = db.EmployeesT.Include(el => el.Rank).Include(el => el.Enrollments).Include(el => el.Services).IgnoreAutoIncludes().Select(el => el).Where(el => el.Salon_Id == SelectedSalon.Id).ToList();
                Admins = db.UsersT.Include(el => el.Employee).Where(el => el.Employee.Salon_Id == SelectedSalon.Id && el.UserType != "Директор").ToList();
            }
        }

        private void FillList(ApplDbContext db)
        {
            Admins = new List<Users>();
            ViewList = new ObservableCollection<object>();

            Salon_Service[] _salonServiceArray = db.Salon_Service.
                Include(empa => empa.Service).
                ThenInclude(ela => ela.Salons).
                Where(el => el.Salon_id == SelectedSalon.Id && el.IsActive == true).
                ToArray();

            Employees = db.EmployeesT.
                Include(el => el.Rank).Include(el => el.Enrollments).
                Include(el => el.Services).
                IgnoreAutoIncludes().
                Select(el => el).
                Where(el => el.Salon_Id == SelectedSalon.Id).
                ToList();

            Admins = db.UsersT.
                Include(el => el.Employee).
                Where(el => el.Employee.Salon_Id == SelectedSalon.Id && el.UserType != "Директор").
                ToList();
            Application.Current.Dispatcher.Invoke(() =>
            {
                for (int item = 0; item < _salonServiceArray.Length; item++)
                {
                    ViewList.Add(new ServiceBlock(SelectedSalon, _salonServiceArray[item].Service, LoggedUser, this));
                }
            });
        }
        private void CheckServices()
        {
            using (var db = new ApplDbContext())
            {
                var list = db.ServicesT.ToList();
                var listThisSalon = ((db.Salon_Service.Include(el => el.Salon).ToList()));
                var list2 = listThisSalon.Where(el => el.Salon_id == SelectedSalon.Id).Select(el=>el.Service).ToList();
                var list3 = list.Except(list2).ToList();
                foreach(var v in list3)
                {
                    db.Salon_Service.Add(new Salon_Service { IsActive = false, Salon_id = SelectedSalon.Id, Service_Id = v.Id });
                }
                db.SaveChanges();
            }
        }
        private Duty _duty;
        public Duty Duty
        {
            get => _duty;
            set => Set(ref _duty, value);
        }
        private bool _yesCheck;
        public bool YesCheck
        {
            get => _yesCheck;
            set => Set(ref _yesCheck, value);
        }
        private bool _noCheck;
        public bool NoCheck
        {
            get => _noCheck;
            set => Set(ref _noCheck, value);
        }
        private decimal _totalAdditCashPerDay;
        public decimal TotalAdditCashPerDay
        {
            get => _totalAdditCashPerDay;
            set => Set(ref _totalAdditCashPerDay, value);
        }
        private decimal _totalAdditNonCashPerDay;
        public decimal TotalAdditNonCashPerDay
        {
            get => _totalAdditNonCashPerDay;
            set => Set(ref _totalAdditNonCashPerDay, value);
        }

        private List<Additional> _listOfAdditional;
        public List<Additional> ListOfAdditional
        {
            get => _listOfAdditional;
            set => Set(ref _listOfAdditional, value);
        }
        private void FillCheck()
        {
            using(var db = new ApplDbContext())
            {
                string date2 = SelectedDate2 is null ? DateTime.Today.ToString("dd/MM/yyyy") : ((DateTime)SelectedDate2).ToString("dd/MM/yyyy");
                ListOfAdditional = db.AdditionalsT.Include(el=> el.User).Where(el => el.Duty.DutyDate == date2).ToList();
                TotalAdditNonCashPerDay = (decimal) db.AdditionalsT.Include(el => el.User).Where(el => el.Duty.DutyDate == date2 && el.User.Id == LoggedUser.Id).Sum(el => el.NonCash);
                TotalAdditCashPerDay = (decimal)db.AdditionalsT.Include(el => el.User).Where(el => el.Duty.DutyDate == date2 && el.User.Id == LoggedUser.Id).Sum(el => el.Cash);
            }
        }
        private decimal _adminTotalAddit;
        public decimal AdminTotalAddit
        {
            get => _adminTotalAddit;
            set => Set(ref _adminTotalAddit, value);
        }
        public void CheckAdminTotalAddit()
        {
            string date2 = SelectedDate2 is null ? DateTime.Today.ToString("dd/MM/yyyy") : ((DateTime)SelectedDate2).ToString("dd/MM/yyyy");
            AdminTotalAddit = 0;
            using (var db = new ApplDbContext())
            {
                

                var dut = db.DutyT.FirstOrDefault(el => el.DutyDate == date2 && el.Salon_Id == SelectedSalon.Id);
                if (dut != null)
                {
                    var user = db.UsersT.FirstOrDefault(el => el.Id == dut.User_Id);

                    var addut = db.AdditionalsT.Where(el => el.UserId == user.Id && el.Duty.DutyDate == date2).ToList();
                    if(addut !=null)
                    {
                        foreach (var item in addut)
                        {
                            AdminTotalAddit += (((item.Cash + item.NonCash) / 100) * (decimal)user.Paddit);
                        }
                    }

                }   
            }
        }
        private void OpenAddAv(object sender, EventArgs e)
        {
            AddAvac wind = new AddAvac(SelectedSalon);
            SetCenterPositionAndOpen(wind);
        }
        private RelayCommand _addAv;
        public RelayCommand AddAv
        {
            get
            {
                return _addAv ?? (_addAv = new RelayCommand(obj =>
                {
                    OpenAddAv(this,new EventArgs());
                    Upp();
                }));
            }
        }
        private RelayCommand _deleteEmployees;
        public RelayCommand DeleteEmployees
        {
            get
            {
                return _deleteEmployees ?? (_deleteEmployees = new RelayCommand(obj =>
                {
                    if (MessageBox.Show("Вы действительно хотите удалить выбранного сотрудника?\nВсе связанные данные будут удалены!", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        if (selectedEmployee != null)
                        {
                            using (var db = new ApplDbContext())
                            {
                                db.JournalT.Select(el => el).Where(el => el.Employee_id == selectedEmployee.Id).ToList().ForEach(el => el.Employee_id = 0);
                                Employees enrl = db.EmployeesT.FirstOrDefault(el => el.Id == selectedEmployee.Id);
                                db.EmployeesT.Remove(enrl);
                                db.SaveChanges();
                            }
                        }
                        else MessageBox.Show("Выберите сотрудника");
                        UpdateList();
                    }

                }));
            }
        }
        private List<Avancies> _listA;
        public List<Avancies> ListA
        {
            get => _listA;
            set => Set(ref _listA, value);
        }
        private Avancies _selectedAvac;
        public Avancies SelectedAvac
        {
            get => _selectedAvac;
            set => Set(ref _selectedAvac, value);
        }
        private List<CashBoxOperations> _cashBoxOperationsList;
        public List<CashBoxOperations> CashBoxOperationsList
        {
            get => _cashBoxOperationsList;
            set => Set(ref _cashBoxOperationsList, value);
        }
        BackgroundWorker backgroundWorker7 = new BackgroundWorker();
        private void backgroundWorker7_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            using(var db = new ApplDbContext())
            {
                Controller.Bench(SelectedSalon, db);
                Controller.CalculateEmployeesTotal(SelectedSalon, db);
                Controller.CalculcateAdminsTotal(SelectedSalon, db);
                FillAnother(db);
            }
            UpdateList();
            CheckCashBox();
            FillAv();
            FillReminders();
            IsEnabled = true;
            IsVisible = false;
            IsVisibility = Visibility.Hidden;
        }
        private RelayCommand _updateC;
        public RelayCommand UpdateC
        {
            get
            {
                return _updateC ?? (_updateC = new RelayCommand(obj => 
                {
                    try
                    {
                        IsEnabled = false;
                        IsVisible = true;
                        IsVisibility = Visibility.Visible;
                        backgroundWorker7.RunWorkerAsync();
                    }
                    catch(Exception ex)
                    {
                        IsEnabled = true;
                        IsVisible = false;
                        IsVisibility = Visibility.Hidden;
                    }

                }));
            }
        }


        public void  LoadVM(Users loggedUser, Salons selectedSalon)
        {
            backgroundWorker9.RunWorkerAsync(); 
        }
        public event EventHandler StopAnimationHandler;
        BackgroundWorker worker = new BackgroundWorker();
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

            LoadVM(LoggedUser, SelectedSalon);

        }
        private protected void StartAnimation()
        {
            IsEnabled = false;
            IsVisible = true;
            IsVisibility = Visibility.Visible;
        }
        private protected void StopAnimation()
        {
            IsEnabled = true;
            IsVisible = false;
            IsVisibility = Visibility.Hidden;
        }
        private string _dutyStat;
        public string DutyStat
        {
            get => _dutyStat;
            set => Set(ref _dutyStat, value);
        }
        private SolidColorBrush _dutyStatusColor;
        public SolidColorBrush DutyStatusColor
        {
            get => _dutyStatusColor;
            set => Set(ref _dutyStatusColor, value);
        }
        private decimal _takenDuty;
        public decimal TakenDuty
        {
            get => _takenDuty;
            set => Set(ref _takenDuty, value);
        }
        private Reminder _todayRemind;
        public Reminder TodayRemind
        {
            get => _todayRemind;
            set => Set(ref _todayRemind, value);
        }
        private void FillReminders()
        {
            if(SelectedSalon != null)
            {
                using(var db = new ApplDbContext())
                {
                    var day =  DateTime.Today.DayOfWeek;
                    TodayRemind = db.ReminderT.FirstOrDefault(el => el.Salon_Id == SelectedSalon.Id && el.Day == day.ToString());
                }
            }
        }
        private DateTime _CashSelectedDate = DateTime.Today;
        public DateTime CashSelectedDate

        {
            get => _CashSelectedDate;
            set
            {
                Set(ref _CashSelectedDate, value);
                using (var db = new ApplDbContext())
                    FillLessesHistory(db);
            }
        }
        private bool _Detalized;
        public bool Detalized
        {
            get => _Detalized;
            set => Set(ref _Detalized, value);
        }
        private DateTime _MinusSelectedDate = DateTime.Today;
        public DateTime MinusSelectedDate
        {
            get => _MinusSelectedDate;
            set 
            {
                Set(ref _MinusSelectedDate, value);
                using (var db = new ApplDbContext())
                FillLessesList(db);
            }
        }
        private List<Employees> _reportAdmins;
        public List<Employees> ReportAdmins
        {
            get => _reportAdmins;
            set => Set(ref _reportAdmins, value);
        }
        private decimal _currentIncomming;
        public decimal CurrentIncomming
        {
            get => _currentIncomming;
            set => Set(ref _currentIncomming, value);
        }
        private DateTime _mainReportDateIn = DateTime.Today;
        public DateTime MainReportDateIn
        {
            get => _mainReportDateIn;
            set => Set(ref _mainReportDateIn, value);
        }
        private DateTime _mainReportDateOut = DateTime.Today;
        public DateTime MainReportDateOut
        {
            get => _mainReportDateOut;
            set => Set(ref _mainReportDateOut, value);
        }
        private RelayCommand _showMainReport;
        public RelayCommand ShowMainReport
        {
            get
            {
                return _showMainReport ?? (_showMainReport = new RelayCommand(obj => 
                {
                    OpenMainReport(this, new EventArgs());                 
                }));
            }
        }
        public MainVM(Users loggedUser,Salons selectedSalon)
        {
            try
            {
                LoggedUser = loggedUser;
                SelectedSalon = selectedSalon;
                worker.DoWork += backgroundWorker1_DoWork;
                backgroundWorker2.DoWork += backgroundWorker2_DoWork;
                backgroundWorker3.DoWork += backgroundWorker3_DoWork;
                backgroundWorker4.DoWork += backgroundWorker4_DoWork;
                backgroundWorker5.DoWork += backgroundWorker5_DoWork;
                backgroundWorker6.DoWork += backgroundWorker6_DoWork;
                backgroundWorker7.DoWork += backgroundWorker7_DoWork;
                backgroundWorker8.DoWork += backgroundWorker8_DoWork;
                backgroundWorker9.DoWork += backgroundWorker9_DoWork;

                if (loggedUser.UserType == "Директор")
                {
                    IsVis = Visibility.Visible;
                    IsEnabledEmpl = true;
                    Back = new SolidColorBrush(Colors.White);
                }
                else
                {
                    IsVis = Visibility.Hidden;
                    IsEnabledEmpl = false;
                    Back = new SolidColorBrush(Colors.Gray);
                    Back.Opacity = 1;
                }

                backgroundWorker9.RunWorkerAsync();
                SelectedMonth = DateTime.Today.Month;
                SelectedYear = DateTime.Today.Year;
                ClMode = CalendarMode.Year;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                StopAnimation();
            }
        }

        SolidColorBrush _back;
        public SolidColorBrush Back
        {
            get => _back;
            set => Set(ref _back, value);
        }

        private bool _IsEnabledEmpl;
        public bool IsEnabledEmpl
        {
            get => _IsEnabledEmpl;
            set => Set(ref _IsEnabledEmpl, value);
        }
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
        private static bool _canUpload;
        public static bool CanUpload
        {
            get => _canUpload;
            set
            {
                _canUpload = value;

            } 
        }
        private void UpdateCheck()
        {
            FillCheck();
        }
        private BackgroundWorker backgroundWorker3 = new BackgroundWorker();
        private void backgroundWorker3_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            using(var db = new ApplDbContext())
            {
                FillAnother(db);
            }
        }
        private void UpdateAnother()
        {
            try
            {
                backgroundWorker3.RunWorkerAsync();

            }
            catch(Exception ex)
            {

            }

        }

        private void backgroundWorker4_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            StartAnimation();
            using (var db = new ApplDbContext())
                FillList(db);
            StopAnimation();
        }
        private void UpdateList()
        {
            using (var db = new ApplDbContext())
            {
                FillList(db);
            }
        }
        private Visibility _IsVis;
        public Visibility IsVis
        {
            get => _IsVis;
            set => Set(ref _IsVis, value);
        }
        private void Update()
        {
            CheckAdminTotalAddit();
            CheckServices();
        }
        private CashBox _currentCashBox;
        public CashBox CurrentCashBox
        {
            get => _currentCashBox;
            set => Set(ref _currentCashBox, value);
        }
        private void CheckCashBox()
        {
            using (var db = new ApplDbContext())
            {
                var isExists = db.CashBoxT.FirstOrDefault(el => el.SalonId == SelectedSalon.Id);
                if (isExists != null)
                {
                    CurrentCashBox = db.CashBoxT.FirstOrDefault(el => el.SalonId == SelectedSalon.Id);
                }
                else
                {
                    db.CashBoxT.Add(new CashBox { SalonId = SelectedSalon.Id }); 
                    db.SaveChanges(); 
                    CurrentCashBox = db.CashBoxT.FirstOrDefault(el => el.SalonId == SelectedSalon.Id);
                }

            }

        }
        private StatisticDTO _salaryEmployee;
        public StatisticDTO SalaryEmployee
        {
            get => _salaryEmployee;
            set => Set(ref _salaryEmployee, value);
        }
        private object _salaryDate;
        public object SalaryDate
        {
            get => _salaryDate;
            set => Set(ref _salaryDate, value);
        }
        
        private RelayCommand _incommingCommand;
        public RelayCommand IncommingCommand
        {
            get
            {
                return _incommingCommand ?? (_incommingCommand = new RelayCommand(obj =>
                {
                    OpenIncomming(this, new EventArgs());

                }));
            }
        }
        private RelayCommand _salaryDoubleClick;
        public RelayCommand SalaryDoubleClick
        {
            get
            {
                return _salaryDoubleClick ?? (_salaryDoubleClick = new RelayCommand(obj =>
                {
                    OpenSalary(this,new EventArgs());
                }));
            }
        }
        private RelayCommand _openCash;
        public RelayCommand OpenCash
        {
            get
            {
                return _openCash ?? (_openCash = new RelayCommand(obj =>
                {
                    OpenCashWindow(this, new EventArgs());
                    try
                    {
                        backgroundWorker6.RunWorkerAsync();
                    }
                    catch(Exception ex)
                    {

                    }
                }));
            }
        }
        private RelayCommand _editAvac;
        public RelayCommand EditAvac
        {
            get
            {
                return _editAvac ?? (_editAvac = new RelayCommand(async obj =>
                {
                    if (SelectedAvac != null)
                    {
                        using (var db = new ApplDbContext())
                        {

                            OpenEditAvac(this, new EventArgs());
                            backgroundWorker9 = new BackgroundWorker();
                            backgroundWorker9.DoWork += backgroundWorker9_DoWork;
                            backgroundWorker9.RunWorkerAsync();
                        }
                    }
                    else MessageBox.Show("Выберите строку!");
                }));
            }
        }

        private RelayCommand _deleteAvac;
        public RelayCommand DeleteAvac
        {
            get
            {
                return _deleteAvac ?? (_deleteAvac = new RelayCommand(obj =>
                {
                    if (SelectedAvac != null)
                    {
                        using (var db = new ApplDbContext())
                        {
                            if (MessageBox.Show("Вы действительно хотите удалить данную запись?", "Подтвреждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                Avancies av = db.AvanciesT.FirstOrDefault(el => el.Id == SelectedAvac.Id);
                                db.AvanciesT.Remove(av);
                                db.SaveChanges();
                                backgroundWorker9 = new BackgroundWorker();
                                backgroundWorker9.DoWork += backgroundWorker9_DoWork;
                                backgroundWorker9.RunWorkerAsync();
                            }
                        }
                    }
                    else MessageBox.Show("Выберите строку!");
                }));
            }
        }
        private RelayCommand _openEditEmployeeWindow;
        public RelayCommand OpenEditEmployeeWindow
        {
            get
            {
                return _openEditEmployeeWindow ?? (_openEditEmployeeWindow = new RelayCommand(obj =>
                {
                    if(selectedEmployee !=null)
                    {
                        OpenEditEmployee(this, new EventArgs());
                        UpdateList();
                    }

                }));
            }
        }
        
        private RelayCommand _editLess;
        public RelayCommand EditLess
        {
            get
            {
                return _editLess ?? (_editLess = new RelayCommand(obj =>
                {
                    if (SelectedLess != null)
                    {
                        OpenEditLess(this, new EventArgs());
                        FillLessList();
                        FillLessHistory();
                    }
                    else MessageBox.Show("Выберите строку!");
                }));
            }
        }
        private RelayCommand _addLess;
        public RelayCommand AddLess
        {
            get
            {
                return _addLess ?? (_addLess = new RelayCommand(obj => 
                {
                    OpenAddLess(this,new EventArgs());
                    FillLessList();
                    FillLessHistory();
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
                    try
                    {
                        backgroundWorker5.RunWorkerAsync();
                    }
                    catch(Exception ex) { }


                }));
            }
        }
        private BackgroundWorker _openAdditionalBackgroundWorker = new BackgroundWorker();
        private void _openAdditionalBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                using (var db = new ApplDbContext())
                {
                    StartAnimation();
                    Controller.Bench(SelectedSalon, db);
                    StopAnimation();
                    CheckAdminTotalAddit(db);
                    CheckServices(db);
                    FillCashBox(db);
                    FillList(db);
                    FillAnother(db);
                    FillReminders();
                    Controller.CalculateEmployeesTotal(SelectedSalon, db);
                    Controller.CalculcateAdminsTotal(SelectedSalon, db);
                }
            }
            catch(Exception ex)
            {
                StopAnimation();
                MessageBox.Show(ex.Message);
            }
        }
        private RelayCommand _openAdditCommand;
        public RelayCommand OpenAdditCommand
        {
            get
            {
                return _openAdditCommand ?? (_openAdditCommand = new RelayCommand(obj =>
                {
                    using(var db = new ApplDbContext())
                    {
                        OpenAddit(this, new EventArgs());
                        _openAdditionalBackgroundWorker = new BackgroundWorker();
                        _openAdditionalBackgroundWorker.DoWork += _openAdditionalBackgroundWorker_DoWork;
                        _openAdditionalBackgroundWorker.RunWorkerAsync();
                    }
                }));
            }
        }
        private CashBoxOperations _selectedCash;
        public CashBoxOperations SelectedCash
        {
            get => _selectedCash;
            set => Set(ref _selectedCash, value);
        }
        private RelayCommand _deleteCash;
        public RelayCommand DeleteCash
        {
            get
            {
                return _deleteCash ?? (_deleteCash = new RelayCommand(obj =>
                {
                    using (var db = new ApplDbContext())
                    {
                        if (SelectedCash != null)
                        {
                            if (MessageBox.Show("Вы действительно хотите удалить данну запись?","Подтверждение",MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    db.CashBoxOperationsT.Remove(SelectedCash);
                                    db.SaveChanges();
                                    backgroundWorker6.RunWorkerAsync();
                                }
                                catch(Exception ex)
                                {

                                }


                            }
                        }
                        else MessageBox.Show("Выберите строку!");
                    }
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
                    try
                    {
                        OpenDutyView(this, new EventArgs());

                    }
                    catch(Exception ex) { MessageBox.Show(ex.Message); }
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
                    UpdateList();
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
                    backgroundWorker4.RunWorkerAsync();
                }));
            }
        }
        private RelayCommand _showReportS;
        public RelayCommand ShowReportS
        {
            get
            {
                return _showReportS ?? (_showReportS = new RelayCommand(obj =>
                {
                    if (SelectedReportSService != null && SelectedReportSDateIn != null && SelectedReportSDateOut != null)
                    {

                        OpenReportSWindow(this, new EventArgs());

                    }
                    else MessageBox.Show("Выберите данные!");
                    UpdateList();
                }));
            }
        }
        private RelayCommand _showReportRanks;
        public RelayCommand ShowReportRanks
        {
            get
            {
                return _showReportRanks ?? (_showReportRanks = new RelayCommand(obj =>
                {
                    if (SelectedReportRank != null && SelectedReportESDateIn != null && SelectedReportESDateOut != null)
                    {

                        OpenReportRank(this, new EventArgs());

                    }
                    else MessageBox.Show("Выберите данные!");
                    UpdateList();
                }));
            }
        }
        private Employees _SelectedReportAdmin;
        public Employees SelectedReportAdmin
        {
            get => _SelectedReportAdmin;
            set => Set(ref _SelectedReportAdmin, value);
        }

        private void OpenReportAdminWindow(object sender, EventArgs e)
        {
            AdminSalarReport wind = new AdminSalarReport(SelectedReportAdmin.Id, SelectedDateInAdminReport.ToString("yyyy-MM-dd"), SelectedDateOutAdminReport.ToString("yyyy-MM-dd"));
            wind.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            wind.Show();
        }
        private RelayCommand _showReportAdm;
        public RelayCommand ShowReportAdm
        {
            get
            {
                return _showReportAdm ?? (_showReportAdm = new RelayCommand(obj =>
                {
                    if (SelectedReportAdmin != null && SelectedDateInAdminReport != null && SelectedDateOutAdminReport != null)
                    {

                        OpenReportAdminWindow(this, new EventArgs());

                    }
                    else MessageBox.Show("Выберите данные!");
                    UpdateList();
                }));
            }
        }
        private RelayCommand _showReportEM;
        public RelayCommand ShowReportEM
        {
            get
            {
                return _showReportEM ?? (_showReportEM = new RelayCommand(obj =>
                {
                    if (SelectedReportEmployee != null && SelectedReportService != null && SelectedReportESDateIn != null && _selectedReportESDateOut != null)
                    {

                        OpenReportWindow(this, new EventArgs());

                    }
                    else MessageBox.Show("Выберите данные!");
                    UpdateList();
                }));
            }
        }
        private async void OpenAddLess(object sender, EventArgs e)
        {
            AddLessWindow wind = new AddLessWindow(Duty, SelectedSalon);
            SetCenterPositionAndOpen(wind);
            FillLessList();
            

        }
        private Lesses _selectedLess;
        public Lesses SelectedLess
        {
            get => _selectedLess;
            set => Set(ref _selectedLess, value);
        }
        private void OpenEditLess(object sender, EventArgs e)
        {
            EditLessWindow wind = new EditLessWindow(SelectedLess);
            SetCenterPositionAndOpen(wind);
        }
        private void OpenMainReport(object sender, EventArgs e)
        {
            AllReport wind = new AllReport(MainReportDateIn.ToString("yyyy-MM-dd"), MainReportDateOut.ToString("yyyy-MM-dd"),SelectedSalon.Id);
            wind.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            wind.Show();
        }
        private void OpenReportSWindow(object sender, EventArgs e)
        {
            ReportS wind = new ReportS(SelectedReportSService.Id, SelectedReportSDateIn.ToString("dd/MM/yyyy"), SelectedReportSDateOut.ToString("dd/MM/yyyy"));
            wind.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            wind.Show();
        }
        private void OpenReportWindow(object sender, EventArgs e)
        {
            if(Detalized == true)
            {
                ReportByEmplAndServ wind = new ReportByEmplAndServ(SelectedReportEmployee.Id, SelectedReportService.ServiceType, SelectedReportESDateIn.ToString("yyyy-MM-dd"), SelectedReportESDateOut.ToString("yyyy-MM-dd"));
                wind.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                wind.Show();
            }
            else
            {
                ReportByEmplAndServ2 wind = new ReportByEmplAndServ2(SelectedReportEmployee.Id, SelectedReportService.ServiceType, SelectedReportESDateIn.ToString("yyyy-MM-dd"), SelectedReportESDateOut.ToString("yyyy-MM-dd"));
                wind.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                wind.Show();
            }

        }
        private void OpenReportRank(object sender, EventArgs e)
        {
            ReportRanks wind = new ReportRanks(SelectedReportRank.Id, SelectedReportRankDateIn.ToString("dd/MM/yyyy"), SelectedReportRankDateOut.ToString("dd/MM/yyyy"));
            wind.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            wind.Show();
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
                        _openAdditionalBackgroundWorker = new BackgroundWorker();
                        _openAdditionalBackgroundWorker.DoWork += _openAdditionalBackgroundWorker_DoWork;
                        _openAdditionalBackgroundWorker.RunWorkerAsync();
                    }
                    else MessageBox.Show("Выберите админа!");
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
                    try
                    {
                        OpenSalonServicesView(this, new EventArgs());
                        backgroundWorker4.RunWorkerAsync();
                    }
                    catch(Exception ex) { MessageBox.Show(ex.Message); }
                }));
            }
        }
        BackgroundWorker backgroundWorker4 = new BackgroundWorker();
        private RelayCommand _openServiceWindowCommand;
        public RelayCommand OpenServiceWindowCommand
        {
            get
            {
                return _openServiceWindowCommand ?? (_openServiceWindowCommand = new RelayCommand(obj =>
                {
                    try
                    {
                        OpenServiceWindow(this,new EventArgs());
                        backgroundWorker4.RunWorkerAsync();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }

                }));
            }
        }
        private void OpenCashWindow(object sender, EventArgs e)
        {
            LessCashBox wind = new LessCashBox(CurrentCashBox,Duty);
            SetCenterPositionAndOpen(wind);
        }
        private void OpenIncomming(object sender, EventArgs e)
        {
            IncommingWindow wind = new IncommingWindow(SelectedSalon);
            SetCenterPositionAndOpen(wind);
            backgroundWorker6.RunWorkerAsync();
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
        private void OpenAddit(object sender, EventArgs e)
        {
            Users user;
            using (var db = new ApplDbContext())
            {
                string date = DateTime.Today.ToString("dd/MM/yyyy");
                user = db.DutyT.Include(el=>el.User).FirstOrDefault(el => el.DutyDate == date && el.Salon.Id == SelectedSalon.Id)?.User;
            }
            AdditionalyWindow wind = new AdditionalyWindow(SelectedSalon, user);
            SetCenterPositionAndOpen(wind);

        }
        private void OpenSalary(object sender, EventArgs e)
        {
            using(var db = new ApplDbContext())
            {
                var date = StatisticSelectedDate is null ? DateTime.Today.ToString("dd/MM/yyyy") : (((DateTime)StatisticSelectedDate).ToString("dd/MM/yyyy")); 
                var dut = db.DutyT.FirstOrDefault(el=>el.Salon_Id == SelectedSalon.Id && el.DutyDate == date);
                if (dut != null)
                {
                    if(SalaryEmployee != null)
                    {
                        var empl = db.EmployeesT.Include(el => el.Services).FirstOrDefault(el => el.Id == SalaryEmployee.Stat.Employee_Id);
                        SalaryWindow wind = new SalaryWindow(empl, dut);
                        SetCenterPositionAndOpen(wind);
                    }

                }
                else MessageBox.Show("Ошибка!");
            }

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
        private void OpenEditAvac(object sender, EventArgs e)
        {
            using(var db = new ApplDbContext())
            {
                var sel = db.AvanciesT.Include(el => el.Employee).FirstOrDefault(el => el.Id == SelectedAvac.Id);
                if (sel != null)
                {
                    View.EditAvac.EditAvacWind wind = new View.EditAvac.EditAvacWind(sel);
                    SetCenterPositionAndOpen(wind);
                }
                else MessageBox.Show("Ошибка!");
            }

        }
        private void OpenAddEmployee(object sender, EventArgs e)
        {
            AddEmployee wind = new AddEmployee(SelectedSalon);
            SetCenterPositionAndOpen(wind);
        }
        private void OpenDutyView(object sender, EventArgs e)
        {
            DutyView wind = new DutyView(SelectedSalon,LoggedUser,this);
            SetCenterPositionAndOpen(wind);

        }
        public MainVM() {
            UpdateList();

        }
        private CalendarMode _clMode = CalendarMode.Year;
        public CalendarMode ClMode
        {
            get => _clMode;
            set => Set(ref _clMode, value);
        }
        
        private RelayCommand _minusDateChanged;
        public RelayCommand MinusDateChanged
        {
            get
            {
                return _minusDateChanged ?? (_minusDateChanged = new RelayCommand(obj =>
                {
                    using(var db = new ApplDbContext())
                        FillLessesList(db);
                }));
            }
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
                //Dutys = TDutys.Where(el => Convert.ToDateTime(el.DutyDate).Month == SelectedMonth && Convert.ToDateTime(el.DutyDate).Year == SelectedYear).ToList();
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

    }
}
