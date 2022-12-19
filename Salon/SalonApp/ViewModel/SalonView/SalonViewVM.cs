using Salon;
using Salon.Models.Data;
using SalonApp.Models.Data;
using SalonApp.Services.Commands;
using SalonApp.Services.DbCommands;
using SalonApp.Services.PropertyChanged;
using SalonApp.View.AddRank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalonApp.ViewModel.SalonView
{
    public class SalonViewVM : PropertyChangedBase
    {
        private Users _selectedUser;
        public Users SelectedUser
        {
            get => _selectedUser;
            set => Set(ref _selectedUser, value);
        }
        private Salons _selectedSalon;
        public Salons SelectedSalon
        {
            get => _selectedSalon;
            set => Set(ref _selectedSalon, value);
        }

        private List<Users> _users;
        public List<Users> Users
        {
            get => _users;
            set => Set(ref _users, value);
        }

        private void FillList()
        {
            using (var db = new ApplDbContext())
                Users = db.UsersT.ToList().Where(user=>user.UserEmployee.Salon_Id == SelectedSalon.Id).ToList();
        }

        public SalonViewVM(Salons selectedSalon)
        {
            this.SelectedSalon = selectedSalon;
            FillList();

        }
        
        private RelayCommand _openAddRank;
        public RelayCommand OpenAddRank
        {
            get
            {
                return _openAddRank ?? (_openAddRank = new RelayCommand(obj =>
                {
                    OpenAddRankV(this, new EventArgs());
                    FillList();

                }));
            }
        }
        
    
    private RelayCommand _openAddEmployee;
    public RelayCommand OpenAddEmployee
    {
        get
        {
            return _openAddEmployee ?? (_openAddEmployee = new RelayCommand(obj =>
            {
                OpenAddEmpl(this, new EventArgs());
                FillList();

            }));
        }
    }
    private RelayCommand _openAddUserWindowCommand;
        public RelayCommand OpenAddUserWindowCommand
        {
            get
            {
                return _openAddUserWindowCommand ?? (_openAddUserWindowCommand = new RelayCommand(obj =>
                {
                    OpenAddUserWindow(this, new EventArgs());
                    FillList();

                }));
            }
        }
        private RelayCommand _openEditUserWindowCommand;
        public RelayCommand OpenEditUserWindowCommand
        {
            get
            {
                return _openEditUserWindowCommand ?? (_openEditUserWindowCommand = new RelayCommand(obj =>
                {
                    if (SelectedUser != null)
                    {
                        OpenEditUserWindow(this, new EventArgs());
                        FillList();
                    }
                    else { MessageBox.Show("Выберите пользователя !"); }

                }));
            }
        }
        private RelayCommand _deleteUserCommand;
        public RelayCommand DeleteUserCommand
        {
            get
            {
                return _deleteUserCommand ?? (_deleteUserCommand = new RelayCommand(obj =>
                {
                    var dialog = MessageBox.Show("Вы уверены что хотите удалить пользователя?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (dialog == MessageBoxResult.Yes)
                    {
                        Controller.DeleteUser(SelectedUser);
                        FillList();
                    }
                }));
            }
        }
        private void SetCenterPositionAndOpen(Window window)
        {

            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.Owner.Visibility = Visibility.Hidden;
            window.ShowDialog();
        }
        private void OpenAddUserWindow(object sender, EventArgs e)
        {
            SalonApp.View.AddUser.AddUser userWind = new SalonApp.View.AddUser.AddUser(SelectedSalon);
            SetCenterPositionAndOpen(userWind);
        }
        private void OpenAddEmpl(object sender, EventArgs e)
        {
            SalonApp.View.AddEmployee.AddEmployee userWind = new SalonApp.View.AddEmployee.AddEmployee(SelectedSalon);
            SetCenterPositionAndOpen(userWind);

        }
        private void OpenEditUserWindow(object sender, EventArgs e)
        {
            SalonApp.View.EditUser.EditUser userWind = new SalonApp.View.EditUser.EditUser(SelectedUser);
            SetCenterPositionAndOpen(userWind);

        }
        private void OpenAddRankV(object sender, EventArgs e)
        {
            AddRankWindow userWind = new AddRankWindow();
            SetCenterPositionAndOpen(userWind);

        }
    }
}
