using DTO;
using DTO.Player.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessAccessLayer.Interfaces
{
    public interface IPlayerService
    {
        public PlayerSignInRespModel PlayerSignUp( PlayerSignInReqModel reqModel);
        public PlayerProfileRespModel GetPlayerProfile(int id);
        public List<PlayerProfileRespModel> GetAllPlayerProfiles();
    }
}
