using Salon;
using Salon.Models.Data;
using SalonApp.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Data = SalonApp.Models.Data;
using SalonApp.View.Duty;
using System.Security.Policy;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.Extensions.Options;
using Microsoft.SqlServer.Management.Common;
using Statistic = SalonApp.Models.Data.Statistic;
using BenchmarkDotNet.Attributes;
using System.Diagnostics;
using SalonApp.View.JournalView;
using static System.Windows.Forms.AxHost;

namespace SalonApp.Services.DbCommands
{
    public class Controller
    {
        public static void CalculcateAdminsTotal(Salons selectedSalon, ApplDbContext db)
        {
            if (selectedSalon != null)
            {
                List<Users> _usersList = new List<Users>();
                List<Duty> _dutysList = new List<Duty>();
                foreach (Users _userItem in db.UsersT.
                    Include(el => el.Employee).
                    Where(el => el.Employee.Salon_Id == selectedSalon.Id && el.UserType == "Админ" || el.UserType == "Виртуальный админ"))
                {
                    _usersList.Add(_userItem);
                }

                foreach (Users _userItem in _usersList)
                {
                    _dutysList.Clear();
                    foreach(Duty _dutyItem in db.DutyT.Where(el => el.User_Id == _userItem.Id))
                    {
                        _dutysList.Add(_dutyItem);
                    }
                    foreach (Duty _dutyItem in _dutysList)
                    {
                        Statistic statistic = db.StatisticT.
                            FirstOrDefault(el => el.Employee_Id == _userItem.Employee.Id && el.Duty_Id == _dutyItem.Id);

                        if (statistic != null)
                        {
                            decimal admt = 0;

                            foreach (Journal _journalItem in db.JournalT.
                                Include(el => el.Duty).
                                Where(el => el.Duty.Salon_Id == selectedSalon.Id && el.Duty.User_Id == _userItem.Id && el.DutyId == _dutyItem.Id).
                                ToList())
                            {
                                admt += (((_journalItem.PackageCash + _journalItem.PackageNonCash) / 100) * (decimal)_userItem.Ppackage);
                            }

                            decimal amdt2 = 0;

                            foreach (Additional additionalItem in db.AdditionalsT.
                                Where(el => el.Duty.Salon_Id == selectedSalon.Id &&
                                el.Duty.User_Id == _userItem.Id &&
                                el.DutyId == _dutyItem.Id))
                            {
                                amdt2 += 
                                    (((additionalItem.Cash + additionalItem.NonCash) / 100) * (decimal)_userItem.Paddit) + 
                                    ((additionalItem.Sertificate / 100) * (decimal)_userItem.Psertificate);
                                additionalItem.UserTotal = 
                                    (((additionalItem.Cash + additionalItem.NonCash) / 100) * (decimal)_userItem.Paddit) + 
                                    ((additionalItem.Sertificate / 100) * (decimal)_userItem.Psertificate);
                            }
                            statistic.Total = admt + amdt2;
                            statistic.VirtualAdminBid = 
                                (db.DutyT.FirstOrDefault(el => el.Id == _dutyItem.Id).IsVirtualAdmin ? (decimal)_userItem.VirtualAdminBid : 0);
                            db.SaveChanges();
                        }
                        else if (statistic == null)
                        {
                            db.StatisticT.Add(new Statistic
                            {
                                Duty_Id = _dutyItem.Id,
                                Employee_Id = _userItem.Employee_Id,
                                IsAdmin = true,
                                IsVirtualAdmin = db.DutyT.FirstOrDefault(el => el.Id == _dutyItem.Id).IsVirtualAdmin ? true : false,
                                Total = 0,
                                VirtualAdminBid = (db.DutyT.FirstOrDefault(el => el.Id == _dutyItem.Id).IsVirtualAdmin ? (decimal)_userItem.VirtualAdminBid : 0)
                            });
                            db.SaveChanges();
                            statistic = db.StatisticT.FirstOrDefault(el => el.Employee_Id == _userItem.Employee.Id && el.Duty_Id == _dutyItem.Id);
                            decimal admt = 0;

                            foreach (Journal _journalItem in db.JournalT.Include(el => el.Duty).Where(el => el.Duty.Salon_Id == selectedSalon.Id && el.Duty.User_Id == _userItem.Id))
                            {
                                admt += (((_journalItem.PackageCash + _journalItem.PackageNonCash) / 100) * (decimal)_userItem.Ppackage);
                            }

                            decimal amdt2 = 0;
                            //var user = db.UsersT.FirstOrDefault(el => el.Id == duty.User_Id);
                            foreach (Additional _additionalItem in db.AdditionalsT.Where(el => el.Duty.Salon_Id == selectedSalon.Id && el.Duty.User_Id == _userItem.Id))
                            {
                                if (_additionalItem.IsSertificate == false)
                                    amdt2 += (((
                                        _additionalItem.Cash + 
                                        _additionalItem.NonCash + 
                                        _additionalItem.Sertificate + 
                                        _additionalItem.DiscountCash + 
                                        _additionalItem.DiscountNonCash + 
                                        _additionalItem.Fictive) / 100) * (decimal)_userItem.Paddit);

                                else if (_additionalItem.IsSertificate)
                                    amdt2 += (((
                                        _additionalItem.Cash + 
                                        _additionalItem.NonCash + 
                                        _additionalItem.Sertificate + 
                                        _additionalItem.DiscountCash + 
                                        _additionalItem.DiscountNonCash + 
                                        _additionalItem.Fictive) / 100) * (decimal)_userItem.Psertificate);
                            }
                            statistic.Total = admt + amdt2;
                            statistic.VirtualAdminBid = (db.DutyT.FirstOrDefault(el => el.Id == _dutyItem.Id).IsVirtualAdmin ? (decimal)_userItem.VirtualAdminBid : 0);
                            db.SaveChanges();

                        }
                        statistic = db.StatisticT.FirstOrDefault(el => el.Employee_Id == _userItem.Employee.Id && el.Duty_Id == _dutyItem.Id);
                        decimal summ = 0;
                        foreach(Journal _journalItem in db.JournalT.Where(el => el.DutyId == _dutyItem.Id))
                            summ += _journalItem.PackageCash + _journalItem.PackageNonCash;

                        decimal dutyTotal = 0;
                        foreach(Duty _dutyInItem in db.DutyT.Where(el => el.Id == _dutyItem.Id))
                            dutyTotal += _dutyInItem.CashPerDay + _dutyInItem.NonCashPerDay + _dutyInItem.TransfersPerDay;

                        decimal adm = dutyTotal - summ;
                        decimal inI = 0, inOut = 0; 
                        string[] tre = new string[] {};
                        foreach (SalaryTreshold _treshold in db.SalaryTresholdT)
                        {
                            tre = _treshold.Threshold.Split('-');
                            inI = decimal.Parse(tre[0]);
                            inOut = decimal.Parse(tre[1]);
                            if (adm >= inI)
                                statistic.BaseBid = _treshold.Bid;
                        }
                        db.SaveChanges();

                    }
                }
            }
        }
        public static void CalculateEmployeesTotal(Salons selectedSalon, ApplDbContext db)
        {
            if(selectedSalon != null)
            {
                Journal[] _journalsList;
                Employees[] _employeesList = db.EmployeesT.
                    Include(el => el.Enrollments).
                    Where(el => el.Salon_Id == selectedSalon.Id && el.IsAdmin == false).ToArray(); 
                
                for(int i = 0; i < _employeesList.Length; i++)
                {
                    _journalsList = db.JournalT.Include(el => el.Duty).Where(el => el.Employee_id == _employeesList[i].Id).ToArray();
                    var journals =
                        from journal in _journalsList
                        group journal
                        by journal.DutyId
                        into journalGroup
                        orderby journalGroup.Key
                        select journalGroup;
                    foreach (IGrouping<int,Journal> item in journals)
                    {
                        decimal sum = 0, temp = 0 ;
                        foreach(var el in item)
                        {
                            temp = (((
                                el.Cash + 
                                el.NonCash + 
                                el.Transfer + 
                                el.Sertificate) / 100) * _employeesList[i].Enrollments.FirstOrDefault(el2 => el2.ServiceId == el.Service_Id).Percent) +
                            ((el.Fictive / 100) * (decimal)_employeesList[i].Pfictive) +
                            (((el.PackageCash + el.PackageNonCash) /100) * (decimal)_employeesList[i].Ppackage) +
                            (((el.AdditCash + el.AdditNonCash) / 100) * (decimal)_employeesList[i].Paddit) +
                            (((el.HandJobCash + el.HandJobNonCash) / 100) * (decimal)_employeesList[i].Phandjob);

                            sum += temp;
                            el.UserTotal = temp;
                            db.SaveChanges();
                        }
                                
                        var statistic = db.StatisticT.FirstOrDefault(el => el.Employee_Id == _employeesList[i].Id && el.Duty_Id == item.Key);
                                
                        if (statistic != null)
                        {
                            statistic.Total = sum;
                            
                            db.SaveChanges();
                            if (statistic.Total < _employeesList[i].EntryTreshold)
                            {
                                statistic.BaseBid = _employeesList[i].Bid;
                                statistic.Salary = _employeesList[i].Bid;
                                db.SaveChanges();

                            }
                            if (statistic.Total > _employeesList[i].EntryTreshold)
                            {
                                statistic.BaseBid = 0;
                                statistic.Salary = statistic.Total;
                                db.SaveChanges();
                            }

                            db.SaveChanges();
                        }
                        else if (statistic == null)
                        {
                            decimal empltotal = sum;
                            db.StatisticT.Add(new Statistic
                            {
                                Duty_Id = item.Key,
                                Employee_Id = _employeesList[i].Id,
                                IsAdmin = _employeesList[i].IsAdmin,
                                IsVirtualAdmin = false,
                                Total = empltotal
                            });
                            db.SaveChanges();
                            var stat = db.StatisticT.FirstOrDefault(el => el.Employee_Id == _employeesList[i].Id && el.Duty_Id == item.Key);
                            if (stat.Total < _employeesList[i].EntryTreshold)
                            {
                                stat.BaseBid = _employeesList[i].Bid;
                                stat.Salary = _employeesList[i].Bid;
                            }
                            if (stat.Total > _employeesList[i].EntryTreshold)
                            {
                                stat.BaseBid = 0;
                                stat.Salary = stat.Total;
                            }
                            db.SaveChanges();
                        }
                        db.SaveChanges();
                    }
                }
            } 
        }

