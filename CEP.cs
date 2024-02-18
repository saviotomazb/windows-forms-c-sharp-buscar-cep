using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaCEP
{
    public class CEP
    {
        [JsonProperty(PropertyName ="state")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "neighborhood")]
        public string Neighborhood { get; set; }

        [JsonProperty(PropertyName = "street")]
        public string Street { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }
    }
}
