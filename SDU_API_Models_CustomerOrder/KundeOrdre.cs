using System;
using System.Collections.Generic;
using System.Text;

namespace SDU_API_Models_CustomerOrder
{
    public class KundeOrdre
    {
        public Kunde Kunde { get; set; }
        public Ordre[] Ordre { get; set; }
    }
}
