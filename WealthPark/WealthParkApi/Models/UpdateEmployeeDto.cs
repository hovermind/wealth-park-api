using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WealthParkApi.Converters;

namespace WealthParkApi.Models
{
    public class UpdateEmployeeDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Boss { get; set; }

        [JsonConverter(typeof(IsoDateConverter))]
        public DateTime? DateOfBirth { get; set; }

        public string Address { get; set; }

        public double Salary { get; set; }
    }
}
