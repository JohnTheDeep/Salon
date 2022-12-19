using Salon;
using SalonApp.Models.Data;
using SalonApp.Services.Commands;
using SalonApp.Services.PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalonApp.View.EditAvac
{
    public class EditAvacVM : PropertyChangedBase
    {
        private Window window;
        private Employees _selectedEmployee;
        public Employees SelectedEmployee
        {
            get => _selectedEmployee;
            set => Set(ref _selectedEmployee, value);
        }
        private Avancies _selectedAvac;
        public Avancies SelectedAvac
        {
            get => _selectedAvac;
            set => Set(ref _selectedAvac, value);
        }
        private List<Employees> _employees;
        public List<Employees> Employees
        {
            get => _employees;
            set => Set(ref _employees, value);
        }
        private DateTime _dateIn;
        public DateTime DateIn
        {
            get => _dateIn;
            set => Set(ref _dateIn, value);
        }
   
        private DateTime _dateOut;
        public DateTime DateOut
        {
            get => _dateOut;
            set => Set(ref _dateOut, value);
        }
        private RelayCommand _save;
        public RelayCommand Save
        {
            get
            {
                return _save ?? (_save = new RelayCommand(obj => 
                {
                    if(SelectedAvac !=null)
                    {
                        using (var db = new ApplDbContext())
                        {
                            var avac = db.AvanciesT.FirstOrDefault(el => el.Id == SelectedAvac.Id);
                            if(avac != null)
                            {
                                avac.DateIn = DateIn.ToString("dd/MM/yyyy");
                                avac.Fine = SelectedAvac.Fine;
                                avac.DateOut = DateOut.ToString("dd/MM/yyyy");
                                avac.Total = SelectedAvac.Total;
                                avac.IsDeduction = SelectedAvac.IsDeduction;
                                db.SaveChanges();
                                window.Close();
                            }
                        }
                    }
                }));
            }
        }
        public EditAvacVM(Avancies selectedAvac, Window window)
        {
            SelectedAvac = selectedAvac;
            DateOut = Convert.ToDateTime(selectedAvac.DateOut);
            DateIn = Convert.ToDateTime(selectedAvac.DateIn);
            this.window = window;
            using(var db = new ApplDbContext())
            {
                Employees = db.EmployeesT.Where(el => el.Salon_Id == selectedAvac.Employee.Salon_Id).ToList();
            }
            foreach(var employee in Employees)
            {
                if(employee.Id == SelectedAvac.Employee_Id)
                {
                    SelectedEmployee = employee;
                }
            }
        }
    }
}
