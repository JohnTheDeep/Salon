using Microsoft.EntityFrameworkCore;
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

namespace SalonApp.View.Additionaly
{
    public class AdditionalyVM : PropertyChangedBase
    {
        private string _ClientName;
        public string ClientName
        {
            get => _ClientName;
            set => Set(ref _ClientName, value);
        }
        private decimal _cash;
        public decimal Cash
        {
            get => _cash;
            set => Set(ref _cash, value);
        }
        private decimal _nonCash;
        public decimal NonCash
        {
            get => _nonCash;
            set => Set(ref _nonCash, value);
        }
        private decimal _sertificate;
        public decimal Sertificate
        {
            get => _sertificate;
            set => Set(ref _sertificate, value);
        }
        private decimal _discountCash;
        public decimal DiscountCash
        {
            get => _discountCash;
            set => Set(ref _discountCash, value);
        }
        private decimal _discountNonCash;
        public decimal DiscountNonCash
        {
            get => _discountNonCash;
            set => Set(ref _discountNonCash, value);
        }
        private decimal _fictive;
        public decimal Fictive
        {
            get => _fictive;
            set => Set(ref _fictive, value);
        }
        private decimal _admintotal;
        public decimal AdminTotal
        {
            get => _admintotal;
            set => Set(ref _admintotal, value);
        }
        private bool _isSelected = false;
        public bool IsSelected
        {
            get => _isSelected;
            set => Set(ref _isSelected, value);
        }
        private void Stat(Users admin)
        {
            using (var db = new ApplDbContext())
            {
                var user = db.UsersT.FirstOrDefault(el => el.Id == admin.Id);
                AdminTotal = (((Cash + NonCash) / 100) * (decimal)user.Paddit) + ((Sertificate / 100) * (decimal)user.Psertificate);
            }
        }
        private RelayCommand _addAdditionaly;
        public RelayCommand AddAdditionaly
        {
            get
            {
                return _addAdditionaly ?? (_addAdditionaly = new RelayCommand(obj =>
                {
                    try
                    {
                        using (var db = new ApplDbContext())
                        {
                            string date = (DateTime.Today.ToString("dd/MM/yyyy")).ToString();
                            var dutyId = (db.DutyT.Include(el=>el.User).FirstOrDefault(el => el.DutyDate == date && el.Salon_Id == selectedSalon.Id));
                            if (dutyId?.Id != 0 && dutyId?.Id != null)
                            {
                                db.AdditionalsT.Add(new Additional
                                {
                                    Cash = this.Cash,
                                    NonCash = this.NonCash,
                                    ClientName = this.ClientName,
                                    DiscountCash = this.DiscountCash,
                                    DiscountNonCash = this.DiscountNonCash,
                                    Sertificate = this.Sertificate,
                                    Fictive = this.Fictive,
                                    DutyId = dutyId.Id,
                                    UserId = dutyAdmin.Id,
                                    IsSertificate = IsSelected
                                }) ;
                                Stat(dutyAdmin);
                                db.SaveChanges();
                                window.Close();
                            }
                            else
                            {
                                MessageBox.Show("Смена на текущий день не открыта!");
                            }
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    
                }));
            }
        }
        private Window window;
        private Salons _selectedSalon;
        public Salons selectedSalon
        {
            get => _selectedSalon;
            set => Set(ref _selectedSalon, value);
        }
        private Users _dutyAdmin;
        public Users dutyAdmin
        {
            get => _dutyAdmin;
            set => Set(ref _dutyAdmin, value);
        }
        public AdditionalyVM(Window wind, Salons _selectedSalon, Users _dutyAdmin)
        {
            selectedSalon = _selectedSalon;
            dutyAdmin = _dutyAdmin;
            window = wind;
        }
    }
}
