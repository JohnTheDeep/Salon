using Salon;
using SalonApp.Models.Data;
using SalonApp.Services.Commands;
using SalonApp.Services.PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalonApp.View.Settings
{
    public class TresholdVM : PropertyChangedBase
    {
        private SalaryTreshold _selected;
        public SalaryTreshold Selected
        {
            get => _selected;
            set => Set(ref _selected, value);
        }
        private List<SalaryTreshold> _SalaryList;
        public List<SalaryTreshold> SalaryList
        {
            get => _SalaryList;
            set => Set(ref _SalaryList, value);
        }
        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
        private void OpenSettingsWindow(object sender, EventArgs e)
        {
            View.AddTreshold.AddTreshold wind = new View.AddTreshold.AddTreshold();
            SetCenterPositionAndOpen(wind);
        }
        private RelayCommand _delete;
        public RelayCommand Delete
        {
            get
            {
                return _delete ?? (_delete = new RelayCommand(obj =>
                {
                    var dialog = MessageBox.Show("Вы уверены что хотите удалить данную запись?","Подтверждение",MessageBoxButton.YesNo,MessageBoxImage.Information);
                    if(dialog == MessageBoxResult.Yes)
                    {
                        if (Selected != null)
                        {
                            using (var db = new ApplDbContext())
                            {
                                SalaryTreshold t = db.SalaryTresholdT.FirstOrDefault(el => el.Id == Selected.Id);
                                if (t != null)
                                    db.SalaryTresholdT.Remove(t); db.SaveChanges();
                            }
                            FillList();
                        }
                        else
                        {
                            MessageBox.Show("Выберите строку!");
                        }
                    }

                }));
            }
        }
        private RelayCommand _add;
        public RelayCommand Add 
        {
            get
            {
                return _add ?? (_add = new RelayCommand(obj => 
                {
                    OpenSettingsWindow(this,new EventArgs());
                    FillList();
                }));
            }
        }
        private void FillList()
        {
            using (var db = new ApplDbContext())
            {
                SalaryList = db.SalaryTresholdT.ToList();
            }
        }
        public TresholdVM()
        {
            FillList();
        }
    }
}
