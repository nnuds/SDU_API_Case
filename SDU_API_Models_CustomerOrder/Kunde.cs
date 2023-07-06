using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SDU_API_Models_CustomerOrder
{
    public class Kunde
    {
        public int Id { get; set; }
        public string Firma { get; set; }
        public string Efternavn { get; set; }
        public string Fornavn { get; set; }
        public string E_mail_adresse { get; set; }
        public string Stilling { get; set; }
        public string Telefon_arbejde { get; set; }
        public string Telefon_privat { get; set; }
        public string Mobiltelefon { get; set; }
        public string Faxnummer { get; set; }
        public string Adresse { get; set; }
        public string By { get; set; }
        public string Stat_provins { get; set; }
        public string Postnummer { get; set; }
        public string Land_omraede { get; set; }
        public string Webside { get; set; }
        public string Noter { get; set; }
        public byte[] Vedhæftede_filer { get; set; }
    }
}