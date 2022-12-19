using Salon;
using Salon.Models.Data;
using SalonApp.Models.Data;
using SalonApp.Services.Commands;
using SalonApp.Services.DbCommands;
using SalonApp.Services.PropertyChanged;
using SalonApp.ViewModel.MainWindowViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Data = SalonApp.Models.Data;

namespace SalonApp.View.AddJournal
{
    public class AddJournalVM : PropertyChangedBase
    {
        private Window window;
        private string _clientName;
        public string ClientName
        {
            get => _clientName;
            set => Set(ref _clientName, value);
        }

        private decimal _cash;
        public decimal Cash
        {
            get => _cash;
            set => Set(ref _cash, value);
        }

        private decimal _nonCash;
        public decimal NonCash
        {
            get => _nonCash;
            set => Set(ref _nonCash, value);
        }

        private decimal _transfer;
        public decimal Transfer
        {
            get => _transfer;
            set => Set(ref _transfer, value);
        }
        private decimal _fictive;
        public decimal Fictive
        {
            get => _fictive;
            set => Set(ref _fictive, value);
        }
        private decimal _package;
        public decimal Package
        {
            get => _package;
            set => Set(ref _package, value);
        }

        private decimal _packageCash;
        public decimal PackageCash
        {
            get => _packageCash;
            set => Set(ref _packageCash, value);
        }

        private decimal _packageNonCash;
        public decimal PackageNonCash
        {
            get => _packageNonCash;
            set => Set(ref _packageNonCash, value);
        }
        private decimal _packageTransfer;
        public decimal PackageTransfer
        {
            get => _packageTransfer;
            set => Set(ref _packageTransfer, value);
        }
        private decimal _additCash;
        public decimal AdditCash
        {
            get => _additCash;
            set => Set(ref _additCash, value);
        }

        private decimal _additNonCash;
        public decimal AdditNonCash
        {
            get => _additNonCash;
            set => Set(ref _additNonCash, value);
        }

        private decimal _handJobCash;
        public decimal HandJobCash
        {
            get => _handJobCash;
            set => Set(ref _handJobCash, value);
        }
        private decimal _handJobNonCash;
        public decimal HandJobNonCash
        {
            get => _handJobNonCash;
            set => Set(ref _handJobNonCash, value);
        }

        private decimal _sertificateCash;
        public decimal SertificateCash
        {
            get => _sertificateCash;
            set => Set(ref _sertificateCash, value);
        }
        private decimal _sertificateNonCash;
        public decimal SertificateNonCash
        {
            get => _sertificateCash;
            set => Set(ref _sertificateCash, value);
        }

