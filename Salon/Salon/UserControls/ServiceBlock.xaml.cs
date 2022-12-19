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
    /// Логика взаимодействия для ServiceBlock.xaml
    /// </summary>
    public partial class ServiceBlock : UserControl
    {
        public ServiceBlock()
        {
            InitializeComponent();
        }
        public ServiceBlock(string title)
        {
            InitializeComponent();
            TitleBox.Text = title;
        }
        public string Title { get; set; }

        private void AddButon_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"{TitleBox.Text}");
        }
    }
}
