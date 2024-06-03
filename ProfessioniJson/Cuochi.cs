using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessioniJson
{
    public class Cuochi : Individui
    {
        public bool StellaMichelin { get; set; }
        public Cuochi(string codiceFiscale, string nome, string cognome, DateTime dataNascita, Professione professione, bool stellaMichelin) : base(codiceFiscale, nome, cognome, dataNascita, professione)
        {
            StellaMichelin = stellaMichelin;
        }
    }
}
