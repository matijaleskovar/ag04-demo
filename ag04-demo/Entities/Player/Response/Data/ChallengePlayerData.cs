using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Player.Response
{
    public class ChallengePlayerData
    {
        [JsonProperty(PropertyName = "player_id")]
        public int PlayerId { get; set; }
        [JsonProperty(PropertyName = "opponent_id")]
        public int OpponentId { get; set; }
        [JsonProperty(PropertyName = "game_id")]
        public int GameId { get; set; }
        [JsonProperty(PropertyName = "starting")]
        public string StartingPlayer { get; set; }
    }
}
