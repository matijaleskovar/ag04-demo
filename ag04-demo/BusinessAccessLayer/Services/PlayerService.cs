using BusinessAccessLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DTO;
using DTO.Player.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BusinessAccessLayer.Services
{
    public class PlayerService : IPlayerService
    {
        public PlayerSignInRespModel PlayerSignUp(PlayerSignInReqModel reqModel)
        {
            var result = new PlayerSignInRespModel();
            var entity = new Player();

            entity.Email = reqModel.Email;
            entity.Name = reqModel.Name;
            entity.CreatedUTC = DateTime.UtcNow;
            entity.ModifiedUTC = DateTime.UtcNow;

            using (var context = new DemoContext())
            {
                if (context.Player.Any(x => x.Email == reqModel.Email))
                {
                    result.PlayerAlreadyExist = true;

                    result.Error.ErrorArg = reqModel.Email;
                    result.Error.ErrorCode = "error.username-already-taken";
                }
                else
                {
                    context.Player.Add(entity);
                    context.SaveChanges();

                    result.PlayerId = entity.Id;
                }
            }

            return result;
        }

        public PlayerProfileRespModel GetPlayerProfile(int id)
        {
            return null;
        }
    }
}
