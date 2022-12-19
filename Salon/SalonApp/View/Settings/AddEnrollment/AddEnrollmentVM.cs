using Microsoft.EntityFrameworkCore;
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

namespace SalonApp.View.Settings.AddEnrollment
{
    public class AddEnrollmentVM : PropertyChangedBase
    {
        private Window window;
        private SalonApp.Models.Data.Services _selectedServ;
        public SalonApp.Models.Data.Services SelectedService
        {
            get => _selectedServ;
            set
            {
                Set(ref _selectedServ, value);
            }
        }
        private decimal _percent;
        public decimal Percent
        {
            get => _percent;
            set => Set(ref _percent, value);
        }
        private Employees _selectedEmployee;
        public Employees SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                Set(ref _selectedEmployee, value);
            }
        }
        private List<SalonApp.Models.Data.Services> _serv;
        public List<SalonApp.Models.Data.Services> ServicesList
        {
            get => _serv;
            set => Set(ref _serv, value);
        }
        public void FillList()
        {
            using (var db = new ApplDbContext())
            {
                ServicesList = (db.Salon_Service.Include(empa => empa.Service).Where(el => el.Salon_id == SelectedEmployee.Salon_Id).ToList()).ToList().Select(el => el.Service).ToList();
            }
        }
        private RelayCommand _add;
        public RelayCommand Add
        {
            get
            {
                return _add ?? (_add = new RelayCommand(obj =>
                {
                    if (SelectedService != null && SelectedService.ServiceName != "" )
                    {
                        using(var db = new ApplDbContext())
                        {
                            if(db.Enrollments.Where(el => el.EmployeeId == SelectedEmployee.Id && el.ServiceId == SelectedService.Id).ToList().Count == 0)
                            {
                                db.Enrollments.Add(new Enrollment { EmployeeId = SelectedEmployee.Id, ServiceId = SelectedService.Id, Percent = Percent }) ;
                                db.SaveChanges();
                            }
                            else { MessageBox.Show("Мастер уже имеет данную услугу!"); }

                        }
                        window.Close();
                    }
                    else MessageBox.Show("Выберите услугу");
                    
                }));
            }
        }
        public AddEnrollmentVM(Window wind,Employees sSelectedEmployee)
        {
            SelectedEmployee = sSelectedEmployee;
            window = wind;
            FillList();
        }
    }
}
