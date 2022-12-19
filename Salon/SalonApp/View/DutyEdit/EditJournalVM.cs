using Microsoft.EntityFrameworkCore;
using Salon;
using SalonApp.Models.Data;
using SalonApp.Services.DbCommands;
using SalonApp.Services.PropertyChanged;
using System;
using System.Linq;
using System.Security.Policy;
using System.Windows;
using static System.Windows.Forms.AxHost;
using RelayCommand = SalonApp.Services.Commands.RelayCommand;

namespace SalonApp.View.DutyEdit
{
    public class EditJournalVM : PropertyChangedBase
    {
        private Journal _selectedJ;
        public Journal SelectedJ
        {
            get => _selectedJ;
            set => Set(ref _selectedJ, value);
        }
        private Journal _oldSelectedJ;
        public Journal OldSelectedJ
        {
            get => _oldSelectedJ;
            set => Set(ref _oldSelectedJ, value);
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
        private decimal _oldCashPerDay;
        public decimal OldCashPerDay
        {
            get => _oldCashPerDay;
            set => Set(ref _oldCashPerDay, value);
        }
        private decimal _oldNonCashPerDay;
        public decimal OldNonCashPerDay
        {
            get => _oldNonCashPerDay;
            set => Set(ref _oldNonCashPerDay, value);
        }
        private decimal _oldTransfersPerDay;
        public decimal OldTransfersPerDay
        {
            get => _oldTransfersPerDay;
            set => Set(ref _oldTransfersPerDay, value);
        }
            private decimal _oldTotal;
        public decimal OldTotal
        {
            get => _oldTotal;
            set => Set(ref _oldTotal, value);
        }
        private decimal _oldTotalSertificates;

        public decimal OldTotalSertificates
        {
            get => _oldTotalSertificates;
            set => Set(ref _oldTotalSertificates, value);
        }
        
        private void Stat(Employees selectedEmployee)
        {
            Total = SelectedJ.Cash + SelectedJ.NonCash;
            using (var db = new ApplDbContext())
            {
                var user = db.UsersT.FirstOrDefault(el => el.Id == Duty.User_Id);
                decimal prA = default;

                AdminTotal =
                    (((SelectedJ.PackageCash + SelectedJ.PackageNonCash) / 100) * (decimal)user.Ppackage);
                decimal prE = default;
                foreach (var v in selectedEmployee.Enrollments)
                {
                    if (v.Service.Id == SelectedJ.Service_Id)
                    {
                        prE = v.Percent;
                        break;
                    }
                }
                UserTotal = (((SelectedJ.Cash + SelectedJ.NonCash + SelectedJ.Transfer + SelectedJ.Sertificate) / 100) * prE) +
                    ((SelectedJ.Fictive / 100) * (decimal)selectedEmployee.Pfictive) +
                    (((SelectedJ.AdditCash + SelectedJ.AdditNonCash) / 100) * (decimal)selectedEmployee.Paddit) +
                    (((SelectedJ.HandJobCash + SelectedJ.HandJobNonCash) / 100) * (decimal)selectedEmployee.Phandjob);
            }
        }
        private RelayCommand _edit;
        public RelayCommand Edit
        {
            get
            {
                return _edit ?? (_edit = new RelayCommand(obj => 
                {
                    EditVoid();

                }));
            }
        }
        private void EditVoid()
        {
            try
            {
                using (var db = new ApplDbContext())
                {
                    if (SelectedJ.ClientName != null && SelectedJ.ClientName != "")
                    {
                        Journal toEdit = db.JournalT.FirstOrDefault(el => el.Id == SelectedJ.Id);
                        toEdit.ClientName = SelectedJ.ClientName;
                        toEdit.Cash = SelectedJ.Cash;
                        toEdit.NonCash = SelectedJ.NonCash;
                        toEdit.Transfer = SelectedJ.Transfer;
                        toEdit.Fictive = SelectedJ.Fictive;
                        toEdit.Package = SelectedJ.Package;
                        toEdit.PackageCash = SelectedJ.PackageCash;
                        toEdit.PackageNonCash = SelectedJ.PackageNonCash;
                        toEdit.PackageTransfer = SelectedJ.PackageTransfer;
                        toEdit.AdditCash = SelectedJ.AdditCash;
                        toEdit.AdditNonCash = SelectedJ.AdditNonCash;
                        toEdit.HandJobCash = SelectedJ.HandJobCash;
                        toEdit.HandJobNonCash = SelectedJ.HandJobNonCash;
                        toEdit.Sertificate = SelectedJ.Sertificate;
                        toEdit.Total = SelectedJ.Cash + SelectedJ.NonCash;
                        Stat(db.EmployeesT.Include(el => el.Enrollments).Include(el => el.Services).Include(el => el.Journals).FirstOrDefault(el => el.Id == SelectedJ.Employee_id));
                        toEdit.UserTotal = UserTotal;
                        db.SaveChanges();           
                        window.Close();
                    }
                    else MessageBox.Show("Заполните все данные!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private Models.Data.Duty _duty;
        public Models.Data.Duty Duty
        {
            get => _duty;
            set => Set(ref _duty, value);
        }
        private Models.Data.Duty _oldduty;
        public Models.Data.Duty OldDuty
        {
            get => _oldduty;
            set => Set(ref _oldduty, value);
        }
        private Window window;
        public EditJournalVM(Journal j,Window w)
        {
            window = w;
            SelectedJ = j;
            OldSelectedJ = j;
            OldDuty = new Models.Data.Duty();
            using (var db = new ApplDbContext())
            {
                Duty = db.DutyT.Include(el=>el.User).FirstOrDefault(el => el.Id == SelectedJ.DutyId);
                OldDuty.Journals = Duty.Journals;
                OldDuty.Salon_Id = Duty.Salon_Id;
                OldDuty.Salon = Duty.Salon;
                OldDuty.NonCashPerDay = Duty.NonCashPerDay;
                OldDuty.CashPerDay = Duty.CashPerDay;
                OldDuty.TransfersPerDay = Duty.TransfersPerDay;
                OldDuty.DutyDate = Duty.DutyDate;
                OldDuty.IsVirtualAdmin = Duty.IsVirtualAdmin;
                OldDuty.Statistics = Duty.Statistics;
                OldDuty.User = Duty.User;
                OldDuty.User_Id = Duty.User_Id;
                OldDuty.Total = Duty.Total;
                Stat(db.EmployeesT.Include(el=>el.Enrollments).Include(el=>el.Services).Include(el=>el.Journals).FirstOrDefault(el=>el.Id == SelectedJ.Employee_id));
            }


        }
    }
}
