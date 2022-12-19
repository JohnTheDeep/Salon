using Salon.Models.Data;
using SalonApp.Models.Data;
using SalonApp.ViewModel.MainWindowViewModel;
using System.Windows;
using System.Windows.Controls;
using Serv = SalonApp.Models.Data;
namespace Salon.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ServiceBlock.xaml
    /// </summary>
    public partial class ServiceBlock : UserControl
    {
        public ServiceBlock(Salons salon, Serv.Services serv,Users selDuty, MainVM wind)
        {

            InitializeComponent();
                this.DataContext = new SalonApp.ViewModel.ServicesVM(salon, serv, selDuty, wind);

        }
    }
}
