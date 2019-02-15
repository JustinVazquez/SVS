using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class WochenNotizModel
    {
        public int ID { get; set; }

        public int Stundenplan_ID { get; set; }

        public string Inhalt { get; set; }

        public DateTime Datum { get; set; }
    }
}
