using SalonApp.Services.PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonApp.View
{
    public class passaVm : PropertyChangedBase
    {
        private string _password;
        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }

        //private void SetCenterPositionAndOpen(Window window)
        //{
        //    Visible = Visibility.Hidden;
        //    window.Owner = Application.Current.MainWindow;
        //    window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        //    window.ShowDialog();
        //    Visible = Visibility.Visible;

        //}
        //private void OpenAdminPanelWindow(object sender, EventArgs e)
        //{
        //    Salon.View.Admin_panel.AdminPanel adminPanel = new Salon.View.Admin_panel.AdminPanel(SelectedSalon);
        //    SetCenterPositionAndOpen(adminPanel);
        
    }
}
