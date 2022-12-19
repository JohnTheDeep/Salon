using Salon;
using Salon.Models.Data;
using SalonApp.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Data = SalonApp.Models.Data;
namespace SalonApp.Services.DbCommands
{
    public class Controller
    {
        public static Ranks GetRankById(int id)
        {
            using (var db = new ApplDbContext())
            {
                return db.RanksT.FirstOrDefault(el => el.Id == id);
            }
        }
        public static void SetActivity(Salon_Service serv, bool statement)
        {
            using(var db = new ApplDbContext())
            {
                if (serv != null)
                {

                    var ss = db.Salon_Service.FirstOrDefault(el => el.Id == serv.Id);
                    ss.IsActive = statement;
                    db.SaveChanges();
                }
            }
        }
        public static void AddService(Data.Services serv, Salons salon)
        {
            using (var db = new ApplDbContext())
            {
                if (!db.ServicesT.Any(el => el.ServiceName == serv.ServiceName))
                {
                    serv.Salon_Service.Add(new Salon_Service { Service_Id = serv.Id, Salon_id = salon.Id, Comment = "", IsActive = false });
                    db.ServicesT.Add(serv);
                    db.SaveChanges();
                }
                else MessageBox.Show("Услуга с таким именем уже существует!");
            }
        }
        public static void AddEnrollment(int empid, int servie)
        {
            using(var db = new ApplDbContext())
            {
                Employees em = db.EmployeesT.FirstOrDefault(el => el.Id == empid);
                em.Enrollments.Add(new Enrollment { EmployeeId = empid, ServiceId = servie, Comment = "Fuck" });
                db.SaveChanges();
            }
        }
        public static List<SalonApp.Models.Data.Services> GetAllEmployeeServices(int id)
        {
            using(var db = new ApplDbContext())
            {
                return (db.ServicesT.Include(empa => empa.Employees).Where(el => el.Id == id).ToList());
            }
        }
        public static List<SalonApp.Models.Data.Employees> GetAllServicesEmployee(int id)
        {
            using (var db = new ApplDbContext())
            {
                return (db.EmployeesT.Include(empa => empa.Services).ThenInclude(el=>el.Enrollments).Where(el => el.Salon_Id == id).ToList());
            }
        }
        public static List<SalonApp.Models.Data.Salon_Service> GetAllSalonServices(int id)
        {
            using (var db = new ApplDbContext())
            {
                return (db.Salon_Service.Include(empa => empa.Service).Where(el => el.Salon_id == id).ToList());
            }
        }
        public static List<SalonApp.Models.Data.Salon_Service> GetAllSalonServicess(int id)
        {
            using (var db = new ApplDbContext())
            {
                return (db.Salon_Service.Include(empa => empa.Service).ThenInclude(ela => ela.Salons).Where(el => el.Salon_id == id && el.IsActive == true).ToList());
            }
        }
        //public static void GetAllSalonServices(int id)
        //{
        //    using (var db = new ApplDbContext())
        //    {
        //        var list = (db.SalonsT.Include(empa => empa.Services).ThenInclude(ela => ela.Salon_Service).Where(el => el.Id == id).ToList());

        //    }
        //}
        public static void AddSalon(Salons salon)
        {
            using (var db = new ApplDbContext())
            {
                if(salon != null && salon.Director != null && salon.SalonName != null)
                {
                    if (!db.SalonsT.Any(el => el.SalonName == salon.SalonName))
                    {
                        db.SalonsT.Add(salon);
                        db.SaveChanges();
                    }
                    else MessageBox.Show("Ошибка, салон под таким именем уже существует!");
                }
                
            }
        }
        public static void DeleteSalon(Salons Salon)
        {
            using (var db = new ApplDbContext())
            {
                db.SalonsT.Remove(Salon);
                db.SaveChanges();
            }
        }
        public static void DeleteService(Data.Services service)
        {
            using (var db = new ApplDbContext())
            {
                db.ServicesT.Remove(service);
                db.SaveChanges();
            }
        }
        public static void DeleteUser(Users user)
        {
            using (var db = new ApplDbContext())
            {
                db.UsersT.Remove(user);
                db.SaveChanges();
            }
        }
        public static void AddRank(Ranks obj)
        {
            using (var db = new ApplDbContext())
            {
                db.RanksT.Add(obj);
                db.SaveChanges();
            }
        }
        public static void AddUser(Users obj)
        {
            if(obj.UserType != "" && 
                obj.UserEmployee != null &&
                obj.NickName != "" && 
                obj.Password != "")
            {
                using (var db = new ApplDbContext())
                {
                    db.UsersT.Add(obj);
                    db.SaveChanges();
                }
            }
            else { MessageBox.Show("Заполните все данные!"); }
        }
        public static void EditUser(Users obj)
        {
            if (obj.UserType != "" &&
                obj.UserEmployee != null &&
                obj.NickName != "" &&
                obj.Password != "")
            {
                using (var db = new ApplDbContext())
                {
                    Users user = db.UsersT.FirstOrDefault(el=> el.Id == obj.Id);
                    user.NickName = obj.NickName;
                    user.UserType = obj.UserType;
                    user.Password = obj.Password;
                    db.SaveChanges();
                }
            }
            else { MessageBox.Show("Заполните все данные!"); }
        }
        public static void EditSalon(Salons obj,Salons newSalon)
        {
            if (newSalon.SalonName != null &&
                newSalon.Director != null)
            {
                using (var db = new ApplDbContext())
                {
                    Salons salon = db.SalonsT.FirstOrDefault(el => el.Id == obj.Id);
                    salon.SalonName = newSalon.SalonName;
                    salon.Director = newSalon.Director;
                    db.SaveChanges();
                }
            }
            else { MessageBox.Show("Заполните все данные!"); }
        }
        public static void EditService(Data.Services obj, Data.Services newObj)
        {
            if (newObj.ServiceName != null)
            {
                using (var db = new ApplDbContext())
                {
                    Data.Services serv = db.ServicesT.FirstOrDefault(el => el.Id == obj.Id);
                    serv.ServiceName = newObj.ServiceName;
                    db.SaveChanges();
                }
            }
            else { MessageBox.Show("Заполните все данные!"); }
        }
        public static bool CheckIfPasswordIsCorrect(Users user, string inputtedPassword)
        {
            bool state = false;
            using (var db = new ApplDbContext())
            {
                 state =  db.UsersT.Any(el => el.Password == inputtedPassword);
                if (!state)
                    MessageBox.Show("Пароль введен не верно!");
            }
            return state;
        }
        //public void AddEmployee(Ranks rank, Salons salon)
        //{
        //    using (var db = new ApplDbContext())
        //    {
        //        Employees emp = new Employees { FullName = "f" };
        //        emp.Rank_Id = rank.Id;
        //        emp.Salon_Id = salon.Id;
             
        //        db.EmployeesT.Add(emp);
        //        db.SaveChanges();
        //    }
        //}

        public static Salons GetSalonById(int id)
        {
            using (var db = new ApplDbContext())
                return db.SalonsT.First(el => el.Id == id);
        }
        public static Employees GetEmployeeById(int id)
        {
            using (var db = new ApplDbContext())
                return db.EmployeesT.First(el => el.Id == id);
        }
        public static List<Employees> GetEmployeesByRankId(int id)
        {
            using (var db = new ApplDbContext())
                return (from user in db.EmployeesT where user.Rank_Id == id select user).ToList();
        }
        public static List<Employees> GetEmployeesBySalonId(int id)
        {
            using (var db = new ApplDbContext())
                return (from user in db.EmployeesT where user.Salon_Id == id select user).ToList();
        }
    }
}
