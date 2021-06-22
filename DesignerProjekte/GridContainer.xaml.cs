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

namespace DesignerProjekte
{
    /// <summary>
    /// Interaktionslogik für GridContainer.xaml
    /// </summary>
    public partial class GridContainer : Window
    {
        public GridContainer()
        {
            InitializeComponent();
        }

        private void myBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
