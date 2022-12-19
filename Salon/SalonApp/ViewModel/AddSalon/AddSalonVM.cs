using Salon;
using Salon.Models.Data;
using SalonApp.Models.Data;
using SalonApp.Services.Commands;
using SalonApp.Services.DbCommands;
using SalonApp.Services.PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalonApp.ViewModel.AddSalon
{
    public class AddSalonVM : PropertyChangedBase
    {
        private Window window;
        private List<Salons> _salons;
        public List<Salons> Salons
        {
            get => _salons;
            set => Set(ref _salons, value);
        }
        private string _salonName;
        public string SalonName
        {
            get => _salonName;
            set => Set(ref _salonName, value);
        }
        private string _director;
        public string Director
        {
            get => _director;
            set => Set(ref _director, value);
        }
        private void FillList()
        {
            using (var db = new ApplDbContext())
                Salons = db.SalonsT.ToList();
        }
        public AddSalonVM(Window wind)
        {
            FillList();
            window = wind;
        }

        private RelayCommand _addSalonCommand;
        public RelayCommand AddSalonCommand
        {
            get
            {
                return _addSalonCommand ?? (_addSalonCommand = new RelayCommand(obj =>
                {
                    if (SalonName != "" && SalonName != null && Director != null && Director != "")
                    {
                        try
                        {
                            Controller.AddSalon(new Salons { SalonName = SalonName, Director = Director });
                            FillList();
                            window.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                    else MessageBox.Show("Заполните все данные!");
                }));
            }
        }
    }
}
