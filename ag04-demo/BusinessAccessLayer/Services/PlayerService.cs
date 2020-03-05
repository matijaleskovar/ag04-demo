using BusinessAccessLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Models;
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
                if (context.Players.Any(x => x.Email == reqModel.Email))
                {
                    result.PlayerAlreadyExist = true;

                    result.Error.ErrorArg = reqModel.Email;
                    result.Error.ErrorCode = "error.username-already-taken";
                }
                else
                {
                    context.Players.Add(entity);
                    context.SaveChanges();

                    result.PlayerId = entity.Id;
                }
            }

            return result;
        }

        public PlayerProfileRespModel GetPlayerProfile(int id)
        {
            var result = new PlayerProfileRespModel();

            using (var context = new DemoContext())
            {
                var entity = context.Players.FirstOrDefault(x => x.Id == id);

                if (entity != null)
                {
                    result.Id = entity.Id;
                    result.Email = entity.Email;
                    result.Name = entity.Name;
                }
                else
                {
                    result.Id = 0;
                }
            }

            return result;
        }
    }
}
