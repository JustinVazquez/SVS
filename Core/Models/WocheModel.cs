using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class WocheModel
    {
        public List<StundenplanModel> monday { get; set; }

        public List<StundenplanModel> tuesday { get; set; }

        public List<StundenplanModel> wednesday { get; set; }

        public List<StundenplanModel> thursday { get; set; }

        public List<StundenplanModel> friday { get; set; }

        public List<WochenNotizModel> WochenNotiz { get; set; }

    }
}
