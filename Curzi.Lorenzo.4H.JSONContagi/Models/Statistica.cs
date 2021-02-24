using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Curzi.Lorenzo._4H.JSONContagi.Models
{
    class Statistica
    {
        //vettore che conterrà tutti i valori deserializzati dal file Json
        Contagio[] statistiche;

        public Statistica() 
        {

        }

        public Statistica (string file)
        {
            StreamReader sr = new StreamReader(file);
            string json = sr.ReadToEnd(); //leggo tutti i contenuti del file json
            sr.Close();

            statistiche = JsonConvert.DeserializeObject<Contagio[]>(json); //deserializzo il file json e aggiungo i valori all'array statistiche 
        }

        //metodo che ricerca il giorno con più contagi all'interno dell'array 
        public string MassimoContagi()
        {
            string date = statistiche[1].Data; //data del giorno con più contagi
            double maxContagi = statistiche[1].Contagi; //numero massimo di contagi registrati

            for (int i = 2; i < statistiche.Length; i++) 
            {
                if (statistiche[i].Contagi > maxContagi) //controllo se vi sono stati giorni con più contagi registrati
                {
                    maxContagi = statistiche[i].Contagi;
                    date = statistiche[i].Data;
                }
            }

            return $"\nIl giorno con più contagi è: \t\t{date}" +
                $"\nI contagi registrati sono stati: \t{maxContagi}";
        }

        //metodo che restituisce il giorno con meno contagi
        public string MinimoContagi()
        {
            string date = statistiche[1].Data; //data del giorno con meno contagi
            double minContagi = statistiche[1].Contagi; //numero minimo di contagi registrati

            for (int i = 2; i < statistiche.Length; i++)
            {
                if (statistiche[i].Contagi < minContagi) //controllo se vi sono stati giorni con meno contagi registrati
                {
                    minContagi = statistiche[i].Contagi;
                    date = statistiche[i].Data;
                }
            }

            return $"\nIl giorno con meno contagi è: \t\t{date}" +
                $"\nI contagi registrati sono stati: \t{minContagi}";
        }

        public override string ToString()
        {
            string retVal = "";

            foreach (var s in statistiche)
                retVal += "\n" + s.ToString();

            return retVal;
        }
    }
}
