using HAL.IU.ViewModel;
using MahApps.Metro.Controls;
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

namespace HAL.IU
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();

            Random r = new Random();
            InitializeComponent();
            for (int i = 0; i < 20; i++)
            {
                myList.Items.Add(new { Name = "Name : BlaBla blabl ablabl abla blla bla bla ll", Online = Convert.ToBoolean(r.Next(-1, 1)), Name2 = "Name 2 : BlaBla blabl ablabl abla blla bla bla ll" });
            }
          
        }
    }
}
