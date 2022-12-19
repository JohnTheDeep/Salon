using Salon.Models.Data;
using SalonApp.Models.Data;
using SalonApp.UserControls;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Salon.UserControls
{
    /// <summary>
    /// Логика взаимодействия для CheckBlock.xaml
    /// </summary>
    public partial class CheckBlock : UserControl
    {
        public CheckBlock(DutyStat[] jj,Duty d,Salons sel)
        {
            InitializeComponent();
            this.DataContext = new CheckBoxVM(jj,d,sel);
        }
    }
}
