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

namespace SalonApp.View.Settings.EditEnrollment
{
    public class EditEnrollmentVM : PropertyChangedBase
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
        private Enrollment _selectedEnrollment;
        public Enrollment SelectedEnrollment
        {
            get => _selectedEnrollment;
            set
            {
                Set(ref _selectedEnrollment, value);
            }
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
        private RelayCommand _save;
        public RelayCommand Save
        {
            get
            {
                return _save ?? (_save = new RelayCommand(obj =>
                {
                    if (Percent != null)
                    {
                        using (var db = new ApplDbContext())
                        {
                                Enrollment item = db.Enrollments.FirstOrDefault(el => el.Id == SelectedEnrollment.Id);
                                item.Percent = SelectedEnrollment.Percent;
                                db.SaveChanges();
                        }
                        window.Close();
                    }
                    else MessageBox.Show("Укажите процент");

                }));
            }
        }
        public EditEnrollmentVM(Window wind, Employees sSelectedEmployee,Enrollment selectedEnrl)
        {
            SelectedEmployee = sSelectedEmployee;
            SelectedEnrollment = selectedEnrl;
            window = wind;
            FillList();
        }
    }
}
