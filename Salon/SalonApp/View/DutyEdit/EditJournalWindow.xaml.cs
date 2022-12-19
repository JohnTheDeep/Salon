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

namespace SalonApp.View.DutyEdit
{
    /// <summary>
    /// Логика взаимодействия для EditJournalWindow.xaml
    /// </summary>
    public partial class EditJournalWindow : Window
    {
        public EditJournalWindow(Journal SelectedJ)
        {
            InitializeComponent();
            this.DataContext = new EditJournalVM(SelectedJ,this);
        }
    }
}
