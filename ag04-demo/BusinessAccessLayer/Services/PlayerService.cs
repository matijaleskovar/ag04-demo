using BusinessAccessLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Models;
using DTO;
using DTO.Player.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DTO.Player.Request;

namespace BusinessAccessLayer.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly DemoContext _context;

        public PlayerService(DemoContext context)
        {
            _context = context;
        }
        public PlayerSignInRespModel PlayerSignUp(PlayerSignInReqModel reqModel)
        {
            var result = new PlayerSignInRespModel();
            var entity = new Player();

            entity.Email = reqModel.Email;
            entity.Name = reqModel.Name;
            entity.CreatedUTC = DateTime.UtcNow;
            entity.ModifiedUTC = DateTime.UtcNow;

            if (_context.Players.Any(x => x.Email == reqModel.Email))
            {
                result.PlayerAlreadyExist = true;

                result.Error.ErrorArg = reqModel.Email;
                result.Error.ErrorCode = "error.username-already-taken";
            }
            else
            {
                _context.Players.Add(entity);
                _context.SaveChanges();

                result.PlayerId = entity.Id;
            }

            return result;
        }

        public PlayerProfileRespModel GetPlayerProfile(int id)
        {
            var result = new PlayerProfileRespModel();

            var player = _context.Players.FirstOrDefault(x => x.Id == id);

            if (player != null)
            {
                result.Id = player.Id;
                result.Email = player.Email;
                result.Name = player.Name;
            }
            else
            {
                result.Id = 0;
            }

            return result;
        }

        public List<PlayerProfileRespModel> GetAllPlayerProfiles()
        {
            var result = new List<PlayerProfileRespModel>();

            var playerList = _context.Players.ToList();

            if (playerList != null)
            {
                foreach (var item in playerList)
                {
                    var player = new PlayerProfileRespModel();

                    player.Id = item.Id;
                    player.Email = item.Email;
                    player.Name = item.Name;

                    result.Add(player);
                }
            }

            return result;
        }

        public PlayerChallengeRespModel ChallengePlayer(PlayerChallengeReqModel reqModel)
        {
            return null;
        }

    }
}
