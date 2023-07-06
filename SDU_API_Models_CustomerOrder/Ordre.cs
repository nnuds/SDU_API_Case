using System;

namespace SDU_API_Models_CustomerOrder
{
    public class Ordre
    {
        public int Id { get; set; }
        public int Ordre_id { get; set; }
        public int Medarbejder_id { get; set; }
        public int Kunde_id { get; set; }
        public DateTime Ordredato { get; set; }
        public DateTime Afsendelsesdato { get; set; }
        public int Speditoer_id { get; set; }
        public string Modtagernavn { get; set; }
        public string Modtageradresse { get; set; }
        public string Modtagerby { get; set; }
        public string Modtagerstat_landsdel { get; set; }
        public string Modtagerpostnummer { get; set; }
        public string Modtagerland_område { get; set; }
        public decimal Forsendelsesgebyr { get; set; }
        public decimal Skatter { get; set; }
        public string Betalingstype { get; set; }
        public DateTime Betalt_den { get; set; }
        public string Noter { get; set; }
        public decimal Momssats { get; set; }
        public string Momsstatus { get; set; }
        public int Status_id { get; set; }
    }
}
