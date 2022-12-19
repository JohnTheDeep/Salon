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

namespace SalonApp.View.JournalView
{
    /// <summary>
    /// Логика взаимодействия для JournalWindow.xaml
    /// </summary>
    public partial class JournalWindow : Window
    {
        public JournalWindow(Employees empl,SalonApp.Models.Data.Duty selDu,SalonApp.Models.Data.Services selServ,Salons sel)
        {
            InitializeComponent();
            this.DataContext = new JournalVM(empl, selDu, selServ,sel);
        }
    }
}
