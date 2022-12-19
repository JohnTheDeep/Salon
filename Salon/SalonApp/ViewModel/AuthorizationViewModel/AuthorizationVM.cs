using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using Salon;
using Salon.Models.Data;
using SalonApp.Models.Data;
using SalonApp.Services.Commands;
using SalonApp.Services.DbCommands;
using SalonApp.Services.PropertyChanged;
using SalonApp.View.AdminPanelAuth;

namespace SalonApp.ViewModel.AuthorizationVM
{
    public class AuthorizationVM : PropertyChangedBase
    {
        private Visibility _visible = Visibility.Visible;
        public Visibility Visible
        {
            get => _visible;
            set => Set(ref _visible, value);
        }
        private bool _canLogged = false;
        public bool CanLogged
        {
            get => _canLogged;
            set
            {
                Set(ref _canLogged, value);
            }
        }
        private Users _selectedUser;
        public Users SelectedUser
        {
            get => _selectedUser;
            set
            {
                Set(ref _selectedUser, value);
                
            }
        }
        private List<Salons> _salonsT;
        public List<Salons> Salons
        {
            
            get => _salonsT;
            set => Set(ref _salonsT, value);
        }
        private List<Ranks> _ranksT;
        public List<Ranks> Ranks
        {

            get => _ranksT;
            set => Set(ref _ranksT, value);
        }
        private List<Users> _usersT;
        public List<Users> Users
        {

            get => _usersT;
            set => Set(ref _usersT, value);
        }
        private string _version;
        public string Version
        {

            get => _version;
            set => Set(ref _version, value);
        }
        public AuthorizationVM()
        {
            Fill();
            Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
        private Salons _selectedSalon;
        public Salons SelectedSalon
        {
            get => _selectedSalon;
            set
            {
                _selectedSalon = value;
                UsersComboEventHandler(this,new EventArgs());
            }
        }
        private string _inputtedPassword;
        public string InputtedPassword
        {
            get => _inputtedPassword;
            set => Set(ref _inputtedPassword, value);
        }
        private event EventHandler? UsersComboEventHandler;
        private void FillUsersCombo(object sender, EventArgs e)
        {
            try
            {
                using (var db = new ApplDbContext())
                {
                    Users = db.UsersT.Include(el=> el.Employee).Where(el=>el.Employee.Salon_Id == SelectedSalon.Id).ToList();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Fill()
        {
            try
            {
                SelectSalons();
                UsersComboEventHandler += FillUsersCombo;
                SelectRanks();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
        public void SelectRanks()
        {
            try
            {
                Ranks = new List<Ranks>();
                using (var db = new ApplDbContext())
                    Ranks = db.RanksT.Select(el => el).ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void SelectSalons()
        {
            try
            {
                using (var db = new ApplDbContext())
                {
                    Salons = db.SalonsT.Select(el => el).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void SelectUsers()
        {
            try
            {
                using (var db = new ApplDbContext())
                    Users = db.UsersT.Select(el => el).ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private RelayCommand _authCommand;
        public RelayCommand AuthCommand
        {
            get 
            { 
                return _authCommand ?? (_authCommand = new RelayCommand(obj =>
                {
                    try
                    {
                        if (SelectedUser != null && ((PasswordBox)obj).Password != "")
                        {
                            if (Controller.CheckIfPasswordIsCorrect(SelectedUser, ((PasswordBox)obj).Password))
                            {
                                OpenMainWindow(this, new EventArgs());
                                InputtedPassword = "";
                                ((PasswordBox)obj).Password = "";
                            }

                        }
                        else MessageBox.Show("Заполните все данные!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                )); 
            }
        }
        private RelayCommand _openAdminPanelWindowCommand;
        public RelayCommand OpenAdminPanelWindowCommand
        {
            get
            {
                return _openAdminPanelWindowCommand ?? (_openAdminPanelWindowCommand = new RelayCommand(obj =>
                {
                    try
                    {

                        OpenAdminPanelWindow(this, new EventArgs());
                        Fill();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }));
            }
        }
        private RelayCommand _enter;
        public RelayCommand Enter
        {
            get
            {
                return _enter ?? (_enter = new RelayCommand(obj =>
                {
                    try
                    {
                        if (SelectedUser != null && obj != null)
                        {
                            if (Controller.CheckIfPasswordIsCorrect(SelectedUser, ((PasswordBox)obj).Password))
                            {

                                OpenMainWindow(this, new EventArgs());
                                InputtedPassword = "";
                                ((PasswordBox)obj).Password = "";
                            }
                        }
                        else MessageBox.Show("Заполните все данные!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    }));
            }
        }
        private void SetCenterPositionAndOpen(Window window)
        {
            Visible = Visibility.Hidden;
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
            Visible = Visibility.Visible;
            SelectedUser = null;
            InputtedPassword = "";

        }
        private void OpenAdminPanelWindow(object sender, EventArgs e)
        {
            AdminPanelAuth adminPanel = new AdminPanelAuth();
            SetCenterPositionAndOpen(adminPanel);
        }
        private void OpenMainWindow(object sender, EventArgs e)
        {
            Salon.View.MainWindow.MainWindow editUserWindow = new Salon.View.MainWindow.MainWindow(SelectedUser,SelectedSalon);
            SetCenterPositionAndOpen(editUserWindow);
            InputtedPassword = "";
        }
    }
}
