using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Player.Response
{
    public class SimpleError
    {
        [JsonProperty(PropertyName = "error-code")]
        public string ErrorCode { get; set; }
        [JsonProperty(PropertyName = "error-arg")]
        public string ErrorArg { get; set; }
    }
}
