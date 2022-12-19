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

namespace SalonApp.View.EditLess
{
    public class EditLessVM : PropertyChangedBase
    {
        private Window wind;
        private Lesses _selectedLess;
        public Lesses SelectedLess
        {
            get => _selectedLess;
            set => Set(ref _selectedLess, value);
        }

        public EditLessVM(Lesses sel,Window w)
        {
            SelectedLess = sel;
            wind = w;
        }

        private RelayCommand _save;
        public RelayCommand Save
        {
            get
            {
                return _save ?? (_save = new RelayCommand(obj => 
                {
                    using(var db = new ApplDbContext())
                    {
                        var les = db.LessesT.FirstOrDefault(el=>el.Id == SelectedLess.Id);
                        if (les != null)
                        {
                            les.Name = SelectedLess.Name;
                            les.Amount = SelectedLess.Amount;
                            db.SaveChanges();
                            wind.Close();
                        }
                        else MessageBox.Show("Неизвестная ошибка");
                    }
                }));
            }
        }
    }
}
