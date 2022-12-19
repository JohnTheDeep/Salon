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

namespace SalonApp.View.EditAvac
{
    /// <summary>
    /// Логика взаимодействия для EditAvacWind.xaml
    /// </summary>
    public partial class EditAvacWind : Window
    {
        public EditAvacWind(Avancies sl)
        {
            InitializeComponent();
            this.DataContext = new EditAvacVM(sl,this);
        }
    }
}
