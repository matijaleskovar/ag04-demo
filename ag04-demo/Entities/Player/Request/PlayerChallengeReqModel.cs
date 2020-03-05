using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTO.Player.Request
{
    public class PlayerChallengeReqModel
    {
        [Required]
        public int PlayerId { get; set; }
        public int OpponentId { get; set; }
    }
}
