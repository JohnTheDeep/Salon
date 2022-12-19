using Microsoft.EntityFrameworkCore;
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

namespace SalonApp.View.Duty
{
    public class DutyVM : PropertyChangedBase
    {
        private List<SalonApp.Models.Data.Duty> _dutys;
        public List<SalonApp.Models.Data.Duty> Dutys
        {
            get => _dutys;
            set => Set(ref _dutys, value);
        }
        private Salons _selectedSalon;
        public Salons SelectedSalon
        {
            get => _selectedSalon;
            set => Set(ref _selectedSalon,value);
        }
        private Users _loggedUser;
        public Users LoggedUser
        {
            get => _loggedUser;
            set => Set(ref _loggedUser, value);
        }
        private void FillList()
        {
            using(var db = new ApplDbContext())
            {
                Dutys = db.DutyT.Include(el=>el.User).ToList();
            }
        }
        private RelayCommand _openDutyCommand;
        public RelayCommand OpenDutyCommand
        {
            get
            {
                return _openDutyCommand ?? (_openDutyCommand = new RelayCommand(obj => 
                {
                    using (var db = new ApplDbContext())
                    {
                        string today = DateTime.Today.ToString("dd/MM/yyyy");
                        bool isExist = db.DutyT.Any(el => el.DutyDate == today);
                        if (isExist == true)
                        {
                            MessageBox.Show("Смена на текущий день уже открыта!");
                        }
                        else
                        {
                            if (LoggedUser.UserType == "Админ" || LoggedUser.UserType == "Виртуальный админ" || LoggedUser.UserType == "Владелец")
                            {
                                var dialog = MessageBox.Show($"Вы вошли под учетной записью " +
                                    $"{LoggedUser.NickName}, тип учетной записи {LoggedUser.UserType}.\nВы уверены что хотите открыть смену под текущим админом?\nИзменить админа будет невозможно.", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Information);
                                if (dialog == MessageBoxResult.Yes)
                                {
                                    db.DutyT.Add(new Models.Data.Duty
                                    {
                                        DutyDate = DateTime.Today.ToString("dd/MM/yyyy"),
                                        Salon_Id = SelectedSalon.Id,
                                        User_Id = LoggedUser.Id,
                                        IsVirtualAdmin = LoggedUser.UserType == "Виртуальный админ" ? true : false,
                                        CashPerDay = 0,
                                        NonCashPerDay = 0
                                    });
                                    db.SaveChanges();
                                    FillList();
                                    MessageBox.Show("Запись успешно добавлена!");
                                }
                            }
                        }
                    }
                }));
            }
        }
        public DutyVM(Salons selectedSalon, Models.Data.Users loggedUser)
        {

            SelectedSalon = selectedSalon;
            LoggedUser = loggedUser;
            FillList();
        }
    }
}
