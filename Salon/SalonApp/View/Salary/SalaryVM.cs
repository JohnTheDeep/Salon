using Microsoft.EntityFrameworkCore;
using Salon;
using SalonApp.Models.Data;
using SalonApp.Services.PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalonApp.View.Salary
{

    public class SalaryVM : PropertyChangedBase
    {
        protected partial class SalaryDTO
        {
             
        }
        private Employees _selectedEmployee;
        public Employees SelectedEmployee
        {
            get => _selectedEmployee;
            set => Set(ref _selectedEmployee, value);
        }
        private List<Journal> _journals;
        public List<Journal> Journals
        {
            get => _journals;
            set => Set(ref _journals, value);
        }
        private List<Additional> _additionals;
        public List<Additional> Additionals
        {
            get => _additionals;
            set => Set(ref _additionals, value);
        }
        private Models.Data.Duty _currentDuty;
        public Models.Data.Duty CurrentDuty
        {
            get => _currentDuty;
            set => Set(ref _currentDuty, value);
        }
        private Visibility _isVis = Visibility.Hidden;
        public Visibility IsVis
        {
            get => _isVis;
            set => Set(ref _isVis, value);
        }
        public SalaryVM(Employees empl,Models.Data.Duty dut)
        {
            SelectedEmployee = empl;
            CurrentDuty = dut;
            Fill();
        }
        private decimal _totalIn;
        public decimal TotalIn
        {
            get => _totalIn;
            set => Set(ref _totalIn, value);
        }
        private Users _user;
        public Users User
        {
            get => _user;
            set => Set(ref _user, value);
        }
        private decimal _totalIn2;
        public decimal TotalIn2
        {
            get => _totalIn2;
            set => Set(ref _totalIn2, value);
        }
        private decimal _bid;
        public decimal Bid
        {
            get => _bid;
            set => Set(ref _bid, value);
        }
        private decimal _adminBid;
        public decimal AdminBid
        {
            get => _adminBid;
            set => Set(ref _adminBid, value);
        }

        private void Fill()
        {
            using(var db = new ApplDbContext())
            {
                Journals = db.JournalT.Include(el=>el.Service).Where(el => el.Employee_id == SelectedEmployee.Id && el.DutyId == CurrentDuty.Id).ToList();
                var stat = db.StatisticT.FirstOrDefault(el=>el.Duty_Id == CurrentDuty.Id && el.Employee_Id == SelectedEmployee.Id);
                TotalIn = Journals is null ?  0 : Journals.Sum(el => el.UserTotal);
                User = db.UsersT.FirstOrDefault(el=>el.Employee_Id == SelectedEmployee.Id);
                if(User != null)
                {
                    Additionals = db.AdditionalsT.Where(el => el.UserId == User.Id && el.DutyId == CurrentDuty.Id).ToList(); 
                    TotalIn2 = Additionals is null ? 0 : Additionals.Sum(el => el.UserTotal);
                    Bid = stat is null ? 0 : stat.BaseBid;
                    IsVis = Visibility.Visible;
                    AdminBid = stat is null ? 0 : stat.VirtualAdminBid;
                }

            }
        }
    }
}
