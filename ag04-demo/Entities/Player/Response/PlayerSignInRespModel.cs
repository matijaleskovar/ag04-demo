using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Player.Response
{
    public class PlayerSignInRespModel
    {
        public int PlayerId { get; set; }
        public bool PlayerAlreadyExist { get; set; }
        public SimpleError Error { get; set; }
    }
}
