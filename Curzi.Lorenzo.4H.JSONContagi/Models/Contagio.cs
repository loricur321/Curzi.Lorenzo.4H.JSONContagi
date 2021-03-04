using System;
using System.Collections.Generic;
using System.Text;

namespace Curzi.Lorenzo._4H.JSONContagi.Models
{
    class Contagio
    {
        DateTime _data;
        int _progressivo;
        double _contagi;

        public DateTime Data 
        {
            get => _data;
            set => _data = value;
        }

        public int Progressivo 
        {
            get => _progressivo;
            set => _progressivo = value;
        }

        public double Contagi
        {
            get => _contagi;
            set => _contagi = value;
        }

        public Contagio() { }

        public Contagio(DateTime data, int counter, double contagi)
        {
            Data = data;
            Progressivo = counter;
            Contagi = contagi;
        }

        public override string ToString()
        {
            return $"\nData: \t\t{Data}" +
                $"\nProgressivo: \t{Progressivo}" +
                $"\nContagi: \t{Contagi}";
        }
    }
}
