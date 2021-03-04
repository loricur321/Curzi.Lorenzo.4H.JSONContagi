using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Curzi.Lorenzo._4H.JSONContagi.Models
{
    class Statistica
    {
        //lista che conterrà tutti i valori deserializzati dal file Json
        List<Contagio> statistiche = new List<Contagio>();

        public Statistica() 
        {

        }

        public Statistica (string file)
        {
            StreamReader sr = new StreamReader(file);
            string json = sr.ReadToEnd(); //leggo tutti i contenuti del file json
            sr.Close();

            statistiche.AddRange(JsonConvert.DeserializeObject<Contagio[]>(json)); //deserializzo il file json e aggiungo i valori alla lista
        }

        //metodo che ricerca il giorno con più contagi all'interno dell'array 
        public string MassimoContagi()
        {
            DateTime date = statistiche[0].Data; //data del giorno con più contagi
            double maxContagi = statistiche[0].Contagi; //numero massimo di contagi registrati

            foreach(var s in statistiche)
            {
                if (s.Contagi > maxContagi) //controllo se vi sono stati giorni con più contagi registrati
                {
                    maxContagi = s.Contagi;
                    date = s.Data;
                }
            }

            return $"\nIl giorno con più contagi è: \t\t{date}" +
                $"\nI contagi registrati sono stati: \t{maxContagi}";
        }

        //metodo che restituisce il giorno con meno contagi
        public string MinimoContagi()
        {
            DateTime date = statistiche[1].Data; //data del giorno con meno contagi
            double minContagi = statistiche[1].Contagi; //numero minimo di contagi registrati

            foreach (var s in statistiche)
            {
                if (s.Contagi < minContagi) //controllo se vi sono stati giorni con meno contagi registrati
                {
                    minContagi = s.Contagi;
                    date = s.Data;
                }
            }

            return $"\nIl giorno con meno contagi è: \t\t{date}" +
                $"\nI contagi registrati sono stati: \t{minContagi}";
        }

        //Metodo per calcolare i contagi dei un giorno della settimana
        public string CalcolaContagiGiorbalieri(DayOfWeek dayOfWeek)
        {
            string retVal = "É stato inserito un giorno sbagliato.";
            double media = 0;
            int day = 0; //calcolo i giorni della settimana presenti nella lista

            foreach(var s in statistiche)
            {
                if(s.Data.DayOfWeek == dayOfWeek)
                {
                    media += s.Contagi;
                    day++;
                }
            }

            //calcolo la media del giorno
            media /= day;

            retVal = $"La media dei contagi registrati nel giorno {dayOfWeek} è:\t{Math.Round(media, 2)}";

            return retVal;
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
