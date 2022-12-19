using Salon;
using Salon.Models.Data;
using SalonApp.Services.Commands;
using SalonApp.Services.PropertyChanged;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalonApp.View.AddReminde
{
    public class AddRemindeVM : PropertyChangedBase
    {
        private Window window;
        public AddRemindeVM(Window wind)
        {
            window = wind;
            Days = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>().ToList();
            using(var db = new ApplDbContext())
            {
                Salons = db.SalonsT.ToList();
            }
        }
        private List<Salons> _salons;
        public List<Salons> Salons
        {
            get => _salons;
            set => Set(ref _salons,value);
        }

        private bool _enabled = true;
        public bool Enabled
        {
            get => _enabled;
            set => Set(ref _enabled, value);
        }
        private bool _forAll = false;
        public bool ForAll
        {
            get => _forAll;
            set 
            { 
                Set(ref _forAll, value);
                if (ForAll)
                    Enabled = false;
                else Enabled = true;
            }
        }
        private List<DayOfWeek> _days;
        public List<DayOfWeek> Days
        {
            get => _days;
            set => Set(ref _days, value);
        }
        private DayOfWeek _SelectedDay;
        public DayOfWeek SelectedDay
        {
            get => _SelectedDay;
            set => Set(ref _SelectedDay, value);
        }
        private Salons _selectedSalon;
        public Salons SelectedSalon
        {
            get => _selectedSalon;
            set => Set(ref _selectedSalon, value);
        }
        private string _message;
        public string Message
        {
            get => _message;
            set => Set(ref _message, value);
        }
        private RelayCommand _add;
        public RelayCommand Add
        {
            get
            {
                return _add ?? (_add = new RelayCommand(obj => 
                {
                    using (var db = new ApplDbContext())
                    {
                        if (SelectedDay != null)
                        {
                            if (ForAll == true)
                            {
                                foreach (var item in Salons)
                                {
                                    db.ReminderT.Add(new Models.Data.Reminder { Salon_Id = item.Id, Day = SelectedDay.ToString(), Message = Message });
                                }
                                db.SaveChanges();
                                window.Close();
                            }
                            else if (ForAll == false && SelectedSalon != null)
                            {
                                db.ReminderT.Add(new Models.Data.Reminder { Salon_Id = SelectedSalon.Id, Day = SelectedDay.ToString(), Message = Message });
                                db.SaveChanges();
                                window.Close();
                            }
                            else MessageBox.Show("Заполните все данные!");

                        }
                        else MessageBox.Show("Заполните все данные!");
 
                    }
                }));
            }
        }
    }
}
