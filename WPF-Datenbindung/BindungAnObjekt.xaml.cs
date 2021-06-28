using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace WPF_Datenbindung
{
    /// <summary>
    /// Interaktionslogik für BindungAnObjekt.xaml
    /// </summary>
    public partial class BindungAnObjekt : Window
    {
        //private Mitarbeiter ma1 { get; set; }
        //private int zeiger = 0;
        
        private ObservableCollection<Mitarbeiter> mitarbeiterListe;
        
        ICollectionView view;


        public BindungAnObjekt()
        {
            //ma1 = new Mitarbeiter { Name = "Peter", Ort = "Musterstadt", PLZ = "12345", Strasse = "Musterweg 1" };

            mitarbeiterListe = new ObservableCollection<Mitarbeiter>();
            InitializeComponent();
            mitarbeiterListe.Add(new Mitarbeiter { Name = "Susi", Ort = "Musterdorf", PLZ = "67890", Strasse = "Musterstrasse 1", Alter=25 });
            mitarbeiterListe.Add(new Mitarbeiter { Name = "Peter", Ort = "Musterstadt", PLZ = "12345", Strasse = "Musterweg 1",Alter = 45 });
            mitarbeiterListe.Add(new Mitarbeiter { Name = "Hans", Ort = "Musterhausen", PLZ = "67550", Strasse = "Musterallee 1",Alter=65 });

            view = CollectionViewSource.GetDefaultView(mitarbeiterListe);
            stackPanel1.DataContext = mitarbeiterListe;
            //listbox1.ItemsSource = mitarbeiterListe;
            //txb_Name.Text = ma1.Name;
            //txb_Strasse.Text = ma1.Strasse;
            //txb_PLZ.Text = ma1.PLZ;
            //txb_Ort.Text = ma1.Ort;
        }

        private void btn_Anzeiger_Click(object sender, RoutedEventArgs e)
        {
            mitarbeiterListe[view.CurrentPosition].Name = "abgeänderter Name im C# Code";
            MessageBox.Show(mitarbeiterListe[view.CurrentPosition].ToString());
        }

        private void txb_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            //ma1.Name = txb_Name.Text;
        }

        private void btn_left_Click(object sender, RoutedEventArgs e)
        {
            //zeiger--;
            //if (zeiger < 0) zeiger = mitarbeiterListe.Count - 1;
            //stackPanel1.DataContext = mitarbeiterListe[zeiger];
            view.MoveCurrentToPrevious();
            if (view.IsCurrentBeforeFirst) view.MoveCurrentToLast();
        }

        private void btn_right_Click(object sender, RoutedEventArgs e)
        {
            //zeiger++;
            //if (zeiger >= mitarbeiterListe.Count) zeiger = 0;
            //stackPanel1.DataContext = mitarbeiterListe[zeiger];

            view.MoveCurrentToNext();
            if (view.IsCurrentAfterLast) view.MoveCurrentToFirst();
        }

        private void btn_neu_Click(object sender, RoutedEventArgs e)
        {
            mitarbeiterListe.Add(new Mitarbeiter());
            view.MoveCurrentToLast();
            txb_Name.IsEnabled = true;
        }

        private void btn_Alter_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Alter: " + listbox1.SelectedValue);
        }
    }
}
