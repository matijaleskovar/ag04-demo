using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Player.Response
{
    public class PlayerChallengeRespModel
    {
        public ChallengePlayerData Data { get; set; }
        public SimpleError Error { get; set; }
    }
}
