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

namespace SalonApp.View.AddTreshold
{
    /// <summary>
    /// Логика взаимодействия для AddTreshold.xaml
    /// </summary>
    public partial class AddTreshold : Window
    {
        public AddTreshold()
        {
            InitializeComponent();
            this.DataContext = new AddTresholdVM(this);
        }
    }
}
