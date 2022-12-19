using Microsoft.EntityFrameworkCore;
using Salon;
using Salon.Models.Data;
using SalonApp.Models.Data;
using SalonApp.Services.DbCommands;
using SalonApp.Services.PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serv = SalonApp.Models.Data;
namespace SalonApp.ViewModel
{
    public class ServicesVM : PropertyChangedBase
    {
        private Serv.Services _service;
        public Serv.Services Service
        {
            get => _service;
            set => Set(ref _service, value);
        }
        private List<Employees> _employees;
        public List<Employees> Employees
        {
            get => _employees;
            set => Set(ref _employees, value);
        }
        public ServicesVM(Salons salon,Serv.Services serv)
        {
            Service = serv;
            using(var db = new ApplDbContext())
            {
                List<Employees> ll = db.EmployeesT.ToList().Where(el => el.Salon_Id == salon.Id && el.IsActive == true).ToList();
                var ss = ll.Select(el => el.Enrollments.ToList()).ToList();
                
            }
            List<Employees> sa = new List<Employees>();
            using (var db = new ApplDbContext())
            {
                var ss = Controller.GetAllServicesEmployee(salon.Id);
                foreach(var item in ss)
                {
                    foreach(var sec in item.Services)
                    {
                        if (sec.Id == serv.Id)
                        {
                            sa.Add(item);
                            break;
                        }
                    }
                }
                
            }
            Employees = sa;
        }
    }
}
