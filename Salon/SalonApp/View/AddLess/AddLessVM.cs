using Salon;
using Salon.Models.Data;
using SalonApp.Models.Data;
using SalonApp.Services.Commands;
using SalonApp.Services.PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalonApp.View.AddLess
{
    public class AddLessVM : PropertyChangedBase
    {
        Window wind;

        private SalonApp.Models.Data.Duty _currentDuty;
        public SalonApp.Models.Data.Duty CurrentDuty
        {
            get => _currentDuty;
            set => Set(ref _currentDuty, value);
        }
        private string _name;
        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }
        private decimal _summ;
        public decimal Summ
        {
            get => _summ;
            set => Set(ref _summ, value);
        }
        private Salons _selected;
        public Salons Selected
        {
            get => _selected;
            set => Set(ref _selected, value);
        }
        public AddLessVM(SalonApp.Models.Data.Duty dut, Window wind,Salons sel)
        {
            this.wind = wind;
            CurrentDuty = dut;
            Selected = sel;
        }
        private RelayCommand _add;
        public RelayCommand Add
        {
            get
            {
                return _add ?? (_add = new RelayCommand(obj => 
                {
                    if (Name != null && Name != "" && Summ != null)
                    {
                        try
                        {
                            if(MessageBox.Show($"Вы уверены что хотите добавить '{Name}' суммой - {Summ} злотых в таблицу расходов?","Подтверждение",MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                using (var db = new ApplDbContext())
                                {
                                    db.LessesT.Add(new Lesses { Name = this.Name, Amount = this.Summ, Duty_Id = CurrentDuty.Id });
                                    db.SaveChanges();
                                    wind.Close();
                                }
                            }
                        }
                        catch(Exception ex) { MessageBox.Show(ex.Message); }

                    }
                    else MessageBox.Show("Заполните все данные");
                    
                }));
            }
        }
    }
}
