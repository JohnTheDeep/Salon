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

namespace SalonApp.View.AddReminde
{
    /// <summary>
    /// Логика взаимодействия для AddReminderWindow.xaml
    /// </summary>
    public partial class AddReminderWindow : Window
    {
        public AddReminderWindow()
        {
            InitializeComponent();
            this.DataContext = new AddRemindeVM(this);
        }
    }
}
