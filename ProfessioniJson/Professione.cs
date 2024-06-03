namespace ProfessioniJson
{
    public class Professione
    {
        private static int Id { set;  get; }
        public string Nome { get; set; }
        public string Tipo { get; set; }

        public Professione(string nome, string tipo)
        {
            Id++;
            Nome = nome;
            Tipo = tipo;
        }
    }
}