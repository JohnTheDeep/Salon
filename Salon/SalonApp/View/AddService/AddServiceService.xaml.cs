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

namespace SalonApp.View.AddService
{
    /// <summary>
    /// Логика взаимодействия для AddServiceService.xaml
    /// </summary>
    public partial class AddServiceService : Window
    {
        public AddServiceService(Salons SelectedSalon)
        {
            InitializeComponent();
            this.DataContext = new ServiceServiceVM(this, SelectedSalon);
        }
    }
}
