using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Datenbindung
{
    class Mitarbeiter : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Name"));
            }
        }
        public string Strasse { get; set; }
        public string PLZ { get; set; }
        public string Ort { get; set; }
        public int Alter { get; set; }
        public override string ToString()
        {
            return $"Name: {Name}\nStrasse: {Strasse}\nPLZ: {PLZ}\nOrt: {Ort}";
        }
    }
}
