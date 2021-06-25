using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Datenbindung
{
    class Mitarbeiter
    {
        public string Name { get; set; }
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
