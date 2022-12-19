using Microsoft.EntityFrameworkCore;
using Salon;
using SalonApp.Models.Data;
using SalonApp.Services.Commands;
using SalonApp.Services.DbCommands;
using SalonApp.Services.PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalonApp.View.EditAddit 
{
    public class EditAdditVM : PropertyChangedBase
    {
        private Additional _selectedAddit;
        public Additional SelectedAddit
        {
            get => _selectedAddit;
            set => Set(ref _selectedAddit,value);
        }
        private Models.Data.Duty _duty;
        public Models.Data.Duty Duty
        {
            get => _duty;
            set => Set(ref _duty, value);
        }
        private Models.Data.Duty _oldduty;
        public Models.Data.Duty OldDuty
        {
            get => _oldduty;
            set => Set(ref _oldduty, value);
        }
        private decimal _admintotal;
        public decimal AdminTotal
        {
            get => _admintotal;
            set => Set(ref _admintotal, value);
        }
        private void Stat(Users admin)
        {
            using (var db = new ApplDbContext())
            {
                var user = db.UsersT.FirstOrDefault(el => el.Id == admin.Id);
                AdminTotal = (((SelectedAddit.Cash + SelectedAddit.NonCash) / 100) * (decimal)user.Paddit) + ((SelectedAddit.Sertificate / 100) * (decimal)user.Psertificate);
            }
        }
        public void EditVoid()
        {
            try
            {
                using (var db = new ApplDbContext())
                {
                    if (SelectedAddit.ClientName != null && SelectedAddit.ClientName != "")
                    {
                        Additional toEdit = db.AdditionalsT.FirstOrDefault(el => el.Id == SelectedAddit.Id);
                        toEdit.ClientName = SelectedAddit.ClientName;
                        toEdit.Cash = SelectedAddit.Cash;
                        toEdit.NonCash = SelectedAddit.NonCash;
                        toEdit.Fictive = SelectedAddit.Fictive;
                        toEdit.Sertificate = SelectedAddit.Sertificate;
                        toEdit.DiscountCash = SelectedAddit.DiscountCash;
                        toEdit.DiscountNonCash = SelectedAddit.DiscountNonCash;
                        Stat(db.UsersT.FirstOrDefault(el=>el.Id == SelectedAddit.UserId));

                        db.SaveChanges();
                        wind.Close();
                    }
                    else MessageBox.Show("Заполните все данные!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private Window wind;
        private RelayCommand _editAdd;
        public RelayCommand EditAdd
        {
            get
            {
                return _editAdd ?? (_editAdd = new RelayCommand(obj => 
                {
                    if (SelectedAddit != null)
                    {
                        EditVoid();

                    }
                    else MessageBox.Show("Выберите строку!");
                }));
            }
        }
        public EditAdditVM(Additional j,Window w)
        {
            wind = w; 
            OldDuty = new Models.Data.Duty(); 
            using (var db = new ApplDbContext())
            {
                SelectedAddit = db.AdditionalsT.Include(el=>el.User).Include(el=>el.User.Employee).FirstOrDefault(el=>el.Id == j.Id);
                Duty = db.DutyT.Include(el => el.User).FirstOrDefault(el => el.Id == SelectedAddit.DutyId);
                OldDuty.Journals = Duty.Journals;
                OldDuty.Salon_Id = Duty.Salon_Id;
                OldDuty.Salon = Duty.Salon;
                OldDuty.NonCashPerDay = Duty.NonCashPerDay;
                OldDuty.CashPerDay = Duty.CashPerDay;
                OldDuty.TransfersPerDay = Duty.TransfersPerDay;
                OldDuty.DutyDate = Duty.DutyDate;
                OldDuty.IsVirtualAdmin = Duty.IsVirtualAdmin;
                OldDuty.Statistics = Duty.Statistics;
                OldDuty.User = Duty.User;
                OldDuty.User_Id = Duty.User_Id;
                OldDuty.Total = Duty.Total;
                Stat(db.UsersT.FirstOrDefault(el => el.Id ==  SelectedAddit.UserId));
            }
        }
    }
}
