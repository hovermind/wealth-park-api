using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WealthParkApi.Converters;

namespace WealthParkApi.Models
{
    public class CreateEmployeeDto
    {
        [Required]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        [Required]
        [MinLength(3)]
        public string Boss { get; set; }

        [Required]
        [JsonConverter(typeof(IsoDateConverter))]
        public DateTime? DateOfBirth { get; set; }

        public string Address { get; set; }

        public double Salary { get; set; }
    }
}
