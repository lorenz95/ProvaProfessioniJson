using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessioniJson
{
    public class Falegnami : Individui
    {
        public bool MaestroDascia {get; set;}
        public Falegnami(string codiceFiscale, string nome, string cognome, DateTime dataNascita, Professione professione, bool maestroDascia) : base(codiceFiscale, nome, cognome, dataNascita, professione)
        {
            MaestroDascia = maestroDascia;
        }
    }
}
