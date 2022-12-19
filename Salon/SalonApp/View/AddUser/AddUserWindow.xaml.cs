using Salon.Models.Data;
using SalonApp.Models.Data;
using SalonApp.ViewModel.AddUser;
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

namespace SalonApp.View.AddUser
{
    /// <summary>
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    /// p
    /// 
    public partial class AddUser : Window
    {
        public AddUser(Salons selectedSalon)
        {
            InitializeComponent();
            this.DataContext = new AddUserVM(this, selectedSalon);
        
        }

    }
}
