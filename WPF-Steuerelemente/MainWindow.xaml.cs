using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WPF_Steuerelemente
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

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            ModalerDialog md = new ModalerDialog();
            md.ShowDialog();
            if ((bool)md.DialogResult) //nullable bool
            {
                btn1.Content = "Text changed";
            }
            else
            {
                MessageBox.Show("keine Änderung");
            }
        }

        private void repeatButton_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Button clicked!");

            if (progressBar.Value < progressBar.Maximum) progressBar.Value++;
            else Debug.WriteLine("Voll");
        }

        private void Java_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ich kann Java :-)");
        }

        private void Java_CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Och kann nicht Java programmieren :D");
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("c++ clicked!");
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (ListBoxItem item in lb.SelectedItems)
            {
                txb.Text += item.Content /* + "\n\r"*/ + System.Environment.NewLine;
            }
            if (!lb.Items.IsEmpty)Debug.WriteLine(lb.SelectedIndex +" - "+(lb.SelectedItem as ListBoxItem).Content);


        }

        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                lb.Items.Add(new ListBoxItem() { Content = "element " + i });
            }
        }

        private void Clear_Click_1(object sender, RoutedEventArgs e)
        {
            lb.Items.Clear();
        }

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
