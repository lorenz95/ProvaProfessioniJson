using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Text.Json;
using System.IO;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ProfessioniJson
{
    internal class Program
    {
        public static int NUM_PERSONE = 10;
        public static string BasePath = AppDomain.CurrentDomain.BaseDirectory;
        private static void ScriviFile()
        {
            List<Individui> listIndividui = new List<Individui>();
            for (int i = 0; i < NUM_PERSONE; i++)
            {
                DateTime dateTime = new DateTime(1976, 5, 23);

                string nomeProfessione = "", tipoProfessione = "";
                if (i % 2 == 0)
                {
                    nomeProfessione = "cuoco";
                    tipoProfessione = "lavoro in cucina";
                }
                else
                {
                    nomeProfessione = "falegname";
                    tipoProfessione = "lavoro in officina";
                }
                Professione pro = new Professione(nomeProfessione, tipoProfessione);
                Individui individui = new Individui("CF" + i, "Nome" + i, "Cognome" + i, dateTime, pro);
                listIndividui.Add(individui);
            }

            List<Individui> listCuochi = new List<Individui>(); // new List<Cuochi>();
            List<Individui> listFalegnami = new List<Individui>(); // new List<Falegnami>();

            listIndividui.ForEach(i =>
            {
                switch (i.Professione.Nome)
                {
                    case "cuoco":
                        listCuochi.Add(i);
                        break;
                    case "falegname":
                        listFalegnami.Add(i);
                        break;
                }
            });

            //JsonSerializer.Serialize(listIndividui);
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };

            /*
            string jsonStringCuochi = JsonSerializer.Serialize(listCuochi, options);
            try
            {
                File.WriteAllText(BasePath + @"cuochi.json", jsonStringCuochi);
            } catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message + " " + ex.StackTrace);
            }
            */
            scritturaFile(listCuochi, options);
            scritturaFile(listFalegnami, options);

            //string jsonStringFalegnami = JsonSerializer.Serialize(listFalegnami, options);
            //File.WriteAllText(BasePath + @"falegnami.json", jsonStringFalegnami);
        }

        private static void scritturaFile(List<Individui> listCuochi, JsonSerializerOptions options)
        {
            string nameFile = listCuochi[0].Professione.Nome == "cuoco" ? "cuochi.json" : "falegnami.json";

            string jsonStringCuochi = JsonSerializer.Serialize(listCuochi, options);
            try
            {
                File.WriteAllText(BasePath + @nameFile, jsonStringCuochi);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message + " " + ex.StackTrace);
            }
        }

        private static void ReadFile(string nomeFile, string mestiere)
        {
            string altroMestiere = mestiere == "cuoco" ? "falegname" : "cuoco";

            string json = File.ReadAllText(BasePath + @nomeFile);
            var individui = JsonConvert.DeserializeObject<List<Individui>>(json);

            // Filter for a particular field (e.g. Level = 8)
            var IndividuiFiltrati = individui.Where(t => t.Professione.Nome == mestiere).ToList();

            var IndividuiAltriFiltrati = individui.Where(t => t.Professione.Nome != mestiere).ToList();

            if (IndividuiAltriFiltrati.Count() > 0)
            {
                Console.WriteLine("Errore la lista contiene persone non del mestiere");
                throw new MyException(IndividuiAltriFiltrati.Count());
            }

            /*
            Individui individuoTrovato = IndividuiFiltrati.Find(e => e.Professione.Nome == altroMestiere);

            if (individuoTrovato != null)
            {
                Console.WriteLine("ciao");
            }
            */

            foreach (var individuo in IndividuiFiltrati)
            {
                Console.WriteLine(individuo.Professione.Nome);
            }
        }
        public static void Main(string[] args)
        {
            //ScriviFile();
            try
            {
                ReadFile("cuochi.json", "cuoco");
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } finally
            {
                Console.WriteLine("Operazione conclusa");
            }
            ReadFile("falegnami.json", "falegname");
        }
    }
}