        public static void Bench(Salons SelectedSalon, ApplDbContext db)
        {
            db.Database.ExecuteSqlRaw("UPDATE AV SET AV.[When] = CONVERT(datetime2, av.WhenString, 103) FROM AvanciesT AV");
            Duty[] _selectedSalonDutys = db.DutyT.
                FromSqlInterpolated($"SELECT * FROM DutyT WHERE Salon_Id = {SelectedSalon.Id}").
                ToArray();

            foreach (Duty _dutyItem in _selectedSalonDutys)
            {
                Duty _currentDuty = db.DutyT.
                    FirstOrDefault(el => el.Id == _dutyItem.Id);

                Additional[] _additionalList = db.AdditionalsT.
                    FromSqlInterpolated($"SELECT * FROM AdditionalsT WHERE DutyId = {_currentDuty.Id}").
                    ToArray();
                Journal[] _journalList = db.JournalT.
                    FromSqlInterpolated($"SELECT * FROM JournalT WHERE DutyId = {_currentDuty.Id}").
                    ToArray();

                Avancies[] _avanciesList = db.AvanciesT.
                    Include(el => el.Employee).
                    Where(el => el.When == _currentDuty.newcol  && el.Employee.Salon_Id == SelectedSalon.Id && el.IsDeduction == true).
                    ToArray();
                Lesses[] _lessesList = db.LessesT.
                    Include(el => el.Duty).
                    Where(el => el.Duty_Id == _currentDuty.Id).
                    ToArray();

                CashBoxOperations[] _cashBoxOperationList = db.CashBoxOperationsT.Include(el=>el.CashBox).
                    Where(el => el.Date == _currentDuty.DutyDate && el.CashBox.SalonId == SelectedSalon.Id).
                    ToArray();

                if (_journalList != null)
                {
                    decimal
                        _currentDutyCashPerDay = 0,
                        _currentDutyNonCashPerDay = 0,
                        _currentDutyTransfersPerDay = 0,
                        _currentDutyTotalSertificates = 0,
                        _lessesTotal = 0, 
                        _takenTotal = 0, 
                        _avanciesTotal = 0;

                    foreach (Journal _journalItem in _journalList)
                    {
                        _currentDutyCashPerDay +=
                            _journalItem.Cash +
                            _journalItem.PackageCash +
                            _journalItem.AdditCash +
                            _journalItem.HandJobCash;

                        _currentDutyNonCashPerDay +=
                            _journalItem.NonCash +
                            _journalItem.PackageNonCash +
                            _journalItem.AdditNonCash +
                            _journalItem.HandJobNonCash;

                        _currentDutyTransfersPerDay +=
                            _journalItem.Transfer +
                            _journalItem.PackageTransfer;

                        _currentDutyTotalSertificates +=
                            _journalItem.Sertificate;

                    }
                    foreach (Additional _additionalItem in _additionalList)
                    {
                        _currentDutyCashPerDay += _additionalItem.Cash;
                        _currentDutyNonCashPerDay += _additionalItem.NonCash;
                        _currentDutyTotalSertificates += _additionalItem.Sertificate;
                    }

                    foreach (Avancies item  in _avanciesList)
                        _avanciesTotal += item.Total;

                    foreach (Lesses item in _lessesList)
                        _lessesTotal += item.Amount;
                    
                    foreach (CashBoxOperations item in _cashBoxOperationList)
                        _takenTotal += item.Taken;

                    _currentDuty.CashPerDay = _currentDutyCashPerDay;
                    _currentDuty.NonCashPerDay = _currentDutyNonCashPerDay;
                    _currentDuty.TransfersPerDay = _currentDutyTransfersPerDay;
                    _currentDuty.TotalSertificates = _currentDutyTotalSertificates;
                    _currentDuty.Total = _currentDutyCashPerDay + _currentDutyNonCashPerDay;
                    _currentDuty.Income = _currentDutyCashPerDay - (_avanciesTotal + _lessesTotal);
                    _currentDuty.Taken = _takenTotal;
                    db.SaveChanges();
                }
            }

            decimal totalnc = 0, totaltr = 0;

            foreach (Duty _dutyItem in _selectedSalonDutys)
            {
                totalnc += _dutyItem.NonCashPerDay;
                totaltr += _dutyItem.TransfersPerDay;
            }
            decimal
                totalTakenС = 0,
                totalTakenТС = 0,
                totalTakenNonCash = 0;

            foreach (CashBoxOperations _operationItem in db.CashBoxOperationsT.Where(el => el.CashBox.SalonId == SelectedSalon.Id).ToArray())
            {
                if (_operationItem.Type == "Наличка")
                    totalTakenС += _operationItem.Taken;

                else if (_operationItem.Type == "Перевод")
                    totalTakenТС += _operationItem.Taken;

                else if (_operationItem.Type == "Безнал")
                    totalTakenNonCash += _operationItem.Taken;
            }

            CashBox _cashBox = db.CashBoxT.FirstOrDefault(el => el.SalonId == SelectedSalon.Id);
            if (_cashBox is null)
            {
                db.CashBoxT.Add(new CashBox { SalonId = SelectedSalon.Id });
                db.SaveChanges();
                _cashBox = db.CashBoxT.FirstOrDefault(el => el.SalonId == SelectedSalon.Id);
            }

            decimal  incommingCash = 0, incommingNonCash = 0;

            foreach (Incommings _incommingItem in db.IncommingsT.FromSqlRaw($"SELECT * FROM IncommingsT WHERE CashBox_ID = {_cashBox.Id}").ToArray())
            {
                if (_incommingItem.Type == "Наличка")
                    incommingCash += _incommingItem.Total;
                if (_incommingItem.Type == "Безнал")
                    incommingNonCash += _incommingItem.Total;
            }

            decimal 
                _sumIncome = 0;

            foreach(var item in _selectedSalonDutys)
                _sumIncome += item.Income;

            _cashBox.amountCash = (_sumIncome + incommingCash) - totalTakenС;
            _cashBox.amountNonCash = (totalnc + incommingNonCash) - totalTakenNonCash;

            _cashBox.amountTransfers = totaltr - totalTakenТС;

            db.SaveChanges();
        }

