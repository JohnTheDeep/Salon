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
using System.Xml.Linq;

namespace SalonApp.View.AddAvancie
{
    public class AddAvVM : PropertyChangedBase
    {
        private decimal _avancie;
        public decimal Avancie
        {
            get => _avancie;
            set => Set(ref _avancie, value);
        }
        private decimal _fine;
        public decimal Fine
        {
            get => _fine;
            set => Set(ref _fine, value);
        }
        private DateTime _dateIn = DateTime.Today;
        public DateTime DateIn
        {
            get => _dateIn;
            set => Set(ref _dateIn, value);
        }
        private DateTime _dateOut = DateTime.Today;
        public DateTime DateOut 
        {
            get => _dateOut;
            set => Set(ref _dateOut, value);
        }
        private Employees _selectedEmployee;
        public Employees SelectedEmployees
        {
            get => _selectedEmployee;
            set => Set(ref _selectedEmployee, value);
        }
        private List<Employees> _employees;
        public List<Employees> Employees
        {
            get => _employees;
            set => Set(ref _employees, value);
        }
        private RelayCommand _add;
        public RelayCommand Add
        {
            get
            {
                return _add ?? (_add = new RelayCommand(obj=> 
                {
                    if (SelectedEmployees != null && SelectedEmployees.FullName != "")
                    {
                        if (MessageBox.Show($"Вы уверены что хотите добавить аванс суммой - {Avancie} злотых в таблицу авансов?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            using (var db = new ApplDbContext())
                            {
                                db.AvanciesT.Add(new Avancies
                                {
                                    Employee_Id = SelectedEmployees.Id,
                                    WhenString = DateTime.Today.ToString("dd/MM/yyyy"),
                                    DateIn = this.DateIn.ToString("dd/MM/yyyy"),
                                    DateOut = this.DateOut.ToString("dd/MM/yyyy"),
                                    IsDeduction = Checked,
                                    Fine = this.Fine,
                                    Total = this.Avancie
                                }); ;
                                db.SaveChanges();
                                wind.Close();
                            }
                        }

                    }
                    else MessageBox.Show("Введите все данные!");
                }));
            }
        }
        private bool _checked;
        public bool Checked
        {
            get => _checked;
            set => Set(ref _checked,value);
        }
        public void FillList(Salons sel)
        {
            using(var db = new ApplDbContext())
            {
                Employees = db.EmployeesT.Where(el => el.Salon_Id == sel.Id).ToList();
            }
        }
        private Salons _selectedSalon;
        public Salons SelectedSalon
        {
            get => _selectedSalon;
            set => Set(ref _selectedSalon, value);
        }
        private Window wind;
        public AddAvVM(Salons sel,Window wind)
        {
            this.wind = wind;
            FillList(sel);
            SelectedSalon = sel;
        }
    }
}
