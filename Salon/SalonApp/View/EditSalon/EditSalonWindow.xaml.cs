using Salon.Models.Data;
using SalonApp.ViewModel.EditSalon;
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

namespace SalonApp.View.EditSalon
{
    /// <summary>
    /// Логика взаимодействия для EditSalonWindow.xaml
    /// </summary>
    public partial class EditSalonWindow : Window
    {
        public EditSalonWindow(Salons selectedSalon)
        {
            InitializeComponent();
            this.DataContext = new EditSalonVM(this, selectedSalon);
        }
    }
}
