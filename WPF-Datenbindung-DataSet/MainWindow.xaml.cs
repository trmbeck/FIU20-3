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
using System.Data;
using System.Configuration;
using System.Diagnostics;
using System.Data.SqlClient;

namespace WPF_Datenbindung_DataSet
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Data.DataSet ds = new DataSet();
        System.Data.SqlClient.SqlDataAdapter da;
        ConnectionStringSettings settings;

        public MainWindow()
        {
            InitializeComponent();
            settings = ConfigurationManager.ConnectionStrings["conStr"];
            Debug.WriteLine(settings.ConnectionString);
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(settings.ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Kunden", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds,"Alle Kunden");

            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            da.DeleteCommand = builder.GetDeleteCommand();
            da.UpdateCommand = builder.GetUpdateCommand();
            da.InsertCommand = builder.GetInsertCommand();

            DetailFenster.ItemsSource = ds.Tables["Alle Kunden"].DefaultView;

            
            cmd = new SqlCommand("Select * from kunden where ort='Karlsruhe'", con);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd);

            da2.Fill(ds, "Kunden aus Karlsruhe");

            builder = new SqlCommandBuilder(da2);
            da2.DeleteCommand = builder.GetDeleteCommand();
            da2.UpdateCommand = builder.GetUpdateCommand();
            da2.InsertCommand = builder.GetInsertCommand();

            DetailFenster.ItemsSource = ds.Tables["Kunden aus Karlsruhe"].DefaultView;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var alleKunden = ds.Tables["Alle Kunden"].AsEnumerable();
            var alleKundenGefiltert = alleKunden.Where(x => x["Ort"].Equals("Musterstadt"));
            
            //var t = ds.Tables["Alle Kunden"].AsEnumerable().Where(x => (string)x["Ort"] == "Musterstadt");
            
            DetailFenster.ItemsSource = alleKundenGefiltert.AsDataView();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DetailFenster.ItemsSource = ds.Tables["Kunden aus Karlsruhe"].DefaultView;
        }
    }
}
