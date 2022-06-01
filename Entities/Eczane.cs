using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Eczane
    {
        [Key]
        public int Id { get; set; }

        public string Eczane_Adı { get; set; }
        public string Eczacı_Adı { get; set; }

        public int Şehir { get; set; }

        public int İlçe { get; set; }

        public string   Adres { get; set; }

        public string Telefon { get; set; }
        public string Eposta { get; set; }
        public string Mediporf_Kodu { get; set; }
        public string Brick_500 { get; set; }

        public int Eczane_Konum_Tipi { get; set; }
        [Column(TypeName="bigint")]
        public int GLN_No { get; set; }

        public int Silinmişmi { get; set; }



    }
}