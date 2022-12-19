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

namespace SalonApp.View.EditAddit
{
    /// <summary>
    /// Логика взаимодействия для EditAdditWindow.xaml
    /// </summary>
    public partial class EditAdditWindow : Window
    {
        public EditAdditWindow(Additional a)
        {
            InitializeComponent();
            this.DataContext = new EditAdditVM(a,this   );
        }
    }
}
