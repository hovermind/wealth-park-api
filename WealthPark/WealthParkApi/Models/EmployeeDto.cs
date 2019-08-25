using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WealthParkApi.Converters;

namespace WealthParkApi.Models
{
    public class EmployeeDto
    {
        public long Id { get; set; }

        public string FullName { get; set; }

        public string Boss { get; set; }

        [JsonConverter(typeof(IsoDateConverter))]
        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }
    }
}
