using SalonApp.ViewModel.AddSalon;
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

namespace SalonApp.View.AddSalon
{
    /// <summary>
    /// Логика взаимодействия для AddSalonWindow.xaml
    /// </summary>
    public partial class AddSalonWindow : Window
    {
        public AddSalonWindow()
        {
            InitializeComponent();
            this.DataContext = new AddSalonVM(this);
        }
    }
}
