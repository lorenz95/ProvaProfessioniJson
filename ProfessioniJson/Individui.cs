using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessioniJson
{
    public class Individui
    {
        public string CodiceFiscale { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public DateTime DataNascita { get; set; }

        public Professione Professione { get; set; }

        public Individui(string codiceFiscale, string nome, string cognome, DateTime dataNascita, Professione professione)
        {
            CodiceFiscale = codiceFiscale;
            Nome = nome;
            Cognome = cognome;
            DataNascita = dataNascita;
            Professione = professione;
        }
    }
}
