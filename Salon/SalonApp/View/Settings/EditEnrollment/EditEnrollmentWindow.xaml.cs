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

namespace SalonApp.View.Settings.EditEnrollment
{
    /// <summary>
    /// Логика взаимодействия для EditEnrollmentWindow.xaml
    /// </summary>
    public partial class EditEnrollmentWindow : Window
    {
        public EditEnrollmentWindow(Employees sl,Enrollment sle)
        {
            InitializeComponent();
            this.DataContext = new EditEnrollmentVM(this,sl,sle);
        }
    }
}
