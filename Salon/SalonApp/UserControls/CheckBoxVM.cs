using Salon;
using Salon.Models.Data;
using SalonApp.Models.Data;
using SalonApp.Services.Commands;
using SalonApp.Services.PropertyChanged;
using SalonApp.View.JournalView;
using SalonApp.View.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalonApp.UserControls
{
    public class CheckBoxVM : PropertyChangedBase
    {
        private DutyStat[] _journals;
        public DutyStat[] Journals
        {
            get => _journals;
            set => Set(ref _journals, value);
        }
        private DutyStat _selectedDuty;
        public DutyStat SelectedDuty
        {
            get => _selectedDuty;
            set => Set(ref _selectedDuty, value);
        }
        private Duty _sDuty;
        public Duty sDuty
        {
            get => _sDuty;
            set => Set(ref _sDuty, value);
        }
        private SalonApp.Models.Data.Services _service;
        public SalonApp.Models.Data.Services Service
        {
            get => _service;
            set => Set(ref _service, value);
        }
        private decimal _TotalCash;
        public decimal TotalCash
        {
            get => _TotalCash;
            set => Set(ref _TotalCash, value);
        }
        private decimal _totalNonCash;
        public decimal TotalNonCash
        {
            get => _totalNonCash;
            set => Set(ref _totalNonCash, value);
        }
        private decimal _totalFictive;
        public decimal TotalFictive
        {
            get => _totalFictive;
            set => Set(ref _totalFictive, value);
        }
        private decimal _totalSertificates;
        public decimal TotalSertificates
        {
            get => _totalSertificates;
            set => Set(ref _totalSertificates, value);
        }
        private decimal _totalSum;
        public decimal TotalSum
        {
            get => _totalSum;
            set => Set(ref _totalSum, value);
        }
        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.Owner.Visibility = Visibility.Hidden;
            window.ShowDialog();
            
        }
        private Salons _selectedSalon;
        public Salons SelectedSalon
        {
            get => _selectedSalon;
            set => Set(ref _selectedSalon, value);
        }
        private void OpenSettingsWindow(object sender, EventArgs e)
        {
            
            JournalWindow wind = new JournalWindow(SelectedDuty.Employee, sDuty, Service,SelectedSalon);
            SetCenterPositionAndOpen(wind);
        }
        private RelayCommand _MBCCheck;
        public RelayCommand MBCCheck
        {
            get
            {

                return _MBCCheck ?? (_MBCCheck = new RelayCommand(obj =>
                {
                    if (SelectedDuty != null)
                    {
                        OpenSettingsWindow(this, new EventArgs());
                    }
                }));
            }
        }
        private decimal _AmountSertificate;
        public decimal AmountSertificate
        {
            get => _AmountSertificate;
            set => Set(ref _AmountSertificate, value);
        }
        public CheckBoxVM(DutyStat[] list, Duty duty,Salons sel) 
        {
            Journals = list;
            sDuty = duty;
            SelectedSalon = sel;
            Service = list.FirstOrDefault().Service;
            foreach(DutyStat _stat in Journals)
            {
                TotalCash += _stat.TotalCash;
                TotalNonCash += _stat.TotalNonCash;
                TotalFictive += _stat.TotalFictive;
                TotalSum += _stat.TotalCash + _stat.TotalNonCash;
                AmountSertificate += _stat.TotalSertificates;
            }
        }
    }
}
