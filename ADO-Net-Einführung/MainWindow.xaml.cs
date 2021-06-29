using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace ADO_Net_Einführung
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string conStr = "Data Source=(localDB)\\MSSQLLocalDB;Database=FIU20-3;Connect Timeout=30;Integrated Security=true";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAbfrage_Click(object sender, RoutedEventArgs e)
        {
            //Write("Hallo ");
            //WriteLine("Welt!");
            //WriteLine("Neue Zeile");

            //Verbindungszeichenfolge
            // "Attribut1=Wert1;Attribut2=Wert2"
            // Attribute:
            // Data Source, Server, Address, Addr, Network Address --> Netzwerkadresse des DB Servers
            // Werte:
            // localhost, (local), .
            //
            // Attribute:
            // Database, Initial Catalog
            //
            // User ID
            // Password, Pwd
            // Connection Timeout, Connect Timeout
            // Integrated Security, Trusted_Connection
            // Packet Size --> Netzwerkpacketgröße
            // Workstation ID --> Computername

            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;

            con = new SqlConnection(conStr); // Alternativ
            string query = "UPDATE Kunden SET Ort='Karlsruhe' WHERE Id=12";
            
            SqlCommand command = new SqlCommand();
            command.CommandText = query; // Zuweisung der SQL-Abfrage an das SQLCommand-Objekt
            command.Connection = con;    // zu verwendende Verbindung

            //Ausführen eines SQL Befehls:
            // 1. ExecuteNonQuery --> keine SELECT-Abfrag. z. B. CREATE, UPDATE, INSERT ...
            // 2. ExecuteScalar --> ein Ergebnis erhalten. z. B. COUNT, MAX, MIN ...
            // 3. ExecuteReader --> Ergebnisrecords

            try
            {
                con.Open();
                
                // NonQuery
                WriteLine("Abfrage: " + query);
                int anzahlZeilen = command.ExecuteNonQuery();
                if ( anzahlZeilen > 0) WriteLine(String.Format("Aktualisierung durchgeführt.\nbetroffene Zeilen: {0}",anzahlZeilen));
                else WriteLine("Keine Aktualisierung vorgenommen!");

                // Scalar
                query = "SELECT COUNT(*) FROM Kunden WHERE Ort='Karlsruhe'";
                command = new SqlCommand(query, con);
                WriteLine("\n\nAbfrage: " + query);
                int ergebnis = Convert.ToInt32(command.ExecuteScalar());
                WriteLine("Anzahl: " + ergebnis);

                query = "SELECT * FROM Kunden Where Ort='Karlsruhe'";
                command = new SqlCommand(query, con);
                WriteLine("\n\nAbfrage: " + query);
                SqlDataReader dr = command.ExecuteReader();
                WriteLine(String.Format("{0,-20}{1,-20}{2,-20}{3,10} {4,-6}", "Nachname", "Vorname", "Ort", "Geb.dat.", "VIP"));
                while (dr.Read())
                    WriteLine(String.Format("{0,-20}{1,-20}{2,-20}{3,10} {4,-6}", dr["Nachname"], dr["Vorname"], dr["Ort"], dr["Geburtsdatum"].ToString().Length>9 ? dr["Geburtsdatum"].ToString().Substring(0,10):"N/A", dr["VIP"]));
                dr.Close();


            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
                return;
            }
            finally
            {
                con.Close();
            }
        }

        private void WriteLine(string message)
        {
            output.Text += message + Environment.NewLine;
        }

        private void Write(string message)
        {
            output.Text += message;
        }

        private void Clear()
        {
            output.Text = "";
        }
    }
}
