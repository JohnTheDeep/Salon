using Salon;
using Salon.Models.Data;
using SalonApp.Services.Commands;
using SalonApp.Services.PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalonApp.View.Incomming
{
    public class AddIncomingVM : PropertyChangedBase
    {
        public AddIncomingVM(Salons sel, Window window)
        {
            Types = new string[] { "Наличка", "Безнал" };
            SelectedSalon = sel;
            this.window = window;
        }
        private Window window;
        public Salons _selectedSalon;
        public Salons SelectedSalon
        {
            get => _selectedSalon;
            set => Set(ref _selectedSalon, value);
        }
        public string[] _types;
        public string[] Types
        {
            get => _types;
            set => Set(ref _types, value);
        }
        private string _selectedType;
        public string SelectedType
        {
            get => _selectedType;
            set => Set(ref _selectedType,value);
        }
        private string _comment = "";
        public string Comment
        {
            get => _comment;
            set => Set(ref _comment, value);
        }
        
        private decimal _total;
        public decimal Total
        {
            get => _total;
            set => Set(ref _total, value);
        }
        private RelayCommand _add;
        public RelayCommand Add
        {
            get
            {
                return _add ?? (_add = new RelayCommand(obj =>
                {
                    if (SelectedType != null && Total != null)
                    {
                        using (var db = new ApplDbContext())
                        {
                            if(SelectedSalon != null)
                            {
                                var sa = db.CashBoxT.FirstOrDefault(el=>el.SalonId == SelectedSalon.Id);
                                if(sa != null)
                                {
                                    db.IncommingsT.Add(new Models.Data.Incommings { CashBox_Id = sa.Id, Total = this.Total, Type = SelectedType, When = DateTime.Today.ToString("dd/MM/yyyy"), Comment = this.Comment });
                                    db.SaveChanges();
                                    window.Close();
                                }
                            }

                        }
                    }
                    else MessageBox.Show("Заполните все данные!");

                }));
            }
        }
    }
}
