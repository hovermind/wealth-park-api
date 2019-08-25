using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WealthParkApi.Converters
{
    /// <summary>
    /// Converter for DOB
    /// </summary>
    public class IsoDateConverter : IsoDateTimeConverter
    {
        //public IsoDateConverter() => this.DateTimeFormat = Culture.DateTimeFormat.ShortDatePattern;

        public IsoDateConverter() => this.DateTimeFormat = "yyyy/MM/dd";
    }
}