        private decimal _sertificate;
        public decimal Sertificate
        {
            get => _sertificate;
            set => Set(ref _sertificate, value);
        }
        private decimal _total;
        public decimal Total
        {
            get => _total;
            set => Set(ref _total, value);
        }
        private decimal _admintotal;
        public decimal AdminTotal
        {
            get => _admintotal;
            set => Set(ref _admintotal, value);
        }
        private decimal _userTotal;
        public decimal UserTotal
        {
            get => _userTotal;
            set => Set(ref _userTotal, value);
        }
        public AddJournalVM()
        {

        }
        private void Stat(Users admin, Employees selectedEmployee)
        {
            Total = Cash + NonCash;
            using (var db = new ApplDbContext())
            {
                var user = db.UsersT.FirstOrDefault(el => el.Id == admin.Id);
                decimal prA = default;
                
                AdminTotal = 
                    (((PackageCash + PackageNonCash) / 100) * (decimal)user.Ppackage);
                decimal prE = default;
                foreach(var v in selectedEmployee.Enrollments)
                {
                    if(v.Service.Id == selectedService.Id)
                    {
                        prE = v.Percent;
                        break;
                    }
                }
                UserTotal = 
                    (((Cash + NonCash + Transfer + Sertificate) / 100) * prE) +
                    ((Fictive / 100) * (decimal)selectedEmployee.Pfictive) + 
                    (( (PackageCash + PackageNonCash) / 100) * (decimal) selectedEmployee.Ppackage) +
                    (((AdditCash + AdditNonCash) / 100) * (decimal)selectedEmployee.Paddit) +
                    (((HandJobCash + HandJobNonCash) / 100) * (decimal)selectedEmployee.Phandjob);
 
            }
        }
        private RelayCommand _addJournal;
        public RelayCommand AddJournal
        {
            get
            {
                return _addJournal ?? (_addJournal = new RelayCommand(obj =>
                {
                    try
                    {
                        using (var db = new ApplDbContext())
                        {
                            string date = (DateTime.Today.ToString("dd/MM/yyyy")).ToString();
                            var dutyId = (db.DutyT.FirstOrDefault(el => el.DutyDate == date && el.Salon_Id == selectedSalon.Id));
                            if (dutyId?.Id != 0 && dutyId?.Id != null)
                            {
                                if (ClientName != null && ClientName != "")
                                {
                                    Stat(dutyAdmin, selectedEmployee);
                                    db.JournalT.Add(new Journal
                                    {
                                        DutyId = dutyId.Id,
                                        Service_Id = selectedService.Id,
                                        Employee_id = selectedEmployee.Id,
                                        ClientName = this.ClientName,
                                        Cash = this.Cash,
                                        NonCash = this.NonCash,
                                        Transfer = this.Transfer,
                                        Fictive = this.Fictive,
                                        Package = this.Package,
                                        PackageCash = this.PackageCash,
                                        PackageNonCash = this.PackageNonCash,
                                        PackageTransfer = this.PackageTransfer,
                                        AdditCash = this.AdditCash,
                                        AdditNonCash = this.AdditNonCash,
                                        HandJobCash = this.HandJobCash,
                                        HandJobNonCash = this.HandJobNonCash,
                                        Sertificate = this.Sertificate,
                                        Total = this.Total,
                                        UserTotal = this.UserTotal

                                    });
          
                                    db.SaveChanges(); 

                                    //string date2 = DateTime.Today.ToString("dd/MM/yyyy");
                                    //var duty = db.DutyT.FirstOrDefault(el => el.DutyDate == date2 && el.Salon_Id == selectedSalon.Id);
                                    //Controller.Calculate(selectedSalon);

                                    //var item = db.StatisticT.FirstOrDefault(el => el.Duty_Id == dutyId.Id && el.Employee_Id == selectedEmployee.Id);
                                    //var itemUser = db.UsersT.First(el => el.Id == duty.User_Id);
                                    //var itemAdmin = db.StatisticT.Where(el => el.Duty.DutyDate == duty.DutyDate).FirstOrDefault(el => el.Employee_Id == db.UsersT.First(el => el.Id == duty.User_Id).Employee_Id);

                                    //if (item != null)
                                    //{
                                    //    item.Total += UserTotal;
                                    //    db.SaveChanges();
                                    //}
                                    //else
                                    //{
                                    //    db.StatisticT.Add(new Statistic { Duty_Id = dutyId.Id, Employee_Id = selectedEmployee.Id, IsAdmin = selectedEmployee.IsAdmin, IsVirtualAdmin = false, Total = UserTotal });
                                    //    db.SaveChanges();
                                    //    item = db.StatisticT.FirstOrDefault(el => el.Duty_Id == duty.Id && el.Employee_Id == selectedEmployee.Id);

                                    //}
                                    //var stat = db.StatisticT.FirstOrDefault(el => el.Employee_Id == selectedEmployee.Id && el.Duty_Id == duty.Id);
                                    //if (stat.Total < selectedEmployee.EntryTreshold && stat.BaseBid < selectedEmployee.Bid)
                                    //{
                                    //    stat.BaseBid = selectedEmployee.Bid; db.SaveChanges();
                                    //}
                                    //if (stat.Total > selectedEmployee.EntryTreshold && stat.BaseBid >= selectedEmployee.Bid)
                                    //{
                                    //    stat.BaseBid = 0; db.SaveChanges();
                                    //}
                                    //if (itemAdmin != null)
                                    //{
                                    //    decimal admt = 0;

                                    //    foreach (var v in db.JournalT.ToList().Where(el => el.DutyId == duty.Id))
                                    //    {
                                    //        admt += (((v.PackageCash + v.PackageNonCash) / 100) * (decimal)duty.User.Ppackage);
                                    //    }

                                    //    decimal amdt2 = 0;
                                    //    var user = db.UsersT.FirstOrDefault(el => el.Id == duty.User_Id);
                                    //    foreach (var v in db.AdditionalsT.Where(el => el.UserId == duty.User_Id && el.DutyId == duty.Id).ToList())
                                    //    {
                                    //        amdt2 += (((v.Cash + v.NonCash) / 100) * (decimal)user.Paddit) + ((v.Sertificate / 100) * (decimal)user.Psertificate);
                                    //    }
                                    //    itemAdmin.Total = admt + amdt2;
                                    //    itemAdmin.VirtualAdminBid = (duty.IsVirtualAdmin ? (decimal)itemUser.VirtualAdminBid : 0);
                                    //    db.SaveChanges();
                                    //}
                                    //else
                                    //{
                                    //    db.StatisticT.Add(new Statistic
                                    //    {
                                    //        Duty_Id = dutyId.Id,
                                    //        Employee_Id = itemUser.Employee_Id,
                                    //        IsAdmin = true,
                                    //        IsVirtualAdmin = duty.IsVirtualAdmin,
                                    //        Total = AdminTotal,
                                    //        VirtualAdminBid = (duty.IsVirtualAdmin ? (decimal)itemUser.VirtualAdminBid : 0)
                                    //    });
                                    //    db.SaveChanges();
                                    //}
                                    //itemAdmin = db.StatisticT.Where(el => el.Duty.DutyDate == duty.DutyDate).FirstOrDefault(el => el.Employee_Id == db.UsersT.First(el => el.Id == duty.User_Id).Employee_Id);

                                    //var ass = db.SalaryTresholdT.ToList();
                                    //var packagesAmount = db.JournalT.Where(el => el.DutyId == duty.Id).ToList();
                                    //var summ = packagesAmount.Sum(el => el.PackageCash + el.PackageNonCash);
                                    //var dutyTotal = duty.Total;
                                    //decimal adm = (decimal)dutyTotal - (decimal)summ;
                                    //if (ass != null)
                                    //{
                                    //    foreach (var d in ass)
                                    //    {
                                    //        string[] tre = d.Threshold.Split('-');
                                    //        decimal inI = decimal.Parse(tre[0]);
                                    //        decimal inOut = decimal.Parse(tre[1]);
                                    //        if (adm >= inI)
                                    //            itemAdmin.BaseBid = d.Bid;
                                    //    }
                                    //}
                                    db.SaveChanges();

                                    window.Close();
                                }
                                else MessageBox.Show("Заполните все данные!");
                            }
                            else
                            {
                                MessageBox.Show("Смена на текущий день не открыта!");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }));
            }
        }
        private Salons _selectedSalon;
        public Salons selectedSalon
        {
            get => _selectedSalon;
            set => Set(ref _selectedSalon, value);
        }
        private Data.Services _selectedService;
        public Data.Services selectedService
        {
            get => _selectedService;
            set => Set(ref _selectedService, value);
        }
        private Employees _selectedEmployee;
        public Employees selectedEmployee
        {
            get => _selectedEmployee;
            set => Set(ref _selectedEmployee, value);
        }
        private Users _dutyAdmin; 
        public Users dutyAdmin
        {
            get => _dutyAdmin;
            set => Set(ref _dutyAdmin, value);
        }
        public AddJournalVM(Window wind, Salons _selectedSalon, Data.Services _selectedService, Employees _selectedEmployee, Users _dutyAdmin)
        {
            selectedSalon = _selectedSalon;
            selectedService = _selectedService;
            selectedEmployee = _selectedEmployee;
            dutyAdmin = _dutyAdmin;
            window = wind;
        }
    }
}