        public static Ranks GetRankById(int id)
        {
            using (var db = new ApplDbContext())
            {
                return db.RanksT.FirstOrDefault(el => el.Id == id);
            }
        }
        public static void SetActivity(Salon_Service serv, bool statement)
        {
            using(var db = new ApplDbContext())
            {
                if (serv != null)
                {

                    var ss = db.Salon_Service.FirstOrDefault(el => el.Id == serv.Id);
                    ss.IsActive = statement;
                    db.SaveChanges();
                }
            }
        }
        public static void AddService(Data.Services serv, Salons salon)
        {
            using (var db = new ApplDbContext())
            {
                if (!db.ServicesT.Any(el => el.ServiceName == serv.ServiceName))
                {
                    serv.Salon_Service.Add(new Salon_Service { Service_Id = serv.Id, Salon_id = salon.Id, Comment = "", IsActive = false });
                    db.ServicesT.Add(serv);
                    db.SaveChanges();
                }
                else MessageBox.Show("Услуга с таким именем уже существует!");
            }
        }
        public static void AddEnrollment(int empid, int servie)
        {
            using(var db = new ApplDbContext())
            {
                Employees em = db.EmployeesT.FirstOrDefault(el => el.Id == empid);
                em.Enrollments.Add(new Enrollment { EmployeeId = empid, ServiceId = servie, Comment = "Fuck" });
                db.SaveChanges();
            }
        }
        public static List<SalonApp.Models.Data.Services> GetAllEmployeeServices(int id)
        {
            using(var db = new ApplDbContext())
            {
                return (db.ServicesT.Include(empa => empa.Employees).Where(el => el.Id == id).ToList());
            }
        }
        public static List<SalonApp.Models.Data.Employees> GetAllServicesEmployee(int id)
        {
            using (var db = new ApplDbContext())
            {
                return (db.EmployeesT.Include(empa => empa.Services).ThenInclude(el=>el.Enrollments).Where(el => el.Salon_Id == id).ToList());
            }
        }
        public static List<SalonApp.Models.Data.Salon_Service> GetAllSalonServices(int id)
        {
            using (var db = new ApplDbContext())
            {
                return (db.Salon_Service.Include(empa => empa.Service).Where(el => el.Salon_id == id).ToList());
            }
        }
        public static List<SalonApp.Models.Data.Salon_Service> GetAllSalonServicess(int id)
        {
            using (var db = new ApplDbContext())
            {
                return (db.Salon_Service.Include(empa => empa.Service).ThenInclude(ela => ela.Salons).Where(el => el.Salon_id == id && el.IsActive == true).ToList());
            }
        }
        //public static void GetAllSalonServices(int id)
        //{
        //    using (var db = new ApplDbContext())
        //    {
        //        var list = (db.SalonsT.Include(empa => empa.Services).ThenInclude(ela => ela.Salon_Service).Where(el => el.Id == id).ToList());

