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

namespace SalonApp.View.Duty
{
    /// <summary>
    /// Логика взаимодействия для DutyView.xaml
    /// </summary>
    public partial class DutyView : Window
    {
        public DutyView(Salons selected,Users logged)
        {
            InitializeComponent();
            this.DataContext = new DutyVM(selected,logged);
        }
    }
}
