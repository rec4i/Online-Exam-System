using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities

{
    public class Town
    {

        [Key]
        public int TownID { get; set; }
        public int CityID { get; set; }
        public string TownName { get; set; }

    }
}