        //    }
        //}
        public static void AddSalon(Salons salon)
        {
            using (var db = new ApplDbContext())
            {
                if(salon != null && salon.Director != null && salon.SalonName != null)
                {
                    if (!db.SalonsT.Any(el => el.SalonName == salon.SalonName))
                    {
                        db.SalonsT.Add(salon);
                        db.SaveChanges();
                    }
                    else MessageBox.Show("Ошибка, салон под таким именем уже существует!");
                }
                
            }
        }
        public static void DeleteSalon(Salons Salon)
        {
            using (var db = new ApplDbContext())
            {
                db.SalonsT.Remove(Salon);
                db.SaveChanges();
            }
        }
        public static void CreateBackUp(string Action, bool init = false)
        {
            try
            {
                Server server = new Server(new ServerConnection());
                Backup dbBack = new Backup() {BackupSetName = Action, Action = BackupActionType.Database, Database = "SalonDbTest" };
                dbBack.Devices.AddDevice(@$"/var/opt/mssql/data/SalonDbTest.bak", DeviceType.File);
                dbBack.Initialize = init;
                dbBack.SqlBackupAsync(server);
            }
            catch(Exception ex)
            {
            }
        }
        public static void DeleteService(Data.Services service)
        {
            using (var db = new ApplDbContext())
            {
                db.ServicesT.Remove(service);
                db.SaveChanges();
                CreateBackUp("DeleteService");
            }
        }
        public static void DeleteUser(Users user)
        {
            using (var db = new ApplDbContext())
            {
                db.UsersT.Remove(user);
                db.SaveChanges(); CreateBackUp("DeleteService");
            }
        }
        public static void AddRank(Ranks obj)
        {
            using (var db = new ApplDbContext())
            {
                db.RanksT.Add(obj);
                db.SaveChanges();
            }
        }
        public static void AddUser(Users obj)
        {
            if(obj.UserType != "" && 
                obj.UserEmployee != null &&
                obj.NickName != "" && 
                obj.Password != "")
            {
                using (var db = new ApplDbContext())
                {
                    db.UsersT.Add(obj);
                    db.SaveChanges();
                }
            }
            else { MessageBox.Show("Заполните все данные!"); }
        }
        public static void EditUser(Users obj)
        {
            if (obj.UserType != "" &&
                obj.UserEmployee != null &&
                obj.NickName != "" &&
                obj.Password != "")
            {
                using (var db = new ApplDbContext())
                {
                    Users user = db.UsersT.FirstOrDefault(el=> el.Id == obj.Id);
                    user.NickName = obj.NickName;
                    user.UserType = obj.UserType;
                    user.Password = obj.Password;
                    db.SaveChanges();
                }
            }
            else { MessageBox.Show("Заполните все данные!"); }
        }
        public static void EditSalon(Salons obj,Salons newSalon)
        {
            if (newSalon.SalonName != null &&
                newSalon.Director != null)
            {
                using (var db = new ApplDbContext())
                {
                    Salons salon = db.SalonsT.FirstOrDefault(el => el.Id == obj.Id);
                    salon.SalonName = newSalon.SalonName;
                    salon.Director = newSalon.Director;
                    db.SaveChanges();
                }
            }
            else { MessageBox.Show("Заполните все данные!"); }
        }
        public static void EditService(Data.Services obj, Data.Services newObj)
        {
            if (newObj.ServiceName != null)
            {
                using (var db = new ApplDbContext())
                {
                    Data.Services serv = db.ServicesT.FirstOrDefault(el => el.Id == obj.Id);
                    serv.ServiceName = newObj.ServiceName;
                    serv.TitleHandJob = newObj.TitleHandJob;
                    serv.TitleService = newObj.TitleService;
                    serv.ServiceType = newObj.ServiceType;
                    db.SaveChanges();
                }
            }
            else { MessageBox.Show("Заполните все данные!"); }
        }
        public static bool CheckIfPasswordIsCorrect(Users user, string inputtedPassword)
        {
            bool state = false;
            Users usera;
            using (var db = new ApplDbContext())
            {
                if (user != null)
                {
                    usera = db.UsersT.FirstOrDefault(el => el.Password == inputtedPassword && el.Id == user.Id);

                    if (usera == null)
                    {
                        state = false;
                        MessageBox.Show("Пароль введен не верно!");
                    }
                    else if(usera!=null)
                    {
                        state = true;
                    }
                }
                else MessageBox.Show("Выберите пользователя");

            }
            return state;
        }
        //public void AddEmployee(Ranks rank, Salons salon)
        //{
        //    using (var db = new ApplDbContext())
        //    {
        //        Employees emp = new Employees { FullName = "f" };
        //        emp.Rank_Id = rank.Id;
        //        emp.Salon_Id = salon.Id;
             
        //        db.EmployeesT.Add(emp);
        //        db.SaveChanges();
        //    }
        //}

        public static Salons GetSalonById(int id)
        {
            using (var db = new ApplDbContext())
                return db.SalonsT.First(el => el.Id == id);
        }
        public static Employees GetEmployeeById(int id)
        {
            using (var db = new ApplDbContext())
                return db.EmployeesT.First(el => el.Id == id);
        }
        public static List<Employees> GetEmployeesByRankId(int id)
        {
            using (var db = new ApplDbContext())
                return (from user in db.EmployeesT where user.Rank_Id == id select user).ToList();
        }
        public static List<Employees> GetEmployeesBySalonId(int id)
        {
            using (var db = new ApplDbContext())
                return (from user in db.EmployeesT where user.Salon_Id == id select user).ToList();
        }
    }
}
