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

namespace SalonApp.View.Settings.AddEnrollment
{
    /// <summary>
    /// Логика взаимодействия для AddEnrollmentWindow.xaml
    /// </summary>
    public partial class AddEnrollmentWindow : Window
    {
        public AddEnrollmentWindow(Employees SelectedEmployee)
        {
            InitializeComponent();
            this.DataContext = new AddEnrollmentVM(this,SelectedEmployee);
        }
    }
}
