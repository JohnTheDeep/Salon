using Salon.Models.Data;
using SalonApp.Models.Data;
using SalonApp.ViewModel.MainWindowViewModel;
using System.Windows;
using System.Windows.Controls;

namespace Salon.View.MainWindow
{
    public partial class MainWindow : Window
    {
 
        public MainWindow(Users loggedUser, Salons selectedSalon)
        {
            InitializeComponent();
            this.DataContext = new MainVM(loggedUser, selectedSalon);
        }
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
