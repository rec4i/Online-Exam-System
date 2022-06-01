using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Eczane_Tip
    {
        [Key]
        public int Id { get; set; }

        public string Eczane_Tip_txt { get; set; }

    }
}