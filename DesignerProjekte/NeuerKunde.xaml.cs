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

namespace DesignerProjekte
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void startGridContainerWindow_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Grid Container wird geöffnet ...");
            GridContainer gcFenster = new GridContainer();
            gcFenster.WindowStartupLocation = WindowStartupLocation.Manual;
            gcFenster.Top = 10;
            gcFenster.Left = 500;
            gcFenster.ShowDialog();
        }

        private void startUniGridContainerWindow_Click(object sender, RoutedEventArgs e)
        {
            UniformGridFenster ufgFenster = new UniformGridFenster();
            ufgFenster.TeilenDurchNull += (int zaehler) => { string message = String.Format("Event Teilen durch Null wurde geraist!! {0}/0 nicht erlaubt!", zaehler); MessageBox.Show(message); };
            ufgFenster.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void WrapPanelContainer_Click(object sender, RoutedEventArgs e)
        {
            WrapPanelFenster wpFenster = new WrapPanelFenster();
            wpFenster.Show();
        }

        private void CanvasContainer_Click(object sender, RoutedEventArgs e)
        {
            CanvasFenster cFenster = new CanvasFenster();
            cFenster.Show();
        }

        private void DockPanelContainer_Click(object sender, RoutedEventArgs e)
        {
            DockPanelFenster dpFenster = new DockPanelFenster();
            dpFenster.Show();
        }
    }
}
