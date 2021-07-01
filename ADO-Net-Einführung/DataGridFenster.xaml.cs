using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace ADO_Net_Einführung
{
    /// <summary>
    /// Interaktionslogik für DataGridFenster.xaml
    /// </summary>
    public partial class DataGridFenster : Window
    {
        public string ConStr { get; set; }
        private SqlDataAdapter sqlDataAdapter;
        private DataTable dataTable;

        public DataGridFenster()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Datenbankverbindung aufbauen, Daten (ganze Tabelle) abfragen und Ergebnis an DataGrid binden
            SqlConnection connection = new SqlConnection(ConStr);
            string query = "SELECT * FROM Kunden";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable("Alle Kunden");

            sqlDataAdapter.Fill(dataTable); //Daten der Datenbanktabelle in das Objekt dataTable schreiben
            
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter); //Objekt zum Generieren/Erstellen von SqlCommands
            sqlDataAdapter.UpdateCommand = sqlCommandBuilder.GetUpdateCommand(); // SqlCommand für DB Aktualisierungen generieren und im Adapter speichern
            Debug.WriteLine("\n\n---------------------------------");
            Debug.WriteLine(sqlDataAdapter.UpdateCommand.CommandText);
            Debug.WriteLine("\n\n---------------------------------");

            


            Datenblatt.ItemsSource = dataTable.DefaultView; //Bindung zwischen DataGrid und dem Tabellenobjekt
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            int zeilen = sqlDataAdapter.Update(dataTable); //DB aktualisieren
            Debug.WriteLine("\n\n---------------------------------");
            Debug.WriteLine("Zeilen betroffen: " + zeilen);
            Debug.WriteLine("\n\n---------------------------------");

            DataTable dataTable2 = new DataTable("bla");
            DataColumn dataColumn;
            DataRow dataRow;

            dataColumn = new DataColumn();
            dataColumn.DataType = System.Type.GetType("System.Int32");
            dataColumn.ColumnName = "Id";
            dataColumn.Unique = true;

            dataTable2.Columns.Add(dataColumn);

            dataRow = dataTable2.NewRow();
            dataRow["Id"] = 26472;

            dataTable2.Rows.Add(dataRow);

            Datenblatt2.ItemsSource = dataTable2.DefaultView;

        }
    }
}
