using Salon;
using SalonApp.Services.Commands;
using SalonApp.Services.PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalonApp.View.AddTreshold
{
    public class AddTresholdVM : PropertyChangedBase
    {
        private Window window;
        private decimal _tresholdIn; 
        public decimal TresholdIn
        {
            get => _tresholdIn;
            set => Set(ref _tresholdIn, value); 
        }
        private decimal _tresholdOut;
        public decimal TresholdOut
        {
            get => _tresholdOut;
            set => Set(ref _tresholdOut, value);
        }
        private string _treshold;
        public string Treshold
        {
            get => _treshold;
            set => Set(ref _treshold, value);
        }
        private decimal _bid;
        public decimal Bid
        {
            get => _bid;
            set => Set(ref _bid, value);
        }
        public AddTresholdVM(Window wind)
        {
            window = wind;
        }
        private RelayCommand _add;
        public RelayCommand Add
        {
            get
            {
                return _add ?? (_add = new RelayCommand(obj => 
                {
                    if (TresholdIn != null && TresholdOut != 0 && Bid != 0)
                    {

                        try
                        {
                            using (var db = new ApplDbContext())
                            {
                                if (!db.SalaryTresholdT.Any(el => el.Threshold == (TresholdIn.ToString() + " _ " + TresholdOut.ToString()).ToString()))
                                {
                                    Treshold = TresholdIn + " - " + TresholdOut;
                                    db.SalaryTresholdT.Add(new Models.Data.SalaryTreshold { Threshold = this.Treshold, Bid = this.Bid });
                                    db.SaveChanges();
                                    window.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Данная запись уже существует!");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                    else MessageBox.Show("Введите все данные!");
                }));
            }
        }
    }
}
