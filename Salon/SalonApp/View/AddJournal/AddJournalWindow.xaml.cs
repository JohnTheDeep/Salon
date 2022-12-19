using Salon.Models.Data;
using SalonApp.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SalonApp.View.AddJournal
{
    /// <summary>
    /// Логика взаимодействия для AddJournalWindow.xaml
    /// </summary>
    public partial class AddJournalWindow : Window
    {
        public AddJournalWindow(Salons selSalon, SalonApp.Models.Data.Services selServ, Employees selEmpl, Users dutyAdmin)
        {
            InitializeComponent();
            this.DataContext = new AddJournalVM(this,selSalon,selServ,selEmpl, dutyAdmin);
        }
    }
}
