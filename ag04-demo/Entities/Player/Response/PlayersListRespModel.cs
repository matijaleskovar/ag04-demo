using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Player.Response
{
    public class PlayersListRespModel
    {
        [JsonProperty(PropertyName = "players")]
        public List<PlayerProfileRespModel> Players { get; set; }
    }
}
