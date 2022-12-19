using Salon.Models.Data;
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

namespace Salon
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
            using (var f1 = new ApplDbContext())
            {
                bool chk = f1._salons.Any(el => el.SalonName == "Salon");
                if (!chk)
                {

                    SalonModel model = new SalonModel { SalonName = "SalonSuka", Id = 1, Director = "Войшнар" };
                    f1._salons.Add(model);
                    f1.SaveChanges();
                }
            }

          
        }
    }
}
