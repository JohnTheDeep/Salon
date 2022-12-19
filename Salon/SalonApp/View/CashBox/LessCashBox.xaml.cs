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

namespace SalonApp.View.CashBox
{
    /// <summary>
    /// Логика взаимодействия для LessCashBox.xaml
    /// </summary>
    public partial class LessCashBox : Window
    {
        public LessCashBox(Models.Data.CashBox box, Models.Data.Duty duty)
        {
            InitializeComponent();
            this.DataContext = new LessVM(box,duty,this);
        }
    }
}
