using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Salon;
using Salon.Models.Data;
using SalonApp.Models.Data;
using SalonApp.Services.Commands;
using SalonApp.Services.DbCommands;
using SalonApp.Services.PropertyChanged;

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
        public AuthorizationVM()
        {
            Controller controller = new Controller();
            using (var db = new ApplDbContext())
            {
                ////Salons s = new Salons { SalonName = "LoveIs1", Director = "Junior Corrado" };
                ////Ranks r = new Ranks { RankName = "Массажист", Description = "" };
                ////db.SalonsT.Add(s);
                ////db.RanksT.Add(r);

                ////db.SaveChanges();
                //db.EmployeesT.Add(new Employees("Иван Иванов", 1, 1, false, ""));
                //db.SaveChanges();
            }
            Fill();
        }
        public AuthorizationVM(Users loggedUser)
        {
           
            Controller controller = new Controller();
            using (var db = new ApplDbContext())
            {
                Salons s = new Salons { SalonName = "LoveIs1", Director = "Junior Corrado" };
                Ranks r = new Ranks { RankName = "Массажист", Description = "" };
                db.SalonsT.Add(s);
                db.RanksT.Add(r);
                db.EmployeesT.Add(new Employees("Иван Иванов", 1, 2, false, ""));
                db.SaveChanges();
            }
            Fill();
            //controller.AddEmployee(Ranks.First(el => el != null), Salons.First(el => el != null));
        }
        private Salons _selectedSalon;
        public Salons SelectedSalon
        {
            get => _selectedSalon;
            set
            {
                Set(ref _selectedSalon, value);
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
        private event EventHandler? CanLoggedEventHandler;
        private void FillUsersCombo(object sender, EventArgs e)
        {
            using (var db = new ApplDbContext())
                Users = (from user in db.UsersT.ToList() where user.UserEmployee.Salon_Id == SelectedSalon?.Id select user).ToList();
        }
        public void Fill()
        {
            Salons = SelectSalons();
            Ranks = SelectRanks();
            UsersComboEventHandler += FillUsersCombo;
            CanLoggedEventHandler += OpenMainWindow;
        }
        public List<Ranks> SelectRanks()
        {
            using (var db = new ApplDbContext())
                return db.RanksT.Select(el => el).ToList();
        }
        public List<Salons> SelectSalons()
        {
            using(var db = new ApplDbContext())
                return db.SalonsT.Select(el => el).ToList();
        }
        public List<Users> SelectUsers()
        {
            using (var db = new ApplDbContext())
                return db.UsersT.Select(el => el).ToList();
        }
        private RelayCommand _authCommand;
        public RelayCommand AuthCommand
        {
            get 
            { 
                return _authCommand ?? (_authCommand = new RelayCommand(obj => 
                {
                    if(Controller.CheckIfPasswordIsCorrect(SelectedUser, ((PasswordBox)obj).Password))
                        CanLoggedEventHandler(this, new EventArgs());
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
                    Visible = Visibility.Hidden;
                    OpenAdminPanelWindow(this, new EventArgs());
                    Fill();
                }));
            }
        }
        private void SetCenterPositionAndOpen(Window window)
        {

            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
            Visible = Visibility.Visible;
        }
        private void OpenAdminPanelWindow(object sender, EventArgs e)
        {
            Salon.View.Admin_panel.AdminPanel adminPanel = new Salon.View.Admin_panel.AdminPanel(SelectedSalon);
            SetCenterPositionAndOpen(adminPanel);
        }
        private void OpenMainWindow(object sender, EventArgs e)
        {
            Salon.View.MainWindow.MainWindow editUserWindow = new Salon.View.MainWindow.MainWindow(SelectedUser,SelectedSalon);
            SetCenterPositionAndOpen(editUserWindow);
        }
    }
}
