using Salon;
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

namespace SalonApp.ViewModel.EditUser
{
    internal class EditUserVM : PropertyChangedBase
    {
        private Users _selectedUser;
        public Users SelectedUser
        {
            get => _selectedUser;
            set => Set(ref _selectedUser, value);
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
        private RelayCommand _editUserCommand;
        public RelayCommand EditUserCommand
        {
            get
            {
                return _editUserCommand ?? (_editUserCommand = new RelayCommand(obj =>
                {
                    if (SelectedUser != null && SelectedUser.NickName != null && SelectedUser.UserType != null && SelectedEmployee != null && ((PasswordBox)obj).Password != "")
                    {
                        SelectedUser.Password = ((PasswordBox)obj).Password.ToString();
                        Controller.EditUser(SelectedUser);
                        _window.Close();
                    }
                    else MessageBox.Show("Заполните все поля!");

                }));
            }
        }
        public void FillList()
        {
            using (var db = new ApplDbContext())
            {
                Users = db.UsersT.ToList();
                Employees = db.EmployeesT?.ToList();
            }
        }
        public EditUserVM(Window window, Users usr)
        {
            FillList();
            _window = window;
            SelectedUser = usr;
            SelectedEmployee = SelectedUser.UserEmployee;
        }
    }
}
