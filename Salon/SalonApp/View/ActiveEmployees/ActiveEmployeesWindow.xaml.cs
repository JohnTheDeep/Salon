using Salon.Models.Data;
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

namespace SalonApp.View.ActiveEmployees
{
    /// <summary>
    /// Логика взаимодействия для ActiveEmployeesWindow.xaml
    /// </summary>
    public partial class ActiveEmployeesWindow : Window
    {
        public ActiveEmployeesWindow(Salons sel)
        {
            InitializeComponent();
            this.DataContext = new ActiveEmployeesVM(sel);
        }
    }
}
