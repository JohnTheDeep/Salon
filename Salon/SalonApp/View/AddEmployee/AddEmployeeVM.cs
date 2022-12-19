using Salon;
using Salon.Models.Data;
using SalonApp.Models.Data;
using SalonApp.Services.Commands;
using SalonApp.Services.PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalonApp.View.AddEmployee
{
    public class AddEmployeeVM : PropertyChangedBase
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
        private decimal _phandjob;
        public decimal Phandjob
        {
            get => _phandjob;
            set => Set(ref _phandjob, value);
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
            using(var db = new ApplDbContext())
            {
                Employees = db.EmployeesT.Where(el=>el.Salon_Id == selectedSalon.Id).ToList();
                Ranks = db.RanksT.ToList();
            }
        }
        private RelayCommand _addEmployeeCommand;
        public RelayCommand AddEmployeeCommand
        {
            get
            {
                return _addEmployeeCommand ?? (_addEmployeeCommand = new RelayCommand(obj => 
                {
                    if (FullName != "" && SelectedRank != null && Email != "")
                    {
                        try
                        {
                            using (var db = new ApplDbContext())
                            {
                                db.EmployeesT.Add(new Employees
                            (FullName, selectedSalon.Id, SelectedRank.Id, false, Email ?? "", Ppackage, Pdepilation, Pmassage, Pelectrodepilation, Phandmassage, Paddit, Pfictive, Bid, false, EntryTreshold, Phandjob));
                                db.SaveChanges();
                                window.Close();
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                    else { MessageBox.Show("Заполните все данные!"); }
                }));
            }
        }
        public AddEmployeeVM(Window wind,Salons selected)
        {
            window = wind;
            selectedSalon = selected;
            FillList();
        }
    }
}
