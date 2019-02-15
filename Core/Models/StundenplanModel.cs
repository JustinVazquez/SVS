using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class StundenplanModel
    {
        public int ID { get; set; }

        public int Klasse_ID { get; set; }
        public string Klasse { get; set; }

        public int Raum_ID { get; set; }
        public string Raum { get; set; }

        public int Notiz_ID { get; set; }

        public NotizModel Notiz { get; set; }

        public int Fach_ID { get; set; }

        public string Fach { get; set; }

        public int Lehrer_ID { get; set; }

        public string Lehrer { get; set; }

        public int Stunde { get; set; }

        public DateTime Datum { get; set; }

    }
}
