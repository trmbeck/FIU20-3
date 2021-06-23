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
    /// Interaktionslogik für DockPanelFenster.xaml
    /// </summary>
    public partial class DockPanelFenster : Window
    {
        public DockPanelFenster()
        {
            InitializeComponent();
        }

        private void MenuNeu_Click(object sender, RoutedEventArgs e)
        {
            editorInhalt.Text = "";
        }
    }
}
