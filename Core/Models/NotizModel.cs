﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class NotizModel
    {
        public int ID { get; set; }

        public int User_ID { get; set; }

        public string User_Name { get; set; }

        public string Text { get; set; }

        public int Stunde { get; set; }

        public DateTime Datum { get; set; }
    }
}
