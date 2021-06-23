using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DesignerProjekte
{
    delegate int OperationHandler(int n1, int n2);
    public delegate void DevideByZeroEventHandler(int zaehler);
    /// <summary>
    /// Interaktionslogik für UniformGridFenster.xaml
    /// </summary>
    public partial class UniformGridFenster : Window
    {
        string tempTextboxText = "";
        int operand1 = 0;
        string Operator = "";
        OperationHandler Operation;

        public event DevideByZeroEventHandler TeilenDurchNull;

        public UniformGridFenster()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button buttonDerGeklicktWurde = sender as Button;
            txb.Text += buttonDerGeklicktWurde.Content.ToString();
        }

        private void txb_KeyUp(object sender, KeyEventArgs e)
        {
            //Debug.WriteLine("\n------------------\nChar:\t{0}\t{1}\t{2}\n", (char)e.Key, (int)e.Key, (byte)e.Key);
            if (e.Key == Key.C) txb.Text = "";
            else
            {
                if ((byte)e.Key > 33 && (byte)e.Key < 44 || (byte)e.Key >= 74 && (byte)e.Key <= 83) Debug.WriteLine("Zifferntaste gedrückt!");
                else
                {
                    Debug.WriteLine("keine Zifferntaste gedrückt!");
                    txb.Text = tempTextboxText;
                }
            }
        }

        private void txb_keyDown(object sender, KeyEventArgs e)
        {
            tempTextboxText = txb.Text;
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            // eingegebene Zahl speichern
            try
            {
                operand1 = Convert.ToInt32(txb.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Falsches Format!!");
            }
            catch(DivideByZeroException ex)
            {
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Allgemeiner Fehler!!!");
            }


            // Operation speichern
            if (txb.Text != "")
            {
                Operator = (sender as ToggleButton).Content.ToString();
                //Operator = "+";
                //txb.Text += "+";
            }
            else
            {
                MessageBox.Show("zuerst Zahl eingeben!");
            }

            switch (Operator)
            {
                case "+":
                    Operation = new OperationHandler(addition); //ausführlich
                    Operation = addition; //verkürzt
                    break;
                case "-":
                    Operation = delegate (int z1, int z2) { return z1 - z2; }; //anonyme Methode
                    break;
                case "x":
                    Operation = (int z1, int z2) => { return z1 * z2; }; //Lambda-Expression
                    Operation = (z1,z2) => z1 * z2; //Lambda-Expression verkürzt
                    break;
                case "/":
                    Operation = (z1, z2) =>
                    {
                        if (z2 == 0)
                        {
                            if (TeilenDurchNull != null)
                            {
                                TeilenDurchNull(z1);
                                return 0;
                            }
                            else
                            {
                                MessageBox.Show("Fehler: Division durch Null!!!!");
                                //return int.MaxValue;
                                throw new DivideByZeroException("Fehler: Division durch Null!!!!");
                            }
                        }
                        else
                        {
                            return z1 / z2;
                        }
                    };
                    break;
                default:
                    MessageBox.Show("Kein gültiger Operator!");
                    break;
            }

            // textbox zurücksetzen ""
            txb.Text = "";

        }

        int addition (int zahl1, int zahl2)
        {
            return zahl1 + zahl2;
        }

        private void IstGleich_Click(object sender, RoutedEventArgs e)
        {
            plusBtn.IsChecked = false;
            minusBtn.IsChecked = false;
            geteiltBtn.IsChecked = false;
            malBtn.IsChecked = false;


            int operand2;
            //Operand2 konvertieren
            try
            {
                operand2 = Convert.ToInt32(txb.Text);
            }catch
            {
                MessageBox.Show("Fehler bei Operand 2");
                return;
            }

            //Berechnung durchführen und Ergebnis ausgeben
            txb.Text = Operation(operand1, operand2).ToString();

        }
    }
}
