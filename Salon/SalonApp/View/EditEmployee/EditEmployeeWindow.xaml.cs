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

namespace SalonApp.View.EditEmployee
{
    /// <summary>
    /// Логика взаимодействия для EditEmployeeWindow.xaml
    /// </summary>
    public partial class EditEmployeeWindow : Window
    {
        public EditEmployeeWindow(Salons selectedSalon,Employees selectedEmployee)
        {
            InitializeComponent();
            this.DataContext = new EditEmployeeVM(this,selectedSalon, selectedEmployee);
        }
    }
}
