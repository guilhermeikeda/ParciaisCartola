using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParciaisCartola.Models
{
    public class GloboLogin
    {
        [JsonProperty(PropertyName = "glbId")]
        public string Id { get; set; }
    }
}
