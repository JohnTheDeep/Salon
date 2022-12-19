using Salon;
using Salon.Models.Data;
using SalonApp.Models.Data;
using SalonApp.Services.PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Data = SalonApp.Models.Data;

namespace SalonApp.View.AddJournal
{
    public class AddJournalVM : PropertyChangedBase
    {
        private Window window;
        public AddJournalVM()
        {

        }
        public AddJournalVM(Window wind,Salons selectedSalon, Data.Services selectedService, Employees selectedEmployee)
        {
            window = wind;
            using(var db = new ApplDbContext())
            {
 
                bool isExist = db.DutyT.Any(el => el.DutyDate == DateTime.Today.ToString("dd/MM/yyyy"));
                if(isExist == true)
                {

                }
                else
                {
                    var dialog = MessageBox.Show("Для того что бы добавить запись необходимо наличие открытой смены на текущий день.\n" +
                        "Хотите открыть смену прямо сейчас?","Уведомление",MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if(dialog == MessageBoxResult.Yes)
                    {

                    }
                    else
                    {
                        wind.Close();
                    }
                }
            }
        }
    }
}
