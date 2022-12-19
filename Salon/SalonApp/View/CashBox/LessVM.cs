using Salon;
using SalonApp.Services.Commands;
using SalonApp.Services.PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SalonApp.View.CashBox
{
    public class LessVM : PropertyChangedBase
    {
        Window wind;
        private Models.Data.CashBox _cash;
        public Models.Data.CashBox Cash
        {
            get => _cash;
            set =>Set(ref _cash, value);
        }
        private Models.Data.Duty _duty;
        public Models.Data.Duty Duty
        {
            get => _duty;
            set => Set(ref _duty, value);
        }
        private ComboBoxItem _selectedType;
        public ComboBoxItem SelectedType
        {
            get => _selectedType;
            set => Set(ref _selectedType,value);
        }
        public LessVM(Models.Data.CashBox box,Models.Data.Duty d,Window w)
        {
            Cash = box;
            wind = w;
            Duty = d;
        }
        private decimal _amount;
        public decimal Amount
        {
            get => _amount;
            set => Set(ref _amount, value);
        }
        private RelayCommand _take;
        public RelayCommand Take
        {
            get
            {
                return _take ?? (_take = new RelayCommand(obj => 
                {
                    using (var db = new ApplDbContext())
                    {
                        var c = db.CashBoxT.FirstOrDefault(el => el.Id == Cash.Id);
                        if (c != null)
                        {
                            if (SelectedType.Name.ToString() == "Наличка")
                            {
                                db.CashBoxOperationsT.Add(
                                    new Models.Data.CashBoxOperations { 
                                        CashBox_Id = c.Id, 
                                        Date = DateTime.Today.ToString("dd/MM/yyyy"), 
                                        Taken = Amount, 
                                        Type = SelectedType.Name.ToString(), 
                                        LessIn = c.amountCash, 
                                        Less = c.amountCash - Amount });

                                db.SaveChanges();
                                wind.Close();
                            }
                            if (SelectedType.Name.ToString() == "Безнал")
                            {
                                db.CashBoxOperationsT.Add(new Models.Data.CashBoxOperations { CashBox_Id = c.Id, Date = DateTime.Today.ToString("dd/MM/yyyy"), Taken = Amount, Type = SelectedType.Name.ToString(), LessIn = c.amountNonCash, Less = c.amountNonCash - Amount });

                                db.SaveChanges();
                                wind.Close();
                            }
                            if (SelectedType.Name.ToString() == "Перевод")
                            {
                                db.CashBoxOperationsT.Add(new Models.Data.CashBoxOperations { CashBox_Id = c.Id, Date = DateTime.Today.ToString("dd/MM/yyyy"), Taken = Amount, Type = SelectedType.Name.ToString(), LessIn = c.amountTransfers, Less = c.amountTransfers - Amount });

                                db.SaveChanges();
                                wind.Close();
                            }
                        }
                    }
                }));
            }
        }
    }
}
