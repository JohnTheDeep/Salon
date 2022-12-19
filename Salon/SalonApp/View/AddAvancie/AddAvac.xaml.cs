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

namespace SalonApp.View.AddAvancie
{
    /// <summary>
    /// Логика взаимодействия для AddAvac.xaml
    /// </summary>
    public partial class AddAvac : Window
    {
        public AddAvac(Salons sel)
        {
            InitializeComponent();
            this.DataContext = new AddAvVM(sel,this);
        }
    }
}
