using Microsoft.EntityFrameworkCore;
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

namespace SalonApp.View.ActiveEmployees
{
    public class ActiveEmployeesVM : PropertyChangedBase
    {
        private Salons _selectedSalon;
        public Salons SelectedSalon
        {
            get => _selectedSalon;
            set => Set(ref _selectedSalon, value);
        }
        private List<Employees> _employees;
        public List<Employees> Employees
        {
            get => _employees;
            set => Set(ref _employees, value);
        }
        private Employees _selectedEmployee;
        public Employees SelectedEmployee
        {
            get => _selectedEmployee;
            set => Set(ref _selectedEmployee, value);
        }
        public void FillList()
        {
            using(var db = new ApplDbContext())
            {
                
                Employees = db.EmployeesT.Include(el=> el.Rank).ToList().Where(el => el.Salon_Id == SelectedSalon?.Id).ToList();
            }
        }
        private RelayCommand _setActivEmployeeCommand;
        public RelayCommand SetActivEmployeeCommand
        {
            get
            {
                return _setActivEmployeeCommand ?? (_setActivEmployeeCommand = new RelayCommand(obj => 
                {
                    if(SelectedEmployee != null && SelectedEmployee?.FullName != "")
                    {
                        try
                        {
                            using (var db = new ApplDbContext())
                            {
                                var emp = db.EmployeesT.FirstOrDefault(el => el == SelectedEmployee);
                                if (emp?.IsActive == false)
                                {
                                    emp.IsActive = true;
                                }
                                else if (emp?.IsActive == true)
                                {
                                    emp.IsActive = false;
                                }
                                db.SaveChanges();
                                FillList();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                    else { MessageBox.Show("Выберите мастера"); }
                }));

            }
        }
        public ActiveEmployeesVM(Salons selectedSalon)
        {
            SelectedSalon = selectedSalon; FillList();
        }
    }
}
