using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Player.Response
{
    public class PlayerProfileRespModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
    }
}
