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
        private decimal _pdepilation;
        public decimal Pdepilation
        {
            get => _pdepilation;
            set => Set(ref _pdepilation, value);
        }
        private decimal _pmassage;
        public decimal Pmassage
        {
            get => _pmassage;
            set => Set(ref _pmassage, value);
        }
        private decimal _pelectrodepilation;
        public decimal Pelectrodepilation
        {
            get => _pelectrodepilation;
            set => Set(ref _pelectrodepilation, value);
        }
        private decimal _phandmassage;
        public decimal Phandmassage
        {
            get => _phandmassage;
            set => Set(ref _phandmassage, value);
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

        private Salons selectedSalon;
        private List<Employees> _empl;
        public List<Employees> Employees
        {
            get => _empl;
            set => Set(ref _empl, value);
        }
        private void FillList()
        {
            using (var db = new ApplDbContext())
            {
                Employees = db.EmployeesT.Include(el=>el.Rank).Where(el => el.Salon_Id == selectedSalon.Id).ToList();
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
                    if (FullName != "" && SelectedRank != null && Email != "")
                    {

                        using (var db = new ApplDbContext())
                        {
                            var emp1 = db.EmployeesT.FirstOrDefault(el => el.Id == SelectedEmp.Id);
                            var rank = db.RanksT.FirstOrDefault(el => el.Id == SelectedRank.Id);
         
                            emp1.FullName = FullName;
                            emp1.Rank_Id = SelectedRank.Id;
                            emp1.Email = Email;
                            emp1.Ppackage = Ppackage;
                            emp1.Pdepilation = Pdepilation;
                            emp1.Pmassage = Pmassage;
                            emp1.Pelectrodepilation = Pelectrodepilation;
                            emp1.Phandmassage = Phandmassage;
                            emp1.Paddit = Paddit;
                            emp1.Pfictive = Pfictive;
                            emp1.Bid = Bid;
                            
                            db.SaveChanges();
                            window.Close();
                        }
                    }
                    else { MessageBox.Show("Заполните все данные!"); }
                }));
            }
        }
        private Employees _selectedEmp;
        public Employees SelectedEmp
        {
            get => _selectedEmp;
            set => Set(ref _selectedEmp, value);
        }
        public EditEmployeeVM(Window wind, Salons selected,Employees selectedEmp)
        {
            window = wind;
            selectedSalon = selected;
            SelectedEmp = selectedEmp;

            FillList();
            FullName = selectedEmp.FullName;
            SelectedRank = selectedEmp.Rank;
            Email = selectedEmp.Email;
            Ppackage = selectedEmp.Ppackage;
            Pdepilation = selectedEmp.Pdepilation;
            Pmassage = selectedEmp.Pmassage;
            Pelectrodepilation = selectedEmp.Pelectrodepilation;
            Phandmassage = selectedEmp.Phandmassage;
            Paddit = selectedEmp.Paddit;
            Pfictive = selectedEmp.Pfictive;
            Bid = selectedEmp.Bid;
        }
    }
}
