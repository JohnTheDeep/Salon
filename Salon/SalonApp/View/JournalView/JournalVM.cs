
using Salon;
using Salon.Models.Data;
using SalonApp.Models.Data;
using SalonApp.Services.PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace SalonApp.View.JournalView
{
    public class JournalVM : PropertyChangedBase
    {

        private List<Journal> _journals;
        public List<Journal> Journals
        {
            get => _journals;
            set => Set(ref _journals, value);
        }
        private SalonApp.Models.Data.Services _service;
        public SalonApp.Models.Data.Services Service
        {
            get => _service;
            set => Set(ref _service, value);
        }
        private Employees _Employee;
        public Employees Employee
        {
            get => _Employee;
            set => Set(ref _Employee, value);
        }
        private SalonApp.Models.Data.Duty _duty;
        public SalonApp.Models.Data.Duty Duty
        {
            get => _duty;
            set => Set(ref _duty, value);
        }
        private decimal _totalCash;
        public decimal TotalCash
        {
            get => _totalCash;
            set => Set(ref _totalCash, value);
        }
        private decimal _totalNonCash;
        public decimal TotalNonCash
        {
            get => _totalNonCash;
            set => Set(ref _totalNonCash, value);
        }
        private decimal _emplTotal;
        public decimal EmplTotal
        {
            get => _emplTotal;
            set => Set(ref _emplTotal,value);
        }
        private decimal _adminTotal;
        public decimal AdminTotal
        {
            get => _adminTotal;
            set => Set(ref _adminTotal, value);
        }
        private decimal _packagesCahs;
        public decimal PackagesCahs
        {
            get => _packagesCahs;
            set => Set(ref _packagesCahs, value);
        }
        private decimal _packagesNonCahs;
        public decimal PackagesNonCahs
        {
            get => _packagesNonCahs;
            set => Set(ref _packagesNonCahs, value);
        }
        private decimal _sertificates;
        public decimal Sertificates
        {
            get => _sertificates;
            set => Set(ref _sertificates, value);
        }
        public JournalVM(Employees empl, SalonApp.Models.Data.Duty duty, SalonApp.Models.Data.Services service, Salons SelectedSalon)
        {
            try
            {
                AdminTotal = 0;
                using (var db = new ApplDbContext())
                {
                    int userId = (int)db.DutyT.FirstOrDefault(el => el.Id == duty.Id && el.Salon_Id == SelectedSalon.Id).User_Id;

                    var user = db.UsersT.FirstOrDefault(el => el.Id == userId);

                    Journals = db.JournalT.Where(el => el.Employee_id == empl.Id && el.DutyId == duty.Id && el.Service_Id == service.Id).ToList();
                    EmplTotal = db.StatisticT.Where(el => el.Employee_Id == empl.Id && el.Duty_Id == duty.Id).FirstOrDefault().Total;
                    foreach (var i in Journals)
                    {
                        AdminTotal += (((i.PackageCash + i.PackageNonCash) / 100) * (decimal)user.Ppackage);
                    }
                    PackagesCahs = Journals.Sum(el => el.PackageCash);
                    PackagesNonCahs = Journals.Sum(el => el.PackageNonCash); ;
                    Sertificates = Journals.Sum(el => el.Sertificate);
                }
                TotalCash = Journals.Sum(el => el.Cash);
                TotalNonCash = Journals.Sum(el => el.NonCash);
                Employee = empl;
                Duty = duty;
                
                Service = service;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }
    }
}
