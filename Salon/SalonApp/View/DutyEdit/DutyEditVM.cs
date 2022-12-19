using SalonApp.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalonApp.Services.PropertyChanged;
using Salon;
using Microsoft.EntityFrameworkCore;
using SalonApp.View.JournalView;
using SalonApp.Services.Commands;
using SalonApp.View.Settings;
using System.Windows;
using SalonApp.View.EditAddit;

namespace SalonApp.View.DutyEdit
{
    public class DutyEditVM : PropertyChangedBase
    {
        private List<Additional> _listAddit;
        public List<Additional> ListAddit
        {
            get => _listAddit;
            set => Set(ref _listAddit, value);
        }
        private List<Journal> _journals;
        public List<Journal> Journals
        {
            get => _journals;
            set => Set(ref _journals, value);
        }
        private Additional _selectedAddit;
        public Additional SelectedAddit
        {
            get => _selectedAddit;
            set => Set(ref _selectedAddit, value);
        }
        
        private Models.Data.Duty _selectedDuty;
        public Models.Data.Duty SelectedDuty
        {
            get => _selectedDuty;
            set => Set(ref _selectedDuty, value);
        }
        private Journal _selectedJ;
        public Journal SelectedJ
        {
            get => _selectedJ;
            set => Set(ref _selectedJ, value);
        }
        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
        private void OpenSettingsWindow(object sender, EventArgs e)
        {
            if ( SelectedJ != null)
            {
                EditJournalWindow wind = new EditJournalWindow(SelectedJ);
                SetCenterPositionAndOpen(wind);
            }
        }
        private void OpenSettingsWindow2(object sender, EventArgs e)
        {
            EditAdditWindow wind = new EditAdditWindow(SelectedAddit);
            SetCenterPositionAndOpen(wind);
        }
        private RelayCommand _previewMouseDoubleClick;
        public RelayCommand PreviewMouseDoubleClick
        {
            get
            {
                return _previewMouseDoubleClick ?? (_previewMouseDoubleClick = new RelayCommand(obj => 
                {
                    OpenSettingsWindow(this,new EventArgs());
                    FillList();
                }));
            }
        }
        private RelayCommand _previewMouseDoubleClick2;
        public RelayCommand PreviewMouseDoubleClick2
        {
            get
            {
                return _previewMouseDoubleClick2 ?? (_previewMouseDoubleClick2 = new RelayCommand(obj =>
                {
                    OpenSettingsWindow2(this, new EventArgs());
                    FillList();
                }));
            }
        }
        
        private void FillList()
        {
            using(var db = new ApplDbContext())
            {
                Journals = db.JournalT.
                    Include(el => el.Duty).
                    Include(el => el.Service).
                    Include(el=>el.Employee).
                    Where(el => el.DutyId == SelectedDuty.Id).
                    ToList();
                ListAddit = db.AdditionalsT.
                    Include(el => el.Duty).
                    Include(el => el.User).
                    Where(el => el.DutyId == SelectedDuty.Id).
                    ToList();
            } 
        }
        public DutyEditVM(Models.Data.Duty selDuty)
        {
            SelectedDuty = selDuty;
            FillList();
        }
    }
}
