using Salon.View.Admin_panel;
using SalonApp.Services.Commands;
using SalonApp.Services.PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SalonApp.View.AdminPanelAuth
{
    public class AdminPanelAuthorizeVM : PropertyChangedBase
    {

        private string _login, _password;
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
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
                        if (Login != "" && ((PasswordBox)(obj)).Password != "")
                        {
                            if (Login == "sys" && ((PasswordBox)(obj)).Password == "root")
                            {
                                OpenAdminPanelWindow(this, new EventArgs());
                            }
                            else MessageBox.Show("Неверные данные!");
                        }
                        else MessageBox.Show("Заполните данные!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }


                }));
            }
        }
        private Visibility _visible = Visibility.Visible;
        public Visibility Visible
        {
            get => _visible;
            set => Set(ref _visible, value);
        }
        private void OpenAdminPanelWindow(object sender, EventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel();
            SetCenterPositionAndOpen(adminPanel);
        }
        private void SetCenterPositionAndOpen(Window window)
        {
            Visible = Visibility.Hidden;
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
            Visible = Visibility.Visible;
            Login = null;

        }
       
    }
}
