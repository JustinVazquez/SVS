using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class WocheModel
    {
        public List<StundenplanModel> Montag { get; set; }

        public List<StundenplanModel> Dienstag { get; set; }

        public List<StundenplanModel> Mittwoch { get; set; }

        public List<StundenplanModel> Donnerstag { get; set; }

        public List<StundenplanModel> Freitag { get; set; }

        public List<WochenNotizModel> WochenNotiz { get; set; }

    }
}
