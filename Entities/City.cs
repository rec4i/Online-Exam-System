using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities

{
    public class City
    {

        [Key]
        public int CityID { get; set; }
        public int CountryID { get; set; }
        public string CityName { get; set; }
        public string PlateNo { get; set; }
        public string PhoneCode { get; set; }


    }
}