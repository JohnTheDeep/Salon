using Microsoft.EntityFrameworkCore;
using Salon;
using Salon.Models.Data;
using SalonApp.Models.Data;
using SalonApp.Services.Commands;
using SalonApp.Services.PropertyChanged;
using SalonApp.View.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalonApp.View.Incomming
{
    public class IncommingVM : PropertyChangedBase
    {
        public IncommingVM(Salons sel)
        {
            SelectedSalon = sel;
            Fill();
        }
        private DateTime _cashSelectedDate = DateTime.Today;
        public DateTime CashSelectedDate
        {
            get => _cashSelectedDate;
            set
            {
                Set(ref _cashSelectedDate, value);
                Fill();
            }
        }
        private Incommings _selectedIncomming;
        public Incommings SelectedIncomming
        {
            get => _selectedIncomming;
            set => Set(ref _selectedIncomming, value);
        }
        private List<Incommings> _incommings;
        public List<Incommings> Incommings
        {
            get => _incommings;
            set => Set(ref _incommings, value);
        }
        private Salons _selectedSalon;
        public Salons SelectedSalon
        {
            get => _selectedSalon;
            set => Set(ref _selectedSalon, value);
        }
        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
        private void OpenSettingsWindow(object sender, EventArgs e)
        {
            AddIncomming wind = new AddIncomming(SelectedSalon);
            SetCenterPositionAndOpen(wind);
        }
        private RelayCommand _openAdd;
        public RelayCommand OpenAddIncomming
        {
            get
            {
                return _openAdd ?? (_openAdd = new RelayCommand(obj => 
                {
                    OpenSettingsWindow(this,new EventArgs());
                    Fill();
                }));
            }
        }
        private RelayCommand _deleteIncomming;
        public RelayCommand DeleteIncomming
        {
            get
            {
                return _deleteIncomming ?? (_deleteIncomming = new RelayCommand(obj =>
                {
                    if (SelectedIncomming != null)
                    {
                        if (MessageBox.Show("Вы уверены что хотите удалить данную запись?","Подтверждение",MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            using (var db = new ApplDbContext())
                            {
                                db.IncommingsT.Remove(SelectedIncomming);
                                db.SaveChanges();
                                Fill();
                            }
                        }
                    }
                    else MessageBox.Show("Выберите строку!");
                }));
            }
        }
        private void Fill()
        {
            using(var db = new ApplDbContext())
            {
                if (SelectedSalon != null)
                    Incommings = db.IncommingsT.
                        Include(el=>el.CashBox).
                        Where(el=>el.CashBox.SalonId == SelectedSalon.Id).ToList().Where(el=>Convert.ToDateTime(el.When).Month == CashSelectedDate.Month && Convert.ToDateTime(el.When).Year == CashSelectedDate.Year).OrderByDescending(el => el.When).ToList();
            }
        }
    }
}
