using Microsoft.EntityFrameworkCore;
using Salon;
using Salon.Models.Data;
using SalonApp.Models.Data;
using SalonApp.Services.Commands;
using SalonApp.Services.DbCommands;
using SalonApp.Services.PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SalonApp.ViewModel.AddUser
{
    public class AddUserVM : PropertyChangedBase
    {
        private Salons _selectedSalon;
        public Salons SelectedSalon
        {
            get => _selectedSalon;
            set => Set(ref _selectedSalon, value);
        }
        public Window _window;
        private List<Employees> _employees;
        public List<Employees> Employees
        {
            get => _employees;
            set => Set(ref _employees, value);
        }
        private List<Users> _users;
        public List<Users> Users
        {
            get => _users;
            set => Set(ref _users, value);
        }

        private Employees _selectedEmployee;
        public Employees SelectedEmployee
        {
            get => _selectedEmployee;
            set => Set(ref _selectedEmployee, value);
        }
        private string _selectedType;
        public string SelectedType
        {
            get => _selectedType;
            set => Set(ref _selectedType, value);
        }
        private string _login;
        public string Login
        {
            get => _login;
            set => Set(ref _login, value);
        }
        private string _inputtedPassword;
        public string InputtedPassword
        {
            get => _inputtedPassword;
            set => Set(ref _inputtedPassword, value);
        }
        private RelayCommand _addUserCommand;
        public RelayCommand AddUserCommand
        {
            get
            {
                return _addUserCommand ?? (_addUserCommand = new RelayCommand(obj => 
                {
                    if(Login != null && SelectedType !=null && SelectedEmployee != null)
                    {
                        Users useer = new Users
                        {
                            NickName = Login,
                            UserType = SelectedType.ToString(),
                            Password = ((PasswordBox)obj)?.Password.ToString() ?? "",
                            Employee_Id = SelectedEmployee.Id
                        };

                        Controller.AddUser(useer);
                        using (var db = new ApplDbContext())
                        {
                            db.UsersT.Include(el => el.Employee).FirstOrDefault(el => el.Employee_Id == SelectedEmployee.Id).Employee.IsAdmin = true;
                            db.SaveChanges();
                        }
                        _window.Close();
                    }
                    
                }));
            }
        }
        public void FillList()
        {
            using(var db = new ApplDbContext())
            {
                Users = db.UsersT.ToList();
                Employees = (db.EmployeesT.Where(el => el.Salon_Id == SelectedSalon.Id).ToList()).Where(el => !Users.Exists(el2 => el2.UserEmployee.Id == el.Id)).ToList();
            }
        }
        public AddUserVM(Window window, Salons selectedSalon)
        {
            SelectedSalon = selectedSalon;
            FillList();
            _window = window;

        }
    }
}
