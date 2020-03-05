using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTO.Player.Request
{
    public class PlayerChallengeReqModel
    {
        [Required]
        [JsonProperty(PropertyName = "player_id")]
        public int PlayerId { get; set; }
        public int OpponentId { get; set; }
    }
}
