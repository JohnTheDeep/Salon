using SalonApp.Models.Data;
using SalonApp.View.Salary;
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

namespace Salon.View.Salary
{
    /// <summary>
    /// Логика взаимодействия для SalaryWindow.xaml
    /// </summary>
    public partial class SalaryWindow : Window
    {
        public SalaryWindow(Employees empl,Duty dut)
        {
            InitializeComponent();
            this.DataContext = new SalaryVM(empl,dut);
        }
    }
}